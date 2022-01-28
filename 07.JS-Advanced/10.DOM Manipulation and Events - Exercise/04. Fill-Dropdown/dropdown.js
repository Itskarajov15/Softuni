function addItem() {
    let selectElement = document.querySelector('#menu');
    let itemTextElement = document.getElementById('newItemText');
    let itemValueElement = document.getElementById('newItemValue');
    
    let optionElement = document.createElement('option');
    optionElement.textContent = itemTextElement.value;
    optionElement.value = itemValueElement.value;

    selectElement.appendChild(optionElement);

    itemTextElement.value = '';
    itemValueElement.value = '';
}