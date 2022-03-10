import { showView } from './util.js';

const detailsSection = document.querySelector('#movie-example');

export function detailsPage(id) {
    showView(detailsSection);
    displayMovie(id);
}

async function getMovie(id) {
    const res = await fetch(`http://localhost:3030/data/movies/${id}`);
    const movie = await res.json();

    return movie;
}

async function displayMovie(id) {
    const movie = await getMovie(id);

    detailsSection.replaceChildren(crateMovieCard(movie));
}

function crateMovieCard(movie) {
    const mainDiv = document.createElement('div');
    mainDiv.className = 'row bg-light text-dark';

    const h1 = document.createElement('h1');
    h1.textContent = movie.title;

    const divImg = document.createElement('div');
    divImg.className = 'col-md-8';

    const img = document.createElement('img');
    img.className = 'img-thumbnail';
    img.src = movie.img;
    img.alt = 'Movie';
    divImg.appendChild(img);

    const descriptionDiv = document.createElement('div');
    descriptionDiv.className = 'col-md-4 text-center';

    const h3 = document.createElement('h3');
    h3.className = 'my-3';
    h3.textContent = 'Movie Description';

    const pDescription = document.createElement('p');
    pDescription.textContent = movie.description;

    const deleteButton = document.createElement('button');
    deleteButton.textContent = 'Delete';
    deleteButton.className = 'btn btn-danger';

    const editButton = document.createElement('button');
    editButton.textContent = 'Edit';
    editButton.className = 'btn btn-warning';

    const likeButton = document.createElement('button');
    likeButton.textContent = 'Like';
    likeButton.className = 'btn btn-primary';

    const spanLikes = document.createElement('span');
    spanLikes.className = 'enrolled-span';
    spanLikes.textContent = 'Liked 1';

    descriptionDiv.appendChild(h3);
    descriptionDiv.appendChild(pDescription);
    descriptionDiv.appendChild(deleteButton);
    descriptionDiv.appendChild(editButton);
    descriptionDiv.appendChild(likeButton);
    descriptionDiv.appendChild(spanLikes);

    mainDiv.appendChild(h1);
    mainDiv.appendChild(divImg);
    mainDiv.appendChild(descriptionDiv);

    return mainDiv;
}