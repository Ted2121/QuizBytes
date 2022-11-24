//script for loading up the sidenav-bar and expanding/collapsing it.
let courseId = 1; // will store the id of the currect course
let course_list= [ // will retrieve all courses
    "Course1",
    "Course2",
    "Course3",
    "Course4"
];

let subject_list = [ //will call the method that will retrieve all subjects in a course via id
    "Subject1",
    "Subject2",
    "Subject3",
    "Subject4"
];
let unlocked_chapters = [ //will store the unlocked chapters and load them before any other chapters
    "Chapter1",
    "Chapter2",
    "Chapter3",
    "Chapter4"
]

let chapter_descriptions = [
    "description"
]

window.onload = function () {
    loadCourses();
    loadSubjects();
    loadChapters();
}

function loadCourses() {
    let courses = document.getElementById("submenuCourses");
    console.log(course_list.length);
    for (i = 0; i < course_list.length; i++) {
        const element = document.createElement('a');
        element.setAttribute('id', 'subtype');
            element.textContent = course_list[i];
            courses.appendChild(element);
    }
}

function loadSubjects() {
    let subjects = document.getElementById("submenuSubjects");
    for (i = 0; i < subject_list.length; i++) {
        const element = document.createElement('a');
        element.setAttribute('id', 'subtype');
        element.textContent = subject_list[i];
        subjects.appendChild(element);
    }
}

function expandCourses() {
            if ($("#submenuCourses").hasClass("activecontent")) {
                $("#submenuCourses").removeClass("activecontent");
                $("#submenuCourses").removeClass("active")
            } else {
                $("#submenuCourses").addClass("activecontent");
                $("#submenuCourses").addClass("active")
            }
}

function expandSubjects() {
    if ($("#submenuSubjects").hasClass("activecontent")) {
        $("#submenuSubjects").removeClass("activecontent");
        $("#submenuSubjects").removeClass("active")
    } else {
        $("#submenuSubjects").addClass("activecontent");
        $("#submenuSubjects").addClass("active")
    }
}

//script for loading chapters on the page

function loadChapters() {
    let chapters = document.getElementById("chapters");
    for (i = 0; i < unlocked_chapters.length; i++) {
        /*const element = document.createElement('div');
        element.setAttribute('class', 'card chapters');
        element.textContent = unlocked_chapters[i];
        chapters.appendChild(element);*/
        chapters.innerHTML = `
<ul>
        <div class="card" style="width: 18rem;">
  <div class="card-body">
    <h5 class="card-title">${unlocked_chapters[i]}</h5>
    <p class="card-text">${chapter_descriptions}.</p>
  </div>
  <div class="card-body">
    <a asp-controller="Quiz" asp-action="Quiz" class="card-link">Start Quiz</a> 
  </div>
</div>
<ul>
`
    }
}

//script for loading chapters on screen.

function goToSelectedElementSubtype() {

}