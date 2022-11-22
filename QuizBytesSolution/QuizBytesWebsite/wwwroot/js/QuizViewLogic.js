let selected_course = [{
    id: 1,
    type: "course",
    subtype: "subject",
}];
let course_list= [
    "Course1",
    "Course2",
    "Course3",
    "Course4"
];


window.onload = function () {
    loadShit();
}

function loadShit() {
    let submenu_elements = document.querySelectorAll("#submenu");
    let submenu = document.getElementById("submenu");
    console.log(course_list.length);
    for (i = 0; i < course_list.length; i++) {
            console.log(submenu_elements.length)
            console.log(i)
            console.log(course_list[i])
            var element = document.createElement('a');
            element.textContent = course_list[i];
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