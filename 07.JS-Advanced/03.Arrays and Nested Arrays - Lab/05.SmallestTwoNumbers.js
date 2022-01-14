function solve(numbers){
    numbers.sort((a, b) => a - b);

    console.log(numbers.slice(0, 2).join(' '));
}

solve([5, 6, 1, 2]);