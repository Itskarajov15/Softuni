import page from '../node_modules/page/page.mjs';
import { authMiddleware } from './middlewares/authMiddleware.js';
import { renderMiddleware } from './middlewares/renderMiddleware.js';

import { homeView } from './views/homeView.js';
import { loginView } from './views/loginView.js';
import { logoutView } from './views/logoutView.js';

page(authMiddleware);
page(renderMiddleware);

page('/', homeView);
page('/login', loginView)
page('/logout', logoutView);

page.start();