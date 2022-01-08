function withOpacityValue(colorVar) {
  return ({ opacityValue }) => {
    if (opacityValue === undefined) {
      return `rgb(var(${colorVar}))`;
    }
    return `rgb(var(${colorVar}) / ${opacityValue})`;
  }
}

module.exports = {
  content: [
    "../Pages/**/*.{cshtml,razor}",
    "../Shared/**/*.{cshtml,razor}"
  ],
  theme: {
    extend: {
      colors: {
        'background': withOpacityValue('--bgsc-background'),
        'on-background': withOpacityValue('--bgsc-on-background'),
        'primary': withOpacityValue('--bgsc-primary'),
        'on-primary': withOpacityValue('--bgsc-on-primary'),
        'secondary': withOpacityValue('--bgsc-secondary'),
        'on-secondary': withOpacityValue('--bgsc-on-secondary'),
        'menu': {
          'top': withOpacityValue('--bgsc-menu-top'),
          'bottom': withOpacityValue('--bgsc-menu-bottom'),
          'text': withOpacityValue('--bgsc-menu-text'),
        },
      },
    },
  },
  plugins: [],
};