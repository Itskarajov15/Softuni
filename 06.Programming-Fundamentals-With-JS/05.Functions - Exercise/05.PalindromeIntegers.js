function solve(numbers){
    for (const number of numbers) {
        let reversedNumber = reverseNumber(number);

        if (number === reversedNumber) {
            console.log("true");
        } else{
            console.log("false");
        }
    }

    function reverseNumber(x){
        let reversedNumberAsString = "";

        while (x > 0) {
            reversedNumberAsString += x % 10;
            x = Math.floor(x / 10);
        }

        return Number(reversedNumberAsString);
    }
}

solve([123,323,421,121]);