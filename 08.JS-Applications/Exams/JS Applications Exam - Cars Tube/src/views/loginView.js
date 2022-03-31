import { html } from '../../node_modules/lit-html/lit-html.js';

import * as userService from '../services/userService.js';

const loginTemplate = (onLogin) => html`
    <section id="login">
        <div class="container">
            <form id="login-form" action="#" method="post" @submit=${onLogin}>
                <h1>Login</h1>
                <p>Please enter your credentials.</p>
                <hr>
    
                <p>Username</p>
                <input placeholder="Enter Username" name="username" type="text">
    
                <p>Password</p>
                <input type="password" placeholder="Enter Password" name="password">
                <input type="submit" class="registerbtn" value="Login">
            </form>
            <div class="signin">
                <p>Dont have an account?
                    <a href="/register">Sign up</a>.
                </p>
            </div>
        </div>
    </section>
`;

export const loginView = (ctx) => {
    const onLogin = async (e) => {
        e.preventDefault();

        const { username, password } = Object.fromEntries(new FormData(e.currentTarget));

        if (!username || !password) {
            alert('All fields must be filled!');
            return;
        }

        const res = await userService.login(username, password);
        e.target.reset();
        ctx.page.redirect('/catalog');
    }

    ctx.render(loginTemplate(onLogin));
}