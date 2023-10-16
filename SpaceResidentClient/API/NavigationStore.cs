using CommunityToolkit.Mvvm.ComponentModel;

namespace SpaceResidentClient.API
{
    internal partial class NavigationStore : ObservableObject
    {
        [ObservableProperty]
        public ObservableObject currentViewModel;
    }
}