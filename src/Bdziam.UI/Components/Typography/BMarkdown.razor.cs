using Bdziam.UI.Components.CommonBase;
using Bdziam.UI.Model.Enums;
using Markdig;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Components.RenderTree;

namespace Bdziam.UI;

public partial class BMarkdown : BComponentBase
{
    private static readonly MarkdownPipeline Pipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions().Build();

    private List<(string Line, Typo Typo)>? RenderedMarkdownLines;

    [Parameter] public RenderFragment? ChildContent { get; set; }

    private string? MarkdownContent { get; set; }

    protected override void OnParametersSet()
    {
        if (ChildContent != null)
        {
            // Render the child content into a string
            using var writer = new StringWriter();
            var renderer = new RenderTreeBuilder();
            ChildContent(renderer);
            var renderedTree = renderer.GetFrames();
            foreach (var frame in renderedTree.Array)
            {
                if (frame.FrameType == RenderTreeFrameType.Markup)
                {
                    MarkdownContent += frame.TextContent.Replace("\r", "")[1..];
                }
            }
        }

        // Parse Markdown if content is provided
        if (!string.IsNullOrWhiteSpace(MarkdownContent))
        {
            var renderedMarkdown = Markdown.ToHtml(MarkdownContent, Pipeline);
            RenderedMarkdownLines = ParseMarkdown(renderedMarkdown);
        }
    }

    private List<(string Line, Typo Typo)> ParseMarkdown(string renderedMarkdown)
    {
        var lines = renderedMarkdown.Split('\n');
        var parsedLines = new List<(string Line, Typo Typo)>();

        foreach (var line in lines)
        {
            var trimmedLine = line.Trim();
            if (string.IsNullOrWhiteSpace(trimmedLine)) continue;

            // Use regex to detect heading tags with or without attributes
            if (Regex.IsMatch(trimmedLine, @"^<h1.*?>"))
                parsedLines.Add((ExtractContent(trimmedLine, "h1"), Typo.DisplayLarge));
            else if (Regex.IsMatch(trimmedLine, @"^<h2.*?>"))
                parsedLines.Add((ExtractContent(trimmedLine, "h2"), Typo.DisplayMedium));
            else if (Regex.IsMatch(trimmedLine, @"^<h3.*?>"))
                parsedLines.Add((ExtractContent(trimmedLine, "h3"), Typo.DisplaySmall));
            else if (Regex.IsMatch(trimmedLine, @"^<h4.*?>"))
                parsedLines.Add((ExtractContent(trimmedLine, "h4"), Typo.HeadlineLarge));
            else if (Regex.IsMatch(trimmedLine, @"^<h5.*?>"))
                parsedLines.Add((ExtractContent(trimmedLine, "h5"), Typo.HeadlineMedium));
            else if (Regex.IsMatch(trimmedLine, @"^<h6.*?>"))
                parsedLines.Add((ExtractContent(trimmedLine, "h6"), Typo.HeadlineSmall));
            else
                // Default for non-headings
                parsedLines.Add((trimmedLine, Typo.BodyMedium));
        }

        return parsedLines;
    }

    private string ExtractContent(string htmlLine, string tag)
    {
        // Use regex to extract content between opening and closing tags
        var regex = new Regex($"<{tag}.*?>(.*?)</{tag}>", RegexOptions.Singleline);
        var match = regex.Match(htmlLine);

        return match.Success ? match.Groups[1].Value : htmlLine;
    }
}
