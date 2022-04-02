import { html, nothing } from '../../node_modules/lit-html/lit-html.js';

import * as animalService from '../services/animalService.js';

const creatorLinks = (animalId) => html`
    <a href="/details/${animalId}/edit" class="edit">Edit</a>
    <a href="/details/${animalId}/delete" class="remove">Delete</a>
`;

const userLinks = (user, isCreator, animalId, onDonate, hasDonation) => html`
    <div class="actionBtn">

        ${user && isCreator
            ? creatorLinks(animalId)
            : nothing
        }

        ${user && !isCreator && !hasDonation
            ? html`<a @click="${onDonate}" href="javascript:void(0)" class="donate">Donate</a>`
            : nothing
        }
    </div>
`;

const detailsTemplate = (user, isCreator, animal, donations, onDonate, hasDonation) => html`
    <section id="detailsPage">
        <div class="details">
            <div class="animalPic">
                <img src="${animal.image}">
            </div>
            <div>
                <div class="animalInfo">
                    <h1>Name: ${animal.name}</h1>
                    <h3>Breed: ${animal.breed}</h3>
                    <h4>Age: ${animal.age}</h4>
                    <h4>Weight: ${animal.weight}</h4>
                    <h4 class="donation">Donation: ${donations}$</h4>
                </div>

                ${
                    userLinks(user, isCreator, animal._id, onDonate, hasDonation)
                }

            </div>
        </div>
    </section>
`;

export const detailsView = async (ctx) => {
    const user = ctx.user;

    let [ animal, allDonations, hasDonation ] = await Promise.all([
        animalService.getAnimalById(ctx.params.id),
        animalService.getAllDonatesByPetId(ctx.params.id),
        user ? animalService.getMyDonationByPetId(ctx.params.id, user._id) : 0
    ]);

    const isCreator = Boolean(user && user._id == animal._ownerId);

    console.log(animal, allDonations, hasDonation, isCreator);

    const onDonate = async (e) => {
        const res = await animalService.donate(animal._id);
        ctx.page.redirect(`/details/${ctx.params.id}`);
        console.log(res);
    }

    ctx.render(detailsTemplate(user, isCreator, animal, allDonations * 100, onDonate, hasDonation));
}