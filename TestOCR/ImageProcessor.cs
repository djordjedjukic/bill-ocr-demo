using System;
using System.Collections.Generic;
using System.Diagnostics;
using Tesseract;

namespace TestOCR
{
    public static class ImageProcessor
    {
        public static List<string> Convert(string imagePath)
        {
            var imageLines = new List<string>();
            try
            {
                using (var engine = new TesseractEngine(@"./tessdata", "srp_latn", EngineMode.Default))
                {
                    using (var img = Pix.LoadFromFile(imagePath))
                    {
                        using (var page = engine.Process(img))
                        {
                            var line = "";

                            using (var iter = page.GetIterator())
                            {
                                iter.Begin();

                                do
                                {
                                    do
                                    {
                                        do
                                        {
                                            do
                                            {
                                                line += $" {iter.GetText(PageIteratorLevel.Word)}";

                                                if (iter.IsAtFinalOf(PageIteratorLevel.TextLine,
                                                    PageIteratorLevel.Word))
                                                {
                                                    if (!string.IsNullOrWhiteSpace(line))
                                                    {
                                                        imageLines.Add(line);
                                                    }

                                                    line = "";
                                                }
                                            } while (iter.Next(PageIteratorLevel.TextLine, PageIteratorLevel.Word));
                                        } while (iter.Next(PageIteratorLevel.Para, PageIteratorLevel.TextLine));
                                    } while (iter.Next(PageIteratorLevel.Block, PageIteratorLevel.Para));
                                } while (iter.Next(PageIteratorLevel.Block));
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Trace.TraceError(e.ToString());
                Console.WriteLine("Unexpected Error: " + e.Message);
                Console.WriteLine("Details: ");
                Console.WriteLine(e.ToString());
            }

            return imageLines;
        }
    }
}