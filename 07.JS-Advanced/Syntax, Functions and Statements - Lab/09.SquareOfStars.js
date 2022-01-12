function solve(input){
    let output = '';

    for (let i = 0; i < input; i++) {
        output += '* ';
        for (let j = 0; j < input - 1; j++) {
            output += '* ';
        }

        output += '\n';
    }

    console.log(output);
}

solve(3);