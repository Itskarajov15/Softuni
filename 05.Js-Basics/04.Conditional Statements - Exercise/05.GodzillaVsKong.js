function godzillaVsKong(input){
    let budget = Number(input[0]);
    let numberOfStatists = Number(input[1]);
    let priceOfOutfit = Number(input[2]);

    let moneyForDecor = budget * 0.1;

    if(numberOfStatists > 150){
        priceOfOutfit -= priceOfOutfit * 0.1;
    }

    let moneyForOutfits = numberOfStatists * priceOfOutfit;
    let neededMoney = moneyForOutfits + moneyForDecor;

    if(budget >= neededMoney){
        console.log("Action!");
        console.log(`Wingard starts filming with ${(budget - neededMoney).toFixed(2)} leva left.`)
    } else {
        console.log("Not enough money!");
        console.log(`Wingard needs ${(neededMoney - budget).toFixed(2)} leva more.`)
    }
}

godzillaVsKong(["20000", "120", "55.5"]);
