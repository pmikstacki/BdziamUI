/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ['./**/*.{razor,html}'], // Adjust paths as necessary
  theme: {
      colors: {
        primary: 'var(--color-primary)',
        secondary: 'var(--color-secondary)',
        tertiary: 'var(--color-tertiary)',
        info: 'var(--color-info)',
        success: 'var(--color-success)',
        warning: 'var(--color-warning)',
        error: 'var(--color-error)',
      },
    extend: {
      fontFamily: {
        sans: ['"Libre Franklin"', 'sans-serif'],
      },
      transitionProperty: {
        opacity: 'opacity',
        transform: 'transform',
      },
      keyframes: {
        fadeIn: {
          '0%': { opacity: '0' },
          '100%': { opacity: '1' },
        },
        fadeOut: {
          '0%': { opacity: '1' },
          '100%': { opacity: '0' },
        },
      },
      animation: {
        fadeIn: 'fadeIn 0.2s ease-in-out',
        fadeOut: 'fadeOut 0.2s ease-in-out',
      }
    },
  },
  safelist: [
    // Utility safelist for padding, margins, borders, etc.
    { pattern: /^p-(0|1|2|4|8)$/ }, // Padding
    { pattern: /^px-(0|1|3|6|2|4|8)$/ }, // Padding
    { pattern: /^py-(0|1|3|6|2|4|8)$/ }, // Padding
    { pattern: /^m-(0|1|2|4|8)$/ }, // Margins
    { pattern: /^(mt|mb|ml|mr)-(0|1|2|4|8)$/ }, // Margin top/bottom/left/right
    { pattern: /^border-(0|1|2|4|8)$/ }, // Borders
    { pattern: /^rounded-(none|sm|md|lg|full)$/ }, // Border radius
    { pattern: /^(top|bottom|left|right)-full$/ }, // Full positioning
    { pattern: /^text-(4xl|3xl|2xl|xl|lg|base|sm)$/ }, // Typography
    { pattern: /^font-(bold|semibold|medium|normal|light)$/ }, // Font weights
    { pattern: /^gap-(0|1|2|4|8)$/ }, // Font weights
    { pattern: /^space-x-(0|1|2|4|8)$/ }, // Font weights
    { pattern: /^font-(bold|medium|semibold|light)$/ }, // Font weights
    { pattern: /^space-y-(0|1|2|4|8)$/ }, // Font weights
    'bg-white', // Background color
    'shadow-md', // Medium shadow
    'opacity-50', // For disabled states
    'hover:brightness-90', // Hover effects
    'transition-all',
      
    'transform',
    'hover:scale-102',
    'active:scale-95',
    'transition-opacity',
    'transform',
    'opacity-100',
    'opacity-0',
      'flex',
      'rounded-pill',
      'flex-row',
      'flex-col',
      'h-screen',
    'scale-100',
      'items-center',
    'scale-95',
    'ease-in-out'
  ],

  plugins: [],
};
