import { html } from '../../node_modules/lit-html/lit-html.js';

const cardTemplate = (person) => html`
    <div class="contact card">
        <div>
            <i class="far fa-user-circle gravatar"></i>
        </div>
        <div class="info">
            <h2>Name: ${person.name}</h2>
            <button class="detailsBtn">Details</button>
            <div class="details" id=${person.id} style="display: none;">
                <p>Phone number: ${person.phoneNumber}</p>
                <p>Email: ${person.email}</p>
            </div>
        </div>
    </div>
`;

export default cardTemplate;