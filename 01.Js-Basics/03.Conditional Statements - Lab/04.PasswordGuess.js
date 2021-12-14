function passwordGuess(input){
    let userPassword = input[0];

    if(userPassword === "s3cr3t!P@ssw0rd"){
        console.log("Welcome");
    }
    else{
        console.log("Wrong password!");
    }
}

passwordGuess(["s3cr3t!P@ssw0rd"]);