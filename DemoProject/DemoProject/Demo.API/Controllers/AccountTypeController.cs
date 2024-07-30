using Demo.API.Interfaces;
using Demo.API.Model;
using Microsoft.AspNetCore.Mvc;

namespace Demo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountTypeController : Controller
    {
        private readonly IAccountTypeRepository _repository;

        public AccountTypeController(IAccountTypeRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<account_type>>> GetAccountTypes()
        {
            var Products = await _repository.GetAllAccountTypeAsync();
            return Ok(Products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<account_type>> GetProduct(int id)
        {
            var Product = await _repository.GetAccountTypeByIdAsync(id);
            if (Product == null)
            {
                return NotFound();
            }
            return Ok(Product);
        }

        [HttpPost]
        public async Task<ActionResult<account_type>> CreateAccountType(account_type Product)
        {
            int newProductId = await _repository.CreateAccountTypeAsync(Product);
            Product.id = newProductId;
            return CreatedAtAction(nameof(GetProduct), new { id = newProductId }, Product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAccountType(int id, account_type Product)
        {
            if (id != Product.id)
            {
                return BadRequest();
            }

            bool updated = await _repository.UpdateAccountTypeAsync(Product);
            if (!updated)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccountType(int id)
        {
            bool deleted = await _repository.DeleteAccountTypeAsync(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
