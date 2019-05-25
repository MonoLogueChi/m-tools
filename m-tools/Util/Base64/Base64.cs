using System;
using System.Text;

namespace m_tools.Util.Base64
{
    public class Base64 : IBase64
    {
        /// <inheritdoc />
        public string ToBase64(Encoding encode, string rawData)
        {
            byte[] bytes = encode.GetBytes(rawData);
            return Convert.ToBase64String(bytes);
        }

        /// <inheritdoc />
        public string FromBase64(Encoding encode, string rawData)
        {
            byte[] bytes = Convert.FromBase64String(rawData);
            return encode.GetString(bytes);
        }
    }
}
