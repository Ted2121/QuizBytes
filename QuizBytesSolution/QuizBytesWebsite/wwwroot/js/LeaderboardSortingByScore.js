document.addEventListener('DOMContentLoaded', () => {
    let elements = []
    let container = document.querySelector('#leaderboard') // this will be different, i just used it to test something, we will be doing the same just using 
    //a different thing as the container.
    container.querySelectorAll('.row').forEach(el => elements.push(el))
    container.innerHTML = ''
    elements.sort((a, b) => b.querySelector('.score').textContent - a.querySelector('.score').textContent)
    elements.forEach(e => container.appendChild(e))
    //might not be optimal to do it like this and instead do it before populating but I feel like this is easier for us and it makes sense that 
    //this would be handled client side
})