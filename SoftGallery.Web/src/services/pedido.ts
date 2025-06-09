import axios from 'axios';
import type { Pedido, PedidoDTO } from '../types/pedido';

const API_URL = 'https://localhost:7273/api/Pedidos';

export const pedidoService = {
  async criarPedido(pedidoDTO: PedidoDTO): Promise<Pedido> {
    try {
      const response = await axios.post<Pedido>(`${API_URL}`, pedidoDTO);
      return response.data;
    } catch (error: any) {
      if (error.response?.data?.mensagem) {
        throw new Error(error.response.data.mensagem);
      }
      throw new Error('Erro ao criar pedido');
    }
  },
  async atualizarPedido(id: string, pedidoDTO: PedidoDTO): Promise<Pedido> {
    try {
      const response = await axios.put<Pedido>(`${API_URL}/${id}`, pedidoDTO);
      return response.data;
    } catch (error: any) {
      if (error.response?.data?.mensagem) {
        throw new Error(error.response.data.mensagem);
      }
      throw new Error('Erro ao atualizar pedido');
    }
  },

  async obterPedido(id: string): Promise<Pedido> {
    const response = await axios.get<Pedido>(`${API_URL}/${id}`);
    return response.data;
  },

  async listarPedidos(): Promise<Pedido[]> {
    const response = await axios.get<Pedido[]>(API_URL);
    return response.data;
  }
};
