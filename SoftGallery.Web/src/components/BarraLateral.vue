<template>
  <el-row class="tac">
    <el-col :span="6">
      <el-menu
        default-active="1"
        class="el-menu-vertical-demo"
        @open="handleOpen"
        @close="handleClose"
        router
      >
      <el-menu-item class="itens logo">
        <img src="../assets/logo.svg" alt="" style="width: 120px;">
      </el-menu-item>
        <el-menu-item index="/adm/geral">
          <el-icon><setting /></el-icon>
          <span>Informações da Loja</span>
        </el-menu-item>

        <el-menu-item index="/adm/cadastrar-produto">
          <el-icon><document /></el-icon>
          <span>Cadastro de Produtos</span>
        </el-menu-item>

        <el-menu-item index="/adm/cadastrar-campanha">
          <el-icon><icon-menu /></el-icon>
          <span>Cadastro de Campanhas</span>
        </el-menu-item>
      </el-menu>
    </el-col>

    <el-col :span="18" :class="[isAdminRoute ? 'admin-bg' : '']">
      <router-view />
    </el-col>
  </el-row>
</template>

<script lang="ts" setup>
import { computed } from 'vue'
import { useRoute } from 'vue-router'
import {
  Document,
  Menu as IconMenu,
  Setting,
} from '@element-plus/icons-vue'

const route = useRoute()
const isAdminRoute = computed(() => route.path.startsWith('/adm'))

const handleOpen = (key: string, keyPath: string[]) => {
  console.log('Aberto:', key, keyPath)
}

const handleClose = (key: string, keyPath: string[]) => {
  console.log('Fechado:', key, keyPath)
}
</script>


<style scoped>
.el-col:not(.admin-bg),
.el-menu-vertical-demo {
  height: calc(100vh - 1rem);
  border-right: none;
  max-width: 250px;
}

.el-menu-vertical-demo{
    background-color: white !important;
}

.logo{
    display: flex;
    justify-content: center;
    align-items: center;
    margin-top: 1rem;
    margin-bottom: 1rem;
}

.admin-bg {
  background-color: #fbfbfb;
  height: 100vh;
  width: 120vw;
  overflow-y: auto;
}
</style>
