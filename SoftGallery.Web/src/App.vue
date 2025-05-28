<template>
  <el-container style="height: 100vh" v-if="!modoAdm">
    <el-header>
      <el-menu class="menu" :router="true" mode="horizontal" :default-active="$route.path">
        <div class="menu">
          <div class="menu">
            <Logo></Logo>
          </div>
          <div class="menu">
            <el-menu-item index="/">Home</el-menu-item>
            <el-menu-item index="/sobre">Sobre</el-menu-item>
            <el-menu-item index="/contato">Contato</el-menu-item>
            <el-menu-item index="/login-adm">Login</el-menu-item>
            <el-menu-item index="/adm/painel-adm">Adm</el-menu-item>
          </div>
        </div>
        <el-menu-item class="itens">
          <div class="interacoes">
            <barra-de-pesquisa></barra-de-pesquisa>
            <heart-button></heart-button>
            <cart-button></cart-button>
          </div>
        </el-menu-item>
      </el-menu>
    </el-header>

    <el-main>
      <router-view />
    </el-main>
    <Footer></Footer>
  </el-container>
  <BarraLateral v-if="modoAdm"/>
</template>

<script lang="ts" setup>
import { computed } from 'vue';
import { useRoute } from 'vue-router';

import HeartButton from './components/HeartButton.vue';
import BarraDePesquisa from './components/BarraDePesquisa.vue';
import CartButton from './components/CartButton.vue';
import BarraLateral from './components/BarraLateral.vue'
import Logo from './assets/Logo.vue'
import Footer from './components/Footer.vue'
const route = useRoute();

// Lista de rotas que são consideradas como "modo administrador"
const rotasAdm = ['/adm/painel-adm', '/adm/cadastrar-produto', '/adm/cadastrar-campanha'];

// Computa se está no modo adm
const modoAdm = computed(() => rotasAdm.includes(route.path));
</script>

<style>
@import url('https://fonts.googleapis.com/css2?family=Geist:wght@100..900&display=swap');

.interacoes {
  display: flex;
  gap: 7px;
  margin-left: auto;
  align-items: center;
}

body {
  font-family: "Geist", sans-serif;
}

.el-main{
  scrollbar-width: none; 
}

.itens {
  background-color: transparent !important;
  cursor: default;
}

.menu{
  display: flex;
  justify-content: space-between;
}

:root{
      --el-color-primary: #4051d0 !important;
}
</style>
