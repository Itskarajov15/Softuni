import { html, nothing } from '../../node_modules/lit-html/lit-html.js';
import * as albumService from '../services/albumService.js';

const details = (albumId) => html`
    <div class="btn-group">
        <a href="/albums/${albumId}" id="details">Details</a>
    </div>
`;

const cardTemplate = (album, withDetails = true) => html`
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

            ${withDetails
                ? details(album._id)
                : nothing
            }

        </div>
    </div>
`;

const catalogTemplate = (albums, user) => html`
    <section id="catalogPage">
        <h1>All Albums</h1>
    
        ${albums.map(a => cardTemplate(a, Boolean(user)))}
        
        ${albums.length == 0
            ? html`<p>No Albums in Catalog!</p>`
            : nothing
        }
    
    </section>
`;

export const catalogView = async (ctx) => {
    const albums = await albumService.getAll();
    const user = ctx.user;

    ctx.render(catalogTemplate(albums, user));
}