function vacationBooksList(input){
    let numberOfPages = Number(input[0]);
    let numberOfPagesReadForOneHour = Number(input[1]);
    let numberOfDays = Number(input[2]);

    let neededTimeForReading = numberOfPages / numberOfPagesReadForOneHour;
    let hoursPerDay = neededTimeForReading / numberOfDays;

    console.log(hoursPerDay);
}

vacationBooksList(["212", "20","2"])