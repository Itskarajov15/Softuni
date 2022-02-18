window.addEventListener('load', solve);

function solve() {
    let addButton = document.getElementById('add-btn');
    addButton.addEventListener('click', addToFavourite);

    let genreElement = document.getElementById('genre');
    let nameElement = document.getElementById('name');
    let authorElement = document.getElementById('author');
    let dateElement = document.getElementById('date');
    let allHitsDiv = document.querySelector('.all-hits-container');
    let savedHitsDiv = document.querySelector('.saved-container');

    function addToFavourite(e) {
        e.preventDefault();

        if (genreElement.value && nameElement.value && authorElement.value && dateElement.value) {
            let hitsInfoDiv = createEl('div', '', 'hits-info');
            
            let imgElement = document.createElement('img');
            imgElement.setAttribute('src', './static/img/img.png');

            let h2GenreElement = createEl('h2', `Genre: ${genreElement.value}`);
            let h2NameElement = createEl('h2', `Name: ${nameElement.value}`);
            let h2AuthorElement = createEl('h2', `Author: ${authorElement.value}`);
            let h3DateElement = createEl('h3', `Date: ${dateElement.value}`);
            
            let saveButton = createEl('button', 'Save song', 'save-btn');
            saveButton.addEventListener('click', addSongToSaved);
            let likeButton = createEl('button', 'Like song', 'like-btn');
            likeButton.addEventListener('click', likeSong);
            let deleteButton = createEl('button', 'Delete', 'delete-btn');
            deleteButton.addEventListener('click', deleteSong);

            hitsInfoDiv.appendChild(imgElement);
            hitsInfoDiv.appendChild(h2GenreElement);
            hitsInfoDiv.appendChild(h2NameElement);
            hitsInfoDiv.appendChild(h2AuthorElement);
            hitsInfoDiv.appendChild(h3DateElement);
            hitsInfoDiv.appendChild(saveButton);
            hitsInfoDiv.appendChild(likeButton);
            hitsInfoDiv.appendChild(deleteButton);

            allHitsDiv.appendChild(hitsInfoDiv);

            genreElement.value = '';
            nameElement.value = '';
            authorElement.value = '';
            dateElement.value = '';
        }
    }

    function deleteSong(e) {
        e.target.parentElement.remove();
    }

    function addSongToSaved(e) {
        savedHitsDiv.appendChild(e.target.parentElement);

        e.target.parentElement.querySelector('.like-btn').remove();
        e.target.remove();
    }

    function likeSong(e) {
        let likesPElement = document.querySelector('.likes p');
        let likes = Number(likesPElement.textContent.split(' ')[2]);
        likes++;

        likesPElement.textContent = `Total Likes: ${likes}`;
        e.target.disabled = true;
    }

    function createEl(type, text, className) {
        const result = document.createElement(type);
        result.textContent = text;
        if (className) {
            result.className = className;
        }
        return result;
    }
}