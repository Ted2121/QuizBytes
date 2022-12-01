var connection = new signalR.HubConnectionBuilder().withUrl("/timerHub").build();
var li = document.createElement("li");
document.getElementById("serverDate").appendChild(li);

connection.on("DisplayTime", function (time) {

    li.textContent = time;
});

connection.start().then(function () {

}).catch(function (err) {
    return console.error(err.toString());
});

setInterval(function () {

    connection.invoke("PrintTime").catch(function (err) {
        return console.error(err.toString());
    });

}, 1000);
