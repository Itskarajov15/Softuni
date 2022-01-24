function toggle() {
    let extraText = document.querySelector('#extra');
    let buttonElement = document.getElementsByClassName('button')[0];

    if (buttonElement.textContent === 'Less') {
        buttonElement.textContent = 'More';
        extraText.style.display = 'none';
    } else{
        buttonElement.textContent = 'Less';
        extraText.style.display = 'block';
    }
}