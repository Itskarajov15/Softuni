function petShop(input){
    let dogFoodPrice = 2.5;
    let catFoodPrice = 4;

    let numberOfDogFoodPackages = Number(input[0]);
    let numberOfCatFoodPackages = Number(input[1]);

    let dogFoodTotalPrice = numberOfDogFoodPackages * dogFoodPrice;
    let catFoodTotalPrice = numberOfCatFoodPackages * catFoodPrice;

    console.log(`${dogFoodTotalPrice + catFoodTotalPrice} lv.`)
}

petShop(["5", "4"]);