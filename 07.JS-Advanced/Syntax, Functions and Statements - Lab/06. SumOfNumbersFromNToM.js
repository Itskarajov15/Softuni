function solve(start, end){
    let sum = 0;
    start = Number(start);
    end = Number(end);

    for(let i = start; i <= end; i++){
        sum += i;
    }

    console.log(sum);
}

solve('-8', '20');