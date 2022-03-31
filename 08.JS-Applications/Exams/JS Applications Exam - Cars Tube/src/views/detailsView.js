import { html, nothing } from '../../node_modules/lit-html/lit-html.js';

import * as carsService from '../services/carsService.js';

const creatorLinks = (carId) => html`
    <div class="listings-buttons">
        <a href="/details/${carId}/edit" class="button-list">Edit</a>
        <a href="/details/${carId}/delete" class="button-list">Delete</a>
    </div>
`;

const detailsTemplate = (car, isCreator) => html`
    <section id="listing-details">
        <h1>Details</h1>
        <div class="details-info">
            <img src="${car.imageUrl}">
            <hr>
            <ul class="listing-props">
                <li><span>Brand:</span>${car.brand}</li>
                <li><span>Model:</span>${car.model}</li>
                <li><span>Year:</span>${car.year}</li>
                <li><span>Price:</span>${car.price}$</li>
            </ul>
    
            <p class="description-para">${car.description}</p>
    
            ${isCreator
                ? creatorLinks(car._id)
                : nothing
            }

        </div>
    </section>
`;

export const detailsView = async (ctx) => {
    const car = await carsService.getCar(ctx.params.id);
    const isCreator = Boolean(ctx.user && car._ownerId == ctx.user._id);

    ctx.render(detailsTemplate(car, isCreator));
}