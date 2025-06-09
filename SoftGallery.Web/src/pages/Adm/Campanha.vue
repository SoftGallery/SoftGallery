<template>
    <div class="campaign-wrapper">
        <div class="header">
            <h2 class="title">Campanhas</h2>
            <el-button type="primary" @click="openModal()">Adicionar Campanha</el-button>
        </div>

        <el-table :data="campanhas" style="width: 100%" v-loading="loading">
            <el-table-column prop="id" label="ID" width="300" />
            <el-table-column prop="nome" label="Nome" />
            <!-- <el-table-column prop="dataInicio" label="Início" width="120">
        <template #default="{ row }">{{ formatDate(row.dataInicio) }}</template>
</el-table-column>
<el-table-column prop="dataFim" label="Fim" width="120">
    <template #default="{ row }">{{ formatDate(row.dataFim) }}</template>
</el-table-column> -->
            <el-table-column label="Imagem" width="100">
                <template #default="{ row }">
                    <img v-if="row.imagemURL" :src="row.imagemURL" class="thumb-img" />
                    <span v-else>—</span>
                </template>
            </el-table-column>
            <el-table-column label="Ações" width="100">
                <template #default="{ row }">
                    <el-dropdown trigger="click" @command="cmd => handleCommand(row, cmd)">
                        <span class="el-dropdown-link">Ações <i class="el-icon-arrow-down el-icon--right"></i></span>
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

        <!-- Modal de Cadastro de Campanha -->
        <el-dialog :title="modalTitle" v-model="modalVisible" width="600px" @close="resetForm">
            <el-form :model="form" ref="formRef" label-position="top">
                <el-form-item label="Nome" prop="nome" :rules="[{ required: true, message: 'Informe o nome' }]">
                    <el-input v-model="form.nome" />
                </el-form-item>

                <!-- <el-form-item label="Descrição">
          <el-input type="textarea" v-model="form.descricao" />
        </el-form-item> -->

                <div class="form-inline">
                    <el-form-item label="Início" prop="dataInicio"
                        :rules="[{ required: true, message: 'Informe a data' }]">
                        <el-date-picker v-model="form.dataInicio" type="date" placeholder="Data de início"
                            style="width: 100%;" />
                    </el-form-item>

                    <el-form-item label="Fim" prop="dataFim" :rules="[{ required: true, message: 'Informe a data' }]">
                        <el-date-picker v-model="form.dataFim" type="date" placeholder="Data de término"
                            style="width: 100%;" />
                    </el-form-item>
                </div>

                <el-form-item label="Imagem da Campanha">
                    <div style="display: flex; justify-content: space-between; border: 2px dotted #cccc; border-radius: 8px; padding: 4px; width: 100%; height: 100px; align-items: center;">
                        <el-upload class="upload-demo" :before-upload="beforeUpload" :show-file-list="false">
                            <el-button type="outline">Selecionar Imagem</el-button>
                        </el-upload>
                        <img v-if="form.imagemPreview" :src="form.imagemPreview" class="preview-img" />
                    </div>
                </el-form-item>

                <el-form-item label="Produtos Vinculados">
                    <el-select v-model="form.produtosSelecionados" multiple filterable placeholder="Selecionar produtos"
                        style="width: 100%">
                        <el-option v-for="produto in todosProdutos" :key="produto.id" :label="produto.nome"
                            :value="produto.id" />
                    </el-select>
                </el-form-item>
            </el-form>

            <template #footer>
                <el-button @click="modalVisible = false">Cancelar</el-button>
                <el-button type="primary" @click="saveCampanha">Salvar</el-button>
            </template>
        </el-dialog>
    </div>
</template>

<script setup>
import { ref, reactive, onMounted } from 'vue'
import axios from 'axios'
import { ElMessage, ElMessageBox } from 'element-plus'

const campanhas = ref([])
const todosProdutos = ref([])
const loading = ref(false)
const modalVisible = ref(false)
const modalTitle = ref('')

const formRef = ref(null)
const form = reactive({
    id: null,
    nome: '',
    //   descricao: '',
    dataInicio: '',
    dataFim: '',
    imagemFile: null,
    imagemPreview: '',
    produtosSelecionados: []
})

function formatDate(date) {
    return new Date(date).toLocaleDateString()
}

function resetForm() {
    Object.assign(form, {
        id: null,
        nome: '',
        // descricao: '',
        dataInicio: '',
        dataFim: '',
        imagemFile: null,
        imagemPreview: '',
        produtosSelecionados: []
    })
    formRef.value?.clearValidate()
}

function beforeUpload(file) {
    if (!file.type.startsWith('image/')) {
        ElMessage.error('Apenas imagens são permitidas')
        return false
    }
    form.imagemFile = file
    const reader = new FileReader()
    reader.onload = () => (form.imagemPreview = reader.result)
    reader.readAsDataURL(file)
    return false
}

async function carregarCampanhas() {
    loading.value = true
    try {
        const res = await axios.get('https://localhost:7273/api/Campanha')
        campanhas.value = res.data
    } finally {
        loading.value = false
    }
}

async function carregarProdutos() {
    const res = await axios.get('https://localhost:7273/api/Produto')
    todosProdutos.value = res.data
}

async function openModal(campanha = null) {
    resetForm()

    if (campanha) {
        modalTitle.value = 'Editar Campanha'
        try {
            const { data } = await axios.get(`https://localhost:7273/api/Campanha/${campanha.id}`)
            Object.assign(form, {
                id: data.id,
                nome: data.nome,
                // descricao: data.descricao || '',
                dataInicio: data.dataInicio,
                dataFim: data.dataFim,
                imagemPreview: data.imagemURL || '',
                produtosSelecionados: data.produtos?.map(p => p.id) || []
            })
        } catch (err) {
            ElMessage.error('Erro ao carregar dados da campanha')
            return
        }
    } else {
        modalTitle.value = 'Adicionar Campanha'
    }

    modalVisible.value = true
}


async function saveCampanha() {
    formRef.value.validate(async valid => {
        if (!valid) return

        try {
            if (form.id) {
                await axios.put(`https://localhost:7273/api/Campanha/${form.id}`, {
                    nome: form.nome,
                    descricao: form.descricao,
                    dataInicio: form.dataInicio,
                    dataFim: form.dataFim,
                    produtoIds: form.produtosSelecionados
                })
                if (form.imagemFile) {
                    const fd = new FormData()
                    fd.append('arquivo', form.imagemFile)
                    await axios.post(`https://localhost:7273/api/Campanha/${form.id}/Upload`, fd)
                }
                ElMessage.success('Campanha atualizada')
            } else {
                const { data } = await axios.post('https://localhost:7273/api/Campanha', {
                    nome: form.nome,
                    descricao: form.descricao,
                    dataInicio: form.dataInicio,
                    dataFim: form.dataFim,
                    produtoIds: form.produtosSelecionados
                })
                if (form.imagemFile) {
                    const fd = new FormData()
                    fd.append('arquivo', form.imagemFile)
                    await axios.post(`https://localhost:7273/api/Campanha/${data.id}/Upload`, fd)
                }
                ElMessage.success('Campanha criada')
            }
            modalVisible.value = false
            carregarCampanhas()
        } catch {
            ElMessage.error('Erro ao salvar campanha')
        }
    })
}

function handleCommand(row, command) {
    if (command === 'editar') {
        openModal(row)
    } else if (command === 'excluir') {
        ElMessageBox.confirm(`Excluir campanha "${row.nome}"?`, 'Atenção', {
            type: 'warning',
            confirmButtonText: 'Sim',
            cancelButtonText: 'Não'
        }).then(async () => {
            await axios.delete(`https://localhost:7273/api/Campanha/${row.id}`)
            ElMessage.success('Campanha excluída')
            carregarCampanhas()
        })
    }
}

onMounted(() => {
    carregarCampanhas()
    carregarProdutos()
})
</script>

<style scoped>
.campaign-wrapper {
    max-width: 1400px;
    width: 100%;
    height: 100%;
    margin: auto;
    padding: 2rem;
}

.header {
    display: flex;
    justify-content: space-between;
    margin-bottom: 1rem;
}

.thumb-img {
    width: 60px;
    height: 60px;
    object-fit: contain;
    border: 1px solid #ccc;
    border-radius: 6px;
}

.preview-img {
    margin-top: 0.5rem;
    width: 120px;
    border: 1px solid #ccc;
    border-radius: 6px;
}

.title {
    font-weight: bold;
    font-size: 1.8rem;
    color: #3b38e6;
    text-align: center;
}

.form-inline {
    display: flex;
    justify-content: space-between;
    gap: 16px;
}
</style>
