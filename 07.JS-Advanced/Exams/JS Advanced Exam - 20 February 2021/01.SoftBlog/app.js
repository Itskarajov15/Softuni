function solve(){
   document.getElementsByClassName('btn create')[0].addEventListener('click', createPost);

   function createPost(e) {
      e.preventDefault();

      let authorElement = document.getElementById('creator');
      let titleElement = document.getElementById('title');
      let categoryElement = document.getElementById('category');
      let contentElement = document.getElementById('content');

      let articleElement = createEl('article')

      let h1Element = createEl('h1', titleElement.value);

      let pCategoryElement = createEl('p', 'Category: ');
      let strongCategoryElement = createEl('strong', categoryElement.value);
      pCategoryElement.appendChild(strongCategoryElement);

      let pCreatorElement = createEl('p', 'Creator: ');
      let strongCreatorElement = createEl('strong', authorElement.value);
      pCreatorElement.appendChild(strongCreatorElement);

      let pContentElement = createEl('p', contentElement.value);

      let divElement = createEl('div', '', 'buttons');
      let deleteButton = createEl('button', 'Delete', 'btn delete');
      deleteButton.addEventListener('click', () => deleteArticle(articleElement));
      let archiveButton = createEl('button', 'Archive', 'btn archive');
      archiveButton.addEventListener('click', moveArticlesToArchive);

      divElement.appendChild(deleteButton);
      divElement.appendChild(archiveButton);

      articleElement.appendChild(h1Element);
      articleElement.appendChild(pCategoryElement);
      articleElement.appendChild(pCreatorElement);
      articleElement.appendChild(pContentElement);
      articleElement.appendChild(divElement);

      document.querySelector('.site-content > main > section').appendChild(articleElement);
   }

   function deleteArticle(el) {
      el.remove();
   }

   function createEl(type, text, className) {
      const result = document.createElement(type);
      result.textContent = text;
      if (className) {
         result.className = className;
      }

      return result;
   }

   function moveArticlesToArchive(e) {
      let articleTitleElement = e.target.parentElement.parentElement.querySelector('h1');
      e.target.parentElement.parentElement.remove();

      let liElement = createEl('li', articleTitleElement.textContent);
      let olElement = document.querySelector('.archive-section > ol');
      olElement.appendChild(liElement);
      
      sortList(olElement);
   }

   function sortList(collection) {
      Array.from(collection.children)
         .sort((a, b) => a.textContent.localeCompare(b.textContent))
         .forEach(li => collection.appendChild(li));
   }
}
