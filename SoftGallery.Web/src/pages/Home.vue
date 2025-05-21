<script lang="ts" setup>
import CardProduto from '../components/CardProduto.vue';
import Section from '../components/Section.vue';
import Footer from '../components/Footer.vue';


</script>

<template>
  <div class="container-principal" style="padding: 64px 64px;">
    <div style="display: flex; flex-direction: row; gap: 3rem; justify-content: space-between;">
      <div style="display: flex; flex-direction: column; justify-content: center;">
        <div>
          <h1 style="font-weight: bold; font-size: 48px; color: silver;">Ofertas Especiais de Verão</h1>
          <p style="padding-top: 8px; color: gray; font-size: 16px;">Descubra nossa nova coleção com até 40% de desconto.<br> Produtos exclusivos para você aproveitar o verão com estilo.</p>
        </div>
        <div style="margin-top: 16px;">
          <el-button style="background-color: #18181B; color: white; padding: 0px 30px;">Ver ofertas</el-button>
          <el-button style="padding: 0px 30px;">Explorar coleção</el-button>
        </div>
        
      </div>
      <img src="https://picsum.photos/400/400" alt="Imagem aleatória" style="border-radius: 10px;">
    </div>
  </div>
  <div class="container" style="padding: 64px 0px;">
    <section>
    <div style="display: flex; flex-direction: row; gap: 2rem;">
      <div style="display: flex; flex-direction: row; gap: 35px; padding: 24px; border-radius: 13px; background-color:	#E1F0FA; align-items: center;">
        <div style="display: flex; flex-direction: column; gap: 8px;">
          <h3 style="font-size: 24px;">Coleção Outono</h3>
          <p style="padding-top: 8px; font-size: 13px; color: gray;">Prepare-se para a nova estação<br> com nossa coleção exclusiva</p>
          <el-button style="background-color: #18181B; color: white;">Comprar Agora</el-button>
        </div>
        <img src="https://picsum.photos/252/252" alt="Imagem aleatória" style="border-radius: 10px">
      </div>
       <div style="display: flex; flex-direction: row; gap: 35px; padding: 24px; border-radius: 13px; background-color: #EAF3FB; align-items: center;">
        <div style="display: flex; flex-direction: column; gap: 8px;">
          <h3 style="font-size: 24px;">Tecnologia em Oferta</h3>
          <p style="padding-top: 8px; font-size: 13px; color: gray;">Até 30% de desconto em produtos<br>   selecionados</p>
          <el-button style="background-color: #18181B; color: white;">Ver Ofertas</el-button>
        </div>
        <img src="https://picsum.photos/252/252" alt="Imagem aleatória" style="border-radius: 10px">
      </div>
    </div>
  </section>
  </div>

  

  <Section type="categorias"></Section>
  <Section type="destaques"></Section>
  <Section type="novidades"></Section>
  <Footer></Footer>

</template>


<style>
.container-principal{
  background: linear-gradient(135deg, #235997, #081124);
  background-size: 400% 400%;
  animation: gradientMove 15s ease infinite;

}

@keyframes gradientMove {
  0% { background-position: 0% 50%; }
  50% { background-position: 100% 50%; }
  100% { background-position: 0% 50%; }
}

</style>

