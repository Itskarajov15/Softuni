function minNumber(input){
    let smallestNumber = Number.POSITIVE_INFINITY;

    let index = 0;
    let currLine = input[index];

    while(currLine !== "Stop"){
        index++;
        let currNumber = Number(currLine);

        if(currNumber < smallestNumber){
            smallestNumber = currNumber;
        }

        currLine = input[index];
    }

    console.log(smallestNumber);
}

minNumber(["100",
"99",
"80",
"70",
"Stop"]);