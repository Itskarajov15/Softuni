import * as request from './request.js';

import * as authService from './authService.js';

export const login = async (email, password) => {
    const user = await request.post('/users/login', { email, password });
    authService.saveUser(user);
    return user;
} 

export const register = async(email, password) => {
    const user = await request.post('/users/register', { email, password });
    authService.saveUser(user);
    return user;
}

export const logout = async(email, password) => {
    const res = await request.get('/users/logout');
    authService.removeUser();
    return res;
}