<template>
  <el-card class="product-card" shadow="hover">
    <h2 class="title">Cadastro de Produto</h2>

    <el-form
      :model="form"
      :rules="rules"
      ref="productForm"
      label-position="top"
      class="product-form"
    >
      <el-form-item label="Nome do Produto" prop="nome">
        <el-input v-model="form.nome" placeholder="Digite o nome do produto" />
      </el-form-item>

      <el-form-item label="Descrição" prop="descricao">
        <el-input
          v-model="form.descricao"
          type="textarea"
          placeholder="Descreva brevemente o produto"
          rows="3"
        />
      </el-form-item>

      <el-form-item label="Preço (R$)" prop="preco">
        <el-input-number
          v-model="form.preco"
          :min="0"
          :step="0.01"
          placeholder="Preço"
          controls-position="right"
          style="width: 30%"
        />
      </el-form-item>

      <el-form-item class="buttons">
        <el-button type="primary" @click="submitForm">Salvar</el-button>
        <el-button @click="resetForm">Limpar</el-button>
      </el-form-item>
    </el-form>
  </el-card>
</template>

<script lang="ts" setup>
import { ref } from 'vue'
import { ElMessage } from 'element-plus'

const form = ref({
  nome: '',
  descricao: '',
  preco: 0,
})

const rules = {
  nome: [{ required: true, message: 'O nome é obrigatório', trigger: 'blur' }],
  descricao: [{ required: true, message: 'A descrição é obrigatória', trigger: 'blur' }],
  preco: [{ required: true, message: 'O preço é obrigatório', trigger: 'blur' }],
}

const productForm = ref()

const submitForm = () => {
  productForm.value?.validate(async (valid: boolean) => {
    if (!valid) {
      ElMessage.error('Preencha todos os campos obrigatórios.')
      return
    }

    try {
      const response = await fetch('https://localhost:7273/api/Produto', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(form.value),
      })

      if (!response.ok) {
        throw new Error('Erro ao cadastrar produto')
      }

      ElMessage.success('Produto cadastrado com sucesso!')
      resetForm()
    } catch (error) {
      console.error(error)
      ElMessage.error('Erro ao cadastrar produto. Verifique o backend.')
    }
  })
}

const resetForm = () => {
  productForm.value?.resetFields()
}
</script>

<style scoped>
.product-card {
  max-width: 600px;
  margin: 2rem auto;
  padding: 2rem 2.5rem;
  background-color: #fff;
  border-radius: 12px;
  box-shadow: 0 2px 12px rgba(0, 0, 0, 0.05);
}

.title {
  font-size: 1.5rem;
  font-weight: 600;
  margin-bottom: 1.5rem;
  color: #333;
  text-align: center;
}

.product-form {
  display: flex;
  flex-direction: column;
  gap: 1.2rem;
}

.buttons {
  display: flex;
  justify-content: flex-end;
  gap: 10px;
  margin-top: 1.5rem;
}
</style>
