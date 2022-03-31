import { html } from '../../node_modules/lit-html/lit-html.js';
import * as gamesService from '../services/gamesService.js';

const editTemplate = (submitHandler, game) => html`
    <section id="edit-page" class="auth">
        <form id="edit" @submit=${submitHandler}>
            <div class="container">
    
                <h1>Edit Game</h1>
                <label for="leg-title">Legendary title:</label>
                <input type="text" id="title" name="title" value="${game.title}">
    
                <label for="category">Category:</label>
                <input type="text" id="category" name="category" value="${game.category}">
    
                <label for="levels">MaxLevel:</label>
                <input type="number" id="maxLevel" name="maxLevel" min="1" value="${game.maxLevel}">
    
                <label for="game-img">Image:</label>
                <input type="text" id="imageUrl" name="imageUrl" value="${game.imageUrl}">
    
                <label for="summary">Summary:</label>
                <textarea name="summary" id="summary" .value="${game.summary}"></textarea>
                <input class="btn submit" type="submit" value="Edit Game">
    
            </div>
        </form>
    </section>
`;

export const editView = async (ctx) => {
    const game = await gamesService.getGame(ctx.params.id);
    
    const submitHandler = async (e) => {
        e.preventDefault();

        let { title, category, maxLevel, imageUrl, summary } = Object.fromEntries(new FormData(e.currentTarget));

        if (!title || !category || !maxLevel || !imageUrl || !summary) {
            alert('All fields must be filled!');
            return;
        }

        const res = await gamesService.editGame(game._id, title, category, maxLevel, imageUrl, summary);
        ctx.page.redirect(`/details/${game._id}`);
    }

    ctx.render(editTemplate(submitHandler, game));
}