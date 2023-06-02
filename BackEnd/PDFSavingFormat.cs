using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Render3D.BackEnd
{
    public class PDFSavingFormat : SavingFormat
    {
        public override void Save(Bitmap ppm, string directory)
        {
            using (Document document = new Document())
            {
                using (PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(directory, FileMode.Create)))
                {
                    document.Open();

                    iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(ppm, ImageFormat.Png);

                    image.SetAbsolutePosition(0, 0);
                    image.ScaleToFit(document.PageSize.Width, document.PageSize.Height);

                    document.Add(image);
                    document.Close();
                }
            }
        }
    }
}
