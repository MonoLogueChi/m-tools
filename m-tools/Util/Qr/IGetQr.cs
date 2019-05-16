using Microsoft.AspNetCore.Mvc;

namespace m_tools.Util.Qr
{
    public interface IGetQr
    {
        FileResult GenByZXingNet(string tt);

        FileResult GenByFlie();
    }
}
