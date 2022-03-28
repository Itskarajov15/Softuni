import { html } from '../../node_modules/lit-html/lit-html.js';

import * as bookService from '../services/bookService.js';

const createTemplate = (createHandler) => html`
    <section id="create-page" class="create">
        <form id="create-form" action="" method="" @submit=${createHandler}>
            <fieldset>
                <legend>Add new Book</legend>
                <p class="field">
                    <label for="title">Title</label>
                    <span class="input">
                        <input type="text" name="title" id="title" placeholder="Title">
                    </span>
                </p>
                <p class="field">
                    <label for="description">Description</label>
                    <span class="input">
                        <textarea name="description" id="description" placeholder="Description"></textarea>
                    </span>
                </p>
                <p class="field">
                    <label for="image">Image</label>
                    <span class="input">
                        <input type="text" name="imageUrl" id="image" placeholder="Image">
                    </span>
                </p>
                <p class="field">
                    <label for="type">Type</label>
                    <span class="input">
                        <select id="type" name="type">
                            <option value="Fiction">Fiction</option>
                            <option value="Romance">Romance</option>
                            <option value="Mistery">Mistery</option>
                            <option value="Classic">Clasic</option>
                            <option value="Other">Other</option>
                        </select>
                    </span>
                </p>
                <input class="button submit" type="submit" value="Add Book">
            </fieldset>
        </form>
    </section>
`;

export const createView = (ctx) => {
    const createHandler = async (e) => {
        e.preventDefault();

        const { title, description, imageUrl } = Object.fromEntries(new FormData(e.currentTarget));
        const type = document.querySelector('#type').value;

        if (!title || !description || !imageUrl || !type) {
            alert('All fields must be filled!');
            return;  
        } 

        const response = await bookService.createBook({ title, description, imageUrl, type});
        e.target.reset();
        ctx.page.redirect('/');
    }

    ctx.render(createTemplate(createHandler));
}