using SpaceResidentClient.Services;
using System.ComponentModel;

namespace SpaceResidentClient.Interfaces
{
    internal interface IWindowNavigationStore : INotifyPropertyChanged
    {
        NavigationStore NavigationStore { get; set; }
    }
}