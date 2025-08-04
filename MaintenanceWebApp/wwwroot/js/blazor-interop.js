// Pastikan objek 'bootstrap' dari Bootstrap 5 JS sudah dimuat!
window.initBootstrapTabs = function() {
    console.log("Custom JS: initBootstrapTabs dipanggil!");
    var tabButtons = document.querySelectorAll('button[data-bs-toggle="tab"]');
    tabButtons.forEach(function(button) {
    });

    // Contoh: Mengaktifkan tab pertama secara default
    var firstTabButton = document.querySelector('.nav-tabs button[data-bs-toggle="tab"]:first-child');
    if (firstTabButton && !firstTabButton.classList.contains('active')) {
        var firstTab = new bootstrap.Tab(firstTabButton);
        firstTab.show();
    }
};

// Contoh fungsi JS Interop lainnya jika Anda punya
window.myCustomAlert = (message) => {
    alert(message);
};