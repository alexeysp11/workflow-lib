using System;
using System.IO;
using System.Reflection;
using System.Data; 
using Xunit;
using Cims.WorkflowLib.DocFormats.Images; 

namespace Cims.Tests.WorkflowLib.DocFormats.Images
{
    public class PngConverterTest
    {
        private string Text = "Hello,_world! 123;532.52,642'2332\"w342\\432/243^w\n(test&something#1@ok)+$32.5~tt`qwerty\ttabulated\n\nTest text was written!";
        private string FolderName = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "PngConverterTest"); 

        #region TextToImg
        [Theory]
        [InlineData(true, true, true)]
        [InlineData(true, true, false)]
        [InlineData(true, false, true)]
        [InlineData(true, false, false)]
        [InlineData(false, true, true)]
        [InlineData(false, true, false)]
        [InlineData(false, false, true)]
        public void TextToImg_OneOrMoreStringParamsEmpty_ReturnsException(bool isTextEmpty, bool isFoldernameEmpty, bool isFilenameEmpty)
        {
            // Arrange 
            string text = isTextEmpty ? string.Empty : Text; 
            string foldername = isFoldernameEmpty ? string.Empty : FolderName; 
            string filename = isFilenameEmpty ? string.Empty : System.Reflection.MethodBase.GetCurrentMethod().Name + ".png"; 

            IImageConverter pngConverter = new PngConverter(); 
            if (!string.IsNullOrEmpty(foldername)) CreateFolderIfNotExists(FolderName); 

            // Act 
            Action act = () => pngConverter.TextToImg(text, foldername, filename); 

            // Assert 
            System.Exception exception = Assert.Throws<System.Exception>(act);
        }

        [Fact]
        public void TextToImg_IncorrectFoldername_ReturnsException()
        {
            // Arrange 
            string foldername = "incorrect path"; 
            string filename = System.Reflection.MethodBase.GetCurrentMethod().Name + ".png"; 

            IImageConverter pngConverter = new PngConverter(); 

            // Act 
            Action act = () => pngConverter.TextToImg(Text, foldername, filename); 

            // Assert 
            System.Exception exception = Assert.Throws<System.Exception>(act);
        }

        [Fact]
        public void TextToImg_IncorrectFileExtenstion_ReturnsException()
        {
            // Arrange 
            string filename = System.Reflection.MethodBase.GetCurrentMethod().Name + ".jpg"; 

            IImageConverter pngConverter = new PngConverter(); 
            CreateFolderIfNotExists(FolderName); 

            // Act 
            Action act = () => pngConverter.TextToImg(Text, FolderName, filename); 

            // Assert 
            System.Exception exception = Assert.Throws<System.Exception>(act);
        }

        [Fact]
        public void TextToImg_CorrectParameters_ImageExists()
        {
            // Arrange
            string filename = System.Reflection.MethodBase.GetCurrentMethod().Name + ".png"; 

            IImageConverter pngConverter = new PngConverter(); 
            CreateFolderIfNotExists(FolderName); 

            // Act
            pngConverter.TextToImg(Text, FolderName, filename);
            string filepath = Path.Combine(FolderName, filename); 

            // Assert
            Assert.True(File.Exists(filepath)); 
        }
        #endregion  // TextToImg

        #region Private methods
        private void CreateFolderIfNotExists(string foldername)
        {
            if (!Directory.Exists(foldername)) Directory.CreateDirectory(foldername); 
        }
        #endregion  // Private methods
    }
}