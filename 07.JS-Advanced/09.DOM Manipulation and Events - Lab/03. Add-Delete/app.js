function addItem() {
    let itemsElement = document.getElementById('items');
    let inputElement = document.getElementById('newItemText');
    let liElement = document.createElement('li');

    let deleteElement = document.createElement('a');
    deleteElement.href = '#';
    deleteElement.textContent = '[Delete]';
    deleteElement.addEventListener('click', (e) => {
        e.currentTarget.parentElement.remove();
    });

    liElement.textContent = inputElement.value;

    inputElement.value = ' ';
    
    liElement.appendChild(deleteElement);
    itemsElement.appendChild(liElement);
}