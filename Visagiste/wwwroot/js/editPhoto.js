var inputCustomFile = document.getElementById("cusotmFile");
var labelCustomFile = document.querySelector('label[class="custom-file-label"]');
var img = document.getElementById("img");

inputCustomFile.addEventListener("change", function () {
    var photo = inputCustomFile.files[0];

    var fileReadr = new FileReader();
    fileReadr.onloadend = function () {
        img.src = fileReadr.result;
    };

    if (photo) {
        fileReadr.readAsDataURL(photo);
        labelCustomFile.innerHTML = photo.name;
    }
    else {
        img.src = "";
        labelCustomFile.innerHTML = "Choose file...";
    }
});