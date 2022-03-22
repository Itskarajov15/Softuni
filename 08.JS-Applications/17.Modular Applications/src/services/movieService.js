const baseUrl = 'http://localhost:3030/data/movies';

export const getAll = async () => {
    const res = await fetch(baseUrl);
    return await res.json();
} 