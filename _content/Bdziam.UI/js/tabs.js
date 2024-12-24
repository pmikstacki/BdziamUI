export function updateActiveLine(tabId, containerId, isPrimary) {
    const tabElement = document.getElementById(tabId);
    const container = document.getElementById(containerId);
    const activeLine = container.querySelector('.active-line');
    if (tabElement && activeLine && !isPrimary) {
        const tabRect = tabElement.getBoundingClientRect();
        const containerRect = tabElement.parentElement.getBoundingClientRect();

        // Calculate the width and position of the active line
        const width = tabRect.width;
        const left = tabRect.left - containerRect.left;

        // Set the styles dynamically
        activeLine.style.width = `${width}px`;
        activeLine.style.left = `${left}px`;

        // Adjust height to align with the middle of the text
        activeLine.style.transform = 'translateY(0)';
    }

    if (tabElement && container && activeLine && isPrimary) {
        const textElement = tabElement.querySelector('.pill'); // Target text within the tab
        if (!textElement) {
            console.warn('No text element found inside the tab.');
            return;
        }

        const textRect = textElement.getBoundingClientRect();
        const containerRect = container.getBoundingClientRect();
        const widthOffset = 20;
        // Calculate the width and position of the active line
        const width = textRect.width - widthOffset;
        const left = textRect.left - containerRect.left + (widthOffset / 2);

        // Set the styles dynamically
        activeLine.style.width = `${width}px`;
        activeLine.style.left = `${left}px`;
        activeLine.style.transform = 'translateY(0)';
    }
}
