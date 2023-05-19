namespace Cims.WorkflowLib.DocFormats.Images
{
    public interface IImageConverter
    {
        void TextToImg(string text, string foldername, string filename); 
        void BinaryToImg(byte[] bytes, string foldername, string filename); 
        byte[] ImgToBinary(string foldername, string filename); 
    }
}