window.bdPopover = {
    popovers: {},

    initializePopover: function (popoverId, targetId, options) {
        const popoverElement = document.getElementById(popoverId);
        const targetElement = document.getElementById(targetId);
        if (!popoverElement || !targetElement) return;

        // Position the popover
        this.positionPopover(popoverElement, targetElement, options);

        // Store the popover instance
        this.popovers[popoverId] = {
            popoverElement,
            targetElement,
            options
        };
    },

    positionPopover: function (popoverElement, targetElement, options) {
        // Calculate position based on options (e.g., top, bottom, left, right)
        // Similar to MudBlazor's calculatePopoverPosition function
        const targetRect = targetElement.getBoundingClientRect();
        const popoverRect = popoverElement.getBoundingClientRect();
        let top = 0;
        let left = 0;

        // Adjust position based on the specified options
        switch (options.position) {
            case 'top':
                top = targetRect.top - popoverRect.height - options.margin;
                left = targetRect.left + (targetRect.width - popoverRect.width) / 2;
                break;
            case 'bottom':
                top = targetRect.bottom + options.margin;
                left = targetRect.left + (targetRect.width - popoverRect.width) / 2;
                break;
            case 'left':
                top = targetRect.top + (targetRect.height - popoverRect.height) / 2;
                left = targetRect.left - popoverRect.width - options.margin;
                break;
            case 'right':
                top = targetRect.top + (targetRect.height - popoverRect.height) / 2;
                left = targetRect.right + options.margin;
                break;
            default:
                // Default to bottom position
                top = targetRect.bottom + options.margin;
                left = targetRect.left + (targetRect.width - popoverRect.width) / 2;
                break;
        }

        // Apply position
        popoverElement.style.position = 'absolute';
        popoverElement.style.top = `${top + window.scrollY}px`;
        popoverElement.style.left = `${left + window.scrollX}px`;
        popoverElement.style.display = 'block';
    },

    closePopover: function (popoverId) {
        const popover = this.popovers[popoverId];
        if (popover) {
            // Hide the popover element
            popover.popoverElement.style.display = 'none';
            delete this.popovers[popoverId];
        }
    },

    handleDocumentClick: function (event) {
        for (const popoverId in this.popovers) {
            const popover = this.popovers[popoverId];
            if (
                !popover.popoverElement.contains(event.target) &&
                !popover.targetElement.contains(event.target)
            ) {
                // Close the popover by invoking .NET method
                DotNet.invokeMethodAsync('Bdziam.UI', 'OnPopoverOutsideClick', popoverId)
                    .catch((error) => console.error(error));
                // Optionally close the popover immediately
                this.closePopover(popoverId);
            }
        }
    }

};

// Attach the click handler once
document.addEventListener('mousedown', window.bdPopover.handleDocumentClick.bind(window.bdPopover));
