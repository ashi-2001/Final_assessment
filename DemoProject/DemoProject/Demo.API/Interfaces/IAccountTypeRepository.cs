using Demo.API.Model;

namespace Demo.API.Interfaces
{
    public interface IAccountTypeRepository
    {
        Task<IEnumerable<account_type>> GetAllAccountTypeAsync();
        Task<account_type> GetAccountTypeByIdAsync(int id);
        Task<int> CreateAccountTypeAsync(account_type Product);
        Task<bool> UpdateAccountTypeAsync(account_type Product);
        Task<bool> DeleteAccountTypeAsync(int id);
    }
}
