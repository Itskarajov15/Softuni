function solve(array){
    let leftSum = 0;
    let rightSum = array.reduce(function(accumulator, currentValue){
        return accumulator + currentValue;
    });
    let isEqual = false;

    for (let i = 0; i < array.length; i++) {
        let currElement = array[i];
        rightSum -= currElement;

        if (leftSum === rightSum) {
            console.log(i);
            isEqual = true;
            break;
        } else{
            leftSum += currElement;
        }
    }

    if (!isEqual) {
        console.log("no");
    }
}

solve([1, 2, 3, 3]);