import { html, render } from '../../node_modules/lit-html/lit-html.js';
import { contacts } from './contacts.js';
import cardTemplate from '../templates/card.js';

const contactsDiv = document.getElementById('contacts');
contactsDiv.addEventListener('click', clickHandler);

render(html`${contacts.map(x => html`${cardTemplate(x)}`)}`, contactsDiv);

function clickHandler(e) {
    if (e.target.classList.contains('detailsBtn')) {
        const divElement = e.target.parentElement.parentElement;
        if (e.target.textContent == 'Details') {
            e.target.textContent = 'Hide';
            divElement.querySelector('.details').style.display = 'block';
        } else {
            e.target.textContent = 'Details';
            divElement.querySelector('.details').style.display = 'none';
        }
    }
}