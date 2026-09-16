using DBOperationsWithEFCore.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DBOperationsWithEFCore.Controllers
{
    [Route("api/currencies")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
       private readonly AppDbContext _context;

        public CurrencyController(AppDbContext context)
        {
            _context = context;
        }
        [Route("")]
        public IActionResult GetAllCurrencies()
        {
            //var result = _context.Currencies.ToList(); // LINQ 

            var result = (from Currencies in _context.Currencies
                          select Currencies).ToList();  // LINQ query - writing format like sql queries
            return Ok(result);
        }
    }
}
