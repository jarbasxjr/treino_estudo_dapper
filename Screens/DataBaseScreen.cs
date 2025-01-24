using System.Text;
using mercadinho.Models;
using mercadinho.Repositories;
using Microsoft.Data.SqlClient;

namespace mercadinho.Screens
{
    public class DataBaseScreen
    {
        public static void Show()
        {
            MainMenu.ApplyDefaultScreenColors();
            Console.Clear();
            Console.WriteLine("###############  TEM DE TUDO MERCADO  ###############");
            Console.WriteLine("");
            Console.WriteLine("1 - Inserir Produto\n2 - Visualizar Produtos\n3 - Deletar produtos\n4 - Atualizar Produto\n0 - Voltar");
            Console.WriteLine("\n####################################################");

            var option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    InsertProductMenu();
                    break;
                case 2:
                    List();
                    break;
                case 3:
                    DrawDeleteMenu();
                    break;
                case 4:
                    break;
                case 0:
                    MainMenu.Show();
                    break;
                default:
                    break;
            }
        }

        public static void InsertProductMenu()
        {
            var product = new Product();
            string[] text = { "Nome", "Price", "Amount" };
            string?[] answers = new string[text.Length];
            MainMenu.ApplyDefaultScreenColors();
            Console.Clear();


            for (int i = 0; i < text.Length; i++)
            {
                Console.WriteLine($"Escreva o {text[i]} do Produto : ");
                answers[i] = Console.ReadLine();
            }

            try
            {
                product.Name = answers[0];
                product.Price = decimal.Parse(answers[1].Replace(".", ","));
                product.Amount = int.Parse(answers[2]);
                product.Category_Id = 1;
                product.Type_Id = 1;
                product.Brand_Id = 1;
            }
            catch (System.Exception)
            {
                Console.WriteLine("Ocorreu um erro ");
                Console.ReadKey();
                Show();
            }



            try
            {
                var repository = new Repository<Product>(Database.Connection);
                repository.Create(product);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{product.Name} Adicionado com Sucesso !");
                AskContinueMessage("ADICIONAR MAIS UM PRODUTO ? (Sim: y | Voltar ao menu principal: esc )");
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Não foi possivel adicionar o produto !");
                Console.WriteLine(ex.Message);
            }





        }

        public static void DrawDeleteMenu()
        {
            Console.WriteLine("DIGITE O ID DO PRODUTO A SER EXCLUÍDO :");


            try
            {
                var repository = new Repository<Product>(Database.Connection);
                var idToDelete = int.Parse(Console.ReadLine()!);

                var model = repository.Get(idToDelete);

                Console.WriteLine($" EXCLUIR {model.Name} DA LISTA DE PRODUTOS ? (Sim: y | Não: n | voltar: esc)");
                var key = Console.ReadKey();

                if (key.Key == ConsoleKey.Y)
                {
                    repository.Delete(idToDelete);
                    Console.Clear();
                    Console.WriteLine($"{model.Name} Excluido com sucesso !");
                    Console.WriteLine($"CONTINUAR OU VOLTAR ? (voltar: esc | continuar: y)");
                    key = Console.ReadKey();

                    if (key.Key == ConsoleKey.Y)
                        DrawDeleteMenu();
                    else if (key.Key == ConsoleKey.Escape)
                        Show();

                }
                else if (key.Key == ConsoleKey.N)
                {
                    Console.Clear();
                    DrawDeleteMenu();
                }
                else if (key.Key == ConsoleKey.Escape)
                {
                    Show();
                }
            }
            catch (System.Exception)
            {
                MainMenu.ErrorMessage("OPCAO INVALIDA ! (voltar : esc | tentar novament: qualquer tecla)");
                var key = Console.ReadKey();

                if (key.Key == ConsoleKey.Escape)
                    Show();
                else
                    DrawDeleteMenu();
            }

        }

        public static void DrawUpdateMenu()
        {
            var repository = new Repository<Product>(Database.Connection);
            Console.Clear();
            Console.WriteLine("DIGITE O ID DO PRODUTO PARA ATUALIZAR: ");

            if (int.TryParse(Console.ReadLine(), out int idUpdate))
            {
                var model = repository.Get(idUpdate);

                if (model != null)
                {
                    Console.WriteLine($"Atualizar {model.Name} ? (sim: y | não: n | voltar: esc) ");
                    var key = Console.ReadKey();

                    if (key.Key == ConsoleKey.Y)
                    {
                        Console.Clear();
                        Console.WriteLine("Escolha o que dejesa atualizar: ");
                        Console.WriteLine($"1 - Nome\n2 - Preço\n3 - Quantidade\n0 - Voltar");
                    }
                    else if (key.Key == ConsoleKey.N)
                        DrawDeleteMenu();
                    else if (key.Key == ConsoleKey.Escape)
                        Show();
                }

            }
            else
            {
                Console.WriteLine("Opcao inválida !");
                DrawUpdateMenu();
            }

        }

        private static void DrawDeleteSubMenu(int option)
        {

        }
        private static void List()
        {
            var repository = new Repository<Product>(Database.Connection);
            var products = repository.Get();

            Console.Clear();
            Console.WriteLine(" PRODUTOS ".PadLeft(30, '=').PadRight(61, '='));
            Console.WriteLine("NOME".PadLeft(24) + "PREÇO".PadLeft(14) + "ESTOQUE".PadLeft(13));
            Console.WriteLine("".PadLeft(61, '='));


            foreach (var product in products)
            {
                var padName = product.Name.PadRight(30, '.');
                var strPrice = product.Price.ToString("C");

                Console.WriteLine($" {padName}{strPrice.PadRight(10)} | Em estoque : {product.Amount}");
            }

            AskContinueMessage("PRESSIONE ESC PARA VOLTAR AO MENU PRINCIPAL");

        }

        private static void AskContinueMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("=============================================================");
            Console.WriteLine(message);

            var ans = Console.ReadKey();

            if (ans.Key == ConsoleKey.Escape)
                MainMenu.Show();
            else if (ans.Key == ConsoleKey.Y)
            {
                DataBaseScreen.InsertProductMenu();
            }
            else
            {
                AskContinueMessage(message);
            }
        }
    }
}