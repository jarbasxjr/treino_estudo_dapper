using Dapper.Contrib.Extensions;

namespace mercadinho.Models
{
    [Table("[Product]")]
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public int Category_Id { get; set; }
        public int Type_Id { get; set; }
        public int Brand_Id { get; set; }
    }
}