using Bdziam.UI.Model.Enums;

namespace BdziamUIExamples.Examples.Input.TextField.TextField;

public class TextFieldSettingsModel
{
    public InputType InputType { get; set; } = Bdziam.UI.Model.Enums.InputType.Text;
    public FieldVariant FieldVariant { get; set; }= FieldVariant.Filled;
    public bool Disabled { get; set; } = false;
    public bool IsRequired { get; set; } = false;
    public bool ShowClearButton { get; set; }= false; 
}