import { html } from '../../node_modules/lit-html/lit-html.js';

import * as bookService from '../services/bookService.js';

const editTemplate = (book, editHandler) => html`
    <section id="edit-page" class="edit">
        <form id="edit-form" action="#" method="" @submit=${editHandler}>
            <fieldset>
                <legend>Edit my Book</legend>
                <p class="field">
                    <label for="title">Title</label>
                    <span class="input">
                        <input type="text" name="title" id="title" value="${book.title}">
                    </span>
                </p>
                <p class="field">
                    <label for="description">Description</label>
                    <span class="input">
                        <textarea name="description"
                            id="description">${book.description}</textarea>
                    </span>
                </p>
                <p class="field">
                    <label for="image">Image</label>
                    <span class="input">
                        <input type="text" name="imageUrl" id="image" value="${book.imageUrl}">
                    </span>
                </p>
                <p class="field">
                    <label for="type">Type</label>
                    <span class="input">
                        <select id="type" name="type" value="${book.type}">
                            <option value="Fiction" selected>Fiction</option>
                            <option value="Romance">Romance</option>
                            <option value="Mistery">Mistery</option>
                            <option value="Classic">Clasic</option>
                            <option value="Other">Other</option>
                        </select>
                    </span>
                </p>
                <input class="button submit" type="submit" value="Save">
            </fieldset>
        </form>
    </section>
`;

export const editView = async (ctx) => {
    const book = await bookService.getBook(ctx.params.id);

    const editHandler = async (e) => {
        e.preventDefault();

        const { title, description, imageUrl } = Object.fromEntries(new FormData(e.currentTarget));
        const type = document.querySelector('#type').value;

        if (!title || !description || !imageUrl || !type) {
            alert('All fields must be filled!');
            return;  
        } 

        const response = await bookService.updateBook(ctx.params.id, { title, description, imageUrl, type});
        e.target.reset();
        ctx.page.redirect(`/details/${ctx.params.id}`);
    }

    ctx.render(editTemplate(book, editHandler));
}