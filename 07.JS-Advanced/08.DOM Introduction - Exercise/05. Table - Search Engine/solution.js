function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick() {
      let rows = document.querySelectorAll('.container tr');
      let searchedFieldElement = document.querySelector('#searchField');

      let rowsArr = Array.from(rows);

      for (const row of rowsArr) {
         if (row.textContent.includes(searchedFieldElement.value)) {
            row.classList.add('select');
         } else {
            row.classList.remove('select');
         }
      }

      searchedFieldElement.value = ' ';
   }
}