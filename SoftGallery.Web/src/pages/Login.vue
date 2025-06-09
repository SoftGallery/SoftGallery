<template>
  <div class="min-h-screen flex items-center justify-center bg-gray-100">
    <div class="bg-white p-8 rounded-xl shadow-lg w-full max-w-md">
      <h2 class="text-2xl font-bold text-center text-gray-800 mb-6">Login</h2>
      <form @submit.prevent="login">
        <div class="mb-4">
          <label class="block text-gray-700">Email</label>
          <input v-model="email" type="email" required
                 class="w-full mt-1 px-4 py-2 border rounded-lg focus:outline-none focus:ring focus:ring-blue-300" />
        </div>
        <div class="mb-6">
          <label class="block text-gray-700">Senha</label>
          <input v-model="senha" type="password" required
                 class="w-full mt-1 px-4 py-2 border rounded-lg focus:outline-none focus:ring focus:ring-blue-300" />
        </div>
        <button type="submit"
                class="w-full bg-blue-500 hover:bg-blue-600 text-white font-semibold py-2 px-4 rounded-lg">
          Entrar
        </button>
        <p v-if="resposta" class="mt-4 text-center text-sm text-gray-600">
          {{ resposta }}
        </p>
      </form>
    </div>
  </div>
</template>

<script setup>
import { ref } from 'vue'
import axios from 'axios'

const email = ref('')
const senha = ref('')
const resposta = ref('')

const login = async () => {
  try {
    const { data } = await axios.post('https://localhost:7273/api/Auth/signIn', {
      email: email.value,
      senha: senha.value
    })
    resposta.value = "Login efetuado com sucesso!"
    localStorage.setItem('token', data)
  } catch (error) {
    resposta.value = 'Erro ao fazer login.'
    console.error(error)
  }
}
</script>
