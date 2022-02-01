function solve(numbers, typeOfOrder) {
    if (typeOfOrder === 'asc') {
        numbers.sort((a, b) => a - b);
    } else if (typeOfOrder === 'desc') {
        numbers.sort((a, b) => b - a);
    }

    return numbers;
}

solve([14, 7, 17, 6, 8], 'asc');