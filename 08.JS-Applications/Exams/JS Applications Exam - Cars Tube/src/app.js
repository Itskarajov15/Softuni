import page from '../node_modules/page/page.mjs';

import { authMiddleware } from './middlewares/authMiddleware.js';
import { renderNavigationMiddleware, renderContentMiddleware } from './middlewares/renderMiddleware.js';
import { catalogView } from './views/catalogView.js';
import { createView } from './views/createView.js';
import { deleteView } from './views/deleteView.js';
import { detailsView } from './views/detailsView.js';
import { editView } from './views/editView.js';
import { homeView } from './views/homeView.js';
import { loginView } from './views/loginView.js';
import { logoutView } from './views/logoutView.js';
import { registerView } from './views/registerView.js';
import { myListingsView } from './views/myListingsView.js';

page(authMiddleware);
page(renderNavigationMiddleware);
page(renderContentMiddleware);

page('/', homeView);
page('/login', loginView);
page('/register', registerView);
page('/logout', logoutView);
page('/catalog', catalogView);
page('/my-listings', myListingsView);
page('/create', createView);
page('/details/:id', detailsView);
page('/details/:id/edit', editView);
page('/details/:id/delete', deleteView);

page.start();