<template>
  <!-- Cabeçalho -->
  <div class="bg-gradient-to-r from-purple-500 to-violet-700 text-white py-8">
    <div class="max-w-6xl mx-auto px-4">
      <div class="flex items-center gap-4">
        <div class="p-3 rounded-xl bg-white/20 backdrop-blur-sm">
          <i class="fa-solid fa-cart-shopping text-2xl"></i>
        </div>
        <div>
          <h1 class="text-2xl sm:text-3xl font-bold">Seu carrinho</h1>
          <p class="text-sm sm:text-base mt-1">{{ cart.items.length }} produtos selecionados</p>
        </div>
      </div>
    </div>
  </div>

  <!-- Conteúdo principal -->
  <div class="min-h-screen -mt-6 pt-6 px-4 max-w-6xl mx-auto">
    <div class="grid grid-cols-1 xl:grid-cols-3 gap-6">

      <!-- Lista de Produtos -->
      <div class="xl:col-span-2 order-2 xl:order-1">
        <div v-if="hasItems" class="bg-gray-100 shadow-md rounded-2xl border border-white/20">
          <div v-for="p in cart.items" :key="p.id" class="p-4 sm:p-6 border-b last:border-b-0 hover:bg-gray-50 transition">
            <div class="grid grid-cols-1 md:grid-cols-3 gap-4 items-center">

              <!-- Imagem -->
              <div>
                <img class="rounded-xl h-32 w-full object-cover" :src="p.imagemUrl" alt="Produto">
              </div>

              <!-- Informações -->
              <div>
                <h3 class="text-base sm:text-lg font-semibold text-slate-900">{{ p.nome }}</h3>
                <p class="text-xs text-gray-500 line-clamp-1 mb-2">ID: {{ p.id }}</p>
                <div class="flex items-center gap-2">
                  <span class="text-lg font-bold bg-clip-text text-transparent bg-gradient-to-r from-purple-500 to-violet-700">
                    {{ formatarPreco(p.preco) }}
                  </span>
                  <span class="text-xs bg-green-100 text-green-900 rounded-full py-1 px-2 font-medium">Em estoque</span>
                </div>
              </div>

              <!-- Controles -->
              <div class="flex flex-col items-start sm:items-end gap-2">
                <div class="flex items-center gap-2">
                  <button @click="diminuirQuantidade(p)" class="p-2 bg-gray-200 rounded hover:bg-rose-300">
                    <i class="fa-solid fa-minus text-rose-500"></i>
                  </button>
                  <span class="text-base font-bold">{{ p.quantity }}</span>
                  <button @click="aumentarQuantidade(p)" class="p-2 bg-gray-200 rounded hover:bg-emerald-200">
                    <i class="fa-solid fa-plus text-emerald-500"></i>
                  </button>
                </div>
                <span class="text-lg font-bold text-slate-900">{{ formatarPreco(p.preco) }}</span>
                <button @click="deleteProduto(p.id)" class="text-sm text-red-500 hover:underline">Remover</button>
              </div>

            </div>
          </div>
        </div>

        <!-- Carrinho vazio -->
        <div v-else class="bg-gray-100 shadow-md rounded-2xl border border-white/20 p-8 text-center">
          <div class="mb-6">
            <i class="fa-solid fa-cart-shopping text-6xl text-purple-400 bg-purple-100 p-6 rounded-full"></i>
          </div>
          <h2 class="text-2xl font-bold mb-2">Seu carrinho está vazio</h2>
          <p class="text-gray-600 mb-6">Adicione alguns produtos incríveis ao seu carrinho!</p>
          <div class="flex flex-col sm:flex-row gap-4 justify-center">
            <router-link to="/" class="px-6 py-3 bg-gradient-to-r from-purple-500 to-violet-700 text-white rounded-xl font-bold hover:scale-105 transition text-sm sm:text-base">
              <i class="fa-solid fa-magnifying-glass mr-2"></i>Descubra Produtos
            </router-link>
            <router-link to="/" class="px-6 py-3 border-2 border-gray-200 rounded-xl font-bold hover:scale-105 transition text-sm sm:text-base">
              <i class="fa-regular fa-heart mr-2"></i>Ver Favoritos
            </router-link>
          </div>
        </div>
      </div>

      <!-- Resumo -->
      <div class="order-1 xl:order-2">
        <div class="bg-gray-100 rounded-2xl shadow-md border border-white/20 p-6 sm:p-8">
          <div class="flex items-center gap-3 mb-4">
            <div class="bg-gray-200 p-2 rounded-lg">
              <i class="fa-solid fa-calculator text-xl bg-gradient-to-r from-purple-500 to-violet-700 bg-clip-text text-transparent"></i>
            </div>
            <h2 class="text-xl font-semibold text-slate-800">Resumo</h2>
          </div>

          <div class="flex justify-between text-gray-600 mb-2">
            <span>Subtotal</span>
            <span class="font-bold">{{ formatarPreco(valorTotal) }}</span>
          </div>
          <div class="flex justify-between text-gray-600 mb-2">
            <span>Frete</span>
            <span class="font-bold">{{ formatarPreco(0) }}</span>
          </div>
          <div class="flex justify-between text-emerald-600 mb-4">
            <span>Desconto</span>
            <span class="font-bold">-{{ formatarPreco(0) }}</span>
          </div>

          <div class="border-t border-gray-200 pt-4 flex justify-between items-center">
            <span class="text-lg font-bold text-slate-800">Total</span>
            <span class="text-2xl font-bold bg-gradient-to-r from-purple-500 to-violet-700 bg-clip-text text-transparent">
              {{ hasItems ? formatarPreco(valorTotal) : formatarPreco(0) }}
            </span>
          </div>

          <button @click="finalizar" class="mt-6 w-full p-3 bg-gradient-to-r from-emerald-500 to-teal-600 text-center rounded-xl hover:scale-105 transition cursor-pointer">
            <span class="text-white font-bold"><i class="fa-regular fa-credit-card mr-2"></i>Finalizar Compra</span>
          </button>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import { computed } from 'vue'
import { cart } from '../store/cart'

// Manipuladores de quantidade
const aumentarQuantidade = (produto: typeof cart.items[number]) => {
  cart.updateQuantity(produto.id, produto.quantity + 1)
}

const diminuirQuantidade = (produto: typeof cart.items[number]) => {
  cart.updateQuantity(produto.id, produto.quantity - 1)
}

// Remoção
const deleteProduto = (id: string) => {
  cart.removeFromCart(id)
}

// Finalização do pedido
const finalizar = () => {
  cart.finalizarPedido()
  alert('Pedido finalizado com sucesso!')
}

// Utilitário para formatar preços
const formatarPreco = (valor: number) =>
  valor.toLocaleString('pt-BR', { style: 'currency', currency: 'BRL' })

// Variáveis reativas para total e existência de itens no carrinho
const valorTotal = computed(() => cart.totalPrice)
const hasItems = computed(() => cart.items.length > 0)
</script>
