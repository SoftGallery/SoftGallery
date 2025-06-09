import { reactive } from 'vue'
import { showAlert } from '../services/alert'
import { Pedido } from '../types/pedido';
import { pedidoService } from '../services/pedido';

interface Product {
  id: string;
  nome: string;
  preco: number;
  stock: number;
  imagemUrl: string;
  quantity: number;
}

interface CartItem extends Product { }


export const cart = reactive({
  items: [] as CartItem[],
  itemIds: [] as string[],

  addToCart(product: Product, quantity: number = 1) {
    const item = cart.items.find((i: Product) => i.id === product.id)
    const availableStock = product.stock
    console.log('Adicionando ao carrinho:', product);

    try {
      if (item) {
        const newQuantity = item.quantity + quantity
        if (newQuantity <= availableStock) {
          item.quantity = newQuantity
        } else {
          item.quantity = availableStock
          showAlert('Quantidade ajustada ao limite do estoque disponível!', 'warning')
        }
      } else {
        const addedQuantity = quantity <= availableStock ? quantity : availableStock
        cart.items.push({ ...product, quantity: addedQuantity })
        cart.itemIds.push(product.id)
        if (quantity > availableStock) {
          showAlert('Quantidade ajustada ao limite do estoque disponível!', 'warning')
        }
      }
    } finally {
      showAlert(`Produto ${product.nome} adicionado na sacola com sucesso!`)
    }
  },


  removeFromCart(id: string) {
    cart.items = cart.items.filter((i: Product) => i.id !== id)
    cart.itemIds = cart.itemIds.filter((itemId: string) => itemId !== id)
  },

  updateQuantity(id: string, quantity: number) {
    const item = cart.items.find(i => i.id === id)
    if (item) {
      if (quantity <= 0) {
        cart.removeFromCart(id)
      } else if (quantity <= item.stock) {
        item.quantity = quantity
      } else {
        item.quantity = item.stock
        showAlert('Quantidade ajustada ao limite do estoque disponível!', 'warning')
      }
    }
  },

  async finalizarPedido(pedidoId?: string): Promise<boolean> {
    const produtosIds = cart.getCartIds().map(id => id.toString());

    if (produtosIds.length === 0) {
      showAlert('O carrinho está vazio!', 'error');
      return false;
    }

    const pedidoDTO = { produtosIds };

    try {
      const pedido = pedidoId
        ? await pedidoService.atualizarPedido(pedidoId, pedidoDTO)
        : await pedidoService.criarPedido(pedidoDTO);

      showAlert(`Pedido ${pedidoId ? 'atualizado' : 'realizado'} com sucesso!`, 'success');
      cart.clearCart();
      console.log('Pedido:', pedido);

      return true; // sucesso
    } catch (e: any) {
      showAlert(e.message, 'error');
      return false; // erro
    }
  },

  clearCart() {
    cart.items = []
    cart.itemIds = [] // Limpa a lista de IDs
  },

  get totalItems(): number { // Anotação explícita de tipo
    return cart.items.reduce((acc, item) => acc + item.quantity, 0)
  },

  get totalPrice(): number {
    return cart.items.reduce((acc, item) => acc + item.quantity * item.preco, 0)
  },


  // Este método retorna a lista de IDs do carrinho
  getCartIds() {
    return cart.itemIds
  }
})
