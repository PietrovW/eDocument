using System;

namespace OCR.Infrastructure.Services
{
    public interface IOCRService
    {
        string GetText(byte[] bytes);
    }
}
