<template>
  <el-card style="border-radius: 15px;" :body-style="{ padding: '1px' }">
    <div style="display: flex; justify-content: center; align-items: center; position: relative;">
      <div style="position: absolute;top: 10px;left: 10px;background-color: red;color: white;padding: 4px 8px;border-radius: 10px;font-size: 12px;font-weight: bold;
">
        { Desconto }
      </div>

      <img src="https://shadow.elemecdn.com/app/element/hamburger.9cf7b091-55e9-11e9-a976-7f4d0b07eef6.png"
        class="image" style="display: block; margin: 0 auto; width: 100%;">
      <HeartButton style="position: absolute; top: 10px; right: 10px;"></HeartButton>

    </div>
    <div style="padding: 14px;">
      <el-card style="border: none; box-shadow: none;" class="box-card">
        <div slot="header" class="clearfix">
          <h1>
            <span>Smartphone XYZ Pro</span>
          </h1>
        </div>
        <div class="block" style="margin-top: 14px;">
          <h4>
            <span class="demonstration">4.5</span>
          </h4>
          <el-rate v-model="value2" :colors="colors"></el-rate>
        </div>
        <div style="margin-top: 10px;"  >
          <CartButton style="align-items: end;"></CartButton>
          <div class="preco-container" style="align-items: start;">
            <div class="preco-original">
              R$ {{ 200}}
            </div>
            <div class="preco-atual">
              R$ {100}
            </div>
          </div>
        </div>
      </el-card>
      <div class="bottom clearfix" style="margin-top: 10px;">
        <time class="time">{{ currentDate }}</time>
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
  color: #67c23a; /* verde */
}

.preco-original {
  font-size: 14px;
  text-decoration: line-through;
  color: #aaa;
}

</style>