using System;
using m_tools.Models;
using m_tools.Util.Base64;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace m_tools.Controllers.Base64
{
    [Route("api/base64")]
    [ApiController]
    public class Base64Controller : ControllerBase
    {
        private readonly IBase64 _base64;
        private readonly ILogger<Base64Controller> _logger;

        public Base64Controller(IBase64 base64, ILogger<Base64Controller> logger)
        {
            _base64 = base64;
            _logger = logger;
        }


        // GET: api/Base64
        [HttpGet]
        public object Get()
        {
            HttpRequest request = Request;
            var data = new Base64RawData<string>
            {
                Type = Enum.Parse<Base64CodeType>(request.Query["type"],true),
                RawData = request.Query["raw"]
            };
            try
            {
                return _base64.StringResult(data);
            }
            catch (Exception e)
            {
                _logger.LogError(e,$"错误类型:{data.Type.ToString()}");
                throw;
            }

            
        }

        [HttpPost]
        public object Post([FromBody] Base64RawData<string> data)
        {
            try
            {
                return _base64.StringResult(data);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"错误类型:{data.Type.ToString()}");
                throw;
            }
        }

        // POST: api/Base64
        [HttpPost("From")]
        public object Post([FromForm]string type, [FromForm]string raw)
        {
            var data = new Base64RawData<string>
            {
                Type = Enum.Parse<Base64CodeType>(type, true),
                RawData = raw
            };
            try
            {
                return _base64.StringResult(data);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"错误类型:{data.Type.ToString()}");
                throw;
            }
        }
    }
}