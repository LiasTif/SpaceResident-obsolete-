using System.Windows;

namespace SpaceResidentClient.Models.Settings
{
    public class WindowMode(WindowStyle style, WindowState state, ResizeMode resizeMode)
    {
        public WindowStyle Style = style;
        public WindowState State = state;
        public ResizeMode ResizeMode = resizeMode;
    }
}