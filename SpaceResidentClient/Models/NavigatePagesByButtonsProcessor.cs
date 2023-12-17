using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace SpaceResidentClient.Models
{
    public class NavigatePagesByButtonsProcessor
    {
        public ObservableCollection<RadioButton> Pages { private get; set; }

        public void NavigatePages(bool isNext)
        {
            if (Pages == null || Pages.Count < 2)
                return;

            for (int i = 0; i < Pages.Count; i++)
            {
                if (isNext && i != Pages.Count - 1 && Pages[i].IsChecked == true)
                {
                    Pages[i].IsChecked = false;
                    Pages[i + 1].IsChecked = true;
                    Pages[i + 1].Command.Execute(null);
                    return;
                }
                else if (!isNext && i - 1 >= 0 && Pages[i].IsChecked == true)
                {
                    Pages[i].IsChecked = false;
                    Pages[i - 1].IsChecked = true;
                    Pages[i - 1].Command.Execute(null);
                }
            }
        }

        public NavigatePagesByButtonsProcessor(ObservableCollection<RadioButton> pages)
        {
            Pages = pages;
        }
    }
}