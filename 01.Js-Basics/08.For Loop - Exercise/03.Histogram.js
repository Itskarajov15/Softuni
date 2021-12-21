function histogram(input){
    let p1 = 0;
    let p2 = 0;
    let p3 = 0;
    let p4 = 0;
    let p5 = 0;

    let end = Number(input[0]);

    for (let i = 1; i <= end; i++) {
        let currNumber = Number(input[i]);

        if(currNumber < 200){
            p1++;
        } else if(currNumber >= 200 && currNumber <= 399){
            p2++;
        } else if(currNumber >= 400 && currNumber <= 599){
            p3++;
        } else if(currNumber >= 600 && currNumber <= 799){
            p4++;
        } else{
            p5++;
        }
    }

    let countOfAllNumbers = p1 + p2 + p3 + p4 + p5;

    console.log(`${((p1 / countOfAllNumbers) * 100).toFixed(2)}%`)
    console.log(`${((p2 / countOfAllNumbers) * 100).toFixed(2)}%`)
    console.log(`${((p3 / countOfAllNumbers) * 100).toFixed(2)}%`)
    console.log(`${((p4 / countOfAllNumbers) * 100).toFixed(2)}%`)
    console.log(`${((p5 / countOfAllNumbers) * 100).toFixed(2)}%`)
}

histogram(["3", "1", "2", "999"]);