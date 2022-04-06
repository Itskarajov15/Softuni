import { html, nothing } from '../../node_modules/lit-html/lit-html.js';

import * as bookService from '../services/bookService.js';
import * as authService from '../services/authService.js';

const creatorLinks = (bookId) => html`
    <a class="button" href="/details/${bookId}/edit">Edit</a>
    <a class="button" href="/details/${bookId}/delete">Delete</a>
`;

const likeControlsTemplate = (showLikeButton, onLike) => {
    if (showLikeButton) {
        return html`<a @click=${onLike} class="button" href="javascript:void(0)">Like</a>`;
    } else {
        return null;
    }
}

const detailsTemplate = (book, isCreator, showLikeButton, onLike, likes) => html`
    <section id="details-page" class="details">
        <div class="book-information">
            <h3>${book.title}</h3>
            <p class="type">Type: ${book.type}</p>
            <p class="img"><img src="${book.imageUrl}"></p>
            <div class="actions">
                ${isCreator
                    ? creatorLinks(book._id)
                    : nothing
                }

                ${likeControlsTemplate(showLikeButton, onLike)}

                <div class="likes">
                    <img class="hearts" src="/images/heart.png">
                    <span id="total-likes">Likes: ${likes}</span>
                </div>
            </div>
        </div>
        <div class="book-description">
            <h3>Description:</h3>
            <p>${book.description}</p>
        </div>
    </section>
`;

export const detailsView = async (ctx) => {
    const user = authService.getUser();

    const [book, likes, hasLike] = await Promise.all([
        bookService.getBook(ctx.params.id),
        bookService.getAllLikesByBookId(ctx.params.id),
        user ? bookService.getMyLike(ctx.params.id, user._id) : 0
    ]);

    const isCreator = Boolean(user && book._ownerId == user._id);
    const showLikeButton = user != null && isCreator == false && hasLike == false;

    const onLike = async () => {
        await bookService.likeBook(ctx.params.id);
        ctx.page.redirect(`/details/${ctx.params.id}`);
    }

    ctx.render(detailsTemplate(book, isCreator, showLikeButton, onLike, likes));
}