function solve(firstArray, secondArray){
    for (const elementFromFirstArray of firstArray) {
        for (elementFromSecondArray  of secondArray) {
            if(elementFromFirstArray === elementFromSecondArray){
                console.log(elementFromFirstArray);
            }
        }
    }
}

solve(['Hey', 'hello', 2, 4, 'Peter', 'e'], ['Petar', 10, 'hey', 4, 'hello', '2']);