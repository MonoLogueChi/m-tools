using System.Text;
using m_tools.Models;

namespace m_tools.Util.Base64
{
    public interface IBase64
    {
        /// <summary>
        /// 转换string类型的数据
        /// </summary>
        /// <param name="data">原始数据</param>
        /// <returns></returns>
        WebResult StringResult(Base64RawData<string> data);
    }
}
