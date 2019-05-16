using System.IO;
using Microsoft.AspNetCore.Mvc;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.PixelFormats;
using ZXing;
using ZXing.QrCode.Internal;

namespace m_tools.Util.Qr
{
    public class GetQr : IGetQr
    {
        public FileResult GenByZXingNet(string tt)
        {
            var writer = new ZXing.ImageSharp.BarcodeWriter<Bgr565>();
            writer.Format = BarcodeFormat.QR_CODE;
            writer.Options.Hints.Add(EncodeHintType.CHARACTER_SET, "UTF-8"); //编码问题
            writer.Options.Hints.Add(
                EncodeHintType.ERROR_CORRECTION,
                ErrorCorrectionLevel.H
            );
            const int codeSizeInPixels = 500; //设置图片长宽
            writer.Options.Height = writer.Options.Width = codeSizeInPixels;
            writer.Options.Margin = 1; //设置边框
            var bm = writer.Encode(tt);
            var img = writer.Write(bm);
            var ms = new MemoryStream();
            img.Save(ms, new PngEncoder());
            ms.Seek(0, SeekOrigin.Begin);
            return new FileStreamResult(ms, "image/png");
        }

        public FileResult GenByFlie()
        {
            var fs = new FileStream("App_Data/aa2.png", FileMode.Open);
            return new FileStreamResult(fs, "image/png");
        }
    }
}