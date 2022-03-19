import { html, render } from '../../node_modules/lit-html/lit-html.js';

const rowTemplate = (person, select) => html`     
   <tr class=${select ? 'select' : ''}>
      <td>${person.firstName} ${person.lastName}</td>
      <td>${person.email}</td>
      <td>${person.course}</td>
   </tr>
`;

const tbodyElement = document.querySelector('tbody');
start();

async function start() {
   document.getElementById('searchBtn').addEventListener('click', () => {
      const searchField = document.getElementById('searchField');
      update(list, searchField.value);
   });

   const res = await fetch('http://localhost:3030/jsonstore/advanced/table');
   const data = await res.json();
   const list = Object.values(data);

   update(list);
}

function update(list, match = '') {
   const result = list.map(e => rowTemplate(e, compare(e, match)));
   render(result, tbodyElement);    
}

function compare(item, match) {
   return Object.values(item).some(v => match && v.toLowerCase().includes(match.toLowerCase()));
}