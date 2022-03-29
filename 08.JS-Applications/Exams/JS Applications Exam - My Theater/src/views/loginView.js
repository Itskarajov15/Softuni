import { html } from '../../node_modules/lit-html/lit-html.js';

import * as userService from '../services/userService.js';

const loginTemplate = (loginHandler) => html`
    <section id="loginaPage">
        <form class="loginForm" @submit=${loginHandler}>
            <h2>Login</h2>
            <div>
                <label for="email">Email:</label>
                <input id="email" name="email" type="text" placeholder="steven@abv.bg" value="">
            </div>
            <div>
                <label for="password">Password:</label>
                <input id="password" name="password" type="password" placeholder="********" value="">
            </div>
    
            <button class="btn" type="submit">Login</button>
    
            <p class="field">
                <span>If you don't have profile click <a href="/register">here</a></span>
            </p>
        </form>
    </section>
`;

export const loginView = (ctx) => {
    const loginHandler = async (e) => {
        e.preventDefault();

        const { email, password } = Object.fromEntries(new FormData(e.currentTarget));
        if (!email || !password) {
            alert('All fields must be filled!');
            return;
        }

        const res = await userService.login(email, password);
        e.target.reset();
        ctx.page.redirect('/');
    }

    ctx.render(loginTemplate(loginHandler));
}