using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace simple_api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TalkbackController : ControllerBase
    {
        private static Queue<string> _talkbackQueue = new Queue<string>();

        [HttpGet("All")]
        public ActionResult<IEnumerable<string>> GetAll()
        {
            var results = new List<string>();

            while(_talkbackQueue.TryDequeue(out string result))
            {
                results.Add(result);
            }

            return results;
        }

        [HttpGet("Next")]
        public ActionResult<string> GetNext()
        {
            if(!_talkbackQueue.TryDequeue(out string value))
            {
                value = string.Empty;
            }

            return value;
        }

        [HttpPost("New")]
        public void Post(string value) => _talkbackQueue.Enqueue(value);
        
    }
}
