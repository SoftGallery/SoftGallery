<template>
  <el-card
    v-if="tipo === 'destaque' || tipo === 'novidade'"
    class="produto-card"
    :body-style="{ padding: '0px' }"
  >
    <div class="imagem-container">
      <div v-if="tipo === 'destaque'" class="badge badge-destaque">
        -{{ desconto }}%
      </div>
      <div v-if="tipo === 'novidade'" class="badge badge-novidade">
        novo
      </div>

      <img :src="computedImg" @error="onImageError" alt="Produto" class="imagem-produto" />
      <!-- <HeartButton class="botao-heart" :applyStyle="true" /> -->
    </div>

    <div class="info-container">
      <div class="card-titulo">{{ nome }}</div>

      <div class="preco-container">
        <div v-if="tipo === 'destaque'">
          <span class="preco-original">R$ {{ precoOriginal.toFixed(2) }}</span><br />
          <span class="preco-desconto">R$ {{ precoDesconto.toFixed(2) }}</span>
        </div>
        <div v-else>
          <span class="preco-final">R$ {{ precoOriginal.toFixed(2) }}</span>
        </div>

        <CartButton @click="addToCartHandler" />
      </div>
    </div>
  </el-card>
</template>

<script>
import CartButton from './CartButton.vue';
import HeartButton from './HeartButton.vue';
import imagemPadrao from '../assets/noimage.png';
import { cart } from '../store/cart';

export default {
  name: 'CardProduto',
  components: { CartButton, HeartButton },
  props: {
    id: {
      type: [String, Number],
      required: true,
    },
    tipo: {
      type: String,
      required: false,
      validator: value => ['destaque', 'novidade'].includes(value),
    },
    img: {
      type: String,
      required: false,
    },
    nome: {
      type: String,
      required: true,
    },
    precoOriginal: {
      type: Number,
      required: false,
      default: 0,
    },
    precoDesconto: {
      type: Number,
      required: false,
      default: 0,
    },
    desconto: {
      type: Number,
      required: false,
      default: 0,
    },
    avaliacao: {
      type: Number,
      required: true,
    },
  },
  data() {
    return {
      imagemAtual: this.img,
    };
  },
  computed: {
    computedImg() {
      return this.imagemAtual && this.imagemAtual.trim() !== ''
        ? this.imagemAtual
        : imagemPadrao;
    },
  },
  methods: {
    onImageError() {
      this.imagemAtual = imagemPadrao;
    },

    addToCartHandler() {
      const produto = {
        id: this.id,
        nome: this.nome,
        imagemUrl: this.computedImg,
        preco: this.precoDesconto || this.precoOriginal,
        stock: 10,
        quantity: 1,
      };

      // console.log('Adicionando ao carrinho:', produto);
      cart.addToCart(produto);
    },
  },
};

</script>

<style scoped>
.produto-card {
  width: 100%;
  max-width: 220px;
  border-radius: 12px;
  display: flex;
  flex-direction: column;
  justify-content: space-between;
  overflow: hidden;
  transition: transform 0.2s ease-in-out;
}

.imagem-container {
  position: relative;
  height: 200px;
  display: flex;
  justify-content: center;
  align-items: center;
}

.imagem-produto {
  width: 100%;
  height: 100%;
  object-fit: contain;
}

.badge {
  position: absolute;
  top: 8px;
  left: 8px;
  padding: 2px 6px;
  border-radius: 8px;
  font-size: 11px;
  font-weight: bold;
  color: white;
  z-index: 1;
}

.badge-destaque {
  background-color: red;
}

.badge-novidade {
  background-color: #67c23a;
}

.botao-heart {
  position: absolute;
  top: 8px;
  right: 8px;
  z-index: 1;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.5);
}

.info-container {
  padding: 10px;
}

.card-titulo {
  font-size: 15px;
  font-weight: bold;
  text-overflow: ellipsis;
  overflow: hidden;
  white-space: nowrap;
}

.avaliacao {
  margin-top: 6px;
  color: #555;
}

.estrela {
  color: #FFDE59;
}

.preco-container {
  margin-top: 15px;
  display: flex;
  justify-content: space-between;
  align-items: center;
}

.preco-original {
  font-size: 12px;
  color: #999;
  text-decoration: line-through;
}

.preco-desconto {
  font-size: 15px;
  font-weight: bold;
  color: #67c23a;
}

.preco-final {
  font-size: 15px;
  font-weight: bold;
}
</style>
