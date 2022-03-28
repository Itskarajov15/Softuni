import { html, nothing } from '../../node_modules/lit-html/lit-html.js';

import * as bookService from '../services/bookService.js';
import * as authService from '../services/authService.js';

const creatorLinks = (bookId) => html`
    <a class="button" href="/details/${bookId}/edit">Edit</a>
    <a class="button" href="/details/${bookId}/delete">Delete</a>
`;

const nonCreatorLink = (bookId) => html`
    <a class="button" href="/details/${bookId}/like">Like</a>
`;

const detailsTemplate = (book, isCreator, user) => html`
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

                ${user && !isCreator
                    ? nonCreatorLink(book._id)
                    : nothing
                }

                <div class="likes">
                    <img class="hearts" src="/images/heart.png">
                    <span id="total-likes">Likes: 0</span>
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
    const book = await bookService.getBook(ctx.params.id);
    const user = authService.getUser();

    ctx.render(detailsTemplate(book, Boolean(user && book._ownerId == user._id), user));
}