<template>
    <div>
      <h1>Bem-vindo ao site!</h1>
  
      <p v-if="tipo === 'info'">Esta é uma mensagem de informação.</p>
      <p v-else-if="tipo === 'erro'">Ocorreu um erro no sistema.</p>
      <p v-else>Mensagem padrão exibida.</p>
      <p>{{ nome_produto }}</p>
    </div>
  </template>
  
  <script setup>
  defineProps({
    tipo: {
      type: String,
      required: false
    },
    nome_produto: {
      type: String,
      required: true
    }
  });
  </script>
  