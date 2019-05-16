using System;
using System.Text;

namespace m_tools.Util.Base64
{
    public class Base64 : IBase64
    {
        /// <inheritdoc />
        public string ToBase64(Encoding encode, string text)
        {
            byte[] bytes = encode.GetBytes(text);
            return Convert.ToBase64String(bytes);
        }

        /// <inheritdoc />
        public string FromBase64(Encoding encode, string code)
        {
            byte[] bytes = Convert.FromBase64String(code);
            return encode.GetString(bytes);
        }
    }
}
