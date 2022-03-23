import { render } from '../../node_modules/lit-html/lit-html.js';
import { navigationView } from '../views/navigationView.js';

const navHeader = document.querySelector('.navigation-header');
const main = document.querySelector('#main-content');

const renderContent = (templateResult) => {
    render(templateResult, main);
}

export const renderNavigationMiddleware = (ctx, next) => {
    render(navigationView(ctx), navHeader);
    next();
}

export const renderContentMiddleware = (ctx, next) => {
    ctx.render = renderContent;

    next();
}