import { showView } from './util.js'
import { detailsPage } from './details.js';


const homeSection = document.querySelector('#home-page');
const catalog = homeSection.querySelector('.card-deck.d-flex.justify-content-center');
catalog.addEventListener('click', (e) => {
    if (e.target.tagName == 'BUTTON') {
        e.preventDefault();
        const id = e.target.dataset.id;
        detailsPage(id);
    }
});

export function homePage() {
    showView(homeSection);
    displayMovies();
}

async function displayMovies() {
    catalog.innerHTML = '';
    getMovies();
}

function createMoviePreview(movie) {
    const divElement = document.createElement('div');
    divElement.className = 'card mb-4';

    const imgElement = document.createElement('img');
    imgElement.className = 'card-img-top'; 
    imgElement.src = movie.img;
    imgElement.alt = 'Card image cap';
    imgElement.width = "400";

    const divBodyElement = document.createElement('div');
    divBodyElement.className = 'card-body';

    const h4 = document.createElement('h4');
    h4.className = 'card-title';
    h4.textContent = movie.title;
    divBodyElement.appendChild(h4);

    const footerDiv = document.createElement('div');
    footerDiv.className = 'card-footer';
    
    const aTag = document.createElement('a');
    aTag.href = "#/details/6lOxMFSMkML09wux6sAF"; ////////////////////////////////////////////////

    const detailsButton = document.createElement('button');
    detailsButton.className = 'btn btn-info';
    detailsButton.textContent = 'Details';
    detailsButton.setAttribute('data-id', movie._id);
    aTag.appendChild(detailsButton);
    footerDiv.appendChild(aTag);

    divElement.appendChild(imgElement);
    divElement.appendChild(divBodyElement);
    divElement.appendChild(footerDiv);
    
    catalog.appendChild(divElement);
}

async function getMovies() {
    const res = await fetch('http://localhost:3030/data/movies');
    const data = await res.json();

    data.forEach(m => {
        createMoviePreview(m);
    });
}

window.getMovies = getMovies;