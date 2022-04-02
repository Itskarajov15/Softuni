import * as animalService from '../services/animalService.js';

export const deleteView = async (ctx) => {
    let result = confirm('Are you sure you want to delete this animal?');
    if (result) {
        const res = await animalService.deleteAnimal(ctx.params.id);
        ctx.page.redirect('/');
    } else {
        return;
    }
}