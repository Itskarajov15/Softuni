function create(words) {
   for (const word of words) {
      let divElementParent = document.getElementById('content');

      let div = document.createElement('div');
      let p = document.createElement('p');

      p.textContent = word;
      p.style.display = 'none';
      div.appendChild(p);

      div.addEventListener('click', (e) => {
         e.target.children[0].style.display = 'block';
      })

      divElementParent.appendChild(div);
   }
}