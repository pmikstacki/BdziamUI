using Bdziam.UI.Components.CommonBase;
using Bdziam.UI.Model.Enums;
using Bdziam.UI.Utilities;
using Microsoft.AspNetCore.Components;

namespace Bdziam.UI
{
    public partial class BText : Components.CommonBase.BComponentBase, IControlColor, IControlElevation
    {
        [Parameter] public Typo Typo { get; set; } = Typo.Body;
        [Parameter] public MaterialColor MaterialColor { get; set; } = MaterialColor.Background;
        [Parameter] public bool IsSurface { get; set; } = true;
        [Parameter] public RenderFragment? ChildContent { get; set; }
        [Parameter] public int Elevation { get; set; }

        private string TypographyClasses => new CssClassBuilder()
            .AddClass(GetTypographyBaseClasses())
            .AddClass(Class)
            .Build();

        private string TypographyStyle => new CssStyleBuilder()
            .AddStyle("color", ColorUtility.GetTextColorVariable(MaterialColor))
            .Build(Style);

        private string GetTypographyBaseClasses()
        {
            return Typo switch
            {
                Typo.H1 => "text-4xl font-bold leading-tight",
                Typo.H2 => "text-3xl font-bold leading-snug",
                Typo.H3 => "text-2xl font-semibold leading-normal",
                Typo.H4 => "text-xl font-semibold leading-relaxed",
                Typo.H5 => "text-lg font-medium",
                Typo.H6 => "text-base font-medium",
                Typo.Body => "text-base font-normal",
                Typo.Caption => "text-sm font-light",
                _ => "text-base font-normal"
            };
        }

    }
}