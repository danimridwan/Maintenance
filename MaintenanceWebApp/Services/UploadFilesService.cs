using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.IO; 

namespace MaintenanceWebApp.Services
{
    public class UploadFilesService
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _configuration;
        private readonly ILogger<UploadFilesService> _logger;
        private const long MaxFileSize = 3 * 1024 * 1024; // 3MB

        public string? FilePath { get; private set; }

        public string? UploadErrorMessage { get; private set; }

        public UploadFilesService(IConfiguration configuration, ILogger<UploadFilesService> logger, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _logger = logger;
            _env = env;
        }

        public async Task FilesUpload(IBrowserFile file, string folderName, string subFolderName, string fileCategory)
        {
            UploadErrorMessage = null;
            FilePath = null;

            if (file == null)
            {
                UploadErrorMessage = "Tidak ada file yang dipilih.";
                return;
            }

            // File Size Validation
            if (file.Size > MaxFileSize)
            {
                UploadErrorMessage = $"Ukuran file melebihi batas maksimum {MaxFileSize / (1024 * 1024)}MB.";
                return;
            }

            var fileExtension = Path.GetExtension(file.Name).ToLowerInvariant();

            // Validasi ekstensi file
            if (fileCategory == null)
            {
                UploadErrorMessage = "Konfigurasi 'File Category' tidak ditemukan atau kosong. Hubungi administrator.";
                return;
            }
            else
            {
                //Image
                if (fileCategory == "img")
                {
                    if (!new[] { ".jpg", ".jpeg", ".png" }.Contains(fileExtension))
                    {
                        UploadErrorMessage = "Format file tidak didukung. Harap unggah file JPG, JPEG, atau PNG.";
                        return;
                    }
                }
                //Document
                else if (fileCategory == "doc")
                {
                    if (!new[] { ".pdf", ".doc", ".docx", ".xls", ".xlsx", ".ppt", ".pptx" }.Contains(fileExtension))
                    {
                        UploadErrorMessage = "Format file tidak didukung. Harap unggah file PDF, DOC, DOCX, XLS, XLSX, PPT, atau PPTX.";
                        return;
                    }
                }
            }

            try
            {
                var basePath = Path.Combine(_env.WebRootPath, "uploads", "images", subFolderName);

                if (string.IsNullOrWhiteSpace(basePath))
                {
                    UploadErrorMessage = "Konfigurasi 'FileStorageInventories' tidak ditemukan atau kosong. Hubungi administrator.";
                    return;
                }

                // Uniqe subfolder as category
                var directoryPath = Path.Combine(basePath, folderName);

                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                // Make a new file name
                var newFileName = $"{Guid.NewGuid()}{fileExtension}";
                var fullFilePath = Path.Combine(directoryPath, newFileName);

                // Save file to folder
                await using (var stream = file.OpenReadStream(MaxFileSize)) // MaxFileSize as buffer limit
                {
                    await using (var fileStream = new FileStream(fullFilePath, FileMode.Create, FileAccess.Write, FileShare.None, 4096, useAsync: true))
                    {
                        await stream.CopyToAsync(fileStream);
                    }
                }

                // Save Relative Path
                FilePath = Path.Combine(folderName, newFileName).Replace("\\", "/");
                return;
            }
            catch (IOException ioEx)
            {
                UploadErrorMessage = "Terjadi masalah saat menyimpan file. Periksa izin folder atau ruang disk.";
                return;
            }
            catch (UnauthorizedAccessException uaEx)
            {
                UploadErrorMessage = "Akses ditolak saat mencoba menyimpan file. Periksa izin tulis untuk folder penyimpanan.";
                return;
            }
            catch (Exception ex)
            {
                UploadErrorMessage = "Gagal mengunggah file. Silakan coba lagi. (Kesalahan tidak terduga)";
                return;
            }
        }

        public async Task FileChange(string? currentRelativePath, string subFolderName)
        {
            UploadErrorMessage = null;

            if (string.IsNullOrWhiteSpace(currentRelativePath))
            {
                UploadErrorMessage = "Konfigurasi 'Relative Path' tidak ditemukan atau kosong.";
                FilePath = null;
                return;
            }

            if (string.IsNullOrWhiteSpace(subFolderName))
            {
                UploadErrorMessage = "Konfigurasi 'Sub Folder' tidak ditemukan atau kosong.";
                FilePath = null;
                return;
            }

            var basePath = Path.Combine(_env.WebRootPath, "uploads", "images", subFolderName);

            if (string.IsNullOrWhiteSpace(basePath))
            {
                UploadErrorMessage = "Konfigurasi 'Base Path' tidak ditemukan atau kosong.";
                FilePath = null;
                return;
            }

            var fullPathToDelete = Path.Combine(basePath, currentRelativePath);

            try
            {
                if (File.Exists(fullPathToDelete))
                {
                    //Delete File
                    File.Delete(fullPathToDelete);
                }
                else
                {
                    UploadErrorMessage = "File tidak ditemukan.";
                    return;
                }
            }
            catch (IOException ioEx)
            {
                UploadErrorMessage = $"IO Exception Error : {ioEx.Message}";
                return;
            }
            catch (UnauthorizedAccessException uaEx)
            {
                UploadErrorMessage = $"Unauthorized Access Exception Error : {uaEx.Message}";
                return;
            }
            catch (Exception ex)
            {
                UploadErrorMessage = $"Exception Error : {ex.Message}";
                return;
            }
            finally
            {
                FilePath = null;
            }
        }
    }
}