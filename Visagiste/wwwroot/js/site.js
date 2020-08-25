window.onload = function () {
    var pathname = window.location.pathname;
    var subpathname = pathname.replace('/Home/', '').toLowerCase();
    switch (subpathname) {
        case '':
        case '/':
        case 'index':
            underlinemenusection('index');
            break;

        case 'collection':
            underlinemenusection('collection');
            break;

        case 'about':
            underlinemenusection('about');
            break;

        case 'services':
            underlinemenusection('services');
            break;

        case 'contact':
            underlinemenusection('contact');
            break;
    }
};

function underlinemenusection(id) {
    var element = document.getElementById(id);
    element.classList.add('colorlib-active');
}