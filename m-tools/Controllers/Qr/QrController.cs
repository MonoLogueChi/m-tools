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
        public readonly IGetQr GetQr;
        public readonly ILogger<QrController> Logger;

        public QrController(IGetQr getQr, ILogger<QrController> logger)
        {
            GetQr = getQr;
            Logger = logger;
        }

        // GET: api/QR
        [HttpGet]
        public FileResult Get()
        {
            string data = Request.Query["data"];
            data = string.IsNullOrWhiteSpace(data) ? "http://weixin.qq.com/r/PjgpMaTEv-nAreBS920s" : data;
            try
            {
                return GetQr.GenByZXingNet(data);
            }
            catch (Exception e)
            {
                Logger.LogError(e, $"错误参数:{data}");
                return GetQr.GenByFlie();
            }
        }

        [HttpPost]
        public FileResult Post()
        {
            string data = Request.Form["data"];
            data = string.IsNullOrWhiteSpace(data) ? "http://weixin.qq.com/r/PjgpMaTEv-nAreBS920s" : data;
            try
            {
                return GetQr.GenByZXingNet(data);
            }
            catch (Exception e)
            {
                Logger.LogError(e, $"错误参数:{data}");
                return GetQr.GenByFlie();
            }
        }
    }
}