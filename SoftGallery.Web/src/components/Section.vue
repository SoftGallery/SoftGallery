<template>
    <section v-if="type == 'novidades'" class="novidades-section">
        <div class="container">
            <div class="header">
                <div class="header-text">
                    <h2 class="titulo">
                        Novidades
                    </h2>
                    <p class="descricao">
                        Os produtos mais recentes da loja
                    </p>
                </div>
                <el-button class="view-all" type="text" icon="el-icon-arrow-right">Ver todos</el-button>
            </div>
            <el-row :gutter="0">
                <el-col v-for="item in produtosNovos" :span="5">
                    <CardProduto tipo="novidade" :nome="item.nome" :precoOriginal="item.precoOriginal" :avalicao="item.avaliacao"></CardProduto>
                </el-col>

                <!-- Aqui você irá percorrer cada produto que vier do Backend -->
            </el-row>
        </div>
        </section>

        <section v-if="type == 'destaques'" class="novidades-section">
        <div class="container">
            <div class="header">
                <div class="header-text">
                    <h2 class="titulo">
                         Produtos em destaque 
                    </h2>
                    <p class="descricao">
                         Selecionados especialmente para você 
                    </p>
                </div>
                <el-button class="view-all" type="text" icon="el-icon-arrow-right">Ver todos</el-button>
            </div>
                <el-row :gutter="0">
                <el-col v-for="item in produtosDestaque" :span="5">
                    <CardProduto tipo="destaque" :nome="item.nome" :precoOriginal="item.precoOriginal" :precoDesconto="item.precoDesconto" :desconto="item.desconto" :avalicao="item.avaliacao"></CardProduto>
                </el-col>

                <!-- Aqui você irá percorrer cada produto que vier do Backend -->
            </el-row>
        </div>
        </section>
</template>

<script>
import CardCategorias from './CardCategorias.vue';
import CardProduto from './CardProduto.vue';

export default {
    props: {
        type: {
            type: String,
            required: true
        }
    },
    data(){
        return{
            produtosDestaque: [
  {
    nome: "Fone de Ouvido Bluetooth",
    precoOriginal: 199.90,
    precoDesconto: 149.90,
    desconto: "25",
    avaliacao: 4.5
  },
  {
    nome: "Smartwatch Esportivo",
    precoOriginal: 349.90,
    precoDesconto: 279.90,
    desconto: "20",
    avaliacao: 4.2
  },
  {
    nome: "Notebook Ultra Slim",
    precoOriginal: 3999.00,
    precoDesconto: 2999.00,
    desconto: "25",
    avaliacao: 4.8
  },
  {
    nome: "Cadeira Gamer Pro",
    precoOriginal: 1299.90,
    precoDesconto: 999.90,
    desconto: "23",
    avaliacao: 4.6
  },
  {
    nome: "Teclado Mecânico RGB",
    precoOriginal: 499.90,
    precoDesconto: 349.90,
    desconto: "30",
    avaliacao: 4.4
  }
]
,
    produtosNovos: [
  {
    nome: "Hub USB-C 5 em 1",
    precoOriginal: 149.90,
    avaliacao: 4.3
  },
  {
    nome: "Monitor Full HD 24''",
    precoOriginal: 899.00,
    avaliacao: 4.7
  },
  {
    nome: "Mouse sem fio silencioso",
    precoOriginal: 79.90,
    avaliacao: 4.1
  },
  {
    nome: "Carregador Turbo 30W",
    precoOriginal: 99.90,
    avaliacao: 4.4
  },
  {
    nome: "Câmera de Segurança Wi-Fi",
    precoOriginal: 249.90,
    avaliacao: 4.6
  }
]    
        }
            
    },
    components:{
        CardProduto,
        CardCategorias
    }
}
</script>

<style>
.novidades-section{
  padding: 2rem 0;

}
@media (min-width: 768px){
  .novidades-section{
    padding: 3rem 0;
  }
}
@media (min-width: 1024px){
  .novidades-section{
    padding: 4rem 0;
  }
}
.container {
  width: 100%;
  max-width: 1200px;
  margin: 0 auto;
  padding: 0 1rem;
}
.header{
  display: flex;
  justify-content: space-between;
  align-items: center;
  margin-bottom: 2rem;
}
.header-text{
  display: flex;
  flex-direction: column;
}
.titulo{
  font-size: 2rem;
  font-weight: bold;
}
.descricao{
  color: #6b7280;
  font-size: 1rem;
  margin-top: 0.5rem;
}
</style>