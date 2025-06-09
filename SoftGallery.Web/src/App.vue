<template>
  <el-container style="height: 100vh" v-if="!modoAdm">
    <el-header class="fixed-header">
      <div class="menu-container" style="display: flex; justify-content: space-between; align-items: center;">
        <!-- <Logo /> -->
        <img :src="logo" alt="Logo da loja" class="loja-img">

        <!-- Botão hamburguer visível em telas pequenas -->
        <button class="hamburguer" @click="menuAberto = !menuAberto">
          <i class="el-icon-menu"></i>
        </button>

        <!-- <div style="display: flex; width: fit-content;"> -->
          <!-- Menu horizontal normal para telas grandes -->
          <el-menu class="menu-desktop" :router="true" mode="horizontal" :default-active="$route.path" style="display: flex; justify-content: right; align-items: center;">
            <el-menu-item index="/">Home</el-menu-item>
            <el-menu-item index="/produtos">Produtos</el-menu-item>
            <el-menu-item index="/contato">Contato</el-menu-item>
            <el-menu-item index="/login-adm">Login</el-menu-item>
            <el-menu-item index="/adm/painel-adm">Adm</el-menu-item>
            <router-link to="/carrinho"><cart-button /></router-link>
          </el-menu>

          <!-- <div class="interacoes"> -->
            <!-- <barra-de-pesquisa></barra-de-pesquisa> -->
            <!-- <HeartButton /> -->
            <!-- <router-link to="/carrinho"><cart-button /></router-link>
          </div>
        </div> -->
      </div>

      <!-- Menu dropdown para mobile -->
      <el-menu v-if="menuAberto" class="menu-mobile" :router="true" mode="vertical" :default-active="$route.path">
        <el-menu-item index="/">Home</el-menu-item>
        <el-menu-item index="/sobre">Sobre</el-menu-item>
        <el-menu-item index="/contato">Contato</el-menu-item>
        <el-menu-item index="/login-adm">Login</el-menu-item>
        <el-menu-item index="/adm/painel-adm">Adm</el-menu-item>
      </el-menu>
    </el-header>

    <div class="main-content">
      <router-view />
      <Alert ref="successAlertRef" />
    </div>
  </el-container>
  <BarraLateral v-if="modoAdm" />
</template>


<script lang="ts" setup>
import { computed } from 'vue';
import { useRoute } from 'vue-router';

import HeartButton from './components/HeartButton.vue';
import BarraDePesquisa from './components/BarraDePesquisa.vue';
import CartButton from './components/CartButton.vue';
import BarraLateral from './components/BarraLateral.vue'
import Logo from './assets/Logo.vue'
import { ref, onMounted, nextTick } from 'vue'
import { registerAlert } from './services/alert.ts'
import Alert from './components/Alert.vue'
import axios from 'axios';

const route = useRoute();
const menuAberto = ref(false)

// Lista de rotas que são consideradas como "modo administrador"
const rotasAdm = ['/adm/painel-adm', '/adm/produto', '/adm/campanha', '/adm/geral'];

// Computa se está no modo adm
const modoAdm = computed(() => rotasAdm.includes(route.path));
const logo = ref('');

const successAlertRef = ref(null)
onMounted(async () => {
  try {
    const { data } = await axios.get('https://localhost:7273/api/Loja')
    logo.value = data.imagemURL || ''
  } catch {
    console.log('Loja ainda não cadastrada.')
  }
})
onMounted(async () => {
  await nextTick()
  registerAlert(successAlertRef.value.showAlert)
})
</script>


<style>
@import url('https://fonts.googleapis.com/css2?family=Geist:wght@100..900&display=swap');

:root {
  --el-color-primary: #4051d0 !important;
}

body {
  font-family: "Geist", sans-serif;
  margin: 0;
}

.loja-img {
  height: 50px;
}

/* Cabeçalho fixo */
.fixed-header {
  position: fixed;
  top: 0;
  left: 0;
  right: 0;
  z-index: 1000;
  background-color: #fff;
  box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1);
}

/* Compensação de altura do header fixo */
.main-content {
  padding-top: 60px;
}

/* Container do menu principal */
.menu-container {
  display: flex;
  align-items: center;
  justify-content: space-between;
  height: 60px;
  padding: 0 1rem;
}

/* Menu desktop */
.menu-desktop {
  display: flex;
  flex-grow: 1;
  justify-content: center;
  background-color: transparent;
  border-bottom: none;
}

/* Itens de interação (pesquisa, coração, carrinho) */
.interacoes {
  display: flex;
  gap: 10px;
  align-items: center;
  margin-left: auto;
}

/* Botão hamburguer */
.hamburguer {
  display: none;
  background: none;
  border: none;
  font-size: 24px;
  cursor: pointer;
  color: #4051d0;
}

/* Menu mobile */
.menu-mobile {
  display: none;
  flex-direction: column;
  background-color: #fff;
  border-top: 1px solid #eee;
  position: absolute;
  top: 60px;
  left: 0;
  right: 0;
  z-index: 999;
  padding: 0.5rem 0;
  box-shadow: 0 2px 8px rgba(0, 0, 0, 0.05);
  animation: slideDown 0.3s ease-out;
}

@keyframes slideDown {
  0% {
    opacity: 0;
    transform: translateY(-10px);
  }

  100% {
    opacity: 1;
    transform: translateY(0);
  }
}

/* Scroll suave */
.el-main {
  scrollbar-width: none;
}

@media (max-width: 768px) {
  .menu-desktop {
    display: none;
  }

  .hamburguer {
    display: block;
  }

  .interacoes {
    display: none;
  }

  .menu-mobile {
    display: flex;
  }
}
</style>