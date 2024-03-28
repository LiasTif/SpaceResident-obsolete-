using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace SpaceResidentClient.Models
{
    internal abstract partial class ComboBoxesRealization : ObservableObject
    {
        public virtual TextBlock? SelectedTextBlock { get; set; }

        private ObservableCollection<TextBlock> textBlocks = [];
        public virtual ObservableCollection<TextBlock> TextBlocks
        {
            get => textBlocks;
            private protected set
            {
                if (textBlocks != value)
                {
                    textBlocks = value;
                    OnPropertyChanged(nameof(textBlocks));
                }
            }
        }

        private protected virtual void UpdateSelectedTB(string text)
        {
            if (SelectedTextBlock != null)
                return;

            foreach (TextBlock tb in TextBlocks)
            {
                if (tb.Text == text)
                    SelectedTextBlock = tb;
            }
        }

        private protected virtual ObservableCollection<TextBlock> SetTBCollection()
        {
            ObservableCollection<TextBlock> result = [];
            foreach (string str in TBContent)
            {
                result.Add(new() { Text = str });
            }

            return result;
        }

        private protected void UpdateTBContent(List<string> content)
        {
            TBContent = content;
            TextBlocks = SetTBCollection();
        }

        private List<string> TBContent = [];
    }
}