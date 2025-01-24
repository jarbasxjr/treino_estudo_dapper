using mercadinho.Models;
using mercadinho.Repositories;
using Microsoft.Data.SqlClient;

namespace mercadinho.Screens
{
    public class ProductRepository : Repository<Product>
    {
        private readonly SqlConnection _connection;

        public ProductRepository(SqlConnection connection) : base(connection)
            => _connection = connection;



    }
}