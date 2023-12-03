using CommunityToolkit.Mvvm.ComponentModel;

namespace SpaceResidentClient.Services
{
    public partial class NavigationStore : ObservableObject
    {
        [ObservableProperty]
        public ObservableObject currentViewModel;
    }
}