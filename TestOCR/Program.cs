using System.Collections.Generic;
using System.IO;

namespace TestOCR
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var testImagePath = "./racun_1.png";
            //var testImagePath = "./racun_2.png";
            //var testImagePath = "./racun_3.png";
            //var testImagePath = "./slip_1.png";

            var imageLines = ImageProcessor.Convert(testImagePath);

            var result = RecognitionStrategy.Process(imageLines);

            File.WriteAllTextAsync("result.txt", result);
        }
    }
}