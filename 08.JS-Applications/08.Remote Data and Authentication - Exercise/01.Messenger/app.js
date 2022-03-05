const url = 'http://localhost:3030/jsonstore/messenger';

function attachEvents() {
    const sendButton = document.getElementById('submit');
    const refreshButton = document.getElementById('refresh');

    sendButton.addEventListener('click', submitData);
    refreshButton.addEventListener('click', getData);
}

async function submitData() {
    let author = document.querySelector('[name="author"]').value;
    let content = document.querySelector('[name="content"]').value;

    const response = await fetch(url, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({author, content})
    });

    document.querySelector('[name="author"]').value = '';
    document.querySelector('[name="content"]').value = '';
}

async function getData() {
    const messages = document.getElementById('messages');
    messages.innerHTML = '';

    const response = await fetch(url);
    const data = await response.json();

    messages.value = Object.values(data).map(({author, content}) => `${author}: ${content}`).join('\n');
}

attachEvents();