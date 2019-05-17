﻿using System;
using System.Text;
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
        public WebResult Get()
        {
            HttpRequest request = Request;
            string type = request.Query["type"];
            string dataType = request.Query["datatype"];
            string data = request.Query["data"];
            try
            {
                if (type == "encode")
                {
                    
                    switch (dataType)
                    {
                        case "text":
                            
                            if (string.IsNullOrWhiteSpace(data)) break;
                            var base64 = _base64.ToBase64(Encoding.UTF8, data);
                            return new WebResult
                            {
                                Code = 1,
                                Data = base64
                            };
                    }
                }
                else if (type == "decode")
                {
                    switch (dataType)
                    {
                        case "text":
                            if (string.IsNullOrWhiteSpace(data)) break;
                            var code = _base64.FromBase64(Encoding.UTF8, data);
                            return new WebResult
                            {
                                Code = 1,
                                Data = code
                            };
                    }
                }

                return new WebResult
                {
                    Code = 2,
                    Data = "参数错误"
                };
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"错误类型{type}");
                return new WebResult();
            }
        }

        // POST: api/Base64
        [HttpPost]
        public void Post()
        {

        }
    }
}