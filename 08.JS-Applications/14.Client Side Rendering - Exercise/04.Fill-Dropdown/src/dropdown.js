import { html, render } from '../../../node_modules/lit-html/lit-html.js';

const selectTemplate = (list) => html`
    <select id="menu">
        ${list.map(x => html`<option value=${x._id}>${x.text}</option>`)}
    </select>
`;

const endpoint = 'http://localhost:3030/jsonstore/advanced/dropdown';

async function initialize() {
    document.querySelector('form').addEventListener('submit', (e) => addItem(e, list))

    const response = await fetch(endpoint);
    const data = await response.json();
    const list = Object.values(data);

    update(list);
}

function update(list) {
    const result = selectTemplate(list);
    const main = document.querySelector('div');
    render(result, main);
}

async function addItem(e, list) {
    e.preventDefault();

    const formData = new FormData(e.currentTarget);
    const input = formData.get('itemText');

    const item = {
        text: input
    }

    const response = await fetch(endpoint, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(item) 
    });

    const result = await response.json();

    list.push(result);
    update(list);
    e.target.reset();
}

initialize();