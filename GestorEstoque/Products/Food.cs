using GestorEstoque.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEstoque.Products {
    [System.Serializable]
    internal class Food : Product, IContract {

        public string Type;
        private int Qtd;

        public Food(string name,float price,string type) {

            this.Name = name;
            this.Price = price;
            this.Type = type;

        }

        public void AddEntry() {
            Console.WriteLine($"Adicionar entrada de produto no estoque {Name}");
            Console.WriteLine("Digite a QTD do produto para dar entrada: ");
            int entrada = int.Parse(Console.ReadLine());
            Qtd += entrada;
            Console.WriteLine("Entrada no estoque com sucesso !!");
            Console.ReadLine();
        }

        public void AddOutput() {
            Console.WriteLine($"Retirar o produto {Name} do estoque");
            Console.WriteLine("Digite a QTD do produto para dar baixa: ");
            int retirada = int.Parse(Console.ReadLine());
            Qtd -= retirada;
            Console.WriteLine("Retirada do estoque com sucesso !");

            Console.ReadLine();
        }

        public void Exibir() {

            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Price: {Price}");
            Console.WriteLine($"Type: {Type}");
            Console.WriteLine($"QTD: {Qtd}");
            Console.WriteLine("===================");
            


        }
    }
}
