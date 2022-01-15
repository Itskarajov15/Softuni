function solve(numbers){
    numbers.sort((a, b) => a - b);

    let biggerHalf = numbers.slice(numbers.length / 2);

    return biggerHalf;
}

console.log(solve([4, 7, 2, 5]));