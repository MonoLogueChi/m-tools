using Microsoft.AspNetCore.Mvc;

namespace m_tools.Util.Qr
{
    public interface IGetQr
    {
        /// <summary>
        /// 生成二维码
        /// </summary>
        /// <param name="tt">参数</param>
        /// <returns>二维码图片</returns>
        FileResult GenByZXingNet(string tt);

        /// <summary>
        /// 错误结果
        /// </summary>
        /// <param name="info">错误提示</param>
        /// <returns>图片</returns>
        FileResult BadResult(string info);
    }
}
