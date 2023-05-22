using System.ComponentModel;
using System.Runtime.CompilerServices;
using OrderBook.UI.Helpers.ErrorHandler;

namespace OrderBook.UI.ViewModels;

public class ViewModelBase : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    protected void ErrorHandlerService_ErrorOccurred(object? sender, ErrorEventArgs e)
    {
        // Handle the error event by displaying a message to the user
        MessageBox.Show(e.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    protected virtual void RaisePropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
