function maxNumber(input){
    let biggestNumber = Number.NEGATIVE_INFINITY;
    
    let index = 0;
    let currLine = input[index];

    while(currLine !== "Stop"){
        index++;
        let currNumber = Number(currLine);

        if(currNumber > biggestNumber)
        {
            biggestNumber = currNumber;
        }

        currLine = input[index];
    }

    console.log(biggestNumber);
}

maxNumber(["-1",
"-2",
"Stop"]);