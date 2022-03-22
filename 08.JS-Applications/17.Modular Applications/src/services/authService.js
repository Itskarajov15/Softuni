const baseUrl = 'http://localhost:3030/users';

const save = (user) => {
    localStorage.setItem('accessToken', user.accessToken);
    localStorage.setItem('email', user.email);
    localStorage.setItem('username', user.username);
    localStorage.setItem('_id', user._id);
}

export const login = async (email, password) => {
    const res = await fetch(`${baseUrl}/login`, { 
        method: 'POST', 
        headers: { 'Content-Type': 'application.json' },
        body: JSON.stringify({ email, password})
    });

    let user = await res.json();
    save(user);

    return user;
}

export const isAuthenticated = () => {
    let accessToken = localStorage.getItem('accessToken');

    return Boolean(accessToken);
}

export const logout = async () => {
    let accessToken = localStorage.getItem('accessToken');

    const res = await fetch(`${baseUrl}/logout`, {
        headers: {
            'X-Authorization': accessToken
        } 
    });

    localStorage.clear();
}