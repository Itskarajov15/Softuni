function solve(numbers){
    numbers.sort((a, b) => a - b);

    let biggerHalf = numbers.slice(numbers.length / 2);

    console.log(biggerHalf);
}

solve([4, 7, 2, 5]);