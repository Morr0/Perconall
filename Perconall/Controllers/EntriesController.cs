using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Perconall.Dtos;
using Perconall.Services.EntryService;

namespace Perconall.Controllers
{
    [ApiController]
    [Route("api/v1/entry")]
    public class EntriesController : ControllerBase
    {
        private readonly IEntryService _entryService;

        public EntriesController(IEntryService entryService)
        {
            _entryService = entryService;
        }
        
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddEntryDto addEntryDto)
        {
            await _entryService.Add(addEntryDto).ConfigureAwait(false);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetMany()
        {
            var entries = await _entryService.Get().ConfigureAwait(false);
            return Ok(entries);
        }
    }
}