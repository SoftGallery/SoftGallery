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
                <el-col :span="5">
                    <CardProduto />
                </el-col>
                <el-col :span="5">
                    <CardProduto />
                </el-col>
                <el-col :span="5">
                    <CardProduto />
                </el-col>
                <el-col :span="5">
                    <CardProduto />
                </el-col>
                <el-col :span="5">
                    <CardProduto />
                </el-col>

                <!-- Aqui você irá percorrer cada produto que vier do Backend -->
            </el-row>
        </div>
        </section>

        <section v-if="type == 'destaque'" class="novidades-section">
        <div class="container">
            <div class="header">
                <div class="header-text">
                    <h2 class="titulo">
                        { Produtos em destaque }
                    </h2>
                    <p class="descricao">
                        { Selecionados especialmente para você }
                    </p>
                </div>
                <el-button class="view-all" type="text" icon="el-icon-arrow-right">Ver todos</el-button>
            </div>
            <el-row :gutter="6">
                <el-col :span="3.5">
                    <CardProduto />
                </el-col>
                <el-col :span="3.5">
                    <CardProduto />
                </el-col>
                <el-col :span="3.5">
                    <CardProduto />
                </el-col>
                <el-col :span="3.5">
                    <CardProduto />
                </el-col>
                <el-col :span="3.5">
                    <CardProduto />
                </el-col>
                <el-col :span="3.5">
                    <CardProduto />
                </el-col>
            </el-row>
        </div>
        </section>
</template>

<script>
import CardCategorias from './CardCategorias.vue';
import CardProduto from './CardProduto.vue';

export default {
    data(){
        return{
            type: 'novidades',
            produtos: []
        }
    },  
  components: {
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