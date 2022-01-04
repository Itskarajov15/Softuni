function solve(firstNumber, secondNumber, thirdNumber){
    let add = (a, b) => a + b;
    let subtract = (a, b) => a - b;

    let firstSum = add(firstNumber, secondNumber);
    let finalResult = subtract(firstSum, thirdNumber);

    return finalResult;
}

console.log(solve(1, 2, 3));