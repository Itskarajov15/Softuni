import { render } from '../../node_modules/lit-html/lit-html.js';

import { navigationView } from '../views/navigationView.js';

const headerElement = document.querySelector('#site-header');
const mainElement = document.querySelector('#site-content');

export const renderContentMiddleware = (ctx, next) => {
    ctx.render = (templateResult) => render(templateResult, mainElement);

    next();
} 

export const renderNavigationMiddleware = (ctx, next) => {
    render(navigationView(ctx), headerElement);

    next();
}