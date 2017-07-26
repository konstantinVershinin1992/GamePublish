var btnSelectFile = document.getElementById("file");
btnSelectFile.onchange = showFileName;

function showFileName() {
    var previewAdd = document.getElementById("picBox");
   
    var file = document.querySelector('input[type=file]').files[0];
    var reader = new FileReader();
    reader.addEventListener("load", function () {
       
        previewAdd.src = reader.result;
    }, false);

    if (file) {
        reader.readAsDataURL(file);
    }   
}