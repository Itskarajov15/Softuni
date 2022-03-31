import { html } from '../../node_modules/lit-html/lit-html.js';

import * as carsService from '../services/carsService.js';

const createTemplate = (onCreate) => html`
    <section id="create-listing">
        <div class="container">
            <form id="create-form" @submit="${onCreate}">
                <h1>Create Car Listing</h1>
                <p>Please fill in this form to create an listing.</p>
                <hr>
    
                <p>Car Brand</p>
                <input type="text" placeholder="Enter Car Brand" name="brand">
    
                <p>Car Model</p>
                <input type="text" placeholder="Enter Car Model" name="model">
    
                <p>Description</p>
                <input type="text" placeholder="Enter Description" name="description">
    
                <p>Car Year</p>
                <input type="number" placeholder="Enter Car Year" name="year">
    
                <p>Car Image</p>
                <input type="text" placeholder="Enter Car Image" name="imageUrl">
    
                <p>Car Price</p>
                <input type="number" placeholder="Enter Car Price" name="price">
    
                <hr>
                <input type="submit" class="registerbtn" value="Create Listing">
            </form>
        </div>
    </section>
`;

export const createView = (ctx) => {
    const onCreate = async (e) => {
        e.preventDefault();

        let { brand, model, description, year, imageUrl, price } = Object.fromEntries(new FormData(e.currentTarget));

        if (!brand || !model || !description || !year || !imageUrl || !price) {
            alert('All fields must be filled!');
            return;
        }

        year = Number(year);
        price = Number(price);
        console.log(typeof year);
        console.log(year);

        const res = await carsService.createCar({ brand, model, description, year, imageUrl, price });
        ctx.page.redirect('/catalog');
    }

    ctx.render(createTemplate(onCreate));
}