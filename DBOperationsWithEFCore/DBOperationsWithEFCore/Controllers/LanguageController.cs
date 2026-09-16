using DBOperationsWithEFCore.Data;
using DBOperationsWithEFCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Runtime.CompilerServices;

namespace DBOperationsWithEFCore.Controllers
{
    [Route("api/Languages")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LanguageController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllLanguages()
        {
            //var Result =await _context.Languages.ToListAsync(); // get all columns

            var Result = await _context.Languages.Select(x=> // select only specific columns
                new Language  // we can map anonymous object here, only use "new"  not new Language 
                {
                    Id = x.Id,  
                    Title= x.Title
                }
            ).ToListAsync();
             
                
    
            return Ok(Result);
        }
        //[HttpGet("{id:int}")] // specifiy int , to avoid ambiguity error of multiple matching end points    
        //public async Task<IActionResult> GetLanguageById([FromRoute] int id)
        //{
        //    var Result = await _context.Languages.FindAsync(id);
        //    return Ok(Result);
        //}

        // get by using single parameter from route
        [HttpGet("{name}")]
        public async Task<IActionResult> GetLanguageByName([FromRoute] String Name)
        {
            //var Result = await _context.Languages.Where(x => x.Title == name).FirstOrDefaultAsync();  
            // get single record
            //var Result = await _context.Languages.FirstOrDefaultAsync(x => x.Title == Name); // writing where inside has better query performance

            // get all records matching the parameter
            var Result = await _context.Languages.Where(x=> x.Title==Name).ToListAsync(); 
            return Ok(Result);
        }

        // get using multiple parameters from route and query
        [HttpGet("{id:int}/{name}")]
        public async Task<IActionResult> GetLanguageByIdOrName([FromRoute] int id, [FromRoute] string name)
        {
            var Result = await _context.Languages.FirstOrDefaultAsync
                (x => x.Id == id && string.IsNullOrEmpty(name) || x.Title==name ); // if name is null only return by id , name is optional - remove null and || to make name mandatory
            return Ok(Result);
        }

        // get records based on [1,2,3 ..., N] ids
        [HttpPost("all")]
        public async Task<IActionResult> GetLanguageByIds([FromBody] List<int> ids)
        {
            var Result = await _context.Languages.Where
                (x => ids.Contains(x.Id))
                .ToListAsync();
                
            return Ok(Result);
        }




    }
}
