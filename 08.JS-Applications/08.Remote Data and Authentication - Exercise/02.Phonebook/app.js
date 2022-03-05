const url = 'http://localhost:3030/jsonstore/phonebook';

function attachEvents() {
    const loadButton = document.getElementById('btnLoad');
    const createButton = document.getElementById('btnCreate');

    loadButton.addEventListener('click', loadContacts);
    createButton.addEventListener('click', createContact);
}

async function createContact() {
    let person = document.getElementById('person').value;
    let phone = document.getElementById('phone').value;

    if (person !== '' && phone !== '') {
        const response = await fetch(url, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ person, phone })
        });

        document.getElementById('person').value = '';
        document.getElementById('phone').value = '';

        loadContacts();
    }
}

async function loadContacts() {
    const response = await fetch(url);
    const data = await response.json();

    const phonebook = document.getElementById('phonebook');
    phonebook.innerHTML = '';

    Object.values(data).forEach(c => {
        const li = document.createElement('li');
        const deleteBtn = document.createElement('button');
        deleteBtn.textContent = 'Delete';
        deleteBtn.addEventListener('click', deleteContact);

        li.textContent = `${c.person}:${c.phone}`;
        li.setAttribute('id', c._id);
        li.appendChild(deleteBtn);
        phonebook.appendChild(li);
    });
}

async function deleteContact(e) {
    const id = e.target.parentElement.id;
    const deleteUrl = `${url}/${id}`;
    e.target.parentElement.remove();

    const response = await fetch(deleteUrl, {
        method: 'DELETE',
    });
}

attachEvents();