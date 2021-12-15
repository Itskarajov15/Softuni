function shopping(input){
    let budget = Number(input[0]);
    let numberOfVideoCards = Number(input[1]);
    let numberOfCPUs = Number(input[2]);
    let numberOfRam = Number(input[3]);

    let priceOfVideoCard = 250;

    let moneyForVideoCards = priceOfVideoCard * numberOfVideoCards;
    let priceOfCPU = moneyForVideoCards * 0.35;
    let moneyForCPUs = priceOfCPU * numberOfCPUs;
    let priceOfRam = moneyForVideoCards * 0.1;
    let moneyForRam = numberOfRam * priceOfRam;

    let totalSum = moneyForVideoCards + moneyForCPUs + moneyForRam;

    if(numberOfVideoCards > numberOfCPUs){
        totalSum -= totalSum * 0.15;
    }

    if(budget >= totalSum){
        console.log(`You have ${(budget - totalSum).toFixed(2)} leva left!`);
    } else{
        console.log(`Not enough money! You need ${(totalSum - budget).toFixed(2)} leva more!`);
    }
}

shopping(["920.45", "3", "1", "1"]);