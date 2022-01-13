function solve(a, b){
    let end = Math.max(a, b);
    let lastDivisor = 0;

    for (let i = 0; i < end; i++) {
        if(a % i === 0 && b % i === 0){
            lastDivisor = i;
        }
    }

    console.log(lastDivisor);
}

solve(15, 15);