import { html } from '../../node_modules/lit-html/lit-html.js';

const template = (data) => html`
    <ul>
        ${data.map(t => html`<li>${t}</li>`)}
    </ul>
`;

export default template;