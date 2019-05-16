using System;
using m_tools.Util.Qr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace m_tools.Controllers.Qr
{
    [Route("api/qr")]
    [ApiController]
    public class QrController : ControllerBase
    {
        private readonly IGetQr _getQr;
        private readonly ILogger<QrController> _logger;

        public QrController(IGetQr getQr, ILogger<QrController> logger)
        {
            _getQr = getQr;
            _logger = logger;
        }

        // GET: api/QR
        [HttpGet]
        public FileResult Get()
        {
            string data = Request.Query["data"];
            data = string.IsNullOrWhiteSpace(data) ? "http://weixin.qq.com/r/PjgpMaTEv-nAreBS920s" : data;
            try
            {
                return _getQr.GenByZXingNet(data);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"错误参数:{data}");
                return _getQr.GenByFlie();
            }
        }

        [HttpPost]
        public FileResult Post()
        {
            string data = Request.Form["data"];
            data = string.IsNullOrWhiteSpace(data) ? "http://weixin.qq.com/r/PjgpMaTEv-nAreBS920s" : data;
            try
            {
                return _getQr.GenByZXingNet(data);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"错误参数:{data}");
                return _getQr.GenByFlie();
            }
        }
    }
}