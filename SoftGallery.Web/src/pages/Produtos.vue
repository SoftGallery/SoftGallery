<template>
    <div class="section">
        <div class="produtos">
            <h2>Produtos</h2>
            <button>+ Novo Produto</button>
        </div>
        <div class="ordenacao">
            <div>
                <button>Order por nome</button>
                <button>Ordenar por preco</button>
            </div>
            <span>Número de Produtos</span>
        </div>
        <div v-for="produto in produtos" class="produto-container">
            <h3>{{produto.nome}}</h3>
            <p>{{ produto.descricao }}</p>
            <span>{{produto.preco}}</span>
        </div>
    </div>
</template>


<style scoped>

.produtos{
    display: flex;
    justify-content: space-between;
    margin-bottom: 6px;
    padding-left: 24px;
    padding-right: 24px;
    padding-top: 32px;
    padding-bottom: 32px;
    margin-left: 175px;
    margin-right: 175px;
}
.section{
    margin-left: 175px;
    margin-right: 175px;
}

.ordenacao{
    border: 1px solid rgb(210, 210, 210);
    padding: 16px 24px;
    display: flex;
    justify-content: space-between;
}
.produto-container{
    padding: 24px;
    cursor: pointer;
    background-color: rgb(249, 249, 249);
    margin: 0.5px;
}

</style>

<script >

export default {
    data() {
        return {
            produtos: [
                {
                    nome: "Camiseta Básica",
                    descricao: "Camiseta 100% algodão, leve e confortável.",
                    preco: 49.90,
                    imagem: "https://via.placeholder.com/150"
                },
                {
                    nome: "Tênis Esportivo",
                    descricao: "Perfeito para corrida e caminhada, leve e resistente.",
                    preco: 199.90,
                    imagem: "https://via.placeholder.com/150"
                },
                {
                    nome: "Fone Bluetooth",
                    descricao: "Fone sem fio com som de alta qualidade e bateria de longa duração.",
                    preco: 159.90,
                    imagem: "https://via.placeholder.com/150"
                },
                {
                    nome: "Mochila Compacta",
                    descricao: "Ideal para viagens e uso diário, com compartimento para notebook.",
                    preco: 89.90,
                    imagem: "https://via.placeholder.com/150"
                },
                {
                    nome: "Livro: A Arte da Guerra",
                    descricao: "Um clássico sobre estratégia e sabedoria, escrito por Sun Tzu.",
                    preco: 39.90,
                    imagem: "https://via.placeholder.com/150"
                }
            ],
        }
    }
}


</script>