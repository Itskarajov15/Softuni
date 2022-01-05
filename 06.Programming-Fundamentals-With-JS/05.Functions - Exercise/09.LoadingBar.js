function solve(number){
    let arr = ['.'.repeat(10)];

    for (let i = 0; i < 9; i++) {
        arr.push('.');
    }

    for (let i = 0; i < number / 10; i++) {
        arr[i] = '%';
    }

    if (number < 100) {
        console.log(`${number}% [${arr.join("")}]`);
        console.log("Still loading...");
    } else{
        console.log(`${number}% Complete!`);
        console.log(`[${arr.join("")}]`);
    }
}

solve(100);