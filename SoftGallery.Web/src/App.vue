<template>
  <el-container style="height: 100vh">
    <el-header>
      <!-- Menu de navegação -->
      <el-menu
        :router="true"
        mode="horizontal"
        :default-active="$route.path"
      >
      <div>
        
      </div>
        <el-menu-item index="/">Home</el-menu-item>
        <el-menu-item index="/sobre">Sobre</el-menu-item>
        <el-menu-item index="/contato">Contato</el-menu-item>
        <el-menu-item index="/login-adm">Login</el-menu-item>
        <el-menu-item>
          <div class="interacoes">
          <barra-de-pesquisa></barra-de-pesquisa>
          <heart-button></heart-button>
          <cart-button></cart-button>
          <div></div>
        </div>
        </el-menu-item>
        
      </el-menu>
      
    </el-header>

    <el-main>
      <!-- Aqui o conteúdo da rota aparece -->
      <router-view />
    </el-main>
  </el-container>
</template>

<script lang="ts" setup>

import HeartButton from './components/HeartButton.vue';
import BarraDePesquisa from './components/BarraDePesquisa.vue';
import CartButton from './components/CartButton.vue';

</script>

<style>
@import url('https://fonts.googleapis.com/css2?family=Geist:wght@100..900&display=swap');
.interacoes{
      display: flex;
      gap: 7px;
      margin-left: auto;
      align-items: center;
}
body{
  font-family: "Geist", sans-serif;
}
</style>
