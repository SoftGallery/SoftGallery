// src/router/index.js
import { createRouter, createWebHistory } from 'vue-router'
import Home from "./pages/Home.vue"
import LoginAdm from "./pages/LoginAdm.vue"


const routes = [
  { path: '/', component: Home },
  { path: '/login-adm', component: LoginAdm },
  { path: '/contato', component: LoginAdm }
]

const router = createRouter({
  history: createWebHistory(),
  routes
})

export default router
