import * as gamesService from '../services/gamesService.js';

export const deleteView = async (ctx) => {
    const game = await gamesService.getGame(ctx.params.id);

    let confirmed = confirm(`Are you sure you want to delete game: ${game.title}`);

    if (confirmed) {
        await gamesService.deleteGame(game._id);
        ctx.page.redirect('/');
    }
}