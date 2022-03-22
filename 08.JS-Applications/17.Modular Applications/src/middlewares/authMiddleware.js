import * as authService from '../services/authService.js';

export const authMiddleware = (ctx, next) => {
    ctx.isAuthenticated = authService.isAuthenticated();

    next();
}