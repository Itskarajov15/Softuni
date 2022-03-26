import * as request from './request.js';
import * as authService from './authService.js';

const url = '/users';

export const login = async (email, password) => {
    const user = await request.post(url + '/login', { email, password });
    authService.saveUser(user);
    return user;
};

export const register = async (email, password) => {
    const user = await request.post(url + '/register', { email, password });
    authService.saveUser(user);
    return user;
}

export const logout = async () => {
    const res = await request.get(url + '/logout');
    authService.deleteUser();
    return res;
}