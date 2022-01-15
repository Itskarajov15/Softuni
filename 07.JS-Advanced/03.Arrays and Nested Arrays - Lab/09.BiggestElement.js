function solve(matrix){
    let biggestElement = Number.MIN_SAFE_INTEGER;

    for (let row = 0; row < matrix.length; row++) {
        let currRow = matrix[row];

        for (let col = 0; col < currRow.length; col++) {
            if(biggestElement < matrix[row][col]){
                biggestElement = matrix[row][col];
            }
        }
    }

    return biggestElement;
}

console.log(solve([[20, 50, 10],
       [8, 33, 145]]));