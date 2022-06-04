using GestorEstoque.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEstoque.Products {
    [System.Serializable]
    internal class Ebook:Product,IContract {

        public string Author;
        public int Sales;

        public Ebook(string name,float price,string author) {

            this.Name = name;
            this.Price = price;
            this.Author = author;
            
        }

        public void AddEntry() {
            
            Console.WriteLine("NÃO É POSSÍVEL DAR ENTRADA EM PRODUTOS DIGITAIS !! ");
        }

        public void AddOutput() {

            Console.WriteLine("NÃO É POSSÍVEL DAR BAIXA NESSE PRODUTO !!");
        }

        public void Exibir() {

            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Price: {Price}");
            Console.WriteLine($"Author: {Author}");
            Console.WriteLine("===================");

        }
    }
}
