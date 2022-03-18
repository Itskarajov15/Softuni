import { html, render } from '../../node_modules/lit-html/lit-html.js';
import template from './templates/listTemplate.js';

const inputTownsElement = document.getElementById('towns');
const rootElement = document.getElementById('root');
document.getElementById('btnLoadTowns').addEventListener('click', loadTowns);

function loadTowns(e) {
    e.preventDefault();

    let townsArray = inputTownsElement.value.split(', '); 
    render(template(townsArray), rootElement);
    inputTownsElement.value = '';
}