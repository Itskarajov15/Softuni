function solve(array, numberOfRotations){
    for (let i = 0; i < numberOfRotations; i++) {
        array.push(array[0]);
        array.shift();
    }

    console.log(array.join(" "));
}

solve([51, 47, 32, 61, 21], 2);