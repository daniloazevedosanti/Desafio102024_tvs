using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListProduct.Entities
{
    public class ListProduct
    {
        public List<Product> products { get; set; }


        public ListProduct(List<Product> products)
        {
            this.products = products;

        }

        public ListProduct()
        {
        }

        public void SaveChanges(Product product)
        {
            if (product == null)
            {
                throw new Exception("Não permitido inserção! ");

            }

            if (product.ValorVenda <= product.ValorCompra)
            {
                throw new Exception("Não permitido inserção - ValorVenda <= ValorCompra! ");

            }

            if (product.DataCriacao < new DateTime(01 / 01 / 2024))
            {
                throw new Exception("Não permitido inserção - DataCriacao < 01/01/2024! ");

            }

            if (product.Descricao?.Length < 5)
            {
                throw new Exception("Não permitido inserção - Descricao ");

            }

            if (product.ValorVenda < 0 && product.ValorCompra < 0)
            {
                throw new Exception("Não permitido inserção - ValorVenda  & ValorCompra! ");

            }


            this.products.Add(product);
        }

        public void ListProducts()
        {
            this.products.ForEach(i => Console.Write("{0}\n", i.showProductStatus()));
            Console.WriteLine();
        }

        public void ListProductsByTrimestre()
        {
            var data = new DateTime(2024, 04, 01);
            var inicioTri = data.AddDays((data.Day * -1) + 1);
            var fimTri = inicioTri.AddMonths(3).AddSeconds(-1);

            var list = this.products.Where(i => (i.DataCriacao >= inicioTri && i.DataCriacao <= fimTri)).ToList();

            list.ForEach(i => Console.Write("{0}\n", i.showProductStatus()));
            Console.WriteLine();
        }

        public void ListProductsByEnumTipo()
        {

            var list = this.products.OrderBy(i => i.Tipo).ToList();
            list.ForEach(i => Console.Write("{0}\n", i.showProductStatus()));
            Console.WriteLine();
        }

        public void ListProductsByMLucro()
        {

            var list = this.products.OrderBy(x => ((x.ValorVenda - x.ValorCompra)*0.9)/((x.ValorVenda - x.ValorCompra))).ToList();
            //list.ForEach(i => Console.Write("{0}\n", i.showProductStatus()));
            var i = 0;
            foreach (var item in list)
            {
                if( i < 3 )
                    Console.Write("{0}\n", item.showProductStatus());
                i++;
            }
            Console.WriteLine();
        }
    }
}
