<template>
    <router-link :to="`/campanha/${id}`">
  <el-card
    class="card-campanha"
    :body-style="{ padding: '0px' }"
  >
    <div class="imagem-container">
      <img
        :src="computedImg"
        @error="onImageError"
        alt="Imagem da campanha"
        class="imagem-campanha"
      />
    </div>

    <div class="info-container">
      <h2 class="card-titulo">{{ nome }}</h2>
      <!-- <p class="card-quantidade" v-if="quantidade !== undefined">{{ quantidade }} itens</p> -->
    </div>
  </el-card>
  </router-link>
</template>

<script>
import imagemPadrao from '../assets/noimage.png';

export default {
  name: 'CardCampanha',
  props: {
    id: {
      type: String,
      required: true,
    },
    nome: {
      type: String,
      required: true,
    },
    imagemUrl: {
      type: String,
      required: false,
    },
    quantidade: {
      type: Number,
      required: false,
    },
  },
  data() {
    return {
      imagemAtual: this.imagemUrl,
    };
  },
  computed: {
    computedImg() {
      return this.imagemAtual?.trim() ? this.imagemAtual : imagemPadrao;
    },
  },
  methods: {
    onImageError() {
      this.imagemAtual = imagemPadrao;
    },
  },
};
</script>

<style scoped>
.card-campanha {
  width: 180px;
  border-radius: 12px;
  display: flex;
  flex-direction: column;
  justify-content: space-between;
  overflow: hidden;
  transition: transform 0.2s ease-in-out;
}

.imagem-container {
  display: flex;
  justify-content: center;
  align-items: center;
  position: relative;
  height: 180px;
}

.imagem-campanha {
  display: block;
  margin: 0 auto;
  width: 100%;
  height: 100%;
  object-fit: cover;
}

.info-container {
  padding: 5px;
  text-align: center;
}

.card-titulo {
  font-size: 15px;
  font-weight: 600;
  margin-bottom: 4px;
}

.card-quantidade {
  font-size: 12px;
  color: #999;
}
</style>

<style>
.el-card.is-always-shadow {
  box-shadow: none !important;
}
.el-card.is-always-shadow:hover {
  box-shadow: 0 0 15px rgba(0, 0, 0, 0.12) !important;
  transform: scale(1.06);
}
</style>
