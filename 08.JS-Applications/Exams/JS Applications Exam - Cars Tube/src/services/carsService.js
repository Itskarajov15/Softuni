import * as request from '../services/request.js';

export const getAllCars = async () => {
    return await request.get('/data/cars?sortBy=_createdOn%20desc');
}

export const getCar = async (carId) => {
    return await request.get(`/data/cars/${carId}`);
}

export const getCarsByUserId = async (userId) => {
    return await request.get(`/data/cars?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`);
}

export const createCar = async (car) => {
    return await request.post('/data/cars', car);
}

export const editCar = async (carId, car) => {
    return await request.put(`/data/cars/${carId}`, car);
}

export const deleteCar = async (carId) => {
    return await request.del(`/data/cars/${carId}`);
}