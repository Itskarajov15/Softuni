import * as userService from '../services/userService.js';

export const logoutView = async(ctx) => {
    const res = await userService.logout();
    ctx.page.redirect('/');
}