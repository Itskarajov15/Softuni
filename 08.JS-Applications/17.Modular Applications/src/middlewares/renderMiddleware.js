import { render, html } from '../../node_modules/lit-html/lit-html.js';
import { navigationView } from '../views/navigation.js';

const root = document.querySelector('#root');
const ctxRender = (ctx, tempalteResult) => {
    let layout = html`
        <nav>
            ${navigationView(ctx)}
        </nav>
        <main>
            ${tempalteResult}
        </main>
    `;

    render(layout, root);
}

export const renderMiddleware = (ctx, next) => {
    ctx.render = ctxRender.bind(null, ctx);

    next();
}