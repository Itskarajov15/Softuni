import { showView } from './util.js'
import { homePage } from './home.js';

const section = document.querySelector('#add-movie');
const formElement = document.querySelector('.text-center.border.border-light.p-5');
formElement.addEventListener('submit', createNewMovie);

export function createPage() {
    showView(section)
}

async function createNewMovie(e) {
    e.preventDefault();

    const formData = new FormData(formElement);
    const title = formData.get('title');
    const description = formData.get('description');
    const img = formData.get('imageUrl');

    let user = JSON.parse(localStorage.getItem('user'));

    if (!user) {
        return;
    }

    let token = user.accessToken;

    try {
        const res = await fetch('http://localhost:3030/data/movies', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                'X-Authorization': token
            },
            body: JSON.stringify({ title, description, img })
        });

        if (res.ok != true) {
            const error = await res.json();
            throw new Error(error.message);
        }

        const result = await res.json();
        formElement.reset();
        homePage();
    } catch (err) {
        alert(arr.message);
    }
}