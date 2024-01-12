using CommunityToolkit.Mvvm.ComponentModel;
using SpaceResidentClient.ViewModels.CharacterCreation;
using System;
using System.Collections.ObjectModel;

namespace SpaceResidentClient.Models.CharacterCreation
{
    public class CharacterCreationPagesBuffer
    {
        private static ObservableCollection<ObservableObject>? pagesCollection;
        public static ObservableCollection<ObservableObject>? PagesCollection
        {
            get => pagesCollection;
            set
            {
                if (value != pagesCollection)
                {
                    pagesCollection = value;
                }
            }
        }

        public static ObservableObject? GetPageFromCollection(Type pageType)
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

        public static void AddPageToCollection(ObservableObject page)
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

        //private static void RemovePageFromCollection(ObservableObject page)
        //{
        //    if (PagesCollection == null)
        //        return;

        //    foreach (ObservableObject curPage in PagesCollection)
        //    {
        //        if (curPage.GetType() == page.GetType())
        //            PagesCollection.Remove(curPage);
        //    }
        //}

        private static ObservableObject? characterCreationViewModel;
        public static ObservableObject? CharacterCreationViewModel
        {
            get => characterCreationViewModel;
            set
            {
                if (value is CharacterCreationViewModel)
                    characterCreationViewModel = value;
            }
        }
    }
}