/** @type {import('tailwindcss').Config} */
const colors = require('tailwindcss/colors')

module.exports = {
  purge: {
    enabled: true,
    content: [
      './**/*.html',
      './**/*.razor',
      './**/*.cshtml',
    ]
  },
  theme: {
    extend: {},
  },
  plugins: [],
}
