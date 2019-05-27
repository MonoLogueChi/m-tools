namespace m_tools.Models
{
    public enum Base64CodeType
    {
        Encode = 0,
        Decode = 1
    }

    public class Base64RawData<T>
    {
        public Base64CodeType Type { get; set; }
        public T RawData { get; set; }
    }
}
