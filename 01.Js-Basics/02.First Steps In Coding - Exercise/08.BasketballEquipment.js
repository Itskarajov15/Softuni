function basketballEquipment(input){
    let priceForTrainings = Number(input[0]);
    let priceForBoots = priceForTrainings - (priceForTrainings * 0.4);
    let priceForOutfit = priceForBoots - (priceForBoots * 0.2);
    let priceForBall = priceForOutfit / 4;
    let priceForAccessories = priceForBall / 5;

    let finalPrice = priceForTrainings + priceForBoots + priceForOutfit + priceForBall + priceForAccessories;

    console.log(finalPrice);
}

basketballEquipment(["365"]);