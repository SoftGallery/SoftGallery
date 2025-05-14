<template>
<el-card
  style="width: 230px; height: 350px; border-radius: 12px; display: flex; flex-direction: column; justify-content: space-between; overflow: hidden;"
  :body-style="{ padding: '0px' }"
>
  <div style="display: flex; justify-content: center; align-items: center; position: relative; height: 150px;">
    <div style="position: absolute; top: 8px; left: 8px; background-color: red; color: white; padding: 2px 6px; border-radius: 8px; font-size: 11px; font-weight: bold;">
      { Desconto }
    </div>
    <img src="https://shadow.elemecdn.com/app/element/hamburger.9cf7b091-55e9-11e9-a976-7f4d0b07eef6.png"
         style="width: 100%; height: 100%; object-fit: cover;">
    <HeartButton style="position: absolute; top: 8px; right: 8px;"></HeartButton>
  </div>

  <div style="padding: 10px;">
    <div style="font-size: 20px; font-weight: bold;">Smartphone XYZ Pro</div>
    <div style="margin-top: 6px;">
      <el-rate v-model="value2" :colors="colors" style="font-size: 12px;"></el-rate>
    </div>
    <div style="margin-top: 45px;">
      <span style="font-size: 19px; color: #999; text-decoration: line-through;">R$ 200</span><br>
      <span style="font-size: 24px; font-weight: bold; color: #67c23a;">R$ 100</span>
    </div>
    <CartButton style="margin-left: 75%;"></CartButton>
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
    nome_produto: {
      type: String,
      required: true
    },
    porcentagem_desconto: {
      type: Number,
      required: false
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

</style>