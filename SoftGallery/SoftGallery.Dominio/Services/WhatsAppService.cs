using SoftGallery.Dominio.Models;
using System.Globalization;

namespace SoftGallery.Dominio.Services
{
    public class WhatsAppService
    {
        private readonly PedidoService servicePedido;
        private readonly LojaService serviceLoja;

        public WhatsAppService(PedidoService servicePedido, LojaService serviceLoja)
        {
            this.servicePedido = servicePedido;
            this.serviceLoja = serviceLoja;
        }
        public string GerarUrlWhatsapp(string pedidoId)
        {
            Pedido? pedido = servicePedido.ObterPedidoPorId(pedidoId);

            if (pedido == null)
            {
                throw new Exception("Pedido não encontrado");
            }

            Loja? loja = serviceLoja.ObterConfiguracao();

            if (loja == null)
            {
                throw new Exception("Loja não encontrada");
            }

            if (string.IsNullOrEmpty(loja.Whatsapp))
            {
                throw new Exception("Número de WhatsApp da loja não cadastrado");
            }

            string mensagem = $"Olá, meu nome é {pedido.Cliente.Nome} e gostaria de confirmar meu pedido #{pedido.Id}.\n\n";
            mensagem += "Produtos:\n";

            foreach (var produto in pedido.Produtos)
            {
                mensagem += $"- {produto.Nome} (R$ {produto.Preco.ToString("F2", new CultureInfo("pt-BR"))})\n";
            }

            mensagem += $"\nData do pedido: {pedido.Data:dd/MM/yyyy HH:mm}";


            string mensagemCodificada = Uri.EscapeDataString(mensagem);

            string url = $"https://wa.me/{loja.Whatsapp}?text={mensagemCodificada}";

            return url;
        }
    }
}
