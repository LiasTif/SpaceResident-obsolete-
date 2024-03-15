using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace SpaceResidentClient.Models
{
    internal class NavigatePagesByButtonsProcessor(ObservableCollection<RadioButton> pages)
    {
        private ObservableCollection<RadioButton> Pages { get; set; } = pages;

        public void NavigatePages(bool isNext)
        {
            if (Pages == null || Pages.Count < 2)
                return;

            for (int i = 0; i < Pages.Count; i++)
            {
                RadioButton currentPage = Pages[i];

                if (isNext && currentPage.IsChecked == true)
                {
                    if (i != Pages.Count - 1)
                    {
                        var nextPage = Pages[i + 1];
                        currentPage.IsChecked = false;
                        nextPage.IsChecked = true;
                        nextPage.Command.Execute(nextPage.CommandParameter);
                    }
                    else
                    {
                        currentPage.IsChecked = false;
                        Pages[0].IsChecked = true;
                        Pages[0].Command.Execute(Pages[0].CommandParameter);
                    }
                    return;
                }
                else if (!isNext && currentPage.IsChecked == true)
                {
                    if (i >= 1)
                    {
                        var nextPage = Pages[i - 1];
                        currentPage.IsChecked = false;
                        nextPage.IsChecked = true;
                        nextPage.Command.Execute(nextPage.CommandParameter);
                    }
                    else
                    {
                        currentPage.IsChecked = false;
                        Pages[^1].IsChecked = true;
                        Pages[^1].Command.Execute(Pages[^1].CommandParameter);
                    }
                    return;
                }
            }
        }
    }
}