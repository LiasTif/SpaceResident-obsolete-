using CommunityToolkit.Mvvm.ComponentModel;
using SpaceResidentClient.ViewModels.CharacterCreation;
using SpaceResidentClient.ViewModels.Windows.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace SpaceResidentClient.Models.CharacterCreation
{
    internal partial class CharacterCreationPagesBuffer : ObservableObject
    {
        [ObservableProperty]
        private static ObservableObject? characterCreationViewModel;
        [ObservableProperty]
        private static ObservableCollection<ObservableObject> tabsCollection = [];

        /// <summary>
        /// Set character creation view model in CharacterCreationPagesBuffer and return it
        /// </summary>
        /// <param name="winVM">Window navigation store interface</param>
        /// /// <param name="winScreenMode">Window screen mode interface</param>
        /// <returns>Character creation view model</returns>
        public ObservableObject InitializeCharacterCreationVM(IWindowNavigationStore winVM, IWindowScreenMode winScreenMode)
        {
            return CharacterCreationViewModel ??= new CharCreationMainViewModel(winVM, winScreenMode);
        }

        public ObservableObject? GetTabFromCollection(ObservableObject tab)
        {
            AddTabToCollection(tab);

            foreach (ObservableObject curTab in TabsCollection)
            {
                if (curTab.GetType() == tab.GetType())
                    return curTab;
            }

            return null;
        }

        private void AddTabToCollection(ObservableObject tab)
        {
            foreach (ObservableObject curTab in TabsCollection)
            {
                if (curTab.GetType() == tab.GetType())
                    return;
            }

            TabsCollection.Add(tab);
        }
    }
}