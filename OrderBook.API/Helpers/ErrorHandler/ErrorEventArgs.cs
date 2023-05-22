using System;

namespace OrderBook.UI.Helpers.ErrorHandler;

public class ErrorEventArgs : EventArgs
{
    public string ErrorMessage { get; }

    public ErrorEventArgs(string errorMessage)
    {
        ErrorMessage = errorMessage;
    }
}