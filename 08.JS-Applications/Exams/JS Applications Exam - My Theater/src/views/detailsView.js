import { html, nothing } from '../../node_modules/lit-html/lit-html.js';

import * as eventsService from '../services/eventsService.js';

const creatorLinks = (eventId) => html`
    <a class="btn-delete" href="/details/${eventId}/delete">Delete</a>
    <a class="btn-edit" href="/details/${eventId}/edit">Edit</a>
`;

const likeControlsTemplate = (showLikeButton, onLike) => {
    if (showLikeButton) {
        return html`<a @click=${onLike} class="btn-like" href="javascript:void(0)">Like</a>`;
    } else {
        return null;
    }
}

const detailsTemplate = (event, isCreator, likes, showLikeButton, onLike) => html`
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

                    ${
                        likeControlsTemplate(showLikeButton, onLike)
                    }

                </div>
                <p class="likes">Likes: ${likes}</p>
            </div>
        </div>
    </section>
`;

export const detailsView = async (ctx) => {
    const user = ctx.user;

    const [theater, likes, hasLike] = await Promise.all([
        eventsService.getEvent(ctx.params.id),
        eventsService.getLikesByTheaterId(ctx.params.id),
        Boolean(user) ? eventsService.getMyLikeByTheaterId(ctx.params.id, user._id) : 0
    ]);

    const isCreator = Boolean(user && theater._ownerId == user._id);
    const showLikeButton = user != null && isCreator == false && hasLike == false;

    const onLike = async () => {
        await eventsService.likeTheater(ctx.params.id);
        ctx.page.redirect(`/details/${ctx.params.id}`);
    }

    ctx.render(detailsTemplate(theater, isCreator, likes, showLikeButton, onLike));
}