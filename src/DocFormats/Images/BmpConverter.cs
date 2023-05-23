namespace Cims.WorkflowLib.DocFormats.Images
{
    /// <summary>
    /// 
    /// </summary>
    public class BmpConverter : BaseImageConverter, IImageConverter
    {
        /// <summary>
        /// 
        /// </summary>
        public void TextToImg(string text, string foldername, string filename)
        {
            base.CheckText(text); 
            base.CheckFolderName(foldername); 
            base.CheckFileName(filename); 

            // 
        }

        /// <summary>
        /// 
        /// </summary>
        public void BinaryToImg(byte[] bytes, string foldername, string filename)
        {
            base.CheckFolderName(foldername); 
            base.CheckFileName(filename); 

            // 
        }

        /// <summary>
        /// 
        /// </summary>
        public byte[] ImgToBinary(string foldername, string filename)
        {
            // 
            base.CheckFolderName(foldername); 
            base.CheckFileName(filename); 

            return new byte[1]; 
        }
    }
}