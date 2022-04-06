import page from '../node_modules/page/page.mjs';

import { renderNavigationMiddleware, renderContentMiddleware } from './middlewares/renderMiddleware.js';
import { authMiddleware } from './middlewares/authMiddleware.js';
import { loginView } from './views/loginView.js';
import { registerView } from './views/registerView.js';
import { logoutView } from './views/logoutView.js';
import { homeView } from './views/homeView.js';
import { dashboardView } from './views/dashboardView.js';
import { createView } from './views/createView.js';
import { detailsView } from './views/detailsView.js';
import { editView } from './views/editView.js';
import { deleteView } from './views/deleteView.js';

page(authMiddleware);
page(renderNavigationMiddleware);
page(renderContentMiddleware);

page('/', homeView);
page('/dashboard', dashboardView);
page('/login', loginView);
page('/register', registerView);
page('/logout', logoutView);
page('/create', createView);
page('/details/:id', detailsView);
page('/details/:id/edit', editView);
page('/details/:id/delete', deleteView);

page.start();