namespace mercadinho;

using mercadinho.Models;
using mercadinho.Repositories;
using Microsoft.Data.SqlClient;
using Screens;

class Program
{
    private const string CONNECTION_STRING = @"Server=localhost,1433;Database=BigMall;User ID=sa;Password=41aAB698236b03374cdb@;Trust Server Certificate=true";
    static void Main(string[] args)
    {
        Database.Connection = new SqlConnection(CONNECTION_STRING);

        try
        {
            using (Database.Connection)
            {
                MainMenu.Show();
            }
        }
        catch (System.Exception ex)
        {
            MainMenu.ErrorMessage($"ERRO AO TENTAR CONECTAR NO BANCO DE DADOS !\n  {ex.Message}");
        }




    }


}
