import { html, render } from '../../node_modules/lit-html/lit-html.js';
import { contacts } from './contacts.js';
import { template } from '../templates/card.js';

const contactsDiv = document.getElementById('contacts');

render(html`${contacts.map(x => html`${template(x)}`)}`, contactsDiv);