function fishingBoat(input){
    let budget = Number(input[0]);
    let season = input[1];
    let numberOfFisherman = Number(input[2]);

    let neededSum = 0;

    switch(season){
        case "Spring":
            neededSum = 3000;
            break;
        case "Summer":
        case "Autumn":
            neededSum = 4200;
            break;
        case "Winter":
            neededSum = 2600;
            break;
    }

    if(numberOfFisherman <= 6){
        neededSum -= neededSum * 0.1;
    } else if(numberOfFisherman >= 7 && numberOfFisherman <= 11){
        neededSum -= neededSum * 0.15;
    } else{
        neededSum -= neededSum * 0.25;
    }

    if(numberOfFisherman % 2 === 0 && season !== "Autumn"){
        neededSum -= neededSum * 0.05;
    }

    if(budget >= neededSum){
        console.log(`Yes! You have ${(budget - neededSum).toFixed(2)} leva left.`)
    } else{
        console.log(`Not enough money! You need ${(neededSum - budget).toFixed(2)} leva.`)
    }
}

fishingBoat(["3000", "Summer", "11"]);