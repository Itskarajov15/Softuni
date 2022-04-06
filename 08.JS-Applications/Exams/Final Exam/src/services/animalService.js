import * as request from './request.js';

export const getAllAnimals = async () => {
    return await request.get('/data/pets?sortBy=_createdOn%20desc&distinct=name');
}

export const getAnimalById = async (animalId) => {
    return await request.get(`/data/pets/${animalId}`);
}
    
export const createAnimal = async (animal) => {
    return await request.post('/data/pets', animal);
}

export const editAnimal = async (animalId, animal) => {
    return await request.put(`/data/pets/${animalId}`, animal);
}

export const deleteAnimal = async (animalId) => {
    return await request.del(`/data/pets/${animalId}`);
}

export const donate = async (petId) => {
    return await request.post('/data/donation', { petId });
}

export const getAllDonatesByPetId = async (petId) => {
    return await request.get(`/data/donation?where=petId%3D%22${petId}%22&distinct=_ownerId&count`);
}

export const getMyDonationByPetId = async (petId, userId) => {
    return await request.get(`/data/donation?where=petId%3D%22${petId}%22%20and%20_ownerId%3D%22${userId}%22&count`);
}