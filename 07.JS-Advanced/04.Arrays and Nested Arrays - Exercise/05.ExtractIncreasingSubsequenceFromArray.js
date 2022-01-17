function solve(numbers){
    return numbers.reduce((result, currValue) => {
        if (currValue >= result[result.length - 1] || result.length === 0) {
            result.push(currValue);
        }

        return result;
    }, []);
}

console.log(solve([20,
    3,
    2,
    15,
    6,
    1]));