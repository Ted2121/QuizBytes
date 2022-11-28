//script for loading up the sidenav-bar and expanding/collapsing it.
//let courses = jQuery.ajax({
//    url: '../Controllers/QuizController/GetCourses',
//    type: 'GET',
//    dataType: "json",
//    success: function (result) {
//        console.log(result);
//    }
//})
//still need to figure out the url to be able to call this here, right now it's being called internally which sucks
let course_list = [{// will retrieve all courses, every course will have to contain an ID as well
        courseName: "Course1",
        id:1
    },
    {
        courseName: "Course2",
        id: 2
    },
    {
        courseName: "Course3",
        id: 3
    },
    {
        courseName: "Course4",
        id: 4
    },
];


let subject_list = [{ //will call the method that will retrieve all subjects in a course via id
    subjectName: "Subject1",
    id: 1
},
    {
        subjectName: "Subject2",
        id: 2
    },
    {
        subjectName: "Subject3",
        id: 3
    },
    {
        subjectName: "Subject4",
        id: 4
    },

];
let unlocked_chapters = [{
    id: 1,
    chapterName:  "Chapter1",
    description:  "Description",
},
    {
        id: 2,
        chapterName: "Chapter2",
        description: "Description",
    }
]
let unlockedable_chapters = [{
    id: 1,
    chapterName: "Chapter1",
    description: "Description",
},
{
    id: 2,
        chapterName: "Chapter2",
            description: "Description",
    }
]
let locked_chapters = [{
    id: 1,
    chapterName: "Chapter1",
    description: "Description",
},
{
    id: 2,
        chapterName: "Chapter2",
            description: "Description",
    }
]


window.onload = function () {
    loadCourses();
    loadSubjects();
    loadUnlockedChapters();
    loadUnlockedableChapters();
    loadLockedChapters();
}

function loadCourses() {
    let courses = document.getElementById("submenuCourses");
    console.log(course_list.length);
    for (i = 0; i < course_list.length; i++) {
        const element = document.createElement('a');
        element.setAttribute('id', 'subtype');
            element.textContent = course_list[i].courseName;
            courses.appendChild(element);
    }
}

function loadSubjects() {
    let subjects = document.getElementById("submenuSubjects");
    for (i = 0; i < subject_list.length; i++) {
        const element = document.createElement('a');
        element.setAttribute('id', 'subtype');
        element.textContent = subject_list[i].subjectName;
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

function loadUnlockedChapters() {
    let unlockedChaptersHTML = document.getElementById("unlocked-chapters");
    for (i = 0; i < unlocked_chapters.length; i++) {
        var card = document.createElement('div');
        this.cardBody = document.createElement('div')
        this.chapterDescription = document.createElement('p')
        this.chapterButtonDiv = document.createElement('div')
        this.chapterButton = document.createElement('button')

        chapterButtonDiv.setAttribute('class', 'cardbody')
        cardBody.setAttribute('class', "card-body")
        card.setAttribute('class', 'chapters');
        chapterButton.setAttribute('class', 'card-link')
        chapterButtonDiv.setAttribute('id', 'startbtn')
        $("#startbtn").on("click", function () {
            //pseudocode for now but it will basically be getChapterById(chapterId) and then it will send it to the QuizController which
            //will pull the questions and answers from the db and create a quiz. After that is done it will load the view.
            location.replace("Quiz")
            console.log(1);
        })

        chapterButton.textContent = "Start Quiz";
        chapterDescription.textContent = unlocked_chapters[i].description;
        card.textContent = unlocked_chapters[i].chapterName;
        chapterButtonDiv.appendChild(this.chapterButton);
        card.appendChild(this.chapterDescription);
        card.appendChild(this.chapterButtonDiv);
        card.appendChild(cardBody);
        unlockedChaptersHTML.appendChild(card);
    }
}
function loadUnlockedableChapters() {
    let unlockedableChaptersHTML = document.getElementById("unlockedable-chapters");
    for (i = 0; i < unlockedable_chapters.length; i++) {
        var card = document.createElement('div');
        this.cardBody = document.createElement('div')
        this.chapterDescription = document.createElement('p')
        this.chapterButtonDiv = document.createElement('div')
        this.chapterButton = document.createElement('a')

        chapterButtonDiv.setAttribute('class', 'cardbody')
        cardBody.setAttribute('class', "card-body")
        card.setAttribute('class', 'chapters');
        chapterButton.setAttribute('class', 'card-link')
        chapterButton.setAttribute('id', 'buybtn')

        chapterButton.textContent = "System.out.println(Wanna buy this?)";
        chapterDescription.textContent = unlockedable_chapters[i].description;
        card.textContent = unlockedable_chapters[i].chapterName;

        chapterButtonDiv.appendChild(this.chapterButton);
        card.appendChild(this.chapterDescription);
        card.appendChild(this.chapterButtonDiv);
        card.appendChild(cardBody);
        unlockedableChaptersHTML.appendChild(card);
    }
}

function loadLockedChapters() {
    let unlockedableChaptersHTML = document.getElementById("locked-chapters");
    for (i = 0; i < locked_chapters.length; i++) {
        var card = document.createElement('div');
        this.cardBody = document.createElement('div')
        this.chapterDescription = document.createElement('p')
        this.chapterButtonDiv = document.createElement('div')
        this.chapterButton = document.createElement('button')

        chapterButtonDiv.setAttribute('class', 'cardbody')
        cardBody.setAttribute('class', "card-body")
        card.setAttribute('class', 'chapters');
        chapterButton.setAttribute('class', 'card-link')

        chapterButton.textContent = "Affordable=false";
        chapterDescription.textContent = locked_chapters[i].description;
        card.textContent = locked_chapters[i].chapterName;

        chapterButtonDiv.appendChild(this.chapterButton);
        card.appendChild(this.chapterDescription);
        card.appendChild(this.chapterButtonDiv);
        card.appendChild(cardBody);
        unlockedableChaptersHTML.appendChild(card);
    }
}

$("#buybtn").on("click", function () {
    //pseudocode for now but it will basically be userPoints - chapterPrice
})
