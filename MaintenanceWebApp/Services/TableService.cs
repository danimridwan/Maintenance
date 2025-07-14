using System;
using System.Threading;
using System.Threading.Tasks;

namespace MaintenanceWebApp.Services
{
    public class TableService : IDisposable
    {
        public event EventHandler? OnFilterApplied; // New event

        private Timer? _filterDebounceTimer;
        private const int DebounceInterval = 300; // milliseconds

        private string? _noFilter;

        public string? NoFilter
        {
            get => _noFilter;
            set
            {
                if (_noFilter != value)
                {
                    _noFilter = value;

                    _filterDebounceTimer?.Dispose();
                    _filterDebounceTimer = new Timer(OnFilterDebounced, null, DebounceInterval, Timeout.Infinite);
                }
            }
        }

        private async void OnFilterDebounced(object? state)
        {
            _filterDebounceTimer?.Dispose();
            _filterDebounceTimer = null;

            OnFilterApplied?.Invoke(this, EventArgs.Empty);

        }

        public async Task ApplyFilter(string? filter)
        {
            await Task.CompletedTask; 
        }

        public void Dispose()
        {
            _filterDebounceTimer?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}