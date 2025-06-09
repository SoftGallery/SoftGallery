<template>
  <div class="thank-you-container">
    <div class="thank-you-box">
      <h1>Obrigado pela sua compra!</h1>
      <p>Esperamos que você tenha uma ótima experiência com nossos produtos da <span class="SoftGallery">SoftGallery</span>.</p>
      <RouterLink to="/" class="back-button">Voltar à loja</RouterLink>
    </div>
  </div>
</template>

<script setup>
// Nada necessário aqui por enquanto.
</script>

<style scoped>
@import url('https://fonts.googleapis.com/css2?family=Inter:wght@100;200;400;600&display=swap');

.thank-you-container {
  display: flex;
  justify-content: center;
  align-items: center;
  height: 100vh;
  padding: 1rem;
  font-family: 'Inter', sans-serif;
  text-align: center;

  /* Background animado */
  background: linear-gradient(-70deg, #235997, #0f2350, #3b38e6, #3e035a9d);
  background-size: 400% 400%;
  animation: gradient 15s ease infinite;
  color: #f5f5f5;
}

@keyframes gradient {
  0% {
    background-position: 0% 50%;
  }
  50% {
    background-position: 100% 50%;
  }
  100% {
    background-position: 0% 50%;
  }
}

.thank-you-box {
  background-color: rgba(14, 12, 12, 0.85); /* leve transparência para deixar o fundo aparecer */
  border-radius: 16px;
  padding: 2rem 2.5rem;
  max-width: 600px;
  width: 100%;
  box-shadow: 0 0 15px rgba(0, 0, 0, 0.4);
}

h1 {
  font-size: 2rem;
  margin-bottom: 1rem;
}

p {
  font-size: 1.1rem;
  margin-bottom: 2rem;
}

.back-button {
  background-color: #5f9fe9;
  color: #fff;
  padding: 0.75rem 1.5rem;
  text-decoration: none;
  border-radius: 8px;
  transition: background-color 0.3s ease;
  font-weight: 500;
  display: inline-block;
  box-shadow: 0 3px 6px rgba(95, 159, 233, 0.5);
}

.back-button:hover {
  background-color: #3f7fc4;
  box-shadow: 0 4px 8px rgba(63, 127, 196, 0.7);
}

.SoftGallery {
  color: #5f9fe9;
  font-weight: 600;
}
</style>
