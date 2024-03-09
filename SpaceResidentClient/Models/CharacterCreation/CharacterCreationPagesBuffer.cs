using CommunityToolkit.Mvvm.ComponentModel;
using SpaceResidentClient.Interfaces;
using SpaceResidentClient.ViewModels.CharacterCreation;
using SpaceResidentClient.ViewModels.Windows;
using System;
using System.Collections.ObjectModel;

namespace SpaceResidentClient.Models.CharacterCreation
{
    internal partial class CharacterCreationPagesBuffer : ObservableObject
    {
        [ObservableProperty]
        private static ObservableObject? characterCreationViewModel;
        [ObservableProperty]
        private static ObservableCollection<ObservableObject>? pagesCollection;

        /// <summary>
        /// Set character creation view model in CharacterCreationPagesBuffer and return it
        /// </summary>
        /// <param name="vm">Window view model</param>
        /// <returns></returns>
        public ObservableObject InitializeCharacterCreationVM(IWindowNavigationStore vm)
        {
            return CharacterCreationViewModel ??= new CharacterCreationViewModel(vm);
        }

        public ObservableObject? GetPageFromCollection(Type pageType)
        {
            if (PagesCollection == null)
                return null;

            foreach (ObservableObject curPage in PagesCollection)
            {
                if (curPage.GetType() == pageType)
                    return curPage;
            }

            return null;
        }

        public void AddPageToCollection(ObservableObject page)
        {
            if (PagesCollection != null)
            {
                foreach (ObservableObject curPage in PagesCollection)
                {
                    if (curPage.GetType() == page.GetType())
                        return;
                }
            }
            else
            {
                PagesCollection = [];
            }

            PagesCollection.Add(page);
        }
    }
}