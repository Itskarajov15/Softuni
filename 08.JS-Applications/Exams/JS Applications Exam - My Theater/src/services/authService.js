export const saveUser = (user) => {
    localStorage.setItem('user', JSON.stringify(user));
}

export const getAccessToken = () => {
    return getUser()?.accessToken;
}

export const getUser = () => {
    let serialezedUser = localStorage.getItem('user');
    if (serialezedUser) {
        return JSON.parse(serialezedUser);
    }
}

export const removeUser = () => {
    localStorage.removeItem('user');
}