import * as request from './request.js';

export const getAllGames = async () => {
    return request.get('/data/games?sortBy=_createdOn%20desc');
}

export const getLatestGames = async () => {
    return request.get('/data/games?sortBy=_createdOn%20desc&distinct=category');
}

export const createGame = async (title, category, maxLevel, imageUrl, summary) => {
    return request.post('/data/games', { title, category, maxLevel, imageUrl, summary});
}

export const getGame = async (gameId) => {
    return request.get(`/data/games/${gameId}`);
}

export const editGame = async (gameId, title, category, maxLevel, imageUrl, summary) => {
    return request.put(`/data/games/${gameId}`, { title, category, maxLevel, imageUrl, summary});
}

export const deleteGame = async (gameId) => {
    return request.del(`/data/games/${gameId}`);
}