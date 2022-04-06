import * as eventsService from '../services/eventsService.js';

export const likeView = async (ctx) => {
    const eventId = ctx.params.id;
    const res = await eventsService.likeEvent({ eventId });
    ctx.page.redirect(`details/${ctx.params.id}`);
}