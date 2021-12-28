function solve(firstNumber, secondNumber, thirdNumber){
    let result = firstNumber + secondNumber + thirdNumber;

    if(Number.isInteger(result)){
        console.log(`${result} - Integer`);
    } else{
        console.log(`${result} - Float`);
    }
}

solve(1, 2, 3);