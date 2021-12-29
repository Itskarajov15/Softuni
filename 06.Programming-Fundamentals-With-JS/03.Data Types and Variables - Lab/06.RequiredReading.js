function solve(numberOfPages, pagesReadPer1Hour, numberOfDays){
    let totalTime = numberOfPages / pagesReadPer1Hour;
    let requiredHoursPerDay = totalTime / numberOfDays;

    console.log(requiredHoursPerDay);
}

solve(212, 20, 2);