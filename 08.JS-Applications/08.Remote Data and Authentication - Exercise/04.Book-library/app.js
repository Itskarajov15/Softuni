const url = 'http://localhost:3030/jsonstore/collections/books';

async function request(url, options) {
    const response = await fetch(url, options);
    if (response.ok != true) {
        const error = await response.json();
        alert(error.message);
        throw new Error(error.message);
    }

    const data = await response.json();
    return data;
}

async function getAllBooks() {
    const tbody = document.querySelector('table tbody');
    tbody.innerHTML = '';
    const books = await request(url);

    Object.entries(books).map(createRow).forEach(r => tbody.appendChild(r));
}

function createRow([id, book]) {
    let trElement = document.createElement('tr');
    trElement.setAttribute('id', id);

    let titleTd = document.createElement('td');
    titleTd.textContent = book.title;
    let authorTd = document.createElement('td');
    authorTd.textContent = book.author;
    let buttonsTd = document.createElement('td');
    let editButton = document.createElement('button');
    editButton.textContent = 'Edit';
    let deleteButton = document.createElement('button');
    deleteButton.textContent = 'Delete';

    buttonsTd.appendChild(editButton);
    buttonsTd.appendChild(deleteButton);

    trElement.appendChild(titleTd);
    trElement.appendChild(authorTd);
    trElement.appendChild(buttonsTd);

    return trElement;
}

async function createBook(e) {
    e.preventDefault();
    const formData = new FormData(e.currentTarget);
    const book = {
        title: formData.get('title'),
        author: formData.get('author')
    };

    await request(url, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(book) 
    });

    e.target.reset();
    getAllBooks();
}

async function updateBook(e) {
    e.preventDefault();
    const formData = new FormData(e.target);
    const id = formData.get('id');
    const book = {
        title: formData.get('title'),
        author: formData.get('author')
    };

    await request(`${url}/${id}`, {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(book)
    });

    document.getElementById('createFrom').style.display = 'block';
    document.getElementById('editForm').style.display = 'none';
    e.target.reset();
    getAllBooks();
}

async function deleteBook(id) {
    const result = await request(`${url}/${id}`, {
        method: 'DELETE'
    });

    getAllBooks();
}

function attachEvents() {
    document.getElementById('loadBooks').addEventListener('click', getAllBooks);

    document.querySelector('form').addEventListener('submit', createBook);

    document.querySelector('table').addEventListener('click', handleTableClick);

    document.querySelector('#editForm').addEventListener('submit', updateBook);

    getAllBooks();
}

attachEvents()

function handleTableClick(e) {
    if (e.target.textContent == 'Edit') {
        document.getElementById('createFrom').style.display = 'none';
        document.getElementById('editForm').style.display = 'block';
        const bookId = e.target.parentElement.parentElement.id;
        loadBookForEditting(bookId);
        e.target.parentElement.parentElement.remove();
    } else if (e.target.textContent == 'Delete') {
        const comfirmed = confirm('Are you sure you want to delete this book?');
        if (comfirmed) {
            const bookId = e.target.parentElement.parentElement.id;
            deleteBook(bookId);
        }
    }
}

async function loadBookForEditting(id) {
    const book = await request(`${url}/${id}`);

    document.querySelector('#editForm [name="id"]').value = id;
    document.querySelector('#editForm [name="title"]').value = book.title;
    document.querySelector('#editForm [name="author"]').value = book.author;
}