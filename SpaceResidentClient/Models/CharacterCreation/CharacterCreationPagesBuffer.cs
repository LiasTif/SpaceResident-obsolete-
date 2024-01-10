using CommunityToolkit.Mvvm.ComponentModel;
using SpaceResidentClient.ViewModels.CharacterCreation;
using System.Collections.ObjectModel;
using System.Linq;

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

        public void AddPageToCollection(ObservableObject page)
        {
            if (PagesCollection == null)
                return;

            foreach (ObservableObject curPage in PagesCollection)
            {
                if (curPage.GetType() == page.GetType())
                    return;
            }

            PagesCollection.Add(page);
        }

        private void RemovePageFromCollection(ObservableObject page)
        {
            if (PagesCollection == null)
                return;

            foreach (ObservableObject curPage in PagesCollection)
            {
                if (curPage.GetType() == page.GetType())
                    PagesCollection.Remove(curPage);
            }
        }

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

        private static ObservableObject? characterViewModel;
        public static ObservableObject? CharacterViewModel
        {
            get => characterViewModel;
            set
            {
                if (value is CreationCharacterViewModel)
                    characterViewModel = value;
            }
        }

        private static ObservableObject? skillsViewModel;
        public static ObservableObject? SkillsViewModel
        {
            get => skillsViewModel;
            set
            {
                if (value is CreationSkillsViewModel)
                    skillsViewModel = value;
            }
        }

        private static ObservableObject? jobViewModel;
        public static ObservableObject? JobViewModel
        {
            get => jobViewModel;
            set
            {
                if (value is CreationJobViewModel)
                    jobViewModel = value;
            }
        }

        private static ObservableObject? locationViewModel;
        public static ObservableObject? LocationViewModel
        {
            get => locationViewModel;
            set
            {
                if (value is CreationLocationViewModel)
                    locationViewModel = value;
            }
        }

        private static ObservableObject? statsViewModel;
        public static ObservableObject? StatsViewModel
        {
            get => statsViewModel;
            set
            {
                if (value is CreationStatsViewModel)
                    statsViewModel = value;
            }
        }
    }
}