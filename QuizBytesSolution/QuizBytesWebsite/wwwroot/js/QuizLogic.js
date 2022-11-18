﻿let questions = [{
    id: 1,
    question: "Who is carrying this group?",
    answer: "Ted",
    options: [
        "Kiril",
        "Vladdy",
        "Jacob",
        "Ted",
    ]
    //need to figure out a way to populate this list. Shouldn't be an issue. These two are test questions to see if the quiz and button will work.
},
    {
        id: 2,
        question: "Which of these is the hardest?",
        answer: "That's what she said",
        options: [
            "That's what she said",
            "JavaScript",
            "Java",
            "Making code for NASA using Assembly"
        ]
    }

];

let questionCount = 0;
let points = 0;

window.onload = function () {
    show(questionCount);
}

function show(count) {
    let question = document.getElementById("quiz-questions");
    let [first, second, third, fourth] = questions[count].options;

    question.innerHTML = `<h2 class ="question-text">Q${count +1}. ${questions[count].question}<h2>
        <ul class="question-options">
        <li class="option">${first}</li>
        <li class="option">${second}</li>
        <li class="option">${third}</li>
        <li class="option">${fourth}</li>
        </ul>`
    toggleActive();
    //only works with questions that have 4 answers but I can write a separate method for ones with two answers
    // there id definitely a better way to code this but this works and I don't want to code js anymore today so yeah
}

function toggleActive() {
    let option = document.querySelectorAll("li.option");
    for (let i = 0; i < option.length; i++) {
        option[i].onclick = function () {
            for (let i = 0; i < option.length; i++) {
                if (option[i].classList.contains("active")) {
                    option[i].classList.remove("active");
                }
            }
            option[i].classList.add("active");
        }
    }
}

function next() {
    if (questionCount == question.length - 1) {
        location.href = "../Leaderboard/Display"
    }
    else {
        show(questionCount); //doesnt work, says question is undefined which is very weird -- show error ss
    }
    console.log(questionCount);
}

let userAnswer = document.querySelector("li.option.active").innerHTML; 

if (userAnswer == questions[questionCount].answer) {
    points += 10;
    sessionStorage.setItem("points",points)
}
console.log(points);

questionCount++;
show(questionCount);