let sidebarToggle = true;

function DisplayText() {
    document.querySelectorAll(".nav-list").forEach(element => {
        element.style.display = "block";
    });

    document.getElementById("nav-title").style.display = "block";
}

function expandSidebarIfNeeded() {
    if (sidebarToggle === false) {
        sidebar();
    }
}

function sidebar() {
    if (sidebarToggle == true) {
        // Menutup submenu "Inventory" dan "Administrator" jika sedang terbuka
        const inventorySubmenu = document.getElementById('InventoryList');
        // DIUBAH: Tambahkan pengecekan apakah submenu sedang terbuka (.show)
        if (inventorySubmenu && inventorySubmenu.classList.contains('show')) {
            const collapseInventory = bootstrap.Collapse.getOrCreateInstance(inventorySubmenu);
            collapseInventory.hide();
        }

        const adminSubmenu = document.getElementById('AdministratorConfig');
        // DIUBAH: Tambahkan pengecekan apakah submenu sedang terbuka (.show)
        if (adminSubmenu && adminSubmenu.classList.contains('show')) {
            const collapseAdmin = bootstrap.Collapse.getOrCreateInstance(adminSubmenu);
            collapseAdmin.hide();
        }

        document.getElementById("sidebar").style.width = "90px";

        document.querySelectorAll(".nav-list").forEach(element => {
            element.style.display = "none";
        });

        document.getElementById("nav-title").style.display = "none";
        document.getElementById("nav-title").style.width = "0%";
        document.getElementById("nav-logo").style.width = "100%";
        document.getElementById("nav-logo").style.marginLeft = "32%";

        sidebarToggle = false;
        console.log(sidebarToggle);
        return sidebarToggle;
    } else {
        document.getElementById("sidebar").style.width = "250px";

        document.getElementById("nav-title").style.width = "83.33333333%";
        document.getElementById("nav-logo").style.width = "16.66666667%";
        document.getElementById("nav-logo").style.marginLeft = "0%";

        const myTimeout = setTimeout(DisplayText, 250);

        sidebarToggle = true;
        console.log(sidebarToggle);
        return sidebarToggle;
    }
}