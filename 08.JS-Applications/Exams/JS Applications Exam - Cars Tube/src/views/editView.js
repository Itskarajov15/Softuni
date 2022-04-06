import { html } from '../../node_modules/lit-html/lit-html.js';

import * as carsService from '../services/carsService.js';

const editTemplate = (car, onEdit) => html`
    <section id="edit-listing">
        <div class="container">

            <form id="edit-form" @submit=${onEdit}>
                <h1>Edit Car Listing</h1>
                <p>Please fill in this form to edit an listing.</p>
                <hr>

                <p>Car Brand</p>
                <input type="text" placeholder="Enter Car Brand" name="brand" value="${car.brand}">

                <p>Car Model</p>
                <input type="text" placeholder="Enter Car Model" name="model" value="${car.model}">

                <p>Description</p>
                <input type="text" placeholder="Enter Description" name="description" value="${car.description}">

                <p>Car Year</p>
                <input type="number" placeholder="Enter Car Year" name="year" value="${car.year}">

                <p>Car Image</p>
                <input type="text" placeholder="Enter Car Image" name="imageUrl" value="${car.imageUrl}">

                <p>Car Price</p>
                <input type="number" placeholder="Enter Car Price" name="price" value="${car.price}">

                <hr>
                <input type="submit" class="registerbtn" value="Edit Listing">
            </form>
        </div>
    </section>
`;

export const editView = async (ctx) => {
    const car = await carsService.getCar(ctx.params.id);

    const onEdit = async (e) => {
        e.preventDefault();

        let { brand, model, description, year, imageUrl, price } = Object.fromEntries(new FormData(e.currentTarget));

        if (!brand || !model || !description || !year || !imageUrl || !price) {
            alert('All fields must be filled!');
            return;
        }

        year = Number(year);
        price = Number(price);

        const res = await carsService.editCar(ctx.params.id, { brand, model, description, year, imageUrl, price });
        e.target.reset();
        ctx.page.redirect(`/details/${ctx.params.id}`);
    }

    ctx.render(editTemplate(car, onEdit));
}