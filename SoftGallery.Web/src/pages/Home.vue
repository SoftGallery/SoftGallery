<script lang="ts" setup>
import Section from '../components/Section.vue';
import Footer from '../components/Footer.vue';
import axios from 'axios';
import { ResumoProdutoDTO } from '../dtos/produtoDTO';
import { onMounted, ref } from 'vue';
import Video from '../assets/video.mp4'

const listaProdutos = ref<ResumoProdutoDTO[]>([]);

onMounted(async () => {
  try {
    const response = await axios.get<ResumoProdutoDTO[]>('https://localhost:7273/api/Produto');
    listaProdutos.value = response.data.map((produto, index) => ({
      ...produto,
      tipo: index % 2 === 0 ? 'destaque' : 'novidade',
      avalicao: 4 + (Math.random() * 1)
    }));
  } catch (error) {
    console.error('Erro ao carregar produtos:', error);
  }
});
</script>

<template>
  <div id="principal-container" class="hero-section h-[500px]">
    <div class="hero-content">
      <div class="hero-text">
        <h1 class="hero-title">Ofertas Especiais de Verão</h1>
        <p class="hero-subtitle">
          Descubra nossa nova coleção com até 40% de desconto.
          Produtos exclusivos para você aproveitar o verão com estilo.
        </p>
        <div class="hero-buttons">
          <el-button class="primary-btn">Ver ofertas</el-button>
          <el-button class="secondary-btn">Explorar coleção</el-button>
        </div>
      </div>
      <!-- <img src="https://picsum.photos/400/400" alt="Imagem aleatória" class="hero-image" /> -->
    </div>
  </div>

  <div class="container">
    <section>
      <div class="offer-cards">
        <div class="offer-card">
          <div class="offer-info">
            <h3 class="offer-title">Coleção Outono</h3>
            <p class="offer-description">Prepare-se para a nova estação com nossa coleção exclusiva</p>
            <el-button class="offer-btn">Comprar Agora</el-button>
          </div>
          <img src="https://picsum.photos/252/252" alt="Imagem aleatória" class="offer-image" />
        </div>
        <div class="offer-card">
          <div class="offer-info">
            <h3 class="offer-title">Tecnologia em Oferta</h3>
            <p class="offer-description">Até 30% de desconto em produtos selecionados</p>
            <el-button class="offer-btn">Ver Ofertas</el-button>
          </div>
          <img src="https://picsum.photos/252/252" alt="Imagem aleatória" class="offer-image" />
        </div>
      </div>
    </section>
  </div>

  <section class="mt-12 relative bg-black text-white container-principal">
    <video autoplay muted loop style="width: 100vw;" class="w-full h-[500px] object-cover brightness-75">
      <source :src="Video" type="video/mp4" />
    </video>
  </section>

  <Section :produtosDestaque="listaProdutos" type="categorias" />
  <Section :produtosDestaque="listaProdutos" type="destaques" />
  <Section :produtosDestaque="listaProdutos" type="novidades" />
  <Footer />
</template>

<style scoped>
.hero-section {
  padding: 64px;
  background: linear-gradient(-70deg, #235997, #0f2350, #3b38e6, #3e035a9d);
  background-size: 400% 400%;
  animation: gradient 15s ease infinite;
}

.hero-content {
  display: flex;
  justify-content: space-between;
  align-items: center;
  gap: 3rem;
}

.hero-text {
  display: flex;
  flex-direction: column;
  justify-content: center;
}

.hero-title {
  font-size: 48px;
  font-weight: bold;
  color: silver;
  margin-bottom: 8px;
}

.hero-subtitle {
  font-size: 16px;
  color: gray;
  margin-bottom: 16px;
}

.hero-buttons {
  display: flex;
  gap: 16px;
}

.primary-btn {
  background-color: #18181B;
  color: white;
  padding: 10px 30px;
}

.secondary-btn {
  padding: 10px 30px;
}

.hero-image {
  border-radius: 10px;
  max-width: 100%;
}

.offer-cards {
  display: flex;
  gap: 2rem;
  margin-top: 64px;
}

.offer-card {
  display: flex;
  align-items: center;
  gap: 35px;
  padding: 24px;
  border-radius: 13px;
  background-color: #E1F0FA;
}

.offer-info {
  display: flex;
  flex-direction: column;
  gap: 8px;
}

.offer-title {
  font-size: 24px;
  margin-bottom: 8px;
}

.offer-description {
  font-size: 13px;
  color: gray;
}

.offer-btn {
  background-color: #18181B;
  color: white;
  padding: 10px 30px;
}

.offer-image {
  border-radius: 10px;
  max-width: 100%;
}

.video-section {
  position: relative;
}

.video-background {
  width: 100%;
  height: 500px;
  object-cover: cover;
  brightness: 75%;
  filter: brightness(0.5);
}

@keyframes gradient {
  0% {
    background-position: 0% 50%;
  }

  50% {
    background-position: 100% 50%;
  }

  100% {
    background-position: 0% 50%;
  }
}

/* Responsividade */
@media (max-width: 768px) {
  .hero-content {
    flex-direction: column;
    align-items: center;
  }

  .hero-text {
    text-align: center;
    margin-bottom: 20px;
  }

  .offer-cards {
    flex-direction: column;
    gap: 2rem;
  }

  .offer-card {
    flex-direction: column;
    text-align: center;
  }
}
</style>
