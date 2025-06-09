<template>
  <transition name="fade">
    <div v-if="visible" :class="alertClass">
      {{ message }}
    </div>
  </transition>
</template>

<script setup>
import { ref, computed, defineExpose } from 'vue'

const visible = ref(false)
const message = ref('')
const alertType = ref('success')

const alertClass = computed(() => {
  if (alertType.value === 'error') return 'alert-error'
  if (alertType.value === 'warning') return 'alert-warning'
  return 'alert-success'
})

function showAlert(msg, type = 'success') {
  message.value = msg
  alertType.value = type
  visible.value = true
  setTimeout(() => {
    visible.value = false
  }, 3000)
}

defineExpose({ showAlert })
</script>

<style scoped>
.alert-success {
  position: fixed;
  bottom: 20px;
  right: 20px;
  background-color: #4caf50;
  color: white;
  padding: 15px 25px;
  border-radius: 8px;
  box-shadow: 0 4px 12px rgba(76, 175, 80, 0.3);
  font-weight: 600;
  font-size: 16px;
  min-width: 220px;
  text-align: center;
  user-select: none;
  z-index: 10000;
}

.alert-error {
  position: fixed;
  bottom: 20px;
  right: 20px;
  background-color: #f44336;
  color: white;
  padding: 15px 25px;
  border-radius: 8px;
  box-shadow: 0 4px 12px rgba(244, 67, 54, 0.3);
  font-weight: 600;
  font-size: 16px;
  min-width: 220px;
  text-align: center;
  user-select: none;
  z-index: 10000;
}

.alert-warning {
  position: fixed;
  bottom: 20px;
  right: 20px;
  background-color: #FBC02D; 
  color: white;
  padding: 15px 25px;
  border-radius: 8px;
  box-shadow: 0 4px 12px rgba(255, 235, 59, 0.3);
  font-weight: 600;
  font-size: 16px;
  min-width: 220px;
  text-align: center;
  user-select: none;
  z-index: 10000;
}

.fade-enter-active,
.fade-leave-active {
  transition: opacity 0.4s ease;
}
.fade-enter-from,
.fade-leave-to {
  opacity: 0;
}
</style>
