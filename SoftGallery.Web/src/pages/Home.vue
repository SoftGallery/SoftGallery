<script lang="ts" setup>
import CardProduto from '../components/CardProduto.vue';


</script>

<template>
<p>oi estou na HOME</p>
<el-row :gutter="6">
  <el-col :span="4">
    <CardProduto />
  </el-col>
  <el-col :span="4">
    <CardProduto />
  </el-col>
  <el-col :span="4">
    <CardProduto />
  </el-col>
  <el-col :span="4">
    <CardProduto />
  </el-col>
</el-row>

</template>


<style scoped>


</style>