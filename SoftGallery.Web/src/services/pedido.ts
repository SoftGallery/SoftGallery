import axios from 'axios';
import type { Pedido, PedidoDTO } from '../types/pedido';

const API_URL = 'https://localhost:7273/api/Pedidos';
const WHATSAPP_API_URL = 'https://localhost:7273/api/WhatsApp/url';

const getAuthHeader = () => {
  const token = localStorage.getItem('token');
  return {
    headers: {
      Authorization: `Bearer ${token}`,
    },
  };
};

const abrirLinkWhatsapp = async (pedidoId: string) => {
  try {
    const response = await axios.get<string>(`${WHATSAPP_API_URL}/${pedidoId}`, getAuthHeader());
    const url = response.data;
    if (url) {
      window.open(url, '_blank');
    } else {
      console.warn('URL do WhatsApp não retornada.');
    }
  } catch (error) {
    console.error('Erro ao obter URL do WhatsApp:', error);
  }
};

export const pedidoService = {
  async criarPedido(pedidoDTO: PedidoDTO): Promise<Pedido> {
    try {
      const response = await axios.post<Pedido>(`${API_URL}`, pedidoDTO, getAuthHeader());
      const pedido = response.data;
      await abrirLinkWhatsapp(pedido.id); // abre o link depois de criar
      return pedido;
    } catch (error: any) {
      if (error.response?.data?.mensagem) {
        throw new Error(error.response.data.mensagem);
      }
      throw new Error('Erro ao criar pedido');
    }
  },

  async atualizarPedido(id: string, pedidoDTO: PedidoDTO): Promise<Pedido> {
    try {
      const response = await axios.put<Pedido>(`${API_URL}/${id}`, pedidoDTO, getAuthHeader());
      const pedido = response.data;
      await abrirLinkWhatsapp(pedido.id); // abre o link depois de atualizar
      return pedido;
    } catch (error: any) {
      if (error.response?.data?.mensagem) {
        throw new Error(error.response.data.mensagem);
      }
      throw new Error('Erro ao atualizar pedido');
    }
  },

  async obterPedido(id: string): Promise<Pedido> {
    const response = await axios.get<Pedido>(`${API_URL}/${id}`, getAuthHeader());
    return response.data;
  },

  async listarPedidos(): Promise<Pedido[]> {
    const response = await axios.get<Pedido[]>(API_URL, getAuthHeader());
    return response.data;
  }
};
