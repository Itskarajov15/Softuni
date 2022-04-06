import { html } from '../../node_modules/lit-html/lit-html.js';

import * as userService from '../services/userService.js';

const registerTemplate = (onRegister) => html`
    <section id="register">
        <div class="container">
            <form id="register-form" @submit=${onRegister}>
                <h1>Register</h1>
                <p>Please fill in this form to create an account.</p>
                <hr>
    
                <p>Username</p>
                <input type="text" placeholder="Enter Username" name="username" required>
    
                <p>Password</p>
                <input type="password" placeholder="Enter Password" name="password" required>
    
                <p>Repeat Password</p>
                <input type="password" placeholder="Repeat Password" name="repeatPass" required>
                <hr>
    
                <input type="submit" class="registerbtn" value="Register">
            </form>
            <div class="signin">
                <p>Already have an account?
                    <a href="/login">Sign in</a>.
                </p>
            </div>
        </div>
    </section>
`;

export const registerView = (ctx) => {
    const onRegister = async (e) => {
        e.preventDefault();

        const { username, password, repeatPass } = Object.fromEntries(new FormData(e.currentTarget));

        if (!username || !password || !repeatPass) {
            alert('All fields must be filled!');
            return
        } else if (password !== repeatPass) {
            alert('Passwords don\'t match');
            return;
        }

        const res = await userService.register(username, password);
        e.target.reset();
        ctx.page.redirect('/catalog');
    }

    ctx.render(registerTemplate(onRegister));
}