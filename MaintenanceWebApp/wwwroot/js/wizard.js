
function nextHeader() {

    var headerGeneral = document.getElementById('headerGeneral');
    var headerSpecific = document.getElementById('headerSpecific');

    var btnNext = document.getElementById('btnNext');
    var btnPreviousSubmit = document.getElementById('btnPreviousSubmit');

    btnNext.style.display = "none";
    btnPreviousSubmit.style.display = "block";

    headerGeneral.classList.remove("active");
    headerGeneral.className += ' disabled';

    headerSpecific.classList.remove("disabled");
    headerSpecific.className += ' active';

}
function previousHeader() {

    btnNext.style.display = "block";
    btnPreviousSubmit.style.display = "none";

    headerGeneral.classList.remove("disabled");
    headerGeneral.className += ' active';

    headerSpecific.classList.remove("active");
    headerSpecific.className += ' disabled';

}