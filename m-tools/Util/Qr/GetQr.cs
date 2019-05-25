using Microsoft.AspNetCore.Mvc;
using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using SixLabors.Primitives;
using System.IO;
using ZXing;
using ZXing.QrCode.Internal;

namespace m_tools.Util.Qr
{
    public class GetQr : IGetQr
    {
        private static readonly FontFamily HeiFamily = new FontCollection().Install("AppData/Hei.TTF");
        private static readonly Font HeiFont = new Font(HeiFamily, 20);

        public FileResult GenByZXingNet(string tt)
        {
            var img = GetQrImage(tt);
            var ms = new MemoryStream();
            img.Save(ms, new PngEncoder());
            ms.Seek(0, SeekOrigin.Begin);
            return new FileStreamResult(ms, "image/png");
        }

        public FileResult GenByFlie()
        {
            var fs = new FileStream("AppData/aa2.png", FileMode.Open);
            return new FileStreamResult(fs, "image/png");
        }

        public FileResult BadResult()
        {
            var img = GetQrImage("http://weixin.qq.com/r/PjgpMaTEv-nAreBS920s");
            img.Mutate(x => x.DrawText("Error", HeiFont, new Bgr565(0, 0, 0), new PointF(220, 480)));
            var ms = new MemoryStream();
            img.Save(ms, new PngEncoder());
            ms.Seek(0, SeekOrigin.Begin);
            return new FileStreamResult(ms, "image/png");
        }

        private Image<Bgr565> GetQrImage(string tt)
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
            return writer.Write(writer.Encode(tt));
        }
    }
}