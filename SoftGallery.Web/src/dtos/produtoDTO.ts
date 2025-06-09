export interface ResumoProdutoDTO {
  id: string;
  nome: string;
  descricao?: string;
  imagemUrl?: string;
  preco: number;
  // Campos fictícios ou adicionados para simular front:
  tipo?: 'novidade' | 'destaque';
  avalicao?: number;
}
