<template>
    <div class="bg-gradient-to-r from-purple-500 to-violet-700 text-white py-12">
        <div class="max-w-6xl mx-auto px-4 sm:px-6">
            <div class="flex items-center space-x-4">
            <div class="p-4 rounded-2xl bg-white/20 backdrop-blur-sm" ><i class="fa-solid fa-cart-shopping text-3xl"></i></div>
            <div>
                <h1 class="text-4xl font-bold">Seu carrinho</h1>
                <p class="mt-2">{{ carrinho.length }} produtos selecionados</p>
            </div>
        </div>
        </div>  
    </div>
    <div class="min-h-screen -mt-8 pt-3">
        <div class="max-w-6xl mx-auto px-4">
            <div class="grid sm:grid-cols-1 xl:grid-cols-3 gap-8">
                <div v-if="carrinho.length >= 1" class=" bg-gray-100 shadow-lg  rounded-3xl border border-white/20 col-span-2  overflow-hidden ">
                    <div v-for="p in carrinho" class="p-8 hover:bg-gray-50/50 transition-all duration-200">
                        <div class="flex items-center space-x-6">
                            <div class="min-h-10 bg-gray-100 p-4 shadow-lg rounded-2xl w-30 h-30 overflow-hidden flex-shrink-0"><img class="rounded-2xl h-full w-full object-cover" :src="p.thumbnail" alt=""></div>
                            <div class="min-h-10 overflow-hidden">
                                <h3 class="mb-1 text-lg font-bold text-slate-900">{{ p.nome }}</h3>
                                <p class="mb-3 text-xs text-gray-500 line-clamp-1">{{ p.descricao }}</p>
                                <div class="flex space-x-2 items-center">
                                    <span class="text-2xl font-bold bg-clip-text text-transparent bg-gradient-to-r from-purple-500 to-violet-700">${{ p.precoDesconto }}</span>
                                    <span class="rounded-full py-1 px-2 text-xs bg-green-100 text-green-900 font-semibold">Em estoque</span>
                                </div>
                            </div>
                            <div class="min-h-10 flex items-center p-2 rounded-2xl bg-gray-100 space-x-3">
                                <button @click="diminuirQuatidade(p)" class="cursor-pointer py-1 px-2 bg-gray-200/50 rounded-lg hover:scale-110 hover:bg-rose-300 transform transition duration-200 hover:shadow"><i class="fa-solid fa-minus text-rose-500"></i></button>
                                <span class="text-lg font-bold text-center text-slate-900">{{ p.quantidade }}</span>
                                <button @click="aumentarQuantidade(p)" class="cursor-pointer py-1 px-2 bg-gray-200/50 rounded-lg hover:scale-110 hover:bg-emerald-200 transform transition duration-200 hover:shadow"><i class="fa-solid fa-plus text-emerald-500"></i></button>
                            </div>
                            <div class="min-h-10 flex flex-col items-center">
                                <span class="text-2xl font-bold text-slate-900 mb-3">${{ p.precoDesconto }}</span>
                                <button @click="deleteProduto(p.id)" class="flex justify-between gap-3 bg-red-100 p-2 rounded-lg font-medium items-center text-red-400 text-sm hover:scale-110 transform transition duration-200 hover:shadow cursor-pointer"><i class="fa-solid fa-trash "></i> Remover</button>
                            </div>
                        </div>
                    </div>
                </div>
                <div v-else="carrinho.length" class="bg-gray-100 shadow-white/50 shadow-md rounded-3xl border border-white/20 col-span-2  overflow-hidden ">
                    <div class="p-16 flex flex-col items-center">
                        <div class="bg-purple-100 rounded-full p-12 text-center mb-8">
                            <i class="fa-solid fa-cart-shopping text-8xl text-purple-400"></i>
                        </div>
                        <h2 class="font-bold text-4xl mb-4">Seu carrinho esta vazio</h2>
                        <p class="text-xl mb-2 text-gray-600">Por que não adicionar alguns produtos incríveis?</p>
                        <p class="text-gray-500">Explore nossa coleção e descubra produtos que você vai amar!</p>
                        <div class="flex gap-4 mt-12 justify-center">
                            <router-link to="/" class="px-8 py-4 rounded-2xl bg-gradient-to-r from-purple-500 to-violet-700 text-white font-bold shadow-lg hover:scale-110 transform transition duration-200 hover:shadow-lg"><i class="fa-solid fa-magnifying-glass text-white"></i> Descubra Produtos</router-link>
                            <router-link class="px-8 py-4 rounded-2xl border-2 border-gray-200 shadow-lg font-bold hover:scale-110 transform transition duration-200 hover:shadow-lg"><i class="fa-regular fa-heart"></i> Ver Favoritos</router-link>
                        </div>
                    </div>
                </div>
                <div class="flex flex-col">
                    <div class="bg-gray-100 rounded-3xl shadow-lg border border-white/20 p-10 w-full backdrop-blur-sm">
                        <div class="flex items-center space-x-3 mb-6">
                            <div class="bg-gray-200/50 py-2 px-3 rounded-xl"><i class="fa-solid fa-calculator text-3xl bg-gradient-to-r from-purple-500 to-violet-700 bg-clip-text text-transparent" ></i></div>
                            <div class="font-bold text-2xl text-slate-800">Resumo</div>
                        </div>
                        <div class="flex justify-between text-gray-600 mb-4">
                            <span class="font-medium">Subtotal</span>
                            <span class="font-bold">${{ valorTotal.toFixed(2) }}</span>
                        </div>
                        <div v-if="carrinho.length >= 1" class="flex justify-between text-gray-600 mb-4">
                            <span class="font-medium">Frete</span>
                            <span class="font-bold">$29.99</span>
                        </div>
                        <div v-else="carrinho.length" class="flex justify-between text-gray-600 mb-4">
                            <span class="font-medium">Frete</span>
                            <span class="font-bold">$0.00</span>
                        </div>
                        <div class="flex justify-between text-gray-600 mb-4">
                            <span class="font-medium text-emerald-600">Desconto</span>
                            <span class="font-bold text-emerald-600">-$0.00</span>
                        </div>
                        <div class="pt-3 border-t border-gray-200">
                            <div class="flex justify-between">
                                <span class="text-2xl text-slate-800 font-bold">Total</span>
                                <span v-if="carrinho.length >= 1" class="text-3xl font-bold bg-gradient-to-r from-purple-500 to-violet-700 bg-clip-text text-transparent">${{ (valorTotal + 29.99).toFixed(2) }}</span>
                                <span v-else="carrinho.length" class="text-3xl font-bold bg-gradient-to-r from-purple-500 to-violet-700 bg-clip-text text-transparent">${{ 0 }}</span>
                            </div>
                        </div>
                        <div class="w-full mt-4 p-3 bg-gradient-to-r from-emerald-500 to-teal-600 rounded-xl hover:scale-105 transition transform duration-200 cursor-pointer hover:shadow-xl">
                            <div class="flex items-center justify-center space-x-2">
                                <i class="fa-regular fa-credit-card text-white text-lg"></i>
                                <span class="font-bold text-white text-lg">Finish Purchase</span>
                            </div>  
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script setup>
import { ref, computed, onMounted } from 'vue'

const carrinho = ref([])

const produtosMockados = [
  {
    id: 1,
    nome: 'Wireless Headphones',
    descricao: 'High-quality sound with noise cancellation.',
    precoDesconto: 99.99,
    quantidade: 1,
    thumbnail: 'https://dummyimage.com/200x200/000/fff&text=Headphones'
  },
  {
    id: 2,
    nome: 'Smart Watch',
    descricao: 'Track your fitness and notifications.',
    precoDesconto: 149.99,
    quantidade: 2,
    thumbnail: 'https://dummyimage.com/200x200/000/fff&text=Smart+Watch'
  }
]


onMounted(() => {
  const local = localStorage.getItem('carrinho')
  if (local) {
    carrinho.value = JSON.parse(local)
  } else {
    localStorage.setItem('carrinho', JSON.stringify(produtosMockados))
    carrinho.value = produtosMockados
  }
  atualizarCarrinho()
})
const valorTotal = computed(() =>
  carrinho.value.reduce((total, p) => total + (p.precoDesconto * p.quantidade), 0)
)

const aumentarQuantidade = (produto) => {
  produto.quantidade++
  atualizarCarrinho()
}

const diminuirQuantidade = (produto) => {
  if (produto.quantidade > 1) {
    produto.quantidade--
    atualizarCarrinho()
  }
}

const deleteProduto = (id) => {
  carrinho.value = carrinho.value.filter(p => p.id !== id)
  atualizarCarrinho()
}

const atualizarCarrinho = () => {
  localStorage.setItem('carrinho', JSON.stringify(carrinho.value))
}


</script>
