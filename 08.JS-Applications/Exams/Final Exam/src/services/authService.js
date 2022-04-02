export const saveUser = (user) => {
    localStorage.setItem('user', JSON.stringify(user));
}

export const getUser = () => {
    let serializedUser = localStorage.getItem('user');
    if (serializedUser) {
        return JSON.parse(serializedUser);
    }
}

export const getAccessToken = () => {
    return getUser()?.accessToken;
}

export const removeUser = () => {
    localStorage.removeItem('user');
}