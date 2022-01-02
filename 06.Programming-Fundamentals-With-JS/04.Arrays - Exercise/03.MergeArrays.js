function solve(firstArray, secondArray){
    let result = [];

    for (let i = 0; i < firstArray.length; i++) {
        if(i % 2 === 0){
            result.push(Number(firstArray[i]) + Number(secondArray[i]));
        } else{
            let concat = firstArray[i] + secondArray[i];
            result.push(concat);
        }
    }

    console.log(result.join(" - "));
}

solve(['5', '15', '23', '56', '35'], ['17', '22', '87', '36', '11']);