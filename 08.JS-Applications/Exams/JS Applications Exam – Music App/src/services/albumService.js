import * as request from './requester.js';

const baseUrl = 'http://localhost:3030/data/albums';

export const getAll = async () => {
    const res = await request.get(`${baseUrl}?sortBy=_createdOn%20desc&distinct=name`);
    return res;
}

export const getCurrentAlbum = async (albumId) => {
    return await request.get(`${baseUrl}/${albumId}`);
}

export const create = async (albumData) => {
    return await request.post(baseUrl, albumData);
}

export const edit = async (albumId, albumData) => request.put(`${baseUrl}/${albumId}`, albumData);

export const deleteAlbum = async(albumId) => request.del(`${baseUrl}/${albumId}`);