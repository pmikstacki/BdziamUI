export function createRipple(container, clientX, clientY) {
    if (!container) return;

    const rect = container.getBoundingClientRect();
    const rippleSize = Math.max(rect.width, rect.height);
    const ripple = document.createElement("span");

    ripple.style.width = ripple.style.height = `${rippleSize}px`;
    ripple.style.left = `${clientX - rect.left - rippleSize / 2}px`;
    ripple.style.top = `${clientY - rect.top - rippleSize / 2}px`;
    ripple.classList.add("ripple");

    container.appendChild(ripple);

    setTimeout(() => {
        ripple.remove();
    }, 600);
}
