import * as authService from '../services/authService.js';

export const logoutView = async (ctx) => {
    const res = await authService.logout();
    ctx.page.redirect('/');
}