function solve(start, end){
    let sum = 0;
    let output = "";

    for (let i = start; i <= end; i++) {
        sum += i;
        output += i + " ";
    }

    console.log(output);
    console.log(`Sum: ${sum}`);
}

solve(5, 10);