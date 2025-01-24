using Dapper.Contrib.Extensions;

namespace mercadinho.Models
{
    [Table("[Category]")]
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}