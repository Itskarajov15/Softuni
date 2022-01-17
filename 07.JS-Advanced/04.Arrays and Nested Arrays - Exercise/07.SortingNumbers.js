function solve(numbers){
    let sorted = numbers.sort((a, b) => a - b);
    let result = [];

    while (sorted.length) {
        result.push(sorted.shift());

        if(sorted.length === 0){
            continue;
        }

        result.push(sorted.pop());
    }

    return result;
}

console.log(solve([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]));