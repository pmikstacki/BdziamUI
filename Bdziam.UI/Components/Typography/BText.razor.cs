using Bdziam.UI.Components.CommonBase;
using Bdziam.UI.Model.Enums;
using Bdziam.UI.Utilities;
using Microsoft.AspNetCore.Components;

namespace Bdziam.UI
{
    public partial class BText : Components.CommonBase.BComponentBase, IControlColor, IControlElevation
    {
        [Parameter] public Typo Typo { get; set; } = Typo.BodyMedium;
        [Parameter] public MaterialColor Color { get; set; } = MaterialColor.Background;
        [Parameter] public bool IsSurface { get; set; } = true;
        [Parameter] public RenderFragment? ChildContent { get; set; }
        [Parameter] public int Elevation { get; set; }

        private string TypographyStyle => new CssStyleBuilder()
            .AddStyle(GetTypographyBaseStyles())
            .AddStyle("color", ColorUtility.GetTextColorVariable(Color))
            .Build(Style);

        private string GetTypographyBaseStyles()
        {
            return Typo switch
            {
                Typo.DisplayLarge => "font-family: Roboto; font-weight: 400; font-size: 57pt; letter-spacing: -0.25pt; line-height: 64pt;",
                Typo.DisplayMedium => "font-family: Roboto; font-weight: 400; font-size: 45pt; letter-spacing: 0pt; line-height: 52pt;",
                Typo.DisplaySmall => "font-family: Roboto; font-weight: 400; font-size: 36pt; letter-spacing: 0pt; line-height: 44pt;",
                Typo.HeadlineLarge => "font-family: Roboto; font-weight: 400; font-size: 32pt; letter-spacing: 0pt; line-height: 40pt;",
                Typo.HeadlineMedium => "font-family: Roboto; font-weight: 400; font-size: 28pt; letter-spacing: 0pt; line-height: 36pt;",
                Typo.HeadlineSmall => "font-family: Roboto; font-weight: 400; font-size: 24pt; letter-spacing: 0pt; line-height: 32pt;",
                Typo.TitleLarge => "font-family: Roboto; font-weight: 400; font-size: 22pt; letter-spacing: 0pt; line-height: 28pt;",
                Typo.TitleMedium => "font-family: Roboto; font-weight: 500; font-size: 16pt; letter-spacing: 0.15pt; line-height: 24pt;",
                Typo.TitleSmall => "font-family: Roboto; font-weight: 500; font-size: 14pt; letter-spacing: 0.1pt; line-height: 20pt;",
                Typo.BodyLarge => "font-family: Roboto; font-weight: 400; font-size: 16pt; letter-spacing: 0.5pt; line-height: 24pt;",
                Typo.BodyMedium => "font-family: Roboto; font-weight: 400; font-size: 14pt; letter-spacing: 0.25pt; line-height: 20pt;",
                Typo.BodySmall => "font-family: Roboto; font-weight: 400; font-size: 12pt; letter-spacing: 0.4pt; line-height: 16pt;",
                Typo.LabelLarge => "font-family: Roboto; font-weight: 500; font-size: 14pt; letter-spacing: 0.1pt; line-height: 20pt;",
                Typo.LabelMedium => "font-family: Roboto; font-weight: 500; font-size: 12pt; letter-spacing: 0.5pt; line-height: 16pt;",
                Typo.LabelSmall => "font-family: Roboto; font-weight: 500; font-size: 11pt; letter-spacing: 0.5pt; line-height: 16pt;",
                _ => "font-family: Roboto; font-weight: 400; font-size: 14pt; line-height: 20pt;"
            };
        }
    }
}
