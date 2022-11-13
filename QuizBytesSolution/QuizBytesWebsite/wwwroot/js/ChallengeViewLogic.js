//0.Button must act based on 'var registered' (if is true then it will deregister and if is false will move on to next step)
//1. Button must check if there are available spots on click
//2. Button must either register or spit out an error based on result
//3. button must change text
var registered = false; // this will be replaced by another variable to handle retrieving data from db(indirectly)
var availableSpaces;
$("#register-button-logic").ready(
function changeButtonLogicToHandleRegisterAndDeregister() {
    if (registered==false && availableSpaces>0) {
        document.getElementById("register-button-logic").innerHTML = "FOR THE HORDE";
        //calls method that adds user from challenge table
    }
    if (registered) {
        document.getElementById("register-button-logic").innerHTML = "Deserter!";
        //calls method that removes user from challenge table
    }
    else {
        document.getElementById("error-message").innerHTML = "Sorry, the challenge has already started or there are no available spaces!";
    }

})