function solve(numbers){
    let result = [];

    for (let i = 0; i < numbers.length; i++) {
        if(i % 2 !== 0){
            result.push(numbers[i] * 2);
        }
    }

    return result.reverse();
}

console.log(solve([10, 15, 20, 25]));