import { html, nothing } from '../../node_modules/lit-html/lit-html.js';
import * as gamesService from '../services/gamesService.js';

const creatorLinks = (gameId) => html`
    <div class="buttons">
        <a href="/details/${gameId}/edit" class="button">Edit</a>
        <a href="/details/${gameId}/delete" class="button">Delete</a>
    </div>
`;

const detailsTemplate = (game, withCreatorLinks = true) => html`
    <section id="game-details">
        <h1>Game Details</h1>
        <div class="info-section">
    
            <div class="game-header">
                <img class="game-img" src="${game.imageUrl}" />
                <h1>${game.title}</h1>
                <span class="levels">MaxLevel: ${game.maxLevel}</span>
                <p class="type">${game.category}</p>
            </div>
    
            <p class="text">${game.summary}</p>

            ${withCreatorLinks
                ? creatorLinks(game._id)
                : nothing
            }
        </div>
    
    </section>
`;

export const detailsView = async (ctx) => {
    const game = await gamesService.getGame(ctx.params.id);
    
    ctx.render(detailsTemplate(game, Boolean(ctx.user && game._ownerId == ctx.user._id)));
}