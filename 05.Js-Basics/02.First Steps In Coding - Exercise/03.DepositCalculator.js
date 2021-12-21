function depositCalculator(input){
    let deposit = Number(input[0]);
    let deadline = Number(input[1]);
    let annualPercentage = Number(input[2]);

    let interest = deposit * annualPercentage / 100;
    let interestForOneMonth = interest / 12;
    let result = deposit + deadline * interestForOneMonth;

    console.log(result);
}

depositCalculator(["200","3","5.7"])