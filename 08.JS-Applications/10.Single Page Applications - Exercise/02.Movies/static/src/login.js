import { showView, updateNav } from './util.js';
import { homePage } from './home.js';

const loginSection = document.querySelector('#form-login');
const loginForm = document.querySelector('#form-login .text-center.border.border-light.p-5');
loginForm.addEventListener('submit', login);

export function loginPage() {
    showView(loginSection);
}

async function login(e) {
    e.preventDefault();

    const formData = new FormData(loginForm);
    const email = formData.get('email');
    const password = formData.get('password');

    try {
        const loginRes = await fetch('http://localhost:3030/users/login', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ email, password })
        });

        if (loginRes.ok != true) {
            const error = await loginRes.json();
            throw new Error(error.message);
        }

        const user = await loginRes.json();
        localStorage.setItem('user', JSON.stringify(user));
        updateNav();
        homePage();
        loginForm.reset();
    } catch (err) {
        alert(err.message);
    }
}