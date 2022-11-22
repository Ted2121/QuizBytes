let course = [{
    id: 1,
    type: "course",
    subtype: "subject",
}];
let courses= [
    "Subject1",
    "Subject2",
    "Subject3",
    "Subject4"
];

window.onload = function () {
    loadShit();
}

function loadShit() {
    let submenu_elements = document.querySelectorAll("#submenu");
    let submenu = document.getElementById("submenu");
    console.log(submenu_elements.length);
        for (i = 0; i < subtype_elements.length; i++) {
            console.log(submenu_elements.length)
            console.log(i)
            console.log(subtype_elements[i])
            var element = document.createElement('a');
            element.textContent = subtype_elements[i];
            submenu.appendChild(element);
    }
}

function expand() {
            if ($("#submenu").hasClass("activecontent")) {
                $("#submenu").removeClass("activecontent");
                $("#submenu").removeClass("active")
            } else {
                $("#submenu").addClass("activecontent");
                $("#submenu").addClass("active")
            }
        }