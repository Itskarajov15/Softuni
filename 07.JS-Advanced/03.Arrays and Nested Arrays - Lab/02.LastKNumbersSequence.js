function solve(b, k){
    let result = [1];

    for (let i = 1; i < b; i++) {
        let sum = 0;
        let start = Math.max(0, i - k);

        for (let j = start; j < i; j++) {
            sum += result[j];
        }

        result[i] = sum;
    }

    console.log(result);
}

solve(6, 3);