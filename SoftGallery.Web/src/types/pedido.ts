export interface PedidoDTO {
  produtosIds: string[];
}

export interface Produto {
  id: string;
  nome: string;
  preco: number;
}

export interface Cliente {
  id: string;
  nome: string;
  email: string;
}

export interface Pedido {
  id: string;
  dataPedido: string;
  cliente: Cliente;
  produtos: Produto[];
}
