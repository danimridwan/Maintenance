window.initBootstrapTabs = () => {
    var triggerTabList = [].slice.call(document.querySelectorAll('#nav-tab button'))
    triggerTabList.forEach(function (triggerEl) {
        var tabTrigger = new bootstrap.Tab(triggerEl)

        triggerEl.addEventListener('click', function (event) {
            event.preventDefault()
            tabTrigger.show()
        })
    })
};