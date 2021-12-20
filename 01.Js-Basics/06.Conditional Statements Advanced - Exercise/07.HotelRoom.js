function hotelRoom(input){
    let month = input[0];
    let numberOfNights = Number(input[1]);

    let priceOfStudio = 0;
    let priceOfApartment = 0;

    switch(month){
        case "May":
        case "October":
            priceOfStudio = numberOfNights * 50;
            priceOfApartment = numberOfNights * 65;
            break;
        case "June":
        case "September":
            priceOfStudio = numberOfNights * 75.2;
            priceOfApartment = numberOfNights * 68.7;
            break;
        case "July":
        case "August":
            priceOfStudio = numberOfNights * 76;
            priceOfApartment = numberOfNights * 77;
            break;
    }

    if(numberOfNights > 14 && (month === "May" || month === "October")){
        priceOfStudio -= priceOfStudio * 0.3;
    }
      else if(numberOfNights > 7 && (month === "May" || month === "October")){
        priceOfStudio -= priceOfStudio * 0.05;
    } else if(numberOfNights > 14 && (month === "June" || month === "September")){
        priceOfStudio -= priceOfStudio * 0.2;
    }

    if(numberOfNights > 14){
        priceOfApartment -= priceOfApartment * 0.1;
    }

    console.log(`Apartment: ${priceOfApartment.toFixed(2)} lv.`);
    console.log(`Studio: ${priceOfStudio.toFixed(2)} lv.`);
}

hotelRoom(["May", "15"]);