import { html } from '../../node_modules/lit-html/lit-html.js';

import * as eventsService from '../services/eventsService.js';

const createTemplate = (createHandler) => html`
    <section id="createPage">
        <form class="create-form" @submit=${createHandler}>
            <h1>Create Theater</h1>
            <div>
                <label for="title">Title:</label>
                <input id="title" name="title" type="text" placeholder="Theater name" value="">
            </div>
            <div>
                <label for="date">Date:</label>
                <input id="date" name="date" type="text" placeholder="Month Day, Year">
            </div>
            <div>
                <label for="author">Author:</label>
                <input id="author" name="author" type="text" placeholder="Author">
            </div>
            <div>
                <label for="description">Description:</label>
                <textarea id="description" name="description" placeholder="Description"></textarea>
            </div>
            <div>
                <label for="imageUrl">Image url:</label>
                <input id="imageUrl" name="imageUrl" type="text" placeholder="Image Url" value="">
            </div>
            <button class="btn" type="submit">Submit</button>
        </form>
    </section>
`;

export const createView = (ctx) => {
    const createHandler = async (e) => {
        e.preventDefault();

        const { title, date, author, description, imageUrl } = Object.fromEntries(new FormData(e.currentTarget));

        if (!title || !date || !author || !description || !imageUrl) {
            alert('All fields must be filled!');
            return;
        }

        const res = await eventsService.createEvent({ title, date, author, description, imageUrl });
        e.target.reset();
        ctx.page.redirect('/');
    }

    ctx.render(createTemplate(createHandler));
}