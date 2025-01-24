using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace mercadinho.Repositories
{
    public class Repository<T> where T : class
    {
        private readonly SqlConnection _connection;

        public Repository(SqlConnection connection) => _connection = connection;

        public void Create(T model) => _connection.Insert<T>(model);

        public IEnumerable<T> Get() => _connection.GetAll<T>();

        public T Get(int id) => _connection.Get<T>(id);

        public bool Update(T model) => _connection.Update<T>(model);


        public void Delete(int id)
        {
            var model = _connection.Get<T>(id);

            _connection.Delete<T>(model);
        }

    }
}