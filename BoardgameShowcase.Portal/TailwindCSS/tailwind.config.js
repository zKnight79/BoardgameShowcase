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
    "../Shared/**/*.{cshtml,razor}",
    "../Widgets/**/*.{cshtml,razor,cs}"
  ],
  theme: {
    extend: {
      colors: {
        'background': withOpacityValue('--bgsc-background'),
        'on-background': withOpacityValue('--bgsc-on-background'),
        'surface': withOpacityValue('--bgsc-surface'),
        'on-surface': withOpacityValue('--bgsc-on-surface'),
        'primary': {
          lighter: withOpacityValue('--bgsc-primary-lighter'),
          light: withOpacityValue('--bgsc-primary-light'),
          DEFAULT: withOpacityValue('--bgsc-primary'),
          dark: withOpacityValue('--bgsc-primary-dark'),
          darker: withOpacityValue('--bgsc-primary-darker'),
        },
        'on-primary': withOpacityValue('--bgsc-on-primary'),
        'secondary': withOpacityValue('--bgsc-secondary'),
        'on-secondary': withOpacityValue('--bgsc-on-secondary'),
        'error': {
          lighter: withOpacityValue('--bgsc-error-lighter'),
          light: withOpacityValue('--bgsc-error-light'),
          DEFAULT: withOpacityValue('--bgsc-error'),
          dark: withOpacityValue('--bgsc-error-dark'),
          darker: withOpacityValue('--bgsc-error-darker'),
        },
        'on-error': withOpacityValue('--bgsc-on-error'),
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