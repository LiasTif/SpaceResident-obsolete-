using CommunityToolkit.Mvvm.ComponentModel;

namespace SpaceResidentClient.Services
{
    internal partial class NavigationStore : ObservableObject
    {
        [ObservableProperty]
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public ObservableObject currentViewModel;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    }
}