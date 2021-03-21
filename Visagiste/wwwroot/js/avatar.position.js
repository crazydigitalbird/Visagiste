el = document.querySelector("#avatar");
b1 = document.querySelector("#btnSubmit");

startPositionX = 0;
startPositionY = 0;
startPositionCursX = 0;
startPositionCursY = 0;

el.addEventListener("mousemove", (e) => {
    if (event.which == 1) {
        x = startPositionX + e.offsetX - startPositionCursX;
        y = startPositionY + e.offsetY - startPositionCursY;
        if (x > 0) {
            x = 0;
        }
        //if (x < -160) {
        //    x = -160;
        //}

        if (y > 0) {
            y = 0;
        }
        //if (y < -160) {
        //    y = -160;
        //}

        el.style.backgroundPositionX = x + "px";
        el.style.backgroundPositionY = y + "px";
    }
});

el.addEventListener("mousedown", (e) => {
    if (el.style.backgroundPositionX != "") {
        startPositionX = parseInt(el.style.backgroundPositionX);
    }
    if (el.style.backgroundPositionY != "") {
        startPositionY = parseInt(el.style.backgroundPositionY);
    }
    startPositionCursX = e.offsetX;
    startPositionCursY = e.offsetY;
});

el.addEventListener("touchmove", (e) => {

    var touch = event.touches[0] || event.changedTouches[0];
    x = startPositionX + touch.pageX - startPositionCursX;
    y = startPositionY + touch.pageY - startPositionCursY;
        if (x > 0) {
            x = 0;
        }
        //if (x < -160) {
        //    x = -160;
        //}

        if (y > 0) {
            y = 0;
        }
        //if (y < -160) {
        //    y = -160;
        //}

        el.style.backgroundPositionX = x + "px";
        el.style.backgroundPositionY = y + "px";
});

el.addEventListener("touchstart", (e) => {
    if (el.style.backgroundPositionX != "") {
        startPositionX = parseInt(el.style.backgroundPositionX);
    }
    if (el.style.backgroundPositionY != "") {
        startPositionY = parseInt(el.style.backgroundPositionY);
    }
    var touch = event.touches[0] || event.changedTouches[0];
    startPositionCursX = touch.pageX;
    startPositionCursY = touch.pageY;
});

b1.addEventListener("click", (e) => {
    x = document.querySelector("#Avatar_X");
    y = document.querySelector("#Avatar_Y");
    x.setAttribute("value", el.style.backgroundPositionX);
    y.setAttribute("value", el.style.backgroundPositionY);
});