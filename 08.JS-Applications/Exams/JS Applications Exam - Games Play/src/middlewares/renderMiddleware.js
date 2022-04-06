import { render } from '../../node_modules/lit-html/lit-html.js';
import { navigationView } from '../views/navigationView.js';

const headerSection = document.querySelector('#navigation-header');
const mainSection = document.querySelector('#main-content');

export const renderNavigationMiddleware = (ctx, next) => {
    render(navigationView(ctx), headerSection);
    next();
}

export const renderContentMiddleware = (ctx, next) => {
    ctx.render = (contentTemplate) => render(contentTemplate, mainSection); 
    next();
}