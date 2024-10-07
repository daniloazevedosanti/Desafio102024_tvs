// See https://aka.ms/new-console-template for more information

//Article default data           
using ListProduct.Entities;

Product product1 = new Product("Celular Huawey", 4500.00, 6500.00, TipoEnum.Final, new DateTime(2024, 04, 01));
Product product2 = new Product("CCelular Iphone X", 7000.00, 10000.00, TipoEnum.Consumo, new DateTime(2024, 05, 23));
Product product3 = new Product("Televisor Samsung", 5000.00, 7000.00, TipoEnum.Intermediario, DateTime.Now);
Product product4 = new Product("PC Moto G97", 45000.00, 65000.00, TipoEnum.MateriaPrima, DateTime.Now);

var list = new List<Product>();
var listProduct = new ListProduct.Entities.ListProduct(list);

listProduct.SaveChanges(product1);
listProduct.SaveChanges(product2);
listProduct.SaveChanges(product3);
listProduct.SaveChanges(product4);

int value;
do
{
    Console.WriteLine("1 - Listagem de Produtos.");

    Console.WriteLine("2 - Add novo Produto.");

    Console.WriteLine("3 - Listagem por Filtro 2o trimestre.");

    Console.WriteLine("4 - Listagem Ordenada Por Tipo.");

    Console.WriteLine("5 - Os 3 Maiores Lucros.");

    Console.WriteLine("0 - SAIR");

    Console.WriteLine("Selecione uma Opção: ");
    value = Convert.ToInt32(Console.ReadLine());
    switch (value)
    {
        case 1:
            listProduct.ListProducts();
            break;
        case 2:
            var objInserted = loadProduct();
            listProduct.SaveChanges(objInserted);
            break;
        case 3:
            listProduct.ListProductsByTrimestre();
            break;
        case 4:
            listProduct.ListProductsByEnumTipo();
            break;
        case 5:
            listProduct.ListProductsByMLucro();
            break;
        default:
            break;
    }
} while (value != 0);


// Parameters to add a new 
static Product loadProduct()
{
    Console.WriteLine("Entre com os dados do produto:");
    Console.WriteLine("Descrição:");
    string desc = Console.ReadLine();

    Console.WriteLine("Valor compra:");
    Double val1 = Double.Parse(Console.ReadLine());

    Console.WriteLine("Valor venda:");
    Double val2 = Double.Parse(Console.ReadLine());

    Console.WriteLine("Tipo: Final = 0, Intermediario = 1, Consumo = 2, MateriaPrima = 3");
    var valor = int.Parse(Console.ReadLine());
    var tipo = (TipoEnum)valor;

    Console.WriteLine("Data de criação:");
    DateTime data = DateTime.Parse(Console.ReadLine());

    Product obj = new Product(desc, val1, val2, tipo, data);
    Console.WriteLine(obj.showProductStatus());

    return obj;
}
