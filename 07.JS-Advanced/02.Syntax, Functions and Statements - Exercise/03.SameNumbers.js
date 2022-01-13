function solve(number){
    let numberAsString = number.toString();
    let isSame = true;
    let sum = 0;
    sum += Number(numberAsString[0]);

    for (let i = 1; i < numberAsString.length; i++) {
        if(!(numberAsString[i] === numberAsString[i - 1])){
            isSame = false;
        }
        
        sum += Number(numberAsString[i]);
    }

    console.log(isSame);
    console.log(sum);
}

solve(1234);