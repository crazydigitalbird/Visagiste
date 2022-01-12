divAvatar = document.querySelector("#avatar");
btnSave = document.querySelector("#btnSave");
inputAvatarFile = document.querySelector('input[name="AvatarFile"]');

widthAvatar = 0;
heightAvatar = 0;

startPositionX = 0;
startPositionY = 0;
startPositionCursX = 0;
startPositionCursY = 0;

loadImage();

function loadImage() {
    var imageSrc = divAvatar
        .style.backgroundImage.replace(/url\((['"])?(.*?)\1\)/gi, '$2');

    // I just broke it up on newlines for readability
    readSizeAvatar(imageSrc);
}

function readSizeAvatar(imageSrc) {
    var image = new Image();
    image.src = imageSrc;

    image.onload = function () {
        widthAvatar = image.width;
        heightAvatar = image.height;
    };
}

divAvatar.addEventListener("mousedown", (e) => {
    GetPositionAvatar();
    startPositionCursX = e.offsetX;
    startPositionCursY = e.offsetY;
});

divAvatar.addEventListener("mousemove", (e) => {
    if (event.which == 1) {
        x = startPositionX + e.offsetX - startPositionCursX;
        y = startPositionY + e.offsetY - startPositionCursY;
        SetPositionAvatar(x, y);
    }
});

divAvatar.addEventListener("touchstart", (e) => {
    GetPositionAvatar();
    var touch = event.touches[0] || event.changedTouches[0];
    startPositionCursX = touch.pageX;
    startPositionCursY = touch.pageY;
});

divAvatar.addEventListener("touchmove", (e) => {
    var touch = event.touches[0] || event.changedTouches[0];
    x = startPositionX + touch.pageX - startPositionCursX;
    y = startPositionY + touch.pageY - startPositionCursY;
    SetPositionAvatar(x, y);
});

function GetPositionAvatar() {
    if (divAvatar.style.backgroundPositionX != "") {
        startPositionX = parseInt(divAvatar.style.backgroundPositionX);
    }

    if (divAvatar.style.backgroundPositionY != "") {
        startPositionY = parseInt(divAvatar.style.backgroundPositionY);
    }
}

function SetPositionAvatar(x, y) {
    if (x > 0 || widthAvatar < heightAvatar) {
        x = 0;
    }
    else if (x < -(widthAvatar / heightAvatar * 160 - 160)) {
        x = -(widthAvatar / heightAvatar * 160 - 160);
    }

    if (y > 0 || heightAvatar < widthAvatar) {
        y = 0;
    }
    else if (y < -(heightAvatar / widthAvatar * 160 - 160)) {
        y = -(heightAvatar / widthAvatar * 160 - 160);
    }

    divAvatar.style.backgroundPositionX = x + "px";
    divAvatar.style.backgroundPositionY = y + "px";
}

btnSave.addEventListener("click", (e) => {
    x = document.getElementById("Avatar_X");
    y = document.getElementById("Avatar_Y");

    x.setAttribute("value", divAvatar.style.backgroundPositionX.replace("px", ""));
    y.setAttribute("value", divAvatar.style.backgroundPositionY.replace("px", ""));
});

inputAvatarFile.addEventListener("change", (e) => {
    var avatarFile = inputAvatarFile.files[0];
    var reader = new FileReader();
    reader.onloadend = function () {
        divAvatar.style.backgroundImage = 'url("' + reader.result + '")';
        divAvatar.style.backgroundPositionX = "0px";
        divAvatar.style.backgroundPositionY = "0px";
        readSizeAvatar(reader.result);
    };

    if (avatarFile) {
        reader.readAsDataURL(avatarFile);
    }
});

var inputBannerOne = document.querySelector('input[name="BannerOne"]');
var divBannerOne = document.querySelector('#bannerOne');
inputBannerOne.addEventListener("change", () => setBackgroundImage(divBannerOne));

var inputBannerTwo = document.querySelector('input[name="BannerTwo"]');
var divBannerTwo = document.querySelector('#bannerTwo');
inputBannerTwo.addEventListener("change", () => setBackgroundImage(divBannerTwo));


function setBackgroundImage(mutabelElement) {
    var file = event.currentTarget.files[0];
    var reader = new FileReader();
    reader.onloadend = function () {
        mutabelElement.style.backgroundImage = 'url("' + reader.result + '")';
    }
    if (file) {
        reader.readAsDataURL(file);
    }
}