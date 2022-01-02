function solve(array){
    let bestCount = 1;
    let start = 0;
    let count = 1;

    for (let i = 1; i < array.length; i++) {
        if (array[i] === array[i - 1]) {
            count++;
        } else{
            count = 1;
        }

        if(count > bestCount){
            bestCount = count;
            start = i - count + 1;
        }
    }

    let result = [];

    for (let j = start; j < start + bestCount; j++) {
        result.push(array[j]);
    }

    console.log(result.join(" "));
}

solve([2, 1, 1, 2, 3, 3, 2, 2, 2, 1]);