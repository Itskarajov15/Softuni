import * as bookService from '../services/bookService.js';

export const deleteView = async (ctx) => {
    const res = await bookService.deleteBook(ctx.params.id);
    ctx.page.redirect('/');
}