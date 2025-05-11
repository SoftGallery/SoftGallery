<template>
  <el-container style="height: 100vh">
    <el-header>
      <!-- Menu de navegação -->
      <el-menu
        :router="true"
        mode="horizontal"
        :default-active="$route.path"
      >
        <el-menu-item index="/">Home</el-menu-item>
        <el-menu-item index="/sobre">Sobre</el-menu-item>
        <el-menu-item index="/contato">Contato</el-menu-item>
        <el-menu-item index="/login-adm">Login</el-menu-item>
        <heart-button></heart-button>
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
</script>
