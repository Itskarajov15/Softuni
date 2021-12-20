function cinema(input){
    let type = input[0];
    let rows = Number(input[1]);
    let cols = Number(input[2]);

    let priceOfTicket = 0;

    switch(type){
        case "Premiere":
            priceOfTicket = 12;
            break;
        case "Normal":
            priceOfTicket = 7.5;
            break;
        case "Discount":
            priceOfTicket = 5;
            break;
    }

    let totalSum = priceOfTicket * rows * cols;

    console.log(`${totalSum.toFixed(2)} leva`);
}

cinema(["Premiere", "10", "12"]);