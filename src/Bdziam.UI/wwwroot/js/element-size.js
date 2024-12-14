export function getElementSize(elementId) {
    const element = document.getElementById(elementId);
    if (!element) {
        console.warn(`Element with ID '${elementId}' not found.`);
        return null;
    }

    const rect = element.getBoundingClientRect();
    console.log(rect.width, rect.height);

    return rect;
}
