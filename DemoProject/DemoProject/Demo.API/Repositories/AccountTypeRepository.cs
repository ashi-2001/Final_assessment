using Dapper;
using Demo.API.Interfaces;
using Demo.API.Model;
using System.Data;

namespace Demo.API.Repositories
{
    public class AccountTypeRepository : IAccountTypeRepository
    {
        public IDapperDbConnection _dapperDbConnection;
        public AccountTypeRepository(IDapperDbConnection dapperDbConnection)
        {
            _dapperDbConnection = dapperDbConnection;
        }
        public async Task<IEnumerable<account_type>> GetAllAccountTypeAsync()
        {
            using (IDbConnection db = _dapperDbConnection.CreateConnection())
            {
                return await db.QueryAsync<account_type>("select id,name from account_type");
            }
        }

        public async Task<account_type> GetAccountTypeByIdAsync(int id)
        {
            using (IDbConnection db = _dapperDbConnection.CreateConnection())
            {
                return await db.QueryFirstOrDefaultAsync<account_type>("SELECT * FROM account_type WHERE id = @Id", new { Id = id });
            }
        }

        public async Task<int> CreateAccountTypeAsync(account_type accountType)
        {
            using (IDbConnection db = _dapperDbConnection.CreateConnection())
            {
                const string query = "INSERT INTO account_type (name) VALUES (@Name); SELECT SCOPE_IDENTITY();";
                return await db.ExecuteScalarAsync<int>(query, accountType);
            }
        }

        public async Task<bool> UpdateAccountTypeAsync(account_type accountType)
        {
            using (IDbConnection db = _dapperDbConnection.CreateConnection())
            {
                const string query = "UPDATE Products SET Name = @Name WHERE Id = @Id";
                int rowsAffected = await db.ExecuteAsync(query, accountType);
                return rowsAffected > 0;
            }
        }

        public async Task<bool> DeleteAccountTypeAsync(int id)
        {
            using (IDbConnection db = _dapperDbConnection.CreateConnection())
            {
                const string query = "DELETE FROM Products WHERE Id = @Id";
                int rowsAffected = await db.ExecuteAsync(query, new { Id = id });
                return rowsAffected > 0;
            }
        }

    }
}
