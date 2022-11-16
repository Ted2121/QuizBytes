//0.Button must act based on 'var registered' (if is true then it will deregister and if is false will move on to next step)
//1. Button must check if there are available spots on click
//2. Button must either register or spit out an error based on result
//3. button must change text
var registered = false;
registered = DotNet.InvokeMethodAsync('{}', '{}');
var availableSpaces = 0;
$("#register-button-logic").ready(
function changeButtonLogicToHandleRegisterAndDeregister() {
    if (registered === false) {
        document.getElementById("register-button-logic").innerHTML = "FOR THE HORDE";
        $("#register-button-logic").on("click", function () {
            if (availableSpaces > 0) {
                 location.replace("Start")
                document.getElementById("error-message").innerHTML = "You have been registered!";
            }
        })
    }
    if (registered === true) {
        document.getElementById("register-button-logic").innerHTML = "Deserter!";
        $("#register-button-logic").on("click", function () {
            document.getElementById("error-message").innerHTML = "Run away little girl, you're not ready!";
            availableSpaces ++; //this is just going to add an available space whenever someone unregisters(using this just so signify that, it will obviously call a method)
        })
    }
    else if (availableSpaces===0){
        document.getElementById("error-message").innerHTML = "Sorry, the challenge has already started or there are no available spaces!";
        document.getElementById("register-button-logic").innerHTML = "Too bad!";
        $("#register-button-logic").on("click", function () {
            document.getElementById("error-message").innerHTML = "Oi!Told you to bugger off and try next time!";
            $("#register-button-logic").on("click", function () {
                document.getElementById("error-message").innerHTML = "That's it, I'm sending you back to the home page next time!";
            });
            $("#register-button-logic").on("click", function () {
                    location.replace("../Home/index")
                })
        })
    }
})