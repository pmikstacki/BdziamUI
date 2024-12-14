using System.Reflection;
using Bdziam.UI;
using Bdziam.UI.Extensions;

public class NavigationService
{
    public IEnumerable<BDrawerMenuItemModel> GetMenuHierarchy()
    {
        var menuItems = new List<BDrawerMenuItemModel>();

        // Find all classes with NavigationItemAttribute
        var navigationItems = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(assembly => assembly.GetTypes())
            .Where(type => type.GetCustomAttribute<NavigationItemAttribute>() != null)
            .Select(attributeType => attributeType.GetCustomAttribute<NavigationItemAttribute>())
            .ToList(); // To avo


        return navigationItems
            .Where(item => !item.Path.Contains('/')) // Root-level items
            .Select(navigationItem =>
            {
                var resolvedIcon = SvgIconResolver.Resolve(navigationItem.IconString, navigationItem.SvgIconString);

                return new BDrawerMenuItemModel
                {
                    Text = navigationItem.Path,
                    Uri = navigationItem.Uri,
                    Icon = resolvedIcon,
                    Order = navigationItem.Order,
                    Children = GetChildren(navigationItem, navigationItems)
                };
            })
            .OrderBy(child => child.Order)
            .Reverse();
    }

    public List<BDrawerMenuItemModel> GetChildren(NavigationItemAttribute parent,
        List<NavigationItemAttribute> allItems)
    {
        var parentPath = parent.Path + "/";
        return allItems
            .Where(item => item.Path.StartsWith(parentPath) && item.Path != parent.Path) // Direct children
            .GroupBy(item => item.Path.Split('/')[parentPath.Split('/').Length - 1]) // Group by next path segment
            .Select(group =>
            {
                var firstItem = group.First();
                var resolvedIcon = SvgIconResolver.Resolve(firstItem.IconString, firstItem.SvgIconString);

                return new BDrawerMenuItemModel
                {
                    Text = group.Key,
                    Uri = firstItem.Uri,
                    Icon = resolvedIcon,
                    Order = firstItem.Order,
                    Children = GetChildren(firstItem, allItems)
                };
            })
            .OrderBy(child => child.Order)
            .ToList();
    }
}