using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace SpaceResidentClient.Models
{
    internal class NavigateTabsByButtonsProcessor(ObservableCollection<RadioButton> tabs)
    {
        private ObservableCollection<RadioButton> Tabs { get; set; } = tabs;

        public void NavigateTabs(bool isNext)
        {
            if (Tabs == null || Tabs.Count < 2)
                return;

            for (int i = 0; i < Tabs.Count; i++)
            {
                RadioButton currentTab = Tabs[i];

                if (currentTab.IsChecked == true)
                {
                    RadioButton nextPage;
                    if (isNext)
                        nextPage = i != Tabs.Count - 1 ? Tabs[i + 1] : Tabs[0];
                    else
                        nextPage = i >= 1 ? Tabs[i - 1] : Tabs[^1];

                    currentTab.IsChecked = false;
                    nextPage.IsChecked = true;
                    nextPage.Command.Execute(nextPage.CommandParameter);
                    return;
                }
            }
        }
    }
}