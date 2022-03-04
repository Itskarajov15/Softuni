function attachEventListeners() {
    let formElement = document.getElementById('login-form');

    formElement.addEventListener('submit', login);
}

function login(e) {
    e.preventDefault();

    const formData = new FormData(e.target);
    let email = formData.get('email');
    let password = formData.get('password');

    const data = { email, password };
    const url = 'http://localhost:3030/users/login';

    fetch(url, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(data)
    })
        .then(response => response.json())
        .then(user => {
            console.log(user);
            localStorage.setItem('token', user.accessToken);
        });
}

function register(e) {
    e.preventDefault();

    const formData = new FormData(e.target);
    let email = formData.get('email');
    let password = formData.get('password');

    const data = { email, password };
    const url = 'http://localhost:3030/users/register';

    fetch(url, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(data)
    })
        .then(response => response.json())
        .then(user => console.log(user));
}

attachEventListeners();