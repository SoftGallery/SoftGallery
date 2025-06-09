<script setup lang="ts">
import { onMounted, ref } from 'vue'
import { useRoute } from 'vue-router'
import axios from 'axios'
import { cart } from '../store/cart'
import Footer from '../components/Footer.vue'
import noImage from '../assets/noimage.png'
import CartButton from '../components/CartButton.vue'

interface ProdutoAPI {
    id: string
    nome: string
    descricao: string
    imagemURL: string
    preco: number
}

const route = useRoute()
const produto = ref<ProdutoAPI>()

async function fetchProduto() {
    try {
        const { data } = await axios.get(`https://localhost:7273/api/produto/${route.params.id}`)
        produto.value = data
    } catch (error) {
        console.error('Erro ao buscar produto:', error)
    }
}

onMounted(fetchProduto)

function addToCart() {
    if (produto.value) {
        const produtoParaCarrinho = {
            id: produto.value.id,
            nome: produto.value.nome,
            preco: produto.value.preco,
            imagemUrl: produto.value.imagemURL,
            stock: 10,
            quantity: 1
        }

        cart.addToCart(produtoParaCarrinho)
    }
}
</script>

<template>
    <div class="min-h-[600px] flex justify-center items-center px-4 py-8">
        <div class="flex flex-wrap max-w-6xl w-full gap-8">
            <!-- Imagem -->

            <div class="flex-1 min-w-[300px] max-w-md">
                <img :src="produto?.imagemURL || noImage" alt="Imagem do Produto"
                    class="w-full h-[400px] object-cover rounded-xl shadow" />
            </div>

            <!-- Informações -->
            <div class="flex-1 min-w-[300px] flex flex-col justify-between gap-6">
                <h2 class="text-3xl font-bold text-zinc-900">{{ produto?.nome || 'Nome do Produto' }}</h2>
                <p class="text-gray-600 leading-relaxed">
                    {{ produto?.descricao || 'Produto de excelente qualidade da CodeCore!' }}
                </p>
                
                <div class="text-2xl text-zinc-800 font-semibold">
                    R$ {{ produto?.preco?.toFixed(2) || '0.00' }}
                </div>


                <!-- Botão -->
                <button
                    class="bg-zinc-900 hover:bg-zinc-800 text-white py-2 px-4 rounded-md border-2 border-black flex items-center gap-2 w-fit"
                    @click="addToCart">
                    <i class="fa-solid fa-cart-shopping text-white"></i>
                    Adicionar ao carrinho
                </button>

                <!-- Info Boxes -->
                <div style="display: flex; justify-content: space-between; height: 45px; width: 100%;">
                    <div style="display: flex; height: 40px; width: 130px;">
                        <div
                            style="background-color: lightgray; border-radius: 3px; padding: 8px; display: flex; align-items: center; justify-content: center;">
                            <img src="../assets/delivery-truck.png" alt="" style="height: 30px;">
                        </div>
                        <div
                            style="font-size: 10px; display: flex; flex-direction: column; justify-content: space-around; margin-left: 5px;">
                            <p style="color: gray; font-weight: 500;">Free Delivery</p>
                            <p style="font-weight: bold;">1-3 days</p>
                        </div>
                    </div>
                    <div style="display: flex; height: 40px; width: 130px;">
                        <div
                            style="background-color: lightgray; border-radius: 3px; padding: 8px; display: flex; align-items: center; justify-content: center;">
                            <img src="../assets/in-stock.png" alt="" style="height: 30px;">
                        </div>
                        <div
                            style="font-size: 10px; display: flex; flex-direction: column; justify-content: space-around; margin-left: 5px;">
                            <p style="color: gray; font-weight: 500;">In Stock</p>
                            <p style="font-weight: bold;">Today</p>
                        </div>
                    </div>
                    <div style="display: flex; height: 40px; width: 130px;">
                        <div
                            style="background-color: lightgray; border-radius: 3px; padding: 8px; display: flex; align-items: center; justify-content: center;">
                            <img src="../assets/guarantee-certificate.png" alt="" style="height: 30px;">
                        </div>
                        <div
                            style="font-size: 10px; display: flex; flex-direction: column; justify-content: space-around; margin-left: 5px;">
                            <p style="color: gray; font-weight: 500;">Guaranteed</p>
                            <p style="font-weight: bold;">1 year</p>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>

    <Footer />
</template>
