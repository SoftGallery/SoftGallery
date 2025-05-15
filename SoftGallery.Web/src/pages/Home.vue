<script lang="ts" setup>
import CardProduto from '../components/CardProduto.vue';
import Section from '../components/Section.vue';


</script>

<template>
  <div class="container" style="padding: 64px 16px">
    <div style="display: flex; flex-direction: row; gap: 3rem;">
      <div style="display: flex; flex-direction: column; justify-content: center;">
        <div>
          <h1 style="font-weight: bold; font-size: 48px;">Ofertas Especiais de Verão</h1>
          <p style="padding-top: 8px; color: gray; font-size: 16px;">Descubra nossa nova coleção com até 40% de desconto. Produtos exclusivos para você aproveitar o verão com estilo.</p>
        </div>
        <div style="margin-top: 16px;">
          <el-button style="background-color: #18181B; color: white; padding: 0px 30px;">Ver ofertas</el-button>
          <el-button style="padding: 0px 30px;">Explorar coleção</el-button>
        </div>
        
      </div>
      <img src="https://picsum.photos/400/400" alt="Imagem aleatória">
    </div>
  </div>

  <section style="padding: 64px 0px;">
    <div style="display: flex; flex-direction: row; gap: 6px;">
      <div style="display: flex; flex-direction: row; gap: 35px;">
        <div style="display: flex; flex-direction: column;">
          <h3 style="font-size: 24px;">Coleção Outono</h3>
          <p style="padding-top: 8px; font-size: 13px; color: gray;">Prepare-se para a nova estação<br> com nossa coleção exclusiva</p>
          <el-button style="background-color: #18181B; color: white;">Comprar Agora</el-button>
        </div>
        <img src="https://picsum.photos/252/252" alt="Imagem aleatória">
      </div>
      <div style="display: flex; flex-direction: row; gap: 35px;">
        <div style="display: flex; flex-direction: column;">
          <h3 style="font-size: 24px;">Tecnologia em Oferta</h3>
          <p style="padding-top: 8px; font-size: 13px; color: gray;">Até 30% de desconto<br> em produtos selecionados</p>
          <el-button style="background-color: #18181B; color: white;">Comprar Agora</el-button>
        </div>
        <img src="https://picsum.photos/252/252" alt="Imagem aleatória">
      </div>
    </div>
  </section>

  <Section type="categorias"></Section>
  <Section type="destaques"></Section>
  <Section type="novidades"></Section>
</template>


<style></style>

