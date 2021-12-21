function accountBalance(input){
    let index = 0;
    let currLine = input[index];
    let account = 0;

    while(currLine != "NoMoreMoney"){
        index++;
        let money = Number(currLine);

        if(money < 0){
            console.log("Invalid operation!");
            break;
        } else{
            console.log(`Increase: ${money.toFixed(2)}`);
            account += money;
        }

        currLine = input[index];
    }

    console.log(`Total: ${account.toFixed(2)}`);
}

accountBalance(["5.51", 
"69.42",
"100",
"NoMoreMoney"]);