function hideModal(modalId) {
    $('#' + modalId).modal('hide');

    setTimeout(function () {
        $('body').removeClass('modal-open');

        $('.modal-backdrop').remove();
    }, 500);
}