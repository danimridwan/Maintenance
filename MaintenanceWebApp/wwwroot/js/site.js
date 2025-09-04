// namespace utama untuk interop Blazor ke JavaScript.
window.blazorInterop = {

    /**
     * Mendaftarkan event handler untuk mendeteksi klik di luar elemen tertentu.
     * Berguna untuk menutup dropdown atau modal saat pengguna klik di tempat lain.
     * @param {HTMLElement} element - Elemen DOM yang ingin dipantau.
     * @param {DotNetObjectReference} dotNetHelper - Referensi ke objek .NET (Blazor) untuk pemanggilan balik.
     */
    addOutsideClickHandler: (element, dotNetHelper) => {
        // Mendefinisikan fungsi handler yang akan dipanggil saat event 'mousedown' terjadi.
        const handleClick = (event) => {
            // Cek apakah klik terjadi di luar elemen yang dipantau dan elemennya valid.
            if (element && !element.contains(event.target)) {
                // Panggil metode C# di Blazor untuk men-handle klik di luar.
                dotNetHelper.invokeMethodAsync('CloseDropdownOnOutsideClick');
            }
        };

        // Menambahkan listener event ke seluruh dokumen.
        document.addEventListener('mousedown', handleClick);

        // Menyimpan referensi fungsi handler pada elemen itu sendiri,
        // sehingga kita bisa menghapusnya nanti untuk mencegah memory leak.
        element.outsideClickHandler = handleClick;
    },

    /**
     * Menghapus event handler klik di luar elemen.
     * Harus dipanggil saat elemen dihapus dari DOM.
     * @param {HTMLElement} element - Elemen DOM yang handler-nya ingin dihapus.
     */
    removeOutsideClickHandler: (element) => {
        // Memastikan elemen dan handler-nya ada sebelum dihapus.
        if (element && element.outsideClickHandler) {
            // Menghapus listener event dari dokumen.
            document.removeEventListener('mousedown', element.outsideClickHandler);
            // Menghapus properti handler dari elemen.
            delete element.outsideClickHandler;
        }
    },

    /**
     * Mendaftarkan listener untuk memantau navigasi "back" pada browser.
     * Berguna untuk menampilkan konfirmasi atau modal saat pengguna ingin kembali.
     * @param {DotNetObjectReference} dotNetHelper - Referensi ke objek .NET (Blazor) untuk pemanggilan balik.
     */
    promptOnBack: (dotNetHelper) => {
        // Menambahkan entri baru ke riwayat browser, ini memanipulasi tombol "back".
        history.pushState(null, '', location.href);

        // Menyiapkan listener yang akan dipicu saat navigasi "back" terjadi.
        window.onpopstate = () => {
            // Memanggil metode C# di Blazor untuk menangani navigasi kembali.
            dotNetHelper.invokeMethodAsync('HandleBackNavigation');
        };
    },

    /**
     * Membersihkan listener untuk event 'popstate'.
     * Penting untuk dipanggil saat komponen tidak lagi memerlukan listener ini.
     */
    removeOnPopState: () => {
        // Menghapus listener dengan men-set-nya menjadi null.
        window.onpopstate = null;
    },

    /**
     * Mengganti entri riwayat saat ini dengan URL saat ini.
     * Berguna untuk memastikan tombol "back" tidak mengarah ke halaman sebelumnya.
     */
    replaceHistoryState: () => {
        // Mengganti entri riwayat saat ini.
        history.replaceState(null, '', location.href);
    },

    // Fungsi ini akan dipanggil saat modal terbuka
    disableBackButton: () => {
        // Mendorong state baru ke history saat modal dibuka
        history.pushState(null, '', location.href);
        // Tambahkan listener untuk event 'popstate' (saat back/forward ditekan)
        window.addEventListener('popstate', blazorInterop.handleBackButtonTrap);
    },

    // Fungsi ini akan dipanggil saat modal ditutup
    enableBackButton: () => {
        // Hapus listener agar tombol back berfungsi normal kembali
        window.removeEventListener('popstate', blazorInterop.handleBackButtonTrap);
    },

    // Inilah yang "menjebak" tombol back
    handleBackButtonTrap: () => {
        // Saat pengguna menekan back, kita dorong lagi state yang sama ke history.
        // Ini secara efektif "membatalkan" aksi 'back' dan membuat URL tetap sama.
        history.pushState(null, '', location.href);
    }
};

/**
 * Menampilkan modal Bootstrap dengan ID tertentu.
 * @param {string} modalId - ID dari elemen modal yang akan ditampilkan.
 */
function showModal(modalId) {
    // Memanggil metode 'show' dari plugin Bootstrap modal.
    $(`#${modalId}`).modal('show');
}

/**
 * Menyembunyikan modal Bootstrap dengan ID tertentu.
 * @param {string} modalId - ID dari elemen modal yang akan disembunyikan.
 */
function hideModal(modalId) {
    // Memanggil metode 'hide' dari plugin Bootstrap modal.
    $(`#${modalId}`).modal('hide');
}