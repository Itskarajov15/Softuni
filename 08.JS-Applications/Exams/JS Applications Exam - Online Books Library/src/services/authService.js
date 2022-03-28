export const saveUser = (user) => {
    if (user.accessToken) {
        localStorage.setItem('user', JSON.stringify(user));
    }
}

export const getUser = () => {
    const serializedUser = localStorage.getItem('user');

    if (serializedUser) {
        return JSON.parse(serializedUser);
    }
}