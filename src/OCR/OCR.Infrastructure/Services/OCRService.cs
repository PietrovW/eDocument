
using System;
using Tesseract;

namespace OCR.Infrastructure.Services
{
    public class OCRService : IOCRService, IDisposable
    {
        private TesseractEngine _tesseractEngine;
        public OCRService(TesseractEngine tesseractEngine)
        {
            _tesseractEngine = tesseractEngine;
        }
        public void Dispose()
        {
            this._tesseractEngine.Dispose();
        }

        public string GetText(byte[] bytes)
        {
                using (var img = Pix.LoadFromMemory(bytes))
                {
                    using (var page = _tesseractEngine.Process(img))
                    {
                    }
                }
                return "";
            }
        }
}
