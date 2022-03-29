import { html } from '../../node_modules/lit-html/lit-html.js';

import * as eventsService from '../services/eventsService.js';

const editTemplate = (event, editHandler) => html`
    <section id="editPage">
        <form class="theater-form" @submit=${editHandler}>
            <h1>Edit Theater</h1>
            <div>
                <label for="title">Title:</label>
                <input id="title" name="title" type="text" placeholder="Theater name" value="${event.title}">
            </div>
            <div>
                <label for="date">Date:</label>
                <input id="date" name="date" type="text" placeholder="Month Day, Year" value="${event.date}">
            </div>
            <div>
                <label for="author">Author:</label>
                <input id="author" name="author" type="text" placeholder="Author" value="${event.author}">
            </div>
            <div>
                <label for="description">Theater Description:</label>
                <textarea id="description" name="description"
                    placeholder="Description">${event.description}</textarea>
            </div>
            <div>
                <label for="imageUrl">Image url:</label>
                <input id="imageUrl" name="imageUrl" type="text" placeholder="Image Url"
                    value="${event.imageUrl}">
            </div>
            <button class="btn" type="submit">Submit</button>
        </form>
    </section>
`;

export const editView = async (ctx) => {
    const event = await eventsService.getEvent(ctx.params.id);

    const editHandler = async(e) => {
        e.preventDefault();

        const { title, date, author, description, imageUrl } = Object.fromEntries(new FormData(e.currentTarget));

        if (!title || !date || !author || !description || !imageUrl) {
            alert('All fields must be filled!');
            return;
        }

        const res = await eventsService.editEvent(ctx.params.id, { title, date, author, description, imageUrl });
        e.target.reset();
        ctx.page.redirect(`/details/${ctx.params.id}`);
    }

    ctx.render(editTemplate(event, editHandler));
}