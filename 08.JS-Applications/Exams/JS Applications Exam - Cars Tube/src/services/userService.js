import * as request from './request.js';
import * as authService from './authService.js';

export const login = async (username, password) => {
    const user = await request.post('/users/login', { username, password });
    authService.saveUser(user);
    return user;
}

export const register = async (username, password) => {
    const user = await request.post('/users/register', { username, password });
    authService.saveUser(user);
    return user;
}

export const logout = async () => {
    const res = await request.get('/users/logout');
    authService.removeUser();
    return res;
}