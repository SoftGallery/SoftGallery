
<script lang="ts" setup>
//template e script - o Router-view que está na "app.vue" exibe dinamicamente os conteúdos que estão  determinados nas rotas. Na Rota 'Home' estão importados os ocmponentes de 'section, cards , etc' - vou criar a página Produto que vai ser uma Rota onde vou importar os componentes e exebir um HTML. É só seguir o exemplo da Página Home.vue.

import CardProduto from '../components/CardProduto.vue';
import Section from '../components/Section.vue';
import Footer from '../components/Footer.vue';
</script>

<template>
    <div style="display: flex; justify-content: center; align-items: center; height: 500px; width:  500px;">
        <div style="position: absolute; top: 8px; left: 8px; background-color: red; color: white; padding: 2px 6px; border-radius: 8px; font-size: 11px; font-weight: bold;">
        </div>
        <img src="https://shadow.elemecdn.com/app/element/hamburger.9cf7b091-55e9-11e9-a976-7f4d0b07eef6.png"
         style="width: 100%; height: 100%; object-fit: cover; align-items: center;">
        <HeartButton style="position: absolute; top: 8px; right: 8px;"></HeartButton>
        <h2>Nome do Produto</h2>
        <div style="background-color: lightgray;">
            <h3>Descrição:</h3>
            <p>"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat."</p>
        </div>
        <div style="display: flex;">
            <div>Preço</div>
            <div>Quantidade</div>
        </div>
    </div>

<Footer></Footer>
</template>
