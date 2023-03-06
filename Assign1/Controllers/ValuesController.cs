using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Assign1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public static readonly Dictionary<string, string> newdict = new Dictionary<string, string>();

        //0. GET: api/<ValuesController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(newdict);
        }

        //1. GET api/<ValuesController>/keys/{key}
        [HttpGet("keys/{key}")]
        public IActionResult Get(string key)
        {
            if (newdict.TryGetValue(key, out string value))
            {
                return Ok(new KeyValuePair<string, string>(key, value));
            }
            else
            {
                return NotFound();
            }
        }

        // 2.POST or PUT api/<ValuesController>/keys
        [HttpPost("keys")]
        public IActionResult AddKeyValuePair([FromBody] KeyValuePair<string, string> keyValue)
        {
            if (newdict.ContainsKey(keyValue.Key))
            {
                return Conflict();
            }
            else
            {
                newdict.Add(keyValue.Key, keyValue.Value);
                return Ok();
            }
        }
        // 3
        [HttpPut("keys")]
        public IActionResult UpdateKeyValuePair([FromBody] KeyValuePair<string, string> keyValue)
        {
            if (newdict.ContainsKey(keyValue.Key))
            {
                return Conflict();
            }
            else
            {
                newdict.Add(keyValue.Key, keyValue.Value);
                return Ok();
            }
        }

        // 4. PATCH api/<ValuesController>/keys/{key}/{value}
        [HttpPatch("keys/{key}/{value}")]
        public IActionResult UpdateValue(string key, string value)
        {
            if (newdict.ContainsKey(key))
            {
                newdict[key] = value;
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        // 5.DELETE api/<ValuesController>/keys/{key}
        [HttpDelete("keys/{key}")]
        public IActionResult Delete(string key)
        {
            if (newdict.Remove(key))
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
