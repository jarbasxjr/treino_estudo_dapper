using Dapper.Contrib.Extensions;

namespace mercadinho.Models
{
    [Table("[Brand]")]
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}