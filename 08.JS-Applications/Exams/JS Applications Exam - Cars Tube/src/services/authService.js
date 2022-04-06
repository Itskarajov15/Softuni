export const saveUser = (user) => {
    localStorage.setItem('user', JSON.stringify(user));
}

export const removeUser = () => {
    localStorage.removeItem('user');
}

export const getUser = () => {
    const serializedUser = localStorage.getItem('user');
    
    if (serializedUser) {
        return JSON.parse(serializedUser);
    }
}

export const getAccessToken = () => {
    return getUser()?.accessToken;
}