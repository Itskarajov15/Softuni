import { html, render } from '../../node_modules/lit-html/lit-html.js';
import cardTemplate from '../templates/cardTemplate.js';
import { cats } from './catSeeder.js';

const catsSection = document.getElementById('allCats');
cats.forEach(c => c.info = false);
update();

function update() {
    render(html`<ul @click=${toggleInfo}>${cats.map(cardTemplate)}</ul>`, catsSection);
}

function toggleInfo(e) {
    const elementId = e.target.parentElement.querySelector('.status').id;
    const cat = cats.find(c => c.id == elementId);
    cat.info = !cat.info;

    update();
}