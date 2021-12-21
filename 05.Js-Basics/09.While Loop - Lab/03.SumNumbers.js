function sumNumbers(input){
    let index = 0;
    let number = Number(input[index]);

    let sum = 0;

    while(sum < number){
        index++;
        sum += Number(input[index]);
    }

    console.log(sum);
}

sumNumbers(["100",
"10",
"20",
"30",
"40"]);