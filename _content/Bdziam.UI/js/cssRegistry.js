export const cssRegistry = {
    injectedStyles: {},

    /**
     * Injects a CSS style block into the <head> of the document.
     * @param {string} id - Unique identifier for the style.
     * @param {string} cssContent - CSS content to inject.
     */
    injectStyle: function (id, cssContent) {
        if (!this.injectedStyles[id]) {
            const styleElement = document.createElement('style');
            styleElement.id = id;
            styleElement.textContent = cssContent;
            document.head.appendChild(styleElement);
            this.injectedStyles[id] = true;
        }
    },

    /**
     * Injects an external CSS file into the <head> of the document.
     * @param {string} cssFile - Path to the CSS file to inject.
     */
    injectCssFile: function (cssFile) {
        const existingLink = document.querySelector(`link[href="${cssFile}"]`);
        if (!existingLink) {
            const linkElement = document.createElement('link');
            linkElement.rel = 'stylesheet';
            linkElement.href = cssFile;
            document.head.appendChild(linkElement);
        }
    }
};
