function solve(array, magicNumber){
    for (let i = 0; i < array.length; i++) {
        let firstNumber = array[i];

        for (let j = i + 1; j < array.length; j++) {
            let secondNumber = array[j];

            if (firstNumber + secondNumber === magicNumber) {
                console.log(`${firstNumber} ${secondNumber}`);
            }
        }
    }
}

solve([1, 7, 6, 2, 19, 23], 8);