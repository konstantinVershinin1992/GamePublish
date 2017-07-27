var btnSelectFile = document.getElementById("file");
btnSelectFile.onchange = showFileName;

function showFileName() {
    var previewAdd = document.getElementById("picBox");
    var previewEdit = document.getElementById("picBoxEdit");

    var file = document.querySelector('input[type=file]').files[0];
    var reader = new FileReader();
    reader.addEventListener("load", function ()
    {
        if (previewAdd != null) {
            previewAdd.src = reader.result;
        }
        if (previewEdit != null) {
            previewEdit.src = reader.result;
        }
    }, false);

    if (file)
    {
        reader.readAsDataURL(file);
    }   
}