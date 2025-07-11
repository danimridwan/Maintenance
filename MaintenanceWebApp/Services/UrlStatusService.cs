using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;

namespace MaintenanceWebApp.Services
{
    public enum StatusType
    {
        None, // Default (No Status)
        CreateSuccess,
        EditSuccess,
        DeleteSuccess,
        OperationFailed
    }

    public class UrlStatusService
    {
        private readonly NavigationManager _navigationManager;

        public UrlStatusService(NavigationManager navigationManager)
        {
            _navigationManager = navigationManager;
        }

        public string? GetAndClearUrlStatusMessage()
        {
            var uri = _navigationManager.ToAbsoluteUri(_navigationManager.Uri);
            string? statusMessage = null;

            // Get Status from Url
            if (QueryHelpers.ParseQuery(uri.Query).TryGetValue("status", out var statusValue))
            {
                // Convert to Enum Type
                if (Enum.TryParse<StatusType>(statusValue.ToString(), true, out var statusEnum)) // 'true' untuk ignore case
                {
                    //Filter by type
                    switch (statusEnum)
                    {
                        case StatusType.CreateSuccess:
                            statusMessage = "Data berhasil ditambahkan.";
                            break;
                        case StatusType.EditSuccess:
                            statusMessage = "Data berhasil diperbarui.";
                            break;
                        case StatusType.DeleteSuccess:
                            statusMessage = "Data berhasil dihapus.";
                            break;
                        case StatusType.OperationFailed:
                            statusMessage = "Operasi gagal. Silakan coba lagi.";
                            break;
                        default:
                            statusMessage = null;
                            break;
                    }
                }
            }

            return statusMessage;
        }
    }
}