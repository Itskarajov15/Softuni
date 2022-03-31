import { html, nothing } from '../../node_modules/lit-html/lit-html.js';

import * as eventsService from '../services/eventsService.js';

const creatorLinks = (eventId) => html`
    <a class="btn-delete" href="/details/${eventId}/delete">Delete</a>
    <a class="btn-edit" href="/details/${eventId}/edit">Edit</a>
`;

const nonCreatorLinks = (eventId) => html`
    <a class="btn-like" href="/details/${eventId}/like">Like</a>
`;

const detailsTemplate = (event, isCreator, user, likes) => html`
    <section id="detailsPage">
        <div id="detailsBox">
            <div class="detailsInfo">
                <h1>Title: ${event.title}</h1>
                <div>
                    <img src="${event.imageUrl}" />
                </div>
            </div>
    
            <div class="details">
                <h3>Theater Description</h3>
                <p>${event.description}</p>
                <h4>Date: ${event.date}</h4>
                <h4>Author: ${event.author}</h4>
                <div class="buttons">

                    ${isCreator
                        ? creatorLinks(event._id)
                        : nothing
                    }

                    ${user && !isCreator
                        ? nonCreatorLinks(event._id)
                        : nothing
                    }

                </div>
                <p class="likes">Likes: ${likes}</p>
            </div>
        </div>
    </section>
`;

export const detailsView = async (ctx) => {
    const event = await eventsService.getEvent(ctx.params.id);
    const likes = await eventsService.getLikes(ctx.params.id);

    ctx.render(detailsTemplate(event, Boolean(ctx.user && event._ownerId == ctx.user._id), ctx.user, likes));
}