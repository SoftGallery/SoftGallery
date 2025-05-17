import { createApp } from 'vue'
import './style.css'
import App from './App.vue'
import router from "./routes"
import ElementPlus from 'element-plus'
import 'element-plus/dist/index.css'
import '/node_modules/@fortawesome/fontawesome-free/css/all.css';

const app = createApp(App)
app.use(router)
app.use(ElementPlus)
app.mount('#app')