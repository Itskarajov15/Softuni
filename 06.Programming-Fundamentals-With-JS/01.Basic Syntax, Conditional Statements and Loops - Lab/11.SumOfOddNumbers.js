function solve(count){
    let counter = 0;
    let sum = 0;
    let number = 1;

    while(counter < count){
        console.log(number);
        sum += number;
        number += 2;
        counter++;
    }

    console.log(`Sum: ${sum}`);
}

solve(5);