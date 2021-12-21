function cleverLily(input){
    let age = Number(input[0]);
    let priceOfLaundry = Number(input[1]);
    let priceOfToy = Number(input[2]);

    let numberOfToys = 0;
    let sum = 0;

    for (let i = 1; i <= age; i++) {
        if(i % 2 == 0){
            sum += 10 * (i / 2) - 1;
        } else{
            numberOfToys++;
        }
    }

    sum += numberOfToys * priceOfToy;

    if(sum >= priceOfLaundry){
        console.log(`Yes! ${(sum - priceOfLaundry).toFixed(2)}`);
    } else{
        console.log(`No! ${(priceOfLaundry - sum).toFixed(2)}`);
    }
}

cleverLily(["10", "170", "6"]);