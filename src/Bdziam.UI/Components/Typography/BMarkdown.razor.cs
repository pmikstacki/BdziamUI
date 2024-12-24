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
            var builder = new RenderTreeBuilder();
            builder.AddContent(0, this.ChildContent);
            var frame = builder.GetFrames().Array.FirstOrDefault(x => new[] 
            {
                RenderTreeFrameType.Text, 
                RenderTreeFrameType.Markup 
            }.Any(t => x.FrameType == t));
            MarkdownContent= string.Join("",frame.MarkupContent.Split("\n").Select(x=> x.TrimStart()));
        }

        // Parse Markdown if content is provided
        if (!string.IsNullOrWhiteSpace(MarkdownContent))
        {
            MarkdownContent = Markdown.ToHtml(MarkdownContent, Pipeline);
        }
    }
    private string ExtractContent(string htmlLine, string tag)
    {
        // Use regex to extract content between opening and closing tags
        var regex = new Regex($"<{tag}.*?>(.*?)</{tag}>", RegexOptions.Singleline);
        var match = regex.Match(htmlLine);

        return match.Success ? match.Groups[1].Value : htmlLine;
    }
}
