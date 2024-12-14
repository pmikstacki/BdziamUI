namespace Bdziam.UI;

/// <summary>
/// Represents CSS pseudo-classes and pseudo-elements for styling.
/// </summary>
public enum StyleState
{
    /// <summary>
    /// No pseudo-class or pseudo-element.
    /// </summary>
    None,

    /// <summary>
    /// The hover pseudo-class, triggered when the user hovers over an element.
    /// </summary>
    Hover,

    /// <summary>
    /// The focus pseudo-class, triggered when an element gains focus.
    /// </summary>
    Focus,
    
    /// <summary>
    /// The active pseudo-class, triggered when an element is being activated (e.g., clicked).
    /// </summary>
    Active,

    /// <summary>
    /// The visited pseudo-class, applicable to visited links.
    /// </summary>
    Visited,

    /// <summary>
    /// The disabled pseudo-class, applied to disabled form elements or buttons.
    /// </summary>
    Disabled,

    /// <summary>
    /// The checked pseudo-class, applied to checkboxes or radio buttons that are checked.
    /// </summary>
    Checked,

    /// <summary>
    /// The before pseudo-element, used to style content inserted before an element.
    /// </summary>
    Before,

    /// <summary>
    /// The after pseudo-element, used to style content inserted after an element.
    /// </summary>
    After,

    /// <summary>
    /// The first-child pseudo-class, applied to the first child of an element.
    /// </summary>
    FirstChild,

    /// <summary>
    /// The last-child pseudo-class, applied to the last child of an element.
    /// </summary>
    LastChild,

    /// <summary>
    /// The not pseudo-class, negates a selector (e.g., :not(.active)).
    /// </summary>
    Not,

    /// <summary>
    /// The first-of-type pseudo-class, applied to the first element of its type within a parent.
    /// </summary>
    FirstOfType,

    /// <summary>
    /// The last-of-type pseudo-class, applied to the last element of its type within a parent.
    /// </summary>
    LastOfType,

    /// <summary>
    /// The only-of-type pseudo-class, applied to an element if it is the only one of its type within a parent.
    /// </summary>
    OnlyOfType
}
