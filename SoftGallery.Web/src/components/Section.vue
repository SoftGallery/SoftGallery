<template>
  <section v-if="type == 'novidades'" id="novidades-section" class="novidades-section">
    <div class="container">
      <div class="header">
        <div class="header-text">
          <h2 class="titulo">Novidades</h2>
          <p class="descricao">Os produtos mais recentes da loja</p>
        </div>
        <button class="view-all">Ver todos</button>
      </div>
      <div class="produtos-grid">
        <div class="produto" v-for="item in produtosNovos" :key="item.id">
          <CardProduto
            tipo="novidade"
            :id="item.id"
            :nome="item.nome"
            :precoOriginal="item.preco"
            :img="item.imagemUrl"
          />
        </div>
      </div>
    </div>
  </section>

  <section v-if="type == 'destaques'" id="destaques" class="novidades-section">
    <div class="container">
      <div class="header">
        <div class="header-text">
          <h2 class="titulo">Produtos em destaque</h2>
          <p class="descricao">Selecionados especialmente para você</p>
        </div>
        <button class="view-all">Ver todos</button>
      </div>
      <div class="produtos-grid">
        <div class="produto" v-for="item in produtosDestaque" :key="item.id">
          <CardProduto
            tipo="novidade"
            :id="item.id"
            :nome="item.nome"
            :img="item.imagemUrl"
            :precoOriginal="item.preco"
          />
        </div>
      </div>
    </div>
  </section>

  <section v-if="type == 'categorias'" id="categorias">
    <div class="container">
      <div class="header">
        <div class="header-text">
          <h2 class="titulo">Categorias</h2>
          <p class="descricao">Explore nossos produtos por categoria</p>
        </div>
        <button class="view-all">Ver todos</button>
      </div>
      <div class="produtos-grid">
        <div class="produto" v-for="item in produtosDestaque" :key="item.nome">
          <CardCategoria :nome="item.nome" />
        </div>
      </div>
    </div>
  </section>
</template>

<script lang="ts">
import CardProduto from './CardProduto.vue';
import CardCategoria from './CardCategoria.vue';
import { PropType } from 'vue';
import { ResumoProdutoDTO } from '../dtos/produtoDTO';

export default {
  props: {
    type: {
      type: String,
      required: true,
    },
    produtosDestaque: {
      type: Array as PropType<ResumoProdutoDTO[]>,
      required: true,
      default: () => [],
    },
    produtosNovos: {
      type: Array as PropType<ResumoProdutoDTO[]>,
      required: false,
      default: () => [],
    },
  },
  data() {
    return {
      input: '',
    };
  },
  components: {
    CardProduto,
    CardCategoria,
  },
};
</script>

<style scoped>
/* Estilo geral */
section {
  padding: 0px 24px;
}

.container {
  width: 100%;
  max-width: 1200px;
  margin: 0 auto;
  padding: 0 1rem;
}

.header {
  display: flex;
  justify-content: space-between;
  align-items: center;
  margin-bottom: 2rem;
}

.header-text {
  display: flex;
  flex-direction: column;
}

.titulo {
  font-size: 2rem;
  font-weight: bold;
}

.descricao {
  color: #6b7280;
  font-size: 1rem;
  margin-top: 0.5rem;
}

.descricao2 {
  text-align: center;
  color: #6b7280;
  font-size: 1rem;
  margin-top: 0.5rem;
}

.titulo2 {
  text-align: center;
  font-size: 2rem;
  font-weight: bold;
}

.containerNovidades {
  background-color: #f3f3f4;
  width: 100%;
  max-width: 1200px;
  margin: 3rem auto 0;
  padding: 2rem 1rem;
  text-align: center;
  border-radius: 8px;
}

.forms-newsletter {
  display: flex;
  justify-content: center;
  align-items: center;
  gap: 0.5rem;
  margin-top: 1.5rem;
  flex-wrap: wrap;
}

.forms-newsletter input {
  width: 240px;
}

.btn-assinar {
  background-color: #000;
  color: #fff;
  border: none;
  padding: 0.6rem 1.2rem;
  border-radius: 4px;
}

/* Grid Flexbox */
.produtos-grid {
  display: flex;
  flex-wrap: wrap;
  gap: 16px;
  justify-content: flex-start; /* Alinhamento à esquerda */
  align-items: flex-start;
}

.produto {
  flex: 1 1 23%; /* Tamanho ideal para 4 colunas */
  max-width: 23%; /* Para garantir que o card ocupe 1/4 da linha */
  margin-bottom: 16px;
}

/* Responsividade para dispositivos móveis e tablets */
@media (max-width: 767px) {
  .produto {
    flex: 1 1 100%; /* Cada produto ocupará 100% da largura da tela */
    max-width: 100%;
  }
}

@media (min-width: 600px) and (max-width: 899px) {
  .produto {
    flex: 1 1 48%; /* 50% para dispositivos de tamanho médio */
    max-width: 48%;
  }
}

@media (min-width: 900px) and (max-width: 1199px) {
  .produto {
    flex: 1 1 31%; /* 3 colunas para telas médias */
    max-width: 31%;
  }
}

@media (min-width: 1200px) {
  .produto {
    flex: 1 1 23%; /* 4 colunas para telas grandes */
    max-width: 23%;
  }
}

/* Estilos para telas pequenas */
@media (max-width: 767px) {
  .header {
    flex-direction: column;
    align-items: flex-start;
  }

  .view-all {
    margin-top: 1rem;
  }

  .forms-newsletter {
    flex-direction: column;
  }

  .forms-newsletter input,
  .forms-newsletter button {
    width: 100%;
  }
}
</style>
