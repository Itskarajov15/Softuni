function sequence(input){
    let number = Number(input[0]);

    let result = 1;

    while(result <= number){
        console.log(result);
        result = result * 2 + 1;
    }
}

sequence(["8"]);