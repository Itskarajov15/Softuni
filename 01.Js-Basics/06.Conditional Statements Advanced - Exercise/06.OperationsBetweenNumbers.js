function operationsBetweenNumbers(input){
    let firstNumber = Number(input[0]);
    let secondNumber = Number(input[1]);
    let operator = input[2];

    let result = 0;
    let evenOrOdd = "";

    if(operator === "+"){
        result = firstNumber + secondNumber;

        if(result % 2 == 0){
            evenOrOdd = "even";
        } else{
            evenOrOdd = "odd";
        }

        console.log(`${firstNumber} ${operator} ${secondNumber} = ${result} - ${evenOrOdd}`);
    } else if(operator === "-"){
        result = firstNumber - secondNumber;

        if(result % 2 == 0){
            evenOrOdd = "even";
        } else{
            evenOrOdd = "odd";
        }

        console.log(`${firstNumber} ${operator} ${secondNumber} = ${result} - ${evenOrOdd}`);
    } else if(operator === "*"){
        result = firstNumber * secondNumber;

        if(result % 2 == 0){
            evenOrOdd = "even";
        } else{
            evenOrOdd = "odd";
        }

        console.log(`${firstNumber} ${operator} ${secondNumber} = ${result} - ${evenOrOdd}`);
    } else if(operator === "/"){
        if(secondNumber === 0){
            console.log(`Cannot divide ${firstNumber} by zero`);
        } else{
            result = firstNumber / secondNumber;

            console.log(`${firstNumber} ${operator} ${secondNumber} = ${result.toFixed(2)}`);
        }
    } else if(operator === "%"){
        if(secondNumber === 0){
            console.log(`Cannot divide ${firstNumber} by zero`);
        } else{
            result = firstNumber % secondNumber;

            console.log(`${firstNumber} ${operator} ${secondNumber} = ${result}`);
        }
    }
}

operationsBetweenNumbers(["10", "12", "+"]);