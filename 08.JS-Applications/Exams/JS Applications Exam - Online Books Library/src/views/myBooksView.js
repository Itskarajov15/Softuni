import { html } from '../../node_modules/lit-html/lit-html.js';

import * as bookService from '../services/bookService.js';

const bookTemplate = (book) => html`
    <li class="otherBooks">
        <h3>${book.title}</h3>
        <p>Type: ${book.type}</p>
        <p class="img"><img src="${book.imageUrl}"></p>
        <a class="button" href="/details/${book._id}">Details</a>
    </li>
`;

const myBooksTemplate = (books) => html`
    <section id="my-books-page" class="my-books">
        <h1>My Books</h1>

        ${books.length > 0
            ? html`<ul class="my-books-list">${books.map(b => bookTemplate(b))}</ul>`
            : html`<p class="no-books">No books in database!</p>`
        }

    </section>
`;

export const myBooksView = async (ctx) => {
    const authorBooks = await bookService.getBooksByAuthor(ctx.user._id);

    ctx.render(myBooksTemplate(authorBooks));
}