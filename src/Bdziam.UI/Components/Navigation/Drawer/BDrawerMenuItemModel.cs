using Blazicons;

namespace Bdziam.UI;

public class BDrawerMenuItemModel
{
    public string? Uri { get; set; }
    public string Text { get; set; }
    public SvgIcon? Icon { get; set; }
    public List<BDrawerMenuItemModel> Children { get; set; } = new();

    public int Order { get; set; }
}