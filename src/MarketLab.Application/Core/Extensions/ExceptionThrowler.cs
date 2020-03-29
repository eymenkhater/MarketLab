using System;

namespace MarketLab.Application.Core.Extensions
{
    public static class ExceptionThrowler
    {
        public static void ThrowIfRejected(this bool result, string message = "İşlem başarısız", int statusCode = 500)
        {
            if (!result)
                throw new Exception(message: message) { HResult = statusCode };
        }
    }
}