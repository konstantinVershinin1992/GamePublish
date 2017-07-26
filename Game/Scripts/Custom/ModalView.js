$(document).ready(function () {

    $.ajaxSetup({ cache: false });

    $(".viewDialog").on("click", function (e) {
        e.preventDefault();

   var dialogview =  $("<div></div>")
            .addClass("dialog")
            .appendTo("body")
            .dialog({
                title: $(this).attr("data-dialog-title"),
                close: function () { $(this).remove() },
                modal: true,
                width: "45%"                
            })
            
   dialogview.load(this.href);
   dialogview[0].style.width = "90%";
   dialogview[0].top = "50px";
   dialogview[0].clientLeft = "60px";
   dialogview[0].cssText ="width: auto; min-height: 500px; max-height: none; height: 700px;"
    });
});
/* window.onload = function () {
    var button = document.getElementById("bt").onclick = function () {
        
        $.ajax(
            {
                url: "Heroes/Test",
                type: "GET",
                data: { "St": "3", "Lk":55},
                success : resp
                
            }
            );
        
    }
    function resp(responce) {

        alert(responce);
    }
}*/