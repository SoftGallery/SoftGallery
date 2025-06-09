<template>
  <div :class="{'heart-wrapper': applyStyle}" class="normal">
    <el-button round style="border: none;">
      <i class="fa-regular fa-heart"></i>
    </el-button>
  </div>
</template>

<script>
export default {
  props: {
    applyStyle: {
      type: Boolean,
      default: false
    }
  }
}
</script>

<style>
.heart-wrapper {
  width: 32px;
  height: 32px;
  background: white;
  border-radius: 50%;
  display: flex;
  justify-content: center;
  align-items: center;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.05);
}

.normal{
    display: flex;
    justify-content: center;
    align-items: center;
}
</style>
