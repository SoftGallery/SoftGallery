// src/router/index.js
import { createRouter, createWebHistory } from 'vue-router'
import Home from "./pages/Home.vue"
import LoginAdm from "./pages/LoginAdm.vue"
import Produto from "./pages/Produto.vue"


const routes = [
  { path: '/', component: Home },
  { path: '/login-adm', component: LoginAdm },
  { path: '/contato', component: LoginAdm },
  { path: '/produto', component: Produto }
]

const router = createRouter({
  history: createWebHistory(),
  routes
})

export default router
