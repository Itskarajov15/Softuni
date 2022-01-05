function printMatrix(number){
    let output = "";

    for (let i = 0; i < number; i++) {
        for (let k = 0; k < number; k++) {
            output += number + " ";
        }

        output += "\n";
    }

    console.log(output);
}

printMatrix(7);