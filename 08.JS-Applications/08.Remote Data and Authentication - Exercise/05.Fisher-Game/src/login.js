const formElement = document.querySelector('form');
formElement.addEventListener('submit', login);

const logoutElement = document.getElementById('logout');
logoutElement.addEventListener('click', async () => {
    const url = 'http://localhost:3030/users/logout';

    const userObj = JSON.parse(sessionStorage.userData);
    const res = await fetch(url, {
        headers: {
            "X-Authorization": userObj.accessToken
        }
    });

    if (res.ok) {
        sessionStorage.clear();
        window.location = 'index.html';
    }
});

async function login(e) {
    e.preventDefault();

    const url = 'http://localhost:3030/users/login';
    const formData = new FormData(e.currentTarget);
    const email = formData.get('email');
    const password = formData.get('password');

    try {
        const res = await fetch(url, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ email, password })
        });

        if (res.ok != true) {
            const err = await res.json();
            throw new Error(err.message);
        }

        const data = await res.json();

        console.log(data);
        sessionStorage.setItem('userData', JSON.stringify(data));
        window.location = 'index.html';
        formElement.reset();
    } catch (error) {
        alert(error.message);
    }
}

window.onload = () => {
    if (sessionStorage.userData) {
        const userObj = JSON.parse(sessionStorage.userData);
        console.log(userObj);
        const userSpan = document.getElementById('user-span');
        userSpan.textContent = userObj.username;
        const divGuestElement = document.getElementById('guest');
        divGuestElement.style.display = 'none';
    } else {
        const userLogout = document.getElementById('user');
        userLogout.style.display = 'none';
    }
};