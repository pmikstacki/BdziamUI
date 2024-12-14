param(
    [Parameter(Mandatory=$true)]
    [string]$rootDirectory,
    
    [Parameter(Mandatory=$false)]
    [string]$outputFile = "merged_codebase.txt"
)

function Format-DirectoryTree {
    param (
        [string]$path,
        [string]$prefix = ""
    )
    
    $tree = ""
    $items = Get-ChildItem -Path $path | Sort-Object { $_.PSIsContainer -eq $false }, Name
    $items_count = $items.Count
    
    for ($i = 0; $i -lt $items_count; $i++) {
        $item = $items[$i]
        $is_last = ($i -eq ($items_count - 1))
        $current_prefix = if ($is_last) { "+-- " } else { "|-- " }
        
        if ($item.PSIsContainer) {
            $tree += "$prefix$current_prefix$($item.Name)`n"
            $new_prefix = if ($is_last) { "$prefix    " } else { "$prefix|   " }
            $tree += Format-DirectoryTree -path $item.FullName -prefix $new_prefix
        } else {
            $tree += "$prefix$current_prefix$($item.Name)`n"
        }
    }
    
    return $tree
}

# Initialize output content
$outputContent = @()
$outputContent += "# Project Analysis created on $(Get-Date)`n"

# Add directory tree
$outputContent += "`n## Project Structure"
$outputContent += "=========================================="
$directoryTree = Format-DirectoryTree -path $rootDirectory
$outputContent += $directoryTree

# Get all C# and Razor files for further analysis
$allFiles = Get-ChildItem -Path $rootDirectory -Recurse -Include "*.cs", "*.cshtml", "*.razor"

# Add statistics
$outputContent += "`n## File Statistics"
$outputContent += "=========================================="
$outputContent += "Total Files: $($allFiles.Count)"

$extensions = $allFiles | Group-Object Extension | Sort-Object Count -Descending
$outputContent += "`nFile Types:"
foreach ($ext in $extensions) {
    $outputContent += "- $($ext.Name): $($ext.Count) files"
}

# Process each file
$outputContent += "`n## Source Code"
$outputContent += "=========================================="

$totalFiles = $allFiles.Count
$currentFile = 0

foreach ($file in $allFiles) {
    $currentFile++
    Write-Progress -Activity "Merging files" -Status "Processing $($file.Name)" -PercentComplete (($currentFile / $totalFiles) * 100)
    
    $relativePath = $file.FullName.Replace($rootDirectory, "").TrimStart("\")
    
    $outputContent += "`n`n=========================================="
    $outputContent += "FILE: $relativePath"
    $outputContent += "=========================================="
    
    $fileInfo = Get-Item $file.FullName
    $outputContent += "Last Modified: $($fileInfo.LastWriteTime)"
    $outputContent += "Size: $($fileInfo.Length) bytes"
    $outputContent += "------------------------------------------`n"
    
    $content = Get-Content -Path $file.FullName -Raw
    if ($content) {
        $outputContent += $content
    }
}

# Write output to file
try {
    $outputContent | Out-File -FilePath $outputFile -Encoding UTF8
    Write-Host "Successfully merged $totalFiles files into $outputFile"
} catch {
    Write-Error "Error writing to output file: $_"
}