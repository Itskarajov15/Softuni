function journey(input){
    let budget = Number(input[0]);
    let season = input[1];

    let country = "";
    let placeToSleep = "";
    let spentMoney = 0;

    if(budget > 1000){
        country = "Europe";
        spentMoney = budget * 0.9;
        placeToSleep = "Hotel";
    } else if(budget > 100 && budget <= 1000){
        country = "Balkans";

        if(season === "summer"){
            placeToSleep = "Camp";
            spentMoney = budget * 0.4;
        } else if(season === "winter"){
            placeToSleep = "Hotel";
            spentMoney = budget * 0.8;
        }
    } else if(budget <= 100){
        country = "Bulgaria";

        if(season === "summer"){
            placeToSleep = "Camp";
            spentMoney = budget * 0.3;
        } else if(season === "winter"){
            placeToSleep = "Hotel";
            spentMoney = budget * 0.7;
        }
    }

    console.log(`Somewhere in ${country}`);
    console.log(`${placeToSleep} - ${spentMoney.toFixed(2)}`);
}

journey(["1500", "summer"]);