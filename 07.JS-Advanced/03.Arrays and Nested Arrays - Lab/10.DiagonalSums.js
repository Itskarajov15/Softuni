function solve(matrix){
    let primaryDiagonal = 0;
    let secondaryDiagonal = 0;

    for (let row = 0; row < matrix.length; row++) {
        primaryDiagonal += matrix[row][row];
        secondaryDiagonal += matrix[row][matrix.length - row - 1];
    }

    console.log(`${primaryDiagonal} ${secondaryDiagonal}`);
}

solve([[20, 40],
    [10, 60]]);