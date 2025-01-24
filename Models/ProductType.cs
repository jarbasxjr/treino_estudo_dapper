using Dapper.Contrib.Extensions;

namespace mercadinho.Models
{
    [Table("[ProductType]")]
    public class ProductType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}