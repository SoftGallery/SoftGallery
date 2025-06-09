<template>
  <div class="form-wrapper">
    <h2 class="title">Cadastro da Loja</h2>

    <el-form
      :model="form"
      ref="formRef"
      label-position="top"
      label-width="120px"
      class="el-form-custom"
      @submit.native.prevent="handleSubmit"
    >
      <el-tabs v-model="activeTab" type="border-card" class="tabs-custom">
        <!-- Tab 1 -->
        <el-tab-pane label="Informações Gerais" name="geral">
          <el-row :gutter="24">
            <el-col :span="12">
              <el-form-item label="Nome da Loja" prop="nome" :rules="[{ required: true, message: 'Informe o nome', trigger: 'blur' }]">
                <el-input v-model="form.nome" placeholder="Nome da Loja" />
              </el-form-item>
            </el-col>

            <el-col :span="12">
              <el-form-item label="Email" prop="email" :rules="[{ required: true, type: 'email', message: 'Email inválido', trigger: ['blur', 'change'] }]">
                <el-input v-model="form.email" placeholder="Email de contato" />
              </el-form-item>
            </el-col>

            <el-col :span="12">
              <el-form-item label="WhatsApp">
                <el-input v-model="form.whatsapp" placeholder="WhatsApp" />
              </el-form-item>
            </el-col>

            <el-col :span="12">
              <el-form-item label="Endereço" prop="endereco" :rules="[{ required: true, message: 'Informe o endereço', trigger: 'blur' }]">
                <el-input v-model="form.endereco" placeholder="Endereço" />
              </el-form-item>
            </el-col>

            <el-col :span="24">
              <el-form-item label="Descrição" prop="descricao" :rules="[{ required: true, message: 'Informe a descrição', trigger: 'blur' }]">
                <el-input
                  type="textarea"
                  v-model="form.descricao"
                  placeholder="Descrição da Loja"
                  :rows="4"
                  resize="none"
                />
              </el-form-item>
            </el-col>
          </el-row>
        </el-tab-pane>

        <!-- Tab 2 -->
        <el-tab-pane label="Redes Sociais" name="redes">
          <el-row :gutter="24">
            <el-col :span="12">
              <el-form-item label="Facebook">
                <el-input v-model="form.facebook" placeholder="Facebook" />
              </el-form-item>
            </el-col>
            <el-col :span="12">
              <el-form-item label="Instagram">
                <el-input v-model="form.instagram" placeholder="Instagram" />
              </el-form-item>
            </el-col>
            <el-col :span="12">
              <el-form-item label="TikTok">
                <el-input v-model="form.tikTok" placeholder="TikTok" />
              </el-form-item>
            </el-col>
            <el-col :span="12">
              <el-form-item label="Twitter/X">
                <el-input v-model="form.x" placeholder="Twitter / X" />
              </el-form-item>
            </el-col>
          </el-row>
        </el-tab-pane>

        <!-- Tab 3 -->
        <el-tab-pane label="Logo da Loja" name="logo">
          <el-form-item label="Imagem da Loja">
            <el-upload
              class="upload-box"
              :show-file-list="false"
              :before-upload="handleBeforeUpload"
            >
              <div v-if="previewImage" class="preview-image-wrapper">
                <img :src="previewImage" class="preview-image" />
              </div>
              <el-button v-else type="primary" plain>Selecionar Imagem</el-button>
            </el-upload>
          </el-form-item>
        </el-tab-pane>
      </el-tabs>

      <el-form-item class="btn-col">
        <el-button type="primary" size="large" native-type="submit" class="submit-btn">
          Salvar
        </el-button>
      </el-form-item>
    </el-form>
  </div>
</template>

<script setup>
import { reactive, ref, onMounted } from 'vue'
import axios from 'axios'
import { ElMessage } from 'element-plus'

const formRef = ref()
const activeTab = ref('geral')
const previewImage = ref('')
const imageFile = ref(null)

const form = reactive({
  id: '', // usado para upload
  nome: '',
  descricao: '',
  endereco: '',
  email: '',
  whatsapp: '',
  facebook: '',
  instagram: '',
  tikTok: '',
  x: '',
})

onMounted(async () => {
  try {
    const { data } = await axios.get('https://localhost:7273/api/Loja')
    Object.assign(form, data)
    previewImage.value = data.imagemURL || ''
    form.id = data.id
  } catch {
    console.log('Loja ainda não cadastrada.')
  }
})

const handleBeforeUpload = (file) => {
  const reader = new FileReader()
  reader.onload = () => {
    previewImage.value = reader.result
    imageFile.value = file
  }
  reader.readAsDataURL(file)
  return false // bloqueia upload automático
}

async function handleSubmit() {
  formRef.value.validate(async (valid) => {
    if (!valid) {
      ElMessage.error('Por favor, corrija os erros do formulário.')
      return
    }

    try {
      await axios.put('https://localhost:7273/api/Loja', form)
      ElMessage.success('Dados da loja salvos!')

      if (imageFile.value && form.id) {
        const formData = new FormData()
        formData.append('arquivo', imageFile.value)

        await axios.post(`https://localhost:7273/api/Loja/${form.id}/Upload`, formData)
        ElMessage.success('Logo enviada com sucesso!')
      }
    } catch (err) {
      ElMessage.error('Erro ao salvar os dados da loja.')
    }
  })
}
</script>

<style scoped>
.form-wrapper {
  background: #fff;
  padding: 1.5rem 3rem;
  border-radius: 12px;
  max-width: 900px;
  min-width: 70vw;
}

.title {
  font-weight: 700;
  font-size: 1.8rem;
  margin-bottom: 2rem;
  color: #3b38e6;
  text-align: center;
  letter-spacing: 0.04em;
}

.tabs-custom {
  margin-bottom: 1rem;
  min-height: 60vh;
}

.el-tabs__item {
  min-width: 250px;
  text-align: center;
  font-weight: 600;
  color: #3b3b3b;
}

.el-tabs__item.is-active {
  color: #3b38e6 !important;
}

.el-tabs--border-card > .el-tabs__content {
  padding: 1.5rem 0;
}

.el-input__inner,
.el-textarea__inner {
  border-radius: 0;
  border: none;
  border-bottom: 2px solid #cfd8dc !important;
  padding-left: 0.6rem;
  font-size: 1rem;
  transition: border-color 0.3s ease;
  box-shadow: none !important;
  outline: none;
}

.el-input__inner:focus,
.el-input__inner:hover,
.el-textarea__inner:focus,
.el-textarea__inner:hover {
  border-bottom-color: #3b38e6 !important;
}

.btn-col {
  margin-top: 1.5rem;
}

.el-form-item__label {
  color: #235997;
  font-weight: 600;
  font-size: 1rem;
  padding-left: 0.3rem;
}

.upload-box {
  display: flex;
  align-items: center;
  gap: 1rem;
}

.preview-image-wrapper {
  width: 300px;
  height: 300px;
  border: 2px dashed #cfd8dc;
  border-radius: 12px;
  background-color: #fafafa;
  display: flex;
  align-items: center;
  justify-content: center;
  overflow: hidden;
  box-shadow: 0 2px 6px rgba(0, 0, 0, 0.06);
}

.preview-image {
  max-width: 100%;
  max-height: 100%;
  object-fit: contain;
}
</style>
