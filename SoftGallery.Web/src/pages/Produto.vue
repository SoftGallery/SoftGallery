
<script lang="ts" setup>
//template e script - o Router-view que está na "app.vue" exibe dinamicamente os conteúdos que estão  determinados nas rotas. Na Rota 'Home' estão importados os ocmponentes de 'section, cards , etc' - vou criar a página Produto que vai ser uma Rota onde vou importar os componentes e exebir um HTML. É só seguir o exemplo da Página Home.vue.

import CardProduto from '../components/CardProduto.vue';
import Section from '../components/Section.vue';
import Footer from '../components/Footer.vue';

</script>

<template>
    <div style="height: 1000px; display: flex; justify-content: center; align-items: center;">
        <div style="display: flex; align-items: center; height: 70%; width:70%;">
            <div style="display: flex; flex-direction: column; height: 100%; width: 10%;">
                <img src="https://placehold.co/100x100" alt="" style="max-width: 100%; max-height: 100%; overflow:hidden; height: 100%; border: 2px solid white">
                <img src="https://placehold.co/100x100" alt="" style="max-width: 100%; max-height: 100%; overflow:hidden; height: 100%; border: 2px solid white">
                <img src="https://placehold.co/100x100" alt="" style="max-width: 100%; max-height: 100%; overflow:hidden; height: 100%; border: 2px solid white">
                <img src="https://placehold.co/100x100" alt="" style="max-width: 100%; max-height: 100%; overflow:hidden; height: 100%; border: 2px solid white">
                <img src="https://placehold.co/100x100" alt="" style="max-width: 100%; max-height: 100%; overflow:hidden; height: 100%; border: 2px solid white">
                <img src="https://placehold.co/100x100" alt="" style="max-width: 100%; max-height: 100%; overflow:hidden; height: 100%; border: 2px solid white">
                
            </div>
            <div style="height: 100%; width: 40%; margin-left: 20px;">
                <img src="https://shadow.elemecdn.com/app/element/hamburger.9cf7b091-55e9-11e9-a976-7f4d0b07eef6.png"
                 style="width: 100%; height: 100%; object-fit: cover; align-items: center;">
            </div>
            <div style="display: flex; flex-direction: column; justify-content: flex-start; gap: 50px; height: 100%; width: 50%; margin-left: 20px;">
                <h2 style="color: black; font-weight:800; font-size: 35px;">Nome do Produto</h2>
                <div style="display: flex; color: black; font-size: 35px;">
                    <div>$1500</div>
                    <span style="text-decoration-line: line-through; font-size: 30px; margin-left: 5px; color: darkgray;">Desconto</span>
                </div>
                <div style="background-color: lightgray;">
                    <h3>Descrição:</h3>
                    <p>"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat."</p>
                </div>
                <div style="display: flex; justify-content: center; align-items: center; border-color: black; border-style: solid;">
                    <button style="background-color: rgb(24, 24, 27); color: white; padding: 0px 30px; border-radius: 3px; height: 60px;">Add to cart</button>
                </div>
            </div>
        </div>
    </div>

<Footer></Footer>
</template>
