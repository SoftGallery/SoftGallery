<template>
  <!-- Cabeçalho -->
  <div class="bg-gray-800 text-white py-6">
    <div class="max-w-4xl mx-auto px-4">
      <div class="flex items-center gap-4">
        <div class="p-3 rounded-lg bg-gray-700">
          <i class="fa-solid fa-cart-shopping text-xl"></i>
        </div>
        <div>
          <h1 class="text-xl sm:text-2xl font-semibold">Seu carrinho</h1>
          <p class="text-sm mt-1 text-gray-300">{{ cart.items.length }} produtos selecionados</p>
        </div>
      </div>
    </div>
  </div>

  <!-- Conteúdo principal -->
  <div class="min-h-screen py-6 px-4 max-w-4xl mx-auto">
    <div class="grid grid-cols-1 xl:grid-cols-3 gap-6">

      <!-- Lista de Produtos -->
      <div class="xl:col-span-2 order-2 xl:order-1">
        <div v-if="hasItems" class="bg-white rounded-xl shadow border border-gray-200">
          <div v-for="p in cart.items" :key="p.id" class="p-4 border-b last:border-b-0 hover:bg-gray-50 transition">
            <div class="grid grid-cols-1 md:grid-cols-3 gap-4 items-center">
              <!-- Imagem -->
              <div>
                <img class="rounded-lg h-28 w-full object-cover" :src="p.imagemUrl" alt="Produto">
              </div>

              <!-- Informações -->
              <div>
                <h3 class="text-base font-medium text-gray-900">{{ p.nome }}</h3>
                <p class="text-xs text-gray-500 mb-2">ID: {{ p.id }}</p>
                <div class="flex items-center gap-2">
                  <span class="text-base font-semibold text-gray-800">
                    {{ formatarPreco(p.preco) }}
                  </span>
                  <span class="text-xs bg-green-100 text-green-800 rounded px-2 py-0.5 font-medium">Em estoque</span>
                </div>
              </div>

              <!-- Controles -->
              <div class="flex flex-col items-start sm:items-end gap-2">
                <div class="flex items-center gap-2">
                  <button @click="diminuirQuantidade(p)" class="p-2 bg-gray-200 rounded hover:bg-gray-300">
                    <i class="fa-solid fa-minus text-gray-700"></i>
                  </button>
                  <span class="text-base font-semibold">{{ p.quantity }}</span>
                  <button @click="aumentarQuantidade(p)" class="p-2 bg-gray-200 rounded hover:bg-gray-300">
                    <i class="fa-solid fa-plus text-gray-700"></i>
                  </button>
                </div>
                <span class="text-base font-bold text-gray-900">{{ formatarPreco(p.preco) }}</span>
                <button @click="deleteProduto(p.id)" class="text-sm text-red-500 hover:underline">Remover</button>
              </div>
            </div>
          </div>
        </div>

        <!-- Carrinho vazio -->
        <div v-else class="bg-white shadow rounded-xl border border-gray-200 p-8 text-center">
          <div class="mb-4">
            <i class="fa-solid fa-cart-shopping text-5xl text-gray-400"></i>
          </div>
          <h2 class="text-xl font-semibold text-gray-800 mb-2">Seu carrinho está vazio</h2>
          <p class="text-gray-600 mb-6">Adicione alguns produtos ao seu carrinho.</p>
          <div class="flex flex-col sm:flex-row gap-4 justify-center">
            <router-link to="/" class="px-5 py-2 bg-gray-800 text-white rounded hover:bg-gray-700 transition text-sm">
              <i class="fa-solid fa-magnifying-glass mr-2"></i>Descobrir Produtos
            </router-link>
            <!-- <router-link to="/" class="px-5 py-2 border border-gray-400 text-gray-700 rounded hover:bg-gray-100 transition text-sm">
              <i class="fa-regular fa-heart mr-2"></i>Ver Favoritos
            </router-link> -->
          </div>
        </div>
      </div>

      <!-- Resumo -->
      <div class="order-1 xl:order-2">
        <div class="bg-white rounded-xl shadow border border-gray-200 p-6">
          <div class="flex items-center gap-2 mb-4">
            <i class="fa-solid fa-calculator text-lg text-gray-600"></i>
            <h2 class="text-lg font-semibold text-gray-800">Resumo</h2>
          </div>

          <div class="flex justify-between text-sm text-gray-600 mb-2">
            <span>Subtotal</span>
            <span class="font-semibold">{{ formatarPreco(valorTotal) }}</span>
          </div>
          <div class="flex justify-between text-sm text-gray-600 mb-2">
            <span>Frete</span>
            <span class="font-semibold">{{ formatarPreco(0) }}</span>
          </div>
          <div class="flex justify-between text-sm text-green-600 mb-4">
            <span>Desconto</span>
            <span class="font-semibold">-{{ formatarPreco(0) }}</span>
          </div>

          <div class="border-t border-gray-200 pt-4 flex justify-between items-center">
            <span class="text-base font-semibold text-gray-800">Total</span>
            <span class="text-xl font-bold text-gray-900">
              {{ hasItems ? formatarPreco(valorTotal) : formatarPreco(0) }}
            </span>
          </div>

          <button @click="finalizar" class="mt-6 w-full py-3 bg-gray-800 text-white rounded hover:bg-gray-700 transition">
            <i class="fa-regular fa-credit-card mr-2"></i>Finalizar Compra
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
