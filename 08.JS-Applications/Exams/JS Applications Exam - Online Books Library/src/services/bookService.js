import * as request from './request.js';

export const createBook = async (book) => {
    return await request.post('/data/books', book);
}

export const deleteBook = async (bookId) => {
    return await request.del(`/data/books/${bookId}`);
}

export const updateBook = async (bookId, book) => {
    return await request.put(`/data/books/${bookId}`, book);
}

export const getAllBooks = async () => {
    return await request.get('/data/books?sortBy=_createdOn%20desc');
}

export const getBook = async (bookId) => {
    return await request.get(`/data/books/${bookId}`);
}

export const getBooksByAuthor = async (authorId) => {
    return await request.get(`/data/books?where=_ownerId%3D%22${authorId}%22&sortBy=_createdOn%20desc`);
}

export const likeBook = async (bookId) => {
    return await request.post('/data/likes', { bookId });
}

export const getAllLikesByBookId = async (bookId) => {
    return await request.get(`/data/likes?where=bookId%3D%22${bookId}%22&distinct=_ownerId&count`)
}

export const getMyLike = async (bookId, userId) => {
    return await request.get(`/data/likes?where=bookId%3D%22${bookId}%22%20and%20_ownerId%3D%22${userId}%22&count`);
}