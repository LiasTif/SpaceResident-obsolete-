using SpaceResidentClient.Services;
using System.ComponentModel;

namespace SpaceResidentClient.ViewModels.Windows.Interfaces
{
    internal interface IWindowNavigationStore : INotifyPropertyChanged
    {
        NavigationStore NavigationStore { get; set; }
    }
}