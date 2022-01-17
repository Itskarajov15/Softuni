function solve(numbers, countOfRotations){
    for (let i = 0; i < countOfRotations; i++) {
        let lastElement = numbers.pop();
        numbers.unshift(lastElement);
    }

    console.log(numbers.join(' '));
}

solve(['1', 
'2', 
'3', 
'4'], 
2);