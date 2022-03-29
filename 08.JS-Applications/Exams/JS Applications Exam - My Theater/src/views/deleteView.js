import * as eventsService from '../services/eventsService.js';

export const deleteView = async (ctx) => {
    const res = await eventsService.deleteEvent(ctx.params.id);
    ctx.page.redirect('/profile');
}