#nullable enable
using System;

namespace MyBlazorServer.Configuration
{
    public class StateContainer
    {
        private string? _savedString;

        private bool _amITracked;

        public bool AmITracked
        {
            get => _amITracked;
            set
            {
                _amITracked = value;
                _savedString = $"New value of {value} set in the State Container component: {DateTime.Now}";
                NotifyStateChanged();
            }
        }

        public string StateChangeString => _savedString;

        public event Action? OnChange;

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
