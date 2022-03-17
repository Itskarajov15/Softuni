import { html } from '../../node_modules/lit-html/lit-html.js';
import { clickHandler } from '../src/clickHandler.js';

export const template = (person) => html`
    <div class="contact card">
        <div>
            <i class="far fa-user-circle gravatar"></i>
        </div>
        <div class="info">
            <h2>Name: ${person.name}</h2>
            <button class="detailsBtn" @click=${clickHandler}>Details</button>
            <div class="details" style="display: none;">
                <p>Phone number: ${person.phoneNumber}</p>
                <p>Email: ${person.email}</p>
            </div>
        </div>
    </div>
`;