using CommunityToolkit.Mvvm.ComponentModel;
using SpaceResidentClient.ViewModels.CharacterCreation;
using SpaceResidentClient.ViewModels.Windows.Interfaces;
using System;
using System.Collections.ObjectModel;

namespace SpaceResidentClient.Models.CharacterCreation
{
    internal partial class CharacterCreationTabsBuffer : ObservableObject
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

        public ObservableObject? GetTabFromCollection(Type type, PortraitViewModel portraitVM)
        {
            foreach (ObservableObject curTab in TabsCollection)
            {
                if (curTab.GetType() == type)
                    return curTab;
            }

            AddTabToCollection(type, portraitVM);
            return GetTabFromCollection(type, portraitVM);
        }

        private void AddTabToCollection(Type type, PortraitViewModel portraitVM)
        {
            if (type == typeof(CharCreationJobViewModel))
                TabsCollection.Add(new CharCreationJobViewModel(portraitVM));
            else if (type == typeof(CharCreationLocationViewModel))
                TabsCollection.Add(new CharCreationLocationViewModel());
            else if (type == typeof(CharCreationPersonalityViewModel))
                TabsCollection.Add(new CharCreationPersonalityViewModel(portraitVM));
            else if (type == typeof(CharCreationSkillsViewModel))
                TabsCollection.Add(new CharCreationSkillsViewModel());
            else if (type == typeof(CharCreationStatsViewModel))
                TabsCollection.Add(new CharCreationStatsViewModel());
        }
    }
}