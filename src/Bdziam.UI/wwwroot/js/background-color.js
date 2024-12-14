// backgroundColorService.js
export function getBackgroundColorFromPoint(x, y) {
    // Get all elements at the specified point
    const elements = document.elementsFromPoint(x, y);

    if (!elements || elements.length === 0) {
        return "transparent";
    }

    // Iterate through elements to find the first one with a non-transparent background color
    for (let i = 1; i < elements.length; i++) {
        const computedStyle = window.getComputedStyle(elements[i]);
        const backgroundColor = computedStyle.backgroundColor;

        // Check if the background color is defined and not transparent
        if (backgroundColor && backgroundColor !== "rgba(0, 0, 0, 0)" && backgroundColor !== "transparent") {
            return backgroundColor;
        }
    }

    // Default fallback if no element with a background color is found
    return "transparent";
}