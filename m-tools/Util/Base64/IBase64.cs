using System.Text;

namespace m_tools.Util.Base64
{
    public interface IBase64
    {
        /// <summary>
        /// 字符串转换为Base64
        /// </summary>
        /// <param name="encode">编码方式</param>
        /// <param name="rawData">需要转换的字符串</param>
        /// <returns>Base64编码</returns>
        string ToBase64(Encoding encode, string rawData);

        /// <summary>
        /// Base64解码为字符串
        /// </summary>
        /// <param name="encode">编码方式</param>
        /// <param name="rawData">编码</param>
        /// <returns>解码后字符串</returns>
        string FromBase64(Encoding encode, string rawData);
    }
}
