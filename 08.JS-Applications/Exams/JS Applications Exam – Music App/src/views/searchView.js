import { html, nothing } from '../../node_modules/lit-html/lit-html.js';

import * as albumService from '../services/albumService.js';

const albumTemplate = (album) => html`
    <div class="card-box">
        <img src="${album.imgUrl}">
        <div>
            <div class="text-center">
                <p class="name">Name: ${album.name}</p>
                <p class="artist">Artist: ${album.artist}</p>
                <p class="genre">Genre: ${album.genre}</p>
                <p class="price">Price: $${album.price}</p>
                <p class="date">Release Date: ${album.releaseDate}</p>
            </div>
            <div class="btn-group">
                <a href="/details/${album._id}" id="details">Details</a>
            </div>
        </div>
    </div>
`;

const displayResults = (matches) => {
    if (matches.length > 0) {
        return matches.map((m) => albumTemplate(m));
    } else {
        return html`<p class="no-result">No result.</p>`;
    }
}

const searchTemplate = (onSearch, matches, showResults) => html`
    <section id="searchPage">
        <h1>Search by Name</h1>
    
        <div class="search">
            <input id="search-input" type="text" name="search" placeholder="Enter desired albums's name">
            <button class="button-list" @click=${onSearch}>Search</button>
        </div>
    
        <h2>Results:</h2>

        <div class="search-result">

        ${showResults
            ? displayResults(matches)
            : nothing
        }

        </div>
    </section>
`;

export const searchView = (ctx) => {
    const onSearch = async (e) => {
        const searchInputElement = document.querySelector('#search-input');
        const searchText = searchInputElement.value;

        if (!searchText) {
            alert('Search field must be filled!');
            return;
        }

        const matches = await albumService.searchAlbum(searchText);
        ctx.render(searchTemplate(onSearch, matches, true));
    }

    ctx.render(searchTemplate(onSearch, [], false));
}