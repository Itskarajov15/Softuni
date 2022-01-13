function solve(firstNumber, secondNumber, thirdNumber){
    let largestNumber = Math.max(firstNumber, Math.max(secondNumber, thirdNumber));
    console.log(`The largest number is ${largestNumber}.`);
}

solve(5, -3, 16);