function solve(array, firstTarget, secondTarget){
    let indexOfFirstTarget = array.indexOf(firstTarget);
    let indexOfSecondTarget = array.indexOf(secondTarget);

    let slicedArray = array.slice(indexOfFirstTarget, indexOfSecondTarget + 1);

    return slicedArray;
}

console.log(solve(['Pumpkin Pie',
'Key Lime Pie',
'Cherry Pie',
'Lemon Meringue Pie',
'Sugar Cream Pie'],
'Key Lime Pie',
'Lemon Meringue Pie'));