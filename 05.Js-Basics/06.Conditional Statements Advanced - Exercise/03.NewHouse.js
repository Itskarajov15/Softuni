function newHouse(input){
    let typeOfFlowers = input[0];
    let numberOfFlowers = Number(input[1]);
    let budget = Number(input[2]);

    let sum = 0;

    if(typeOfFlowers === "Roses"){
        sum = 5 * numberOfFlowers;
    } else if(typeOfFlowers === "Dahlias"){
        sum = 3.8 * numberOfFlowers;
    } else if(typeOfFlowers === "Tulips"){
        sum = 2.8 * numberOfFlowers;
    } else if(typeOfFlowers === "Narcissus"){
        sum = 3 * numberOfFlowers;
    } else if(typeOfFlowers === "Gladiolus"){
        sum = 2.5 * numberOfFlowers;
    }

    if(typeOfFlowers === "Roses" && numberOfFlowers > 80){
        sum -= sum * 0.1;
    } else if(typeOfFlowers === "Dahlias" && numberOfFlowers > 90){
        sum -= sum * 0.15;
    } else if(typeOfFlowers === "Tulips" && numberOfFlowers > 80){
        sum -= sum * 0.15;
    } else if(typeOfFlowers === "Narcissus" && numberOfFlowers < 120){
        sum += sum * 0.15;
    } else if(typeOfFlowers == "Gladiolus" && numberOfFlowers < 80){
        sum += sum * 0.2;
    }

    if(budget >= sum){
        let moneyLeft = budget - sum;

        console.log(`Hey, you have a great garden with ${numberOfFlowers} ${typeOfFlowers} and ${moneyLeft.toFixed(2)} leva left.`);
    } else {
        let neededSum = sum - budget;

        console.log(`Not enough money, you need ${neededSum.toFixed(2)} leva more.`)
    }
}

newHouse(["Gladiolus", "64", "160"]);