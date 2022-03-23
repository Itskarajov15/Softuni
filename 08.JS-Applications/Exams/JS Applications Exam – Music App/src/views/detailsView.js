import { html, nothing } from '../../node_modules/lit-html/lit-html.js';
import * as albumService from '../services/albumService.js';

const userTemplate = (albumId) => html`
    <div class="actionBtn">
        <a href="/albums/${albumId}/edit" class="edit">Edit</a>
        <a href="/albums/${albumId}/delete" class="remove">Delete</a>
    </div>
`;

const detailsTemplate = (album, withUser = true) => html`
    <section id="detailsPage">
        <div class="wrapper">
            <div class="albumCover">
                <img src="${album.imgUrl}">
            </div>
            <div class="albumInfo">
                <div class="albumText">
    
                    <h1>Name: ${album.name}</h1>
                    <h3>Artist: ${album.artist}</h3>
                    <h4>Genre: ${album.genre}</h4>
                    <h4>Price: $${album.price}</h4>
                    <h4>Date: ${album.releaseDate}</h4>
                    <p>Description: ${album.description}</p>
                </div>

                ${withUser
                    ? userTemplate(album._id)
                    : nothing
                }

            </div>
        </div>
    </section>
`;

export const detailsView = async (ctx) => {
    let currAlbum = await albumService.getCurrentAlbum(ctx.params.id);

    ctx.render(detailsTemplate(currAlbum, Boolean(currAlbum._ownerId == ctx.user._id)));
}