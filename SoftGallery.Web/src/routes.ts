// src/router/index.js
import { createRouter, createWebHistory } from 'vue-router'
import Home from "./pages/Home.vue"
import LoginAdm from "./pages/LoginAdm.vue"
import Produto from "./pages/Produto.vue"
import Produtos from './pages/Produtos.vue'
import Carrinho from './pages/Carrinho.vue'
import Loja from './pages/Adm/Loja.vue'
import ProdutoAdmin from './pages/Adm/Produto.vue'
import CampanhaAdmin from './pages/Adm/Campanha.vue'
import ProdutosCampanha from './pages/ProdutosCampanha.vue'


const routes = [
  { path: '/', component: Home },
  { path: '/login-adm', component: LoginAdm },
  { path: '/contato', component: LoginAdm },
  { path: '/produto/:id', component: Produto },
  {path: '/produtos', component: Produtos},
  {path: '/carrinho', component: Carrinho},
  {path: '/adm/geral', component: Loja},
  {path: '/adm/produto', component: ProdutoAdmin},
  {path: '/adm/campanha', component: CampanhaAdmin},
  {path: '/campanha/:id', component: ProdutosCampanha},
]

const router = createRouter({
  history: createWebHistory(),
  routes
})

export default router
