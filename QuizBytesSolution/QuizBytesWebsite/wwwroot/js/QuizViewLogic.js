function expand() {
    //Maybe it would work if I add a function which checks if the button that was clicked has the .active css class
    //and if yes removes these items and if not adds them to the #submenu a .active
    //needs to check which element was pressed and retrieve the required data(if Course was pressed then it would retrieve a
    //list of courses and so on)
    //needs to send user to the desired course/subject/ whatever
    let submenu = document.getElementById("submenu"); 
    submenu.innerHTML = //this will go through a for loop to add an <a></a> for each element in an array which will come from
        //lower layers. The rest will be handles can hopefully be handled in C#
       `<a>Course1</a>
        <a>Course2</a>
        <a>Course3</a>
        <a>Course4</a>
        <a>Course5</a>
        <a>Course6</a>
        <a>Course7</a>
        <a>Course8</a>
        <a>Course9</a>
        <a>Course10</a>
        <a>Course11</a>
        <a>Course12</a>`
    let opened = true;
    //if button is pressed again it should close the menu
}