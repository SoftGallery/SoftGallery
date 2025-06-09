<template>
    <div class="product-list-wrapper">
        <div style="display: flex; justify-content: space-between; margin-bottom: 4px;">
            <h2 class="title">Produtos</h2>
            <el-button type="primary" @click="openModal()">Adicionar Produto</el-button>
        </div>
        <el-table :data="produtos" style="width: 100%" v-loading="loading">
            <el-table-column prop="id" label="ID" width="300" />
            <el-table-column prop="nome" label="Nome" />
            <!-- <el-table-column prop="descricao" label="Descrição" /> -->
            <el-table-column label="Preço" width="120">
                <template #default="{ row }">
                    R$ {{ row.preco.toFixed(2) }}
                </template>
            </el-table-column>
            <el-table-column label="Imagem" width="100">
                <template #default="{ row }">
                    <img v-if="row.imagemUrl" :src="row.imagemUrl" alt="thumbnail" class="thumb-img" />
                    <span v-else>—</span>
                </template>
            </el-table-column>
            <el-table-column label="Ações" width="100">
                <template #default="{ row }">
                    <el-dropdown trigger="click" @command="command => handleCommand(row, command)">
                        <span class="el-dropdown-link">
                            Ações <i class="el-icon-arrow-down el-icon--right"></i>
                        </span>
                        <template #dropdown>
                            <el-dropdown-menu>
                                <el-dropdown-item command="editar">Editar</el-dropdown-item>
                                <el-dropdown-item command="excluir">Excluir</el-dropdown-item>
                            </el-dropdown-menu>
                        </template>
                    </el-dropdown>
                </template>
            </el-table-column>
        </el-table>

        <!-- Modal para adicionar/editar produto -->
        <el-dialog :title="modalTitle" v-model="modalVisible" width="500px" @close="resetForm">
            <el-form :model="form" ref="formRef" label-position="top" label-width="100px">
                <el-form-item label="Nome" :rules="[{ required: true, message: 'Informe o nome', trigger: 'blur' }]"
                    prop="nome">
                    <el-input v-model="form.nome" />
                </el-form-item>

                <el-form-item label="Descrição" prop="descricao">
                    <el-input type="textarea" v-model="form.descricao" :rows="4"
                        placeholder="Digite a descrição do produto" />
                </el-form-item>

                <div style="display: flex; justify-content: space-between;">
                    <el-form-item label="Preço"
                        :rules="[{ required: true, type: 'number', message: 'Informe o preço', trigger: 'blur' }]"
                        prop="preco">
                        <el-input-number v-model="form.preco" :min="0" :step="0.01" />
                    </el-form-item>

                    <el-form-item label="Imagem">
                        <div style="display: flex; flex-direction: column; gap: 8px; justify-content: left;">
                            <el-upload class="upload-demo" action="" :before-upload="beforeUpload"
                                :show-file-list="false">
                                <el-button size="small" type="outline">Selecionar Imagem</el-button>
                            </el-upload>
                            <img v-if="form.imagemPreview" :src="form.imagemPreview" class="preview-img" />
                        </div>
                    </el-form-item>
                </div>
            </el-form>

            <template #footer>
                <el-button @click="modalVisible = false">Cancelar</el-button>
                <el-button type="primary" @click="saveProduto">Salvar</el-button>
            </template>
        </el-dialog>
    </div>
</template>

<script setup>
import { ref, reactive, onMounted } from 'vue'
import axios from 'axios'
import { ElMessage, ElMessageBox } from 'element-plus'

const produtos = ref([])
const loading = ref(false)
const modalVisible = ref(false)
const modalTitle = ref('')

const formRef = ref(null)
const form = reactive({
    id: null,
    nome: '',
    descricao: '',
    preco: 0,
    imagemFile: null,
    imagemPreview: '',
})

async function carregarProdutos() {
    loading.value = true
    try {
        const response = await axios.get('https://localhost:7273/api/Produto')
        produtos.value = response.data.map(p => ({
            id: p.id,
            nome: p.nome,
            descricao: p.descricao || '',
            preco: p.preco,
            imagemUrl: p.imagemUrl || '',
        }))
    } catch (error) {
        ElMessage.error('Erro ao carregar produtos')
    } finally {
        loading.value = false
    }
}

function resetForm() {
    form.id = null
    form.nome = ''
    form.descricao = ''
    form.preco = 0
    form.imagemFile = null
    form.imagemPreview = ''
    formRef.value?.clearValidate()
}

async function openModal(produto = null) {
    resetForm()
    if (produto) {
        modalTitle.value = 'Editar Produto'

        try {
            const { data } = await axios.get(`https://localhost:7273/api/Produto/${produto.id}`)
            form.id = data.id
            form.nome = data.nome
            form.descricao = data.descricao || ''
            form.preco = data.preco
            form.imagemPreview = data.imagemURL || ''
            form.imagemFile = null
        } catch (error) {
            ElMessage.error('Erro ao buscar os dados do produto')
            return
        }
    } else {
        modalTitle.value = 'Adicionar Produto'
    }
    modalVisible.value = true
}

function beforeUpload(file) {
    const isImage = file.type.startsWith('image/')
    if (!isImage) {
        ElMessage.error('Só é permitido arquivos de imagem')
        return false
    }
    form.imagemFile = file
    const reader = new FileReader()
    reader.readAsDataURL(file)
    reader.onload = () => {
        form.imagemPreview = reader.result
    }
    return false // impedir upload automático
}

async function saveProduto() {
    formRef.value.validate(async valid => {
        if (!valid) {
            ElMessage.error('Corrija os erros do formulário')
            return
        }

        try {
            if (form.id) {
                // Editar produto (PUT)
                await axios.put(`https://localhost:7273/api/Produto/${form.id}`, {
                    nome: form.nome,
                    descricao: form.descricao,
                    preco: form.preco,
                })
                if (form.imagemFile) {
                    const fd = new FormData()
                    fd.append('arquivo', form.imagemFile)
                    await axios.post(`https://localhost:7273/api/Produto/${form.id}/Upload`, fd, {
                        headers: { 'Content-Type': 'multipart/form-data' },
                    })
                }
                ElMessage.success('Produto atualizado')
            } else {
                // Criar produto (POST)
                const { data } = await axios.post('https://localhost:7273/api/Produto', {
                    nome: form.nome,
                    descricao: form.descricao,
                    preco: form.preco,
                })
                if (form.imagemFile) {
                    const fd = new FormData()
                    fd.append('arquivo', form.imagemFile)
                    await axios.post(`https://localhost:7273/api/Produto/${data.id}/Upload`, fd, {
                        headers: { 'Content-Type': 'multipart/form-data' },
                    })
                }
                ElMessage.success('Produto criado')
            }
            modalVisible.value = false
            carregarProdutos()
        } catch (error) {
            ElMessage.error('Erro ao salvar produto')
        }
    })
}

async function handleCommand(row, command) {
    if (command === 'editar') {
        await openModal(row)
    } else if (command === 'excluir') {
        ElMessageBox.confirm(`Deseja excluir o produto "${row.nome}"?`, 'Confirmação', {
            confirmButtonText: 'Sim',
            cancelButtonText: 'Não',
            type: 'warning',
        }).then(async () => {
            try {
                await axios.delete(`https://localhost:7273/api/Produto/${row.id}`)
                ElMessage.success('Produto excluído')
                carregarProdutos()
            } catch {
                ElMessage.error('Erro ao excluir')
            }
        }).catch(() => {
            // Cancelado
        })
    }
}

onMounted(() => {
    carregarProdutos()
})
</script>

<style scoped>
.product-list-wrapper {
    max-width: 2000px;
    width: 100%;
    margin: auto;
    padding: 2rem;
}

.thumb-img {
    width: 60px;
    height: 60px;
    object-fit: contain;
    border-radius: 4px;
    border: 1px solid #ccc;
}

.preview-img {
    width: 120px;
    height: auto;
    object-fit: contain;
    border-radius: 6px;
    margin-top: 0.5rem;
    border: 1px solid #ccc;
}

.el-form-item__content {
    align-items: left !important;
}

.title {
  font-weight: 700;
  font-size: 1.8rem;
  /* margin-bottom: 2rem; */
  color: #3b38e6;
  text-align: center;
  letter-spacing: 0.04em;
}
</style>
