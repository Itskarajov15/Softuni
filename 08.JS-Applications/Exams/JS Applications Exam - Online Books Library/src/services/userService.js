import * as request from './request.js';

import * as authService from './authService.js';

export const login = async (email, password) => {
    const user = await request.post('/users/login', { email, password });
    authService.saveUser(user);
    return user;
} 