import { getAllIdeas } from "./api/data.js";

const section = document.getElementById('dashboard-holder');

export async function showCatalog(context) {
    context.showSection(section);
    const ideas = await getAllIdeas();
    section.replaceChildren(...ideas.map(createIdeaPreview));
}

function createIdeaPreview(idea) {
    const element = document.createElement('div');
    element.className = 'card overflow-hidden current-card details';
    element.style.width = '20rem';
    element.style.height = '18rem';
    element.innerHTML = `<div class="card overflow-hidden current-card details" style="width: 20rem; height: 18rem;">
    <div class="card-body">
        <p class="card-text">${idea.title}</p>
    </div>
    <img class="card-image" src="${idea.img}" alt="Card image cap">
    <a class="btn" href="">Details</a>
    </div>`;

    return element;
}