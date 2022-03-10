import { showView, updateNav } from "./util.js";
import { homePage } from './home.js';
import { createPage } from './create.js';
import { loginPage } from './login.js';

const routes = {
    '/': homePage,
    '/login': loginPage,
    '/logout': logoutPage,
    '/register': registerPage,
    '/create': createPage,
}

document.querySelector('nav').addEventListener('click', onNavigate);
document.querySelector('#add-movie-button a').addEventListener('click', onNavigate);

function onNavigate(event) {
    if (event.target.tagName === 'A' && event.target.href) {
        event.preventDefault();
        const url = new URL(event.target.href);
        const view = routes[url.pathname];

        if (typeof view == 'function') {
            view();
        }
    }
}

const registerSection = document.querySelector('#form-sign-up');
const editSection = document.querySelector('#edit-movie');

function registerPage() {
    showView(registerSection);
}

function editPage() {
    showView(editSection);
}

function logoutPage() {
    localStorage.removeItem('user');
    updateNav();
}

updateNav();
homePage();