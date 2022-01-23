window.onload = function () {
    var pathname = window.location.pathname;

    if (pathname.includes("Admin")) {
        var subpathname = pathname.replace('Admin', '').replaceAll('/', '').toLowerCase();
        switch (subpathname) {
            case '':
            case '/':
            case 'index':
                underlinemenusection('profile');
                break;

            case 'collection':
                underlinemenusection('editCollection');
                break;

            default:
                underlinemenusection(subpathname);
                break;
        }
    }
    else {
        var subpathname = pathname.replace('Home', '').replaceAll('/', '').toLowerCase();
        switch (subpathname) {
            case '':
            case '/':
                underlinemenusection('index');
                break;

            default:
                underlinemenusection(subpathname);
                break;
        }
    }
};

function underlinemenusection(id) {
    var element = document.getElementById(id);
    element.classList.add('colorlib-active');
}