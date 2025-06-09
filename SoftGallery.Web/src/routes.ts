// src/router/index.js
import { createRouter, createWebHistory } from 'vue-router'
import Home from "./pages/Home.vue"
import LoginAdm from "./pages/LoginAdm.vue"
import Produto from "./pages/Produto.vue"
import Produtos from './pages/Produtos.vue'
import component from 'element-plus/es/components/tree-select/src/tree-select-option.mjs'
import Carrinho from './pages/Carrinho.vue'
import Agradecimento from './pages/Agradecimento.vue'


const routes = [
  { path: '/', component: Home },
  { path: '/login-adm', component: LoginAdm },
  { path: '/contato', component: LoginAdm },
  { path: '/produto', component: Produto },
  {path: '/produtos', component: Produtos},
  {path: '/carrinho', component: Carrinho},
  {path: '/agradecimento', component: Agradecimento}
]

const router = createRouter({
  history: createWebHistory(),
  routes
})

export default router
