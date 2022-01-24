function search() {
   let towns = document.querySelectorAll('#towns li');
   let townsArr = Array.from(towns);

   let searchText = document.getElementById('searchText').value;
   let count = 0;

   townsArr.forEach(town => {
      if (town.textContent.includes(searchText)) {
         count++;
         town.style.textDecoration = 'underline';
         town.style.fontWeight = 'bold';
      } else{
         town.style.textDecoration = 'normal';
         town.style.fontWeight = 'none';
      }
   })

   let resultElement = document.getElementById('result');
   resultElement.textContent = `${count} matches found`;
}
