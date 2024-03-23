using SpaceResidentClient.Models.Settings;
using System.Windows;

namespace SpaceResidentClient.ViewModels.Windows.Interfaces
{
    internal interface IWindowScreenMode
    {
        ResizeMode ResizeMode { get; set; }
        WindowState WinState { get; set; }
        WindowStyle WinStyle { get; set; }
        string ModeName { get; set; }

        void UpdateScreenMode(WindowMode mode);
    }
}