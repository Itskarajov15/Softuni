function solve(array){
    let sumOfFirstArray = 0;
    for (const num of array) {
        sumOfFirstArray += num;
    }

    let sumOfSecondArray = 0;

    for (let i = 0; i < array.length; i++) {
        if(array[i] % 2 === 0){
            array[i] += i;
        } else{
            array[i] -= i;
        }

        sumOfSecondArray += array[i];
    }

    console.log(array);
    console.log(sumOfFirstArray);
    console.log(sumOfSecondArray);
}

solve([5, 15, 23, 56, 35]);