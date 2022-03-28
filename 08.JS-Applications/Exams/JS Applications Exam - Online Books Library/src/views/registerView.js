import { html } from '../../node_modules/lit-html/lit-html.js';

import * as userService from '../services/userService.js';

const registerTemplate = (registerHandler) => html`
    <section id="register-page" class="register">
        <form id="register-form" action="" method="" @submit=${registerHandler}>
            <fieldset>
                <legend>Register Form</legend>
                <p class="field">
                    <label for="email">Email</label>
                    <span class="input">
                        <input type="text" name="email" id="email" placeholder="Email">
                    </span>
                </p>
                <p class="field">
                    <label for="password">Password</label>
                    <span class="input">
                        <input type="password" name="password" id="password" placeholder="Password">
                    </span>
                </p>
                <p class="field">
                    <label for="repeat-pass">Repeat Password</label>
                    <span class="input">
                        <input type="password" name="confirm-pass" id="repeat-pass" placeholder="Repeat Password">
                    </span>
                </p>
                <input class="button submit" type="submit" value="Register">
            </fieldset>
        </form>
    </section>
`;

export const registerView = (ctx) => {
    const registerHandler = async (e) => {
        e.preventDefault();

        const formData = new FormData(e.currentTarget);
        const email = formData.get('email');
        const password = formData.get('password');
        const confirmPass = formData.get('confirm-pass');

        if (!email || !password || !confirmPass) {
            alert('All fields must be filled!');
            return;
        } else if (password !== confirmPass) {
            alert('Passwords don\'t match');
            return;
        }

        const response = await userService.register(email, password);
        e.target.reset();
        ctx.page.redirect('/');
    }

    ctx.render(registerTemplate(registerHandler));
}