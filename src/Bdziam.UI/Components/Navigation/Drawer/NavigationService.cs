using System.Reflection;
using Bdziam.UI;
using Bdziam.UI.Extensions;
using Microsoft.AspNetCore.Components;

public class NavigationService
{
    public IEnumerable<BDrawerMenuItemModel> GetMenuHierarchy()
    {
        var menuItems = new List<BDrawerMenuItemModel>();

        // Find all classes with NavigationItemAttribute
        var navigationItems = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(assembly => assembly.GetTypes())
            .Where(type => type.GetCustomAttribute<NavigationItemAttribute>() != null)
            .Select(attributeType => (Page: attributeType, Attribute: attributeType.GetCustomAttribute<NavigationItemAttribute>()))
            .ToList(); 


        return navigationItems
            .Where(item => !item.Attribute.Path.Contains('/')) // Root-level items
            .Select(navigationItem =>
            {
                var resolvedIcon = SvgIconResolver.Resolve(navigationItem.Attribute.IconString, navigationItem.Attribute.SvgIconString);

                return new BDrawerMenuItemModel
                {
                    Text = navigationItem.Attribute.Path,
                    Uri = navigationItem.Attribute.Uri ?? navigationItem.Page.GetCustomAttribute<RouteAttribute>()?.Template,
                    Icon = resolvedIcon,
                    Order = navigationItem.Attribute.Order,
                    Children = GetChildren(navigationItem.Attribute, navigationItems)
                };
            })
            .OrderBy(child => child.Order)
            .Reverse();
    }

    public List<BDrawerMenuItemModel> GetChildren(NavigationItemAttribute parent,
        List<(Type Page, NavigationItemAttribute NavigationAttribute)> allItems)
    {
        var parentPath = parent.Path + "/";
        return allItems
            .Where(item => item.NavigationAttribute.Path.StartsWith(parentPath) && item.NavigationAttribute.Path != parent.Path) // Direct children
            .GroupBy(item => item.NavigationAttribute.Path.Split('/')[parentPath.Split('/').Length - 1]) // Group by next path segment
            .Select(group =>
            {
                var firstItem = group.First();
                var resolvedIcon = SvgIconResolver.Resolve(firstItem.NavigationAttribute.IconString, firstItem.NavigationAttribute.SvgIconString);

                return new BDrawerMenuItemModel
                {
                    Text = group.Key,
                    Uri = firstItem.NavigationAttribute.Uri ?? firstItem.Page.GetCustomAttribute<RouteAttribute>()?.Template,
                    Icon = resolvedIcon,
                    Order = firstItem.NavigationAttribute.Order,
                    Children = GetChildren(firstItem.NavigationAttribute, allItems)
                };
            })
            .OrderBy(child => child.Order)
            .ToList();
    }
}