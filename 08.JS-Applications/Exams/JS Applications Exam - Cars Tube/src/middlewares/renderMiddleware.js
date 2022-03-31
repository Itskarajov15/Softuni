import { render } from '../../node_modules/lit-html/lit-html.js';

import { navigationView } from '../views/navigationView.js';

const header = document.querySelector('#nav-header');
const main = document.querySelector('#site-content');

export const renderNavigationMiddleware = (ctx, next) => {
    render(navigationView(ctx), header);
    next();
}

export const renderContentMiddleware = (ctx, next) => {
    ctx.render = (tempalteResult) => render(tempalteResult, main);
    next();
}