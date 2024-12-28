/** @type {import('tailwindcss').Config} */
module.exports = {
    content: ['./**/*.{razor,html}'],
    theme: {
        extend: {
            screens: {
                '2xl': '1280px', // Hd 1920x1080
            },
            colors: {
                primary: "var(--primary-color)",
                secondary: "var(--secondary-color)",
                subtext: "var(--subtext-color)"
            },
        },
    },
    plugins: [],
}

