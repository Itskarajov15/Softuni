function solve(arrayOfNumbers, start, end) {
    if (!Array.isArray(arrayOfNumbers)) {
        return NaN;
    }

    let startIndex = Math.max(0, start);
    let endIndex = Math.min(end, arrayOfNumbers.length - 1);

    let sum = arrayOfNumbers.slice(startIndex, endIndex + 1).reduce((a, x) => a + Number(x), 0);

    return sum;
}