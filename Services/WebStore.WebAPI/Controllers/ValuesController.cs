using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebStore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private static readonly Dictionary<int, string> _Values = Enumerable.Range(1, 10)
            .Select(i => (Id: i, Value: $"Value-{i}"))
            .ToDictionary(v => v.Id, v => v.Value);

        private readonly ILogger<ValuesController> _Logger;

        public ValuesController(ILogger<ValuesController> Logger) { _Logger = Logger; }

        [HttpGet]
        public IEnumerable<string> GetAll() => _Values.Values;

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            if (!_Values.ContainsKey(id))
            {
                return NotFound();
            }
            return Ok(_Values[id]);
        }

        [HttpGet("count")]
        public int Count() => _Values.Count;

        [HttpPost]
        [HttpPost("add")]
        public IActionResult Add([FromBody] string Value)
        {
            var id = _Values.Count == 0 ? 1 : _Values.Keys.Max() +1;
            _Values[id] = Value;

            return CreatedAtAction(nameof(GetById), id, Value);
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, [FromBody] string Value)
        {
            if (!_Values.ContainsKey(id))
                return NotFound();

            _Values[id] = Value;
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!_Values.ContainsKey(id))
                return NotFound();

            _Values.Remove(id);
            return Ok();
        }
    }
}
