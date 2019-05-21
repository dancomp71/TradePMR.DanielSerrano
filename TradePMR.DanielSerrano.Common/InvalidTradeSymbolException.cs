using System;

namespace TradePMR.DanielSerrano.Common
{
    public class InvalidTradeSymbolException : Exception
    {
        public InvalidTradeSymbolException() : base() { }
        public InvalidTradeSymbolException(string message) : base(message) { }
        public InvalidTradeSymbolException(string message, Exception innerException) : base(message, innerException) { }
    }
}
