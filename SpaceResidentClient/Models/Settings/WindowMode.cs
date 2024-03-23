using System.Windows;

namespace SpaceResidentClient.Models.Settings
{
    internal class WindowMode(WindowStyle style, WindowState state, ResizeMode resizeMode, string name)
    {
        public WindowStyle Style { get; private set; } = style;
        public WindowState State { get; private set; } = state;
        public ResizeMode ResizeMode { get; private set; } = resizeMode;
        public string ModeName { get; set; } = name;
    }
}