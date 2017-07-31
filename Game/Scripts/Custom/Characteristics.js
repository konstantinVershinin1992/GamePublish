var plusButtons = document.getElementsByClassName("plusButton");
if(plusButtons != null)
 if(plusButtons.length > 0) {
     for (var i = 0; i < plusButtons.length; i++)
         plusButtons[i].onclick = ButtonPlus;
}
function ButtonPlus(e){
    alert(e.currentTarget.id);
}