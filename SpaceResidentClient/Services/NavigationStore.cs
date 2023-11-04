using CommunityToolkit.Mvvm.ComponentModel;

namespace SpaceResidentClient.Services
{
    internal partial class NavigationStore : ObservableObject
    {
        [ObservableProperty]
        public ObservableObject currentViewModel;
    }
}