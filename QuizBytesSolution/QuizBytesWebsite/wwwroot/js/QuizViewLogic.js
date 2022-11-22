let sidenav_elements = [{
    id: 1,
    type: "course",
    subtype: "subject",
}];
let subtype_elements= [
    "Subject1",
    "Subject2",
    "Subject3",
    "Subject4"
];

function expand() {

    //Maybe it would work if I add a function which checks if the button that was clicked has the .active css class
    //and if yes removes these items and if not adds them to the #submenu a .active
    //needs to check which element was pressed and retrieve the required data(if Course was pressed then it would retrieve a
    //list of courses and so on)
    //needs to send user to the desired course/subject/ whatever

    let submenu = document.getElementById("submenu");
        //this will go through a for loop to add an <a></a> for each element in an array which will come from
        for (i = 0; i < subtype_elements.length; i++) {
            console.log(i);
            console.log(subtype_elements[i])
            var element = document.createElement('a');
            element.setAttribute('id' ,'submenu-element')
            element.textContent = subtype_elements[i];
            submenu.appendChild(element);
        }
    let opened = true;
    toggleActive(); 
    //if button is pressed again it should close the menu
}

function toggleActive() {
    let sidenav = document.querySelectorAll("div.item");
    let button = document.querySelectorAll("a.submenu-btn")
    let submenu_elements = document.querySelectorAll("#submenu")
    for (let i = 0; i < sidenav.length; i++) {
        button[i].onclick = function () {
            for (let i = 0; i < sidenav.length; i++) {
                if (sidenav[i].classList.contains("active")) {
                    sidenav[i].classList.remove("active");
                    for (let i = 0; i < submenu_elements.length; i++) {
                        $("#submenu-element").remove();
                    }
                }
            }
            sidenav[i].classList.add("active");
        }
    }
}