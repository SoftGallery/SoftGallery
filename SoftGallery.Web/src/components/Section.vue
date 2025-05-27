<template>
    <section v-if="type == 'novidades'" id= "novidades-section"class="novidades-section">
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
            <el-row :gutter="1">
                <el-col v-for="item in produtosNovos" :span="4" style="margin-bottom: 25px;">
                    <CardProduto tipo="novidade" :nome="item.nome" :precoOriginal="item.precoOriginal" :avalicao="item.avaliacao"></CardProduto>
                </el-col>
                <!-- Aqui você irá percorrer cada produto que vier do Backend -->
            </el-row>
        </div>
         <div class="containerNovidades">
              <div class="header-text">
                <h2 class="titulo2">
                    Fique por dentro das novidades
                </h2>
                <p class="descricao2" style="font-size:19px;">Assine nossa newsletter e receba ofertas exclusivas e novidades em primeira mão.</p>
                <div class="forms-newsletter">
                  <el-input placeholder="Seu melhor e-mail" style="width: 240px" v-model="input"></el-input>
                  <el-button size="large"  style="background-color: #18181B; color: white;">Assinar</el-button>
                </div>
                <p style="color:#6b7280; font-size:11px;" >Ao assinar, você concorda com nossa Política de Privacidade.</p>
              </div>
            </div>
        </section>
        <section v-if="type == 'destaques'" id="destaques"class="novidades-section">
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
                <el-row :gutter="1">
                <el-col v-for="item in produtosDestaque" :span="4" style="margin-bottom: 25px;">
                    <CardProduto tipo="destaque" :nome="item.nome" :precoOriginal="item.precoOriginal" :precoDesconto="item.precoDesconto" :desconto="item.desconto" :avalicao="item.avaliacao"></CardProduto>
                </el-col>

                <!-- Aqui você irá percorrer cada produto que vier do Backend -->
            </el-row>
        </div>
        </section>
        <section v-if="type == 'categorias'" id="categorias">
          <div class="container">
            <div class="header">
                <div class="header-text">
                    <h2 class="titulo">
                         Categorias 
                    </h2>
                    <p class="descricao">
                         Explore nossos produtos por categoria 
                    </p>
                </div>
                <el-button class="view-all" type="text" icon="el-icon-arrow-right">Ver todos</el-button>
            </div>
                  <el-row :gutter="1">
                    <el-col v-for="item in Categorias" :span="4 " style="margin-bottom: 25px;">
                      <CardCategoria :nome="item.nome" :quantidade="item.quantidade"></CardCategoria>
                    </el-col>

                <!-- Aqui você irá percorrer cada produto que vier do Backend -->
            </el-row>
        </div>
        </section>
</template>

<script>
import CardProduto from './CardProduto.vue';
import CardCategoria from './CardCategoria.vue';

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
  
],

 Categorias: [
  { nome: 'Eletrônicos', quantidade: 120 },
  { nome: 'Roupas', quantidade: 85 },
  { nome: 'Livros', quantidade: 60 },
  { nome: 'Beleza', quantidade: 40 },
  { nome: 'Esportes', quantidade: 30 },
  { nome: 'Móveis', quantidade: 25 },
  { nome: 'Brinquedos', quantidade: 50 },
  { nome: 'Papelaria', quantidade: 15 }
]

        }
            
    },
    components:{
        CardProduto,
        CardCategoria
    }
    
}
</script>

<style>
section{
  padding: 0px 24px;

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
.descricao2{
  text-align: center;
  color: #6b7280;
  font-size: 1rem;
  margin-top: 0.5rem;
}

.titulo2{
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

.form-newsletter .el-input {
  width: 240px;
}

.btn-assinar {
  background-color: #000;
  color: #fff;
  border: none;
  padding: 0.6rem 1.2rem;
  border-radius: 4px;

}

#BotaoEmail{
  align-items: center;
}

</style>

