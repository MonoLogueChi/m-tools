using System;
using System.Text;
using m_tools.Models;

namespace m_tools.Util.Base64
{
    public class Base64 : IBase64
    {
        /// <summary>
        /// 字符串转换为Base64
        /// </summary>
        /// <param name="encode">编码方式</param>
        /// <param name="rawData">需要转换的字符串</param>
        /// <returns>Base64编码</returns>
        private string ToBase64(Encoding encode, string rawData)
        {
            byte[] bytes = encode.GetBytes(rawData);
            return Convert.ToBase64String(bytes);
        }

        /// <summary>
        /// Base64解码为字符串
        /// </summary>
        /// <param name="encode">编码方式</param>
        /// <param name="rawData">编码</param>
        /// <returns>解码后字符串</returns>
        private string FromBase64(Encoding encode, string rawData)
        {
            byte[] bytes = Convert.FromBase64String(rawData);
            return encode.GetString(bytes);
        }

        /// <inheritdoc />
        public WebResult StringResult(Base64RawData<string> data)
        {
            if (string.IsNullOrWhiteSpace(data.RawData))
            {
                return new WebResult
                {
                    Code = 2,
                    Data = "参数错误"
                };
            }

            switch (data.Type)
            {
                case Base64CodeType.Encode:
                    return new WebResult
                    {
                        Code = 1,
                        Data = ToBase64(Encoding.UTF8, data.RawData)
                    };
                case Base64CodeType.Decode:
                    return new WebResult
                    {
                        Code = 1,
                        Data = FromBase64(Encoding.UTF8, data.RawData)
                    };
            }

            return new WebResult();
        }
    }
}
