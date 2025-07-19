using Dapper;
using DependencyStore.Models;
using DependencyStore.Repositories.Interfaces;
using Microsoft.Data.SqlClient;

namespace DependencyStore.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly SqlConnection _connection;
        public CustomerRepository(SqlConnection connection)
        {
            _connection = connection;
        }
        public async Task<Customer?> GetCustomerById (string customerId)
        {
            const string query = "SELECT [Id], [Name], [Email] FROM CUSTOMER WHERE ID=@id";
            return await _connection.QueryFirstOrDefaultAsync<Customer>(query, new { id = customerId });
        }
    }
}
