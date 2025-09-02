using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Shared;

namespace MaintenanceWebApp.Services
{
    public enum StatusType
    {
        None, // Default (No Status)
        CreateSuccess,
        EditSuccess,
        DeleteSuccess,
        ApproveSuccess,
        RejectSuccess,
        OperationFailed
    }

    public class UrlStatusService
    {
        private readonly NavigationManager _navigationManager;

        public UrlStatusService(NavigationManager navigationManager)
        {
            _navigationManager = navigationManager;
        }

        public string? GetStatus()
        {
            var uri = _navigationManager.ToAbsoluteUri(_navigationManager.Uri);
            var queryParameters = QueryHelpers.ParseQuery(uri.Query);

            if (queryParameters.TryGetValue("status", out var status))
            {
                if (Enum.TryParse<StatusType>(status.ToString(), true, out var statusEnum))
                {
                    switch (statusEnum)
                    {
                        case StatusType.CreateSuccess:
                            status = "Data berhasil ditambahkan.";
                            break;
                        case StatusType.EditSuccess:
                            status = "Data berhasil diperbarui.";
                            break;
                        case StatusType.DeleteSuccess:
                            status = "Data berhasil dihapus.";
                            break;
                        case StatusType.ApproveSuccess:
                            status = "PPM berhasil disetujui.";
                            break;
                        case StatusType.RejectSuccess:
                            status = "PPM berhasil ditolak.";
                            break;
                        case StatusType.OperationFailed:
                            status = "Operasi gagal. Silakan coba lagi.";
                            break;
                        default:
                            status = "";
                            break;
                    }

                    return status;
                }
            }

            return null;
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
                        case StatusType.ApproveSuccess:
                            statusMessage = "PPM berhasil diapprove.";
                            break;
                        case StatusType.RejectSuccess:
                            statusMessage = "PPM berhasil direject.";
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