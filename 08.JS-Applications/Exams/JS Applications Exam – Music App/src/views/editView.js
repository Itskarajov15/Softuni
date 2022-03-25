import { html } from '../../node_modules/lit-html/lit-html.js';
import * as albumService from '../services/albumService.js';
import { validator } from '../utils.js/validators.js';

const editTemplate = (album, submitHandler) => html`
    <section class="editPage">
        <form @submit=${submitHandler}>
            <fieldset>
                <legend>Edit Album</legend>
    
                <div class="container">
                    <label for="name" class="vhide">Album name</label>
                    <input id="name" name="name" class="name" type="text" value=${album.name}>
    
                    <label for="imgUrl" class="vhide">Image Url</label>
                    <input id="imgUrl" name="imgUrl" class="imgUrl" type="text" value="${album.imgUrl}">
    
                    <label for="price" class="vhide">Price</label>
                    <input id="price" name="price" class="price" type="text" value=${album.price}>
    
                    <label for="releaseDate" class="vhide">Release date</label>
                    <input id="releaseDate" name="releaseDate" class="releaseDate" type="text" value=${album.releaseDate}>
    
                    <label for="artist" class="vhide">Artist</label>
                    <input id="artist" name="artist" class="artist" type="text" value=${album.artist}>
    
                    <label for="genre" class="vhide">Genre</label>
                    <input id="genre" name="genre" class="genre" type="text" value=${album.genre}>
    
                    <label for="description" class="vhide">Description</label>
                    <textarea name="description" class="description" rows="10" .value=${album.description} cols="10"></textarea>
    
                    <button class="edit-album" type="submit">Edit Album</button>
                </div>
            </fieldset>
        </form>
    </section>
`; 

export const editView = async (ctx) => {
    const album = await albumService.getCurrentAlbum(ctx.params.id);

    const submitHandler = (e) => {
        e.preventDefault();

        const albumData = Object.fromEntries(new FormData(e.currentTarget));

        if (!validator(albumData)) {
            albumService.edit(ctx.params.id, albumData);

            ctx.page.redirect(`/albums/${album._id}`);
        } else {
            alert('All fields must be filled');
            return;
        }
    }

    ctx.render(editTemplate(album, submitHandler));
}