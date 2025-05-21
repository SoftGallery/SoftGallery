<template>
<el-card v-if="tipo == 'destaque' "
  style="width: 180px; height: auto; border-radius: 12px; display: flex; flex-direction: column; justify-content: space-between; overflow: hidden;"
  :body-style="{ padding: '0px' }"
>
  <div style="display: flex; justify-content: center; align-items: center; position: relative; height: 150px;">
    <div style="position: absolute; top: 8px; left: 8px; background-color: red; color: white; padding: 2px 6px; border-radius: 8px; font-size: 11px; font-weight: bold;">
      -{{ desconto }}%
    </div>
    <img src="https://shadow.elemecdn.com/app/element/hamburger.9cf7b091-55e9-11e9-a976-7f4d0b07eef6.png"
         style="width: 100%; height: 100%; object-fit: cover;">
    <HeartButton style="position: absolute; top: 8px; right: 8px;"></HeartButton>
  </div>

  <div style="padding: 10px;">
    <div class="card-titulo" style="font-size: 15px; font-weight: bold; ">{{ nome }}</div>
    <div style="margin-top: 6px;">
      <i class="fa-solid fa-star" style="color: #FFDE59;"></i>
      {{ avalicao }}
    </div>
    <div style="margin-top: 15px; display: flex; justify-content: space-between; align-items: center;">
      <div>
        <span style="font-size: 12px; color: #999; text-decoration: line-through;">R$ {{ precoOriginal }}</span><br>
      <span style="font-size: 15px; font-weight: bold; color: #67c23a;">R$ {{ precoDesconto }}</span>
      </div>
      <div style="top: 0%;">
        <CartButton></CartButton> 
      </div>  
    </div>
    
  </div>
</el-card>

<el-card v-if="tipo == 'novidade'" style="width: 180px; height: auto; border-radius: 12px; display: flex; flex-direction: column; justify-content: space-between; overflow: hidden;"
  :body-style="{ padding: '0px' }"
>
<div style="display: flex; justify-content: center; align-items: center; position: relative; height: 150px;">
    <div style="position: absolute; top: 8px; left: 8px; background-color: #67c23a; color: white; padding: 2px 6px; border-radius: 8px; font-size: 11px; font-weight: bold;">
      novo
    </div>
    <img src="https://shadow.elemecdn.com/app/element/hamburger.9cf7b091-55e9-11e9-a976-7f4d0b07eef6.png"
         style="width: 100%; height: 100%; object-fit: cover;">
    <HeartButton style="position: absolute; top: 8px; right: 8px;"></HeartButton>
  </div>

  <div style="padding: 10px;">
    <div class="card-titulo" style="font-size: 15px; font-weight: bold;">{{ nome }}</div>
    <div style="margin-top: 6px;">
      <i class="fa-solid fa-star" style="color: #FFDE59;"></i>
      {{ avalicao }}
    </div>
    <div style="margin-top: 15px; display: flex; justify-content: space-between; align-items: center;">
      <div>
         <span style="font-size: 15px; font-weight: bold;">R$ {{ precoOriginal }}</span><br>
      </div>
      <div>
         <CartButton style=""></CartButton>
      </div>
    </div>
    
  </div>

</el-card>

</template>
<script>
import CartButton from './CartButton.vue';
import HeartButton from './HeartButton.vue'

export default {
  name: 'MensagemDinamica',
  props: {
    tipo: {
      type: String,
      required: false
    },
    nome: {
      type: String,
      required: true
    },
    precoOriginal: {
      type: Number,
      required: false
    },
    precoDesconto: {
      type: Number,
      required: true
    },
    desconto: {
      type: Number,
      required: true
    },
    avalicao: {
      type: Number,
      required: true
    }
  },
  components: {
    CartButton,
    HeartButton


  }
}

</script>

<style>
.preco-container {
  display: flex;
  flex-direction: column;
  align-items: flex-start;
  margin-top: 10px;
}

.preco-atual {
  font-size: 18px;
  font-weight: bold;
  color: #67c23a; 
}

.preco-original {
  font-size: 14px;
  text-decoration: line-through;
  color: #aaa;
}
.card-titulo{
  text-overflow: ellipsis; overflow: hidden; white-space: nowrap;
}


</style>