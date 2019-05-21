using System;

namespace TradePMR.DanielSerrano.Common
{
    public class InvalidTradeAccountIdException : Exception
    {
        public InvalidTradeAccountIdException() : base() { }
        public InvalidTradeAccountIdException(string message) : base(message) { }
        public InvalidTradeAccountIdException(string message, Exception innerException) : base(message, innerException) { }
    }
}
