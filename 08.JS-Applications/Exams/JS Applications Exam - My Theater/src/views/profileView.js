import { html } from '../../node_modules/lit-html/lit-html.js';

import * as eventsService from '../services/eventsService.js';

const eventTemplate = (event) => html`
    <div class="event-info">
        <img src="${event.imageUrl}">
        <h2>${event.title}</h2>
        <h6>${event.date}</h6>
        <a href="/details/${event._id}" class="details-button">Details</a>
    </div>
`;

const profileTempalte = (user, events) => html`
    <section id="profilePage">
        <div class="userInfo">
            <div class="avatar">
                <img src="./images/profilePic.png">
            </div>
            <h2>${user.email}</h2>
        </div>
        <div class="board">

            ${events.length > 0
                ? html`<div class="eventBoard">
                ${events.map(e => eventTemplate(e))}
                </div>`
                : html`<div class="no-events"><p>This user has no events yet!</p></div>`
            }

        </div>
    </section>
`;

export const profileView = async (ctx) => {
    const user = ctx.user;
    const eventsByUser = await eventsService.getEventsByUser(user._id);

    ctx.render(profileTempalte(user, eventsByUser));
}