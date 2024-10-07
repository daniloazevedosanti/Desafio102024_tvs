using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListProduct.Entities
{
    public class Product
    {
        public string? Descricao { get; set; }
        public double ValorCompra { get; set; }
        public double ValorVenda { get; set; }
        public TipoEnum Tipo { get; set; }
        public DateTime DataCriacao { get; set; }

        public Product(string descricao, double valorCompra, double valorVenda, TipoEnum tipo, DateTime dataCriacao)
        {
            Descricao = descricao;
            ValorCompra = valorCompra;
            ValorVenda = valorVenda;
            Tipo = tipo;
            DataCriacao = dataCriacao;
        }

        public string showProductStatus()
        {
            //Margem de Lucro(10 %) { ((this.ValorVenda - this.ValorCompra) * 0.9) / ((this.ValorVenda - this.ValorCompra)) * 100}
            var show = $"Descrição: {this.Descricao}, Valor de Venda: {this.ValorVenda}, Valor de Compra: {this.ValorCompra}, Tipo/ValorTipo = {this.Tipo} - {((int)this.Tipo)} , Data: {this.DataCriacao}" ;
            return show;
        }

    }
}
