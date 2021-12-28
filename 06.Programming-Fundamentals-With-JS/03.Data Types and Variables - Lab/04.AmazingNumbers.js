function solve(number){
    let sum = 0;
    let numberToWorkWith = number;

    while(numberToWorkWith > 0){
        let digit = numberToWorkWith % 10;
        numberToWorkWith = Math.floor(numberToWorkWith / 10);

        sum += digit;
    }

    console.log(`${number} Amazing? ${sum.toString().includes("9") ? "True" : "False"}`);
}

solve(1233);