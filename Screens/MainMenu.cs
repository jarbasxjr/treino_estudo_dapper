using System.Drawing;

namespace mercadinho.Screens
{
    public class MainMenu
    {
        public static ConsoleColor DfForegroundColor = ConsoleColor.White;
        public static ConsoleColor DfBackgroundColor = ConsoleColor.DarkBlue;
        public static void Show()
        {
            ApplyDefaultScreenColors();
            Console.Clear();
            Console.WriteLine("###############  TEM DE TUDO MERCADO  ###############");
            Console.WriteLine("");
            Console.WriteLine("1 - Registrar Venda\n2 - Configuração Banco de dados\n3 - Sair");
            Console.WriteLine("\n####################################################");


            int.TryParse(Console.ReadLine(), out int option);

            switch (option)
            {
                case 1:
                    break;
                case 2:
                    DataBaseScreen.Show();
                    break;
                case 3:
                    Console.Clear();
                    break;
                default:
                    Console.WriteLine("ESCOLHA INVÁLIDA !");
                    Console.ReadKey();
                    Show();
                    break;
            }
        }

        public static void ApplyDefaultScreenColors()
        {
            Console.BackgroundColor = DfBackgroundColor;
            Console.ForegroundColor = DfForegroundColor;
        }

        public static void ErrorMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(message);
        }

        public static void ConfirmedMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
        }

    }
}