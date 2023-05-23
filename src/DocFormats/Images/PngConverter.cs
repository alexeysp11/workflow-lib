using System.IO; 
using System.Drawing; 
using System.Linq; 

namespace Cims.WorkflowLib.DocFormats.Images
{
    public class PngConverter : BaseImageConverter, IImageConverter
    {
        public void TextToImg(string text, string foldername, string filename)
        {
            base.CheckText(text); 
            base.CheckFolderName(foldername); 
            base.CheckFileName(filename); 

            // 
            MemoryStream ms = new MemoryStream();            
            System.Drawing.Image img = new Bitmap(200, 30, System.Drawing.Imaging.PixelFormat.Format64bppArgb);
            Graphics drawing = Graphics.FromImage(img);
            Font font = new Font("Arial", 30, FontStyle.Bold, GraphicsUnit.Pixel);

            SizeF textSize = drawing.MeasureString(text, font);
            img.Dispose();
            drawing.Dispose();

            //create a new image of the right size
            img = new Bitmap((int)textSize.Width + 30, (int)textSize.Height + 40);
            drawing = Graphics.FromImage(img);
            Color backColor = Color.White;
            Color textColor = Color.FromArgb(1, 119, 245);

            //textColor. = "#0177F5";

            //paint the background
            drawing.Clear(backColor);

            //create a brush for the text
            Brush textBrush = new SolidBrush(textColor);
            drawing.DrawString(text, font, textBrush, 40, 20);
            drawing.Save();
            font.Dispose();
            textBrush.Dispose();
            drawing.Dispose();

            string filepath = Path.Combine(foldername, filename); 
            img.Save(filepath, System.Drawing.Imaging.ImageFormat.Png);
            img.Dispose();
        }

        public void BinaryToImg(byte[] bytes, string foldername, string filename)
        {
            // 
            base.CheckFolderName(foldername); 
            base.CheckFileName(filename); 
        }

        public byte[] ImgToBinary(string foldername, string filename)
        {
            // 
            base.CheckFolderName(foldername); 
            base.CheckFileName(filename); 

            return new byte[1]; 
        }
    }
}