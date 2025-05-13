<template>
  <div>
    <h1>Bem-vindo ao site!</h1>

    <!-- Muda o conteúdo conforme o valor da prop 'tipo' -->
    <p v-if="tipo === 'info'">Esta é uma mensagem de informação.</p>
    <p v-else-if="tipo === 'erro'">Ocorreu um erro no sistema.</p>
    <p v-else>Mensagem padrão exibida.</p>
    <p>{{ nome_produto }}</p>
    <h1>Novidades</h1>
  </div>
  <el-row justify="center">
    <el-col :span="4">
      <el-card style="border-radius: 15px;" :body-style="{ padding: '1px' }">
        <div style="display: flex; justify-content: center; align-items: center; position: relative;">
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
            <div style="margin-top: 16px; text-align: right;">
              <CartButton></CartButton>
            </div>
          </el-card>
          <div class="bottom clearfix" style="margin-top: 10px;">
            <time class="time">{{ currentDate }}</time>
          </div>
        </div>
      </el-card>
    </el-col>
  </el-row>
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
    }
  },
  components: {
    CartButton,
    HeartButton


  }
}

</script>