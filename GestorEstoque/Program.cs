using GestorEstoque.Contract;
using GestorEstoque.Products;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace GestorEstoque {
    internal class Program {

        static List<IContract> products = new List<IContract>();
        enum Menu { Listar = 1, Adicionar, Remover, Entrada, Saida, Sair }
        enum MenuRegis { PhisicalProduct = 1, Ebook, Food }

        static void Main(string[] args) {

            Loading();

            bool escolherSair = false;
            while (escolherSair == false) {

                Console.WriteLine("=================================");
                Console.WriteLine("Gestor de Estoque - Modal Import │");
                Console.WriteLine("=================================");
                Console.WriteLine("1-Listar Produtos│\n2-Adicionar Produtos│\n3-Remover Produtos│\n4-Registrar Entrada│\n5-Registrar Saída│\n6-Sair│");
                string opStr = Console.ReadLine();
                int opInt = int.Parse(opStr);

                if (opInt > 0 && opInt < 6) {

                    Menu escolha = (Menu)opInt;
                    switch (escolha) {
                        case Menu.Listar:
                            Listing();
                            break;
                        case Menu.Adicionar:
                            Registration();
                            break;
                        case Menu.Remover:
                            Remove();
                            break;
                        case Menu.Entrada:
                            Entry();
                            break;
                        case Menu.Saida:
                            Output();
                            break;
                        case Menu.Sair:
                            escolherSair = true;
                            break;

                    }
                }
                else
                    escolherSair = true;

                Console.Clear();

            }


            static void Listing() {

                Console.WriteLine("List of Products ");
                int i = 0;
                foreach (IContract p in products) {
                    Console.WriteLine("ID: " + i);
                    p.Exibir();
                    i++;
                }
                Console.ReadLine();
            }

            static void Remove() {
                Listing();
                Console.WriteLine("Entre com o ID do elemento que deseja remover: ");
                int id = int.Parse(Console.ReadLine());
                if (id >= 0 && id < products.Count) {

                    products.RemoveAt(id);
                    Save();
                }
            }


            static void Entry() {

                Listing();
                Console.WriteLine("Entre com o ID do elemento que deseja dar entrada: ");
                int id = int.Parse(Console.ReadLine());
                if (id >= 0 && id < products.Count) {

                    products[id].AddEntry();
                    Save();
                }

            }

            static void Output() {
                Listing();
                Console.WriteLine("Entre com o ID do elemento que deseja dar baixa: ");
                int id = int.Parse(Console.ReadLine());
                if (id >= 0 && id < products.Count) {

                    products[id].AddOutput();
                    Save();
                }
            }

            static void Registration() {

                Console.WriteLine("Registration Product");
                Console.WriteLine("1-PhisicalProduct\n2-Ebook\n3-Food");
                int opInt = int.Parse(Console.ReadLine());
                MenuRegis regis = (MenuRegis)opInt;

                switch (regis) {
                    case (MenuRegis)1:
                        RegistrationPP();
                        break;
                    case (MenuRegis)2:
                        RegistrationEbook();
                        break;
                    case (MenuRegis)3:
                        RegistrationFood();
                        break;
                }

            }
            static void RegistrationPP() {

                Console.WriteLine("Registration Phisical Products: ");
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Price: ");
                float price = float.Parse(Console.ReadLine());
                Console.Write("Shipping: ");
                float shipping = float.Parse(Console.ReadLine());

                PhisicalProduct pp = new PhisicalProduct(name, price, shipping);
                products.Add(pp);

                Save();
            }

            static void RegistrationEbook() {

                Console.WriteLine("Registration Ebooks: ");
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Price: ");
                float price = float.Parse(Console.ReadLine());
                Console.Write("Author: ");
                string author = Console.ReadLine();

                Ebook eb = new Ebook(name, price, author);
                products.Add(eb);

                Save();
            }

            static void RegistrationFood() {

                Console.WriteLine("Registration Foods: ");
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Price: ");
                float price = float.Parse(Console.ReadLine());
                Console.Write("Type: ");
                string type = Console.ReadLine();

                Food fd = new Food(name, price, type);
                products.Add(fd);

                Save();
            }

            static void Save() {
                FileStream stream = new FileStream("products.dat", FileMode.OpenOrCreate);
                BinaryFormatter enconder = new BinaryFormatter();
                enconder.Serialize(stream, products);

                stream.Close();
            }

            static void Loading() {
                FileStream stream = new FileStream("products.dat", FileMode.OpenOrCreate);
                BinaryFormatter encoder = new BinaryFormatter();


                try {

                    products = (List<IContract>)encoder.Deserialize(stream);
                    if (products == null) {

                        products = new List<IContract>();
                    }
                }
                catch (Exception) {

                    products = new List<IContract>();
                }
                stream.Close();

            }


        }
    }
}