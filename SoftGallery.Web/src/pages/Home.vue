<script lang="ts" setup>
import CardProduto from '../components/CardProduto.vue';


</script>

<template>
  <p>oi estou na HOME</p>
<section>
<h1 class="novidades">Novidades</h1>
<p style="color: gray">Os produtos mais recentes de nossa loja</p>
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
</section>
</template>


<style scoped>
.novidades{
  font-size: 100px;
  font-size:bold;

}




</style>