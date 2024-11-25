// popover.js

export function initializePopover(popoverId, targetId, options, dotNetHelper) {
    const popoverElement = document.getElementById(popoverId);
    const targetElement = document.getElementById(targetId);
    if (!popoverElement || !targetElement) return;

    // Position the popover
    positionPopover(popoverElement, targetElement, options);

    // Store the popover instance
    if (!window.bdPopoverInstances) {
        window.bdPopoverInstances = {};
    }
    window.bdPopoverInstances[popoverId] = {
        popoverElement,
        targetElement,
        options,
        dotNetHelper
    };

    // Attach the click handler if not already attached
    if (!window.bdPopoverClickHandlerAttached) {
        document.addEventListener('mousedown', handleDocumentClick);
        window.bdPopoverClickHandlerAttached = true;
    }
}

export function closePopover(popoverId) {
    const instance = window.bdPopoverInstances && window.bdPopoverInstances[popoverId];
    if (instance) {
        // Hide the popover element
        instance.popoverElement.style.display = 'none';
        // Do NOT dispose of the .NET object reference here
        // Remove the instance
        delete window.bdPopoverInstances[popoverId];
    }
}

export function dispose() {
    if (window.bdPopoverClickHandlerAttached) {
        document.removeEventListener('mousedown', handleDocumentClick);
        window.bdPopoverClickHandlerAttached = false;
    }
    if (window.bdPopoverInstances) {
        for (const popoverId in window.bdPopoverInstances) {
            const instance = window.bdPopoverInstances[popoverId];
            // Do NOT dispose of the .NET object reference here
        }
        window.bdPopoverInstances = {};
    }
}
function positionPopover(popoverElement, targetElement, options) {
    const targetRect = targetElement.getBoundingClientRect();
    const popoverRect = popoverElement.getBoundingClientRect();

    const margin = options.margin || 8; // Default margin if not provided
    const viewportWidth = window.innerWidth;
    const viewportHeight = window.innerHeight;

    let top = 0;
    let left = 0;

    // Initial positioning based on the requested position
    switch (options.position) {
        case 'top':
            top = targetRect.top - popoverRect.height - margin;
            left = targetRect.left + targetRect.width / 2 - popoverRect.width / 2;
            break;
        case 'bottom':
            top = targetRect.bottom + margin;
            left = targetRect.left + targetRect.width / 2 - popoverRect.width / 2;
            break;
        case 'left':
            top = targetRect.top + targetRect.height / 2 - popoverRect.height / 2;
            left = targetRect.left - popoverRect.width - margin;
            break;
        case 'right':
            top = targetRect.top + targetRect.height / 2 - popoverRect.height / 2;
            left = targetRect.right + margin;
            break;
        default:
            top = targetRect.bottom + margin;
            left = targetRect.left + targetRect.width / 2 - popoverRect.width / 2;
            break;
    }

    // Adjust to keep the popover within the viewport
    // Adjust horizontal position
    if (left < 0) {
        left = margin; // Align to the left edge
    } else if (left + popoverRect.width > viewportWidth) {
        left = viewportWidth - popoverRect.width - margin; // Align to the right edge
    }

    // Adjust vertical position
    if (top < 0) {
        top = targetRect.bottom + margin; // Move below the target
    } else if (top + popoverRect.height > viewportHeight) {
        top = targetRect.top - popoverRect.height - margin; // Move above the target
    }

    // Fallback: Ensure the popover stays entirely within bounds
    if (top + popoverRect.height > viewportHeight) {
        top = viewportHeight - popoverRect.height - margin; // Align to the bottom edge
    }
    if (left + popoverRect.width > viewportWidth) {
        left = viewportWidth - popoverRect.width - margin; // Align to the right edge
    }

    // Apply scroll offsets if using `absolute` positioning
    if (popoverElement.style.position === 'absolute') {
        top += window.scrollY;
        left += window.scrollX;
    }

    // Apply calculated styles
    popoverElement.style.top = `${Math.max(top, 0)}px`;
    popoverElement.style.left = `${Math.max(left, 0)}px`;
    popoverElement.style.display = 'block';
}




function handleDocumentClick(event) {
    const instances = window.bdPopoverInstances || {};
    for (const popoverId in instances) {
        const instance = instances[popoverId];
        if (
            !instance.popoverElement.contains(event.target) &&
            !instance.targetElement.contains(event.target)
        ) {
            // Invoke the .NET method via the DotNetObjectReference
            instance.dotNetHelper.invokeMethodAsync('OnOutsideClick')
                .catch(error => console.error(error));
        }
    }
}

