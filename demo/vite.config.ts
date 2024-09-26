import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react'

// https://vitejs.dev/config/
export default defineConfig({
    base: "/Glutinum.Feliz.Victory/",
    plugins: [
        react({
            jsxRuntime: 'classic',
        })
    ],
    server: {
        watch: {
            ignored: [
                "**/*.fs"
            ]
        },
    },
    clearScreen: false
})
