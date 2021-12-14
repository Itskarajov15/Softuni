function foodDelivery(input){
    let priceForChickenMenu = 10.35;
    let priceForFishMenu = 12.40;
    let priceForVegeterianMenu = 8.15;

    let numberOfChichenMenus = Number(input[0]);
    let numberOfFishMenus = Number(input[1]);
    let numberOfVegeterianMenus = Number(input[2]);

    let totalSumOfMenus = (numberOfChichenMenus * priceForChickenMenu) + (numberOfFishMenus * priceForFishMenu)
    + (numberOfVegeterianMenus * priceForVegeterianMenu);

    let priceOfDessert = totalSumOfMenus * 0.2;

    let finalPrice = totalSumOfMenus + priceOfDessert + 2.50;

    console.log(finalPrice);
}

foodDelivery(["2", "4", "3"]);