import * as request from './request.js';

export const createEvent = async (event) => {
    return await request.post('/data/theaters', event);
}

export const editEvent = async (eventId, event) => {
    return await request.put(`/data/theaters/${eventId}`, event);
}

export const deleteEvent = async (eventId) => {
    return await request.del(`/data/theaters/${eventId}`);
}

export const getEvent = async (eventId) => {
    return await request.get(`/data/theaters/${eventId}`);
}

export const getAllEvents = async () => {
    return await request.get('/data/theaters?sortBy=_createdOn%20desc&distinct=title');
}

export const getEventsByUser = async (userId) => {
    return await request.get(`/data/theaters?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`);
}

export const likeTheater = async (theaterId) => {
    return await request.post('/data/likes', {
        theaterId
    });
}

export const getLikesByTheaterId = async (theaterId) => {
    return await request.get(`/data/likes?where=theaterId%3D%22${theaterId}%22&distinct=_ownerId&count`);
}

export const getMyLikeByTheaterId = async (theaterId, userId) => {
    return await request.get(`/data/likes?where=theaterId%3D%22${theaterId}%22%20and%20_ownerId%3D%22${userId}%22&count`);
}

window.likeTheater = likeTheater;
window.getLikesByTheaterId = getLikesByTheaterId;
window.getMyLikeByTheaterId = getMyLikeByTheaterId;