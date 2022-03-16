import { showHome } from './views/home.js';
import { showRegister } from './views/register.js';
import { showLogin } from './views/login.js';
import { showCatalog } from './views/catalog.js';
import { showDetails } from './views/details.js';
import { showCreate } from './views/create.js';
import { initialize } from './views/register.js'


document.getElementById('views').remove();

const links = {
    '/': showHome,
    '/register': showRegister,
    '/login': showLogin,
    '/catalog': showCatalog,
    '/details': showDetails,
    '/create': showCreate
} 

const router = initialize(links);

router.goTo('/');