function toyShop(input){
    let priceOfPuzzle = 2.60;
    let priceOfDoll = 3;
    let priceOfBear = 4.10;
    let priceOfMinion = 8.20;
    let priceOfTruck = 2;

    let priceOfExcursion = Number(input[0]);
    let numberOfPuzzles = Number(input[1]);
    let numberOfDolls = Number(input[2]);
    let numberOfBears = Number(input[3]);
    let numberOfMinions = Number(input[4]);
    let numberOfTrucks = Number(input[5]);

    let totalSum = (numberOfPuzzles * priceOfPuzzle) + (numberOfDolls * priceOfDoll) + (numberOfBears * priceOfBear)
    +(numberOfMinions * priceOfMinion) + (numberOfTrucks * priceOfTruck);
    let numberOfToys = numberOfPuzzles + numberOfDolls + numberOfBears + numberOfMinions + numberOfTrucks;

    if(numberOfToys >= 50){
        totalSum -= totalSum * 0.25;
    }

    totalSum -= totalSum * 0.1;

    if(totalSum >= priceOfExcursion){
        let moneyLeft = totalSum - priceOfExcursion;

        console.log(`Yes! ${moneyLeft.toFixed(2)} lv left.`)
    } else{
        let moneyNeeded = priceOfExcursion - totalSum;

        console.log(`Not enough money! ${moneyNeeded.toFixed(2)} lv needed.`)
    }
}

toyShop(["40.8", "20", "25", "30", "50", "10"]);
