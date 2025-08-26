let sidebarToggle = true;

function DisplayText() {
    document.querySelectorAll(".nav-list").forEach(element => {
        element.style.display = "block";
    });

    document.getElementById("nav-title").style.display = "block";
}
function sidebar() {
    if (sidebarToggle == true) {
        document.getElementById("sidebar").style.width = "80px";

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
