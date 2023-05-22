using System;

namespace OrderBook.UI.Helpers.ErrorHandler;

public static class ErrorHandlerService
{
    public static event EventHandler<ErrorEventArgs>? ErrorOccurred;

    public static void RaiseError(string errorMessage)
    {
        ErrorOccurred?.Invoke(null, new ErrorEventArgs(errorMessage));
    }
}