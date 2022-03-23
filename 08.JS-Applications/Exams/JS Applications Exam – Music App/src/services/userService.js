import * as request from './requester.js'; 
import * as authService from './authService.js';

const baseUrl = 'http://localhost:3030/users';

export const login = async (email, password) => {
    const user = await request.post(`${baseUrl}/login`, { email, password });

    authService.save(user);
    return user;
}

export const register = async (email, password) => {
    const user = await request.post(`${baseUrl}/register`, { email, password });

    authService.save(user);
    return user;
}

export const logout = async () => {
    const res = await fetch(`${baseUrl}/logout`, { headers: { 'X-Authorization': authService.getAccessToken() } });

    authService.deleteUser();
    return res;
}