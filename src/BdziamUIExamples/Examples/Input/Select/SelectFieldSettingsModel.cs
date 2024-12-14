using Bdziam.UI.Model.Enums;

namespace BdziamUIExamples.Examples.Input.TextField.Select;

public class SelectFieldSettingsModel
{
    public FieldVariant FieldVariant { get; set; }= FieldVariant.Filled;
    public bool Disabled { get; set; } = false;
    public bool IsRequired { get; set; } = false;
    public bool ShowSearch { get; set; } = false;
    public bool ShowClearButton { get; set; }= false; 
}