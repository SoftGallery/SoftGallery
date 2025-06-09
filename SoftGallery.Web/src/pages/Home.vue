<script lang="ts" setup>
import Section from '../components/Section.vue';
import Footer from '../components/Footer.vue';
import axios from 'axios';
import { ResumoProdutoDTO } from '../dtos/produtoDTO';
import { onMounted, ref } from 'vue';
import Video from '../assets/video.mp4'

const listaProdutos = ref<ResumoProdutoDTO[]>([]);
const campanha = ref([]);
onMounted(async () => {
  try {
    const response = await axios.get<ResumoProdutoDTO[]>('https://localhost:7273/api/Produto');
    const res = await axios.get('https://localhost:7273/api/Campanha');
    campanha.value = res.data
    console.log(campanha.value)
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
        <h1 class="hero-title">Tecnologia de Ponta com Descontos Imperdíveis</h1>
        <p class="hero-subtitle">
          Aproveite o Super Verão Tech! Gadgets, celulares, notebooks e acessórios com até <strong>40% OFF</strong>.
          Ofertas exclusivas para transformar seu dia a dia com inovação.
        </p>
        <!-- <div class="hero-buttons">
          <el-button class="primary-btn">Comprar Agora</el-button>
          <el-button class="secondary-btn">Ver Coleção Completa</el-button>
        </div> -->
      </div>
    </div>
  </div>

  <!-- <img src="https://picsum.photos/400/400" alt="Imagem aleatória" class="hero-image" /> -->

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


  <Section :campanhas="campanha" type="categorias" />
  <Section :produtosDestaque="listaProdutos" type="destaques" />
  <section class="mt-12 relative bg-black text-white container-principal">
    <video autoplay muted loop style="width: 100vw;" class="w-full h-[500px] object-cover brightness-75">
      <source :src="Video" type="video/mp4" />
    </video>
  </section>
  <!-- <Section :produtosDestaque="listaProdutos" type="novidades" /> -->
  <Footer />
</template>

<style scoped>
.hero-section {
  padding: 64px 32px;
  background: linear-gradient(-70deg, #235997, #0f2350, #3b38e6, #3e035a9d);
  background-size: 400% 400%;
  animation: gradient 15s ease infinite;
  display: flex;
  align-items: center;
  justify-content: center;
  color: #f1f1f1;
}

/* .hero-section {
  padding: 64px;
  background: linear-gradient(-70deg, #235997, #0f2350, #3b38e6, #3e035a9d);
  background-size: 400% 400%;
  animation: gradient 15s ease infinite;
} */

.hero-text {
  max-width: 1000px;
  display: flex;
  flex-direction: column;
  justify-content: center;
  /* text-shadow: 0 2px 4px rgba(0, 0, 0, 0.6); */
  text-align: center;
}

.hero-title {
  font-size: 3rem;
  font-weight: 700;
  color: #ffffff;
  line-height: 1.2;
  margin-bottom: 1rem;
  text-transform: uppercase;
  font-weight: 500;
  width: fit-content;
}

.hero-subtitle {
  font-size: 1.125rem;
  line-height: 1.6;
  color: #cbd5e1;
  margin-bottom: 2rem;
  max-width: 900px;
}

.hero-buttons {
  display: flex;
  gap: 1rem;
  flex-wrap: wrap;
}

/* Botões estilizados */
.primary-btn {
  background: linear-gradient(to right, #3b82f6, #9333ea);
  color: white;
  padding: 12px 28px;
  font-weight: 600;
  border-radius: 8px;
  transition: all 0.3s ease;
  box-shadow: 0 4px 12px rgba(59, 130, 246, 0.3);
}

.primary-btn:hover {
  background: linear-gradient(to right, #2563eb, #7c3aed);
  transform: translateY(-2px);
}

.secondary-btn {
  background-color: transparent;
  color: #cbd5e1;
  border: 1px solid #cbd5e1;
  padding: 12px 28px;
  font-weight: 500;
  border-radius: 8px;
  transition: all 0.3s ease;
}

.secondary-btn:hover {
  background-color: rgba(255, 255, 255, 0.1);
  border-color: #fff;
  color: #fff;
  transform: translateY(-2px);
}

/* Responsivo */
@media (max-width: 768px) {
  .hero-title {
    font-size: 2rem;
  }

  .hero-subtitle {
    font-size: 1rem;
  }

  .hero-buttons {
    flex-direction: column;
    align-items: center;
  }
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
