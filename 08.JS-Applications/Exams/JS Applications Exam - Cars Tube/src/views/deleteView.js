import * as carsService from '../services/carsService.js';

export const deleteView = async (ctx) => {
    const res = await carsService.deleteCar(ctx.params.id);
    ctx.page.redirect('/catalog');
}