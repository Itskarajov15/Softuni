function solve(numbers){
    let result = '';

    for (let i = 0; i < numbers.length; i += 2) {
        result += numbers[i] + ' ';
    }

    console.log(result);
}

solve(['20', '30', '40', '50', '60']);