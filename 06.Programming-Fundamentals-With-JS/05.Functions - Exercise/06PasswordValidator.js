function solve(input){
    let isValid = validatePassword(input);

    if (isValid) {
        console.log("Password is valid");
    }
    
    function validatePassword(password){
        let validLength = false
        let validChars = false;
        let validCountOfDigits = false;

        if(password.length >= 6 && password.length <= 10){
            validLength = true;
        } else{
            console.log("Password must be between 6 and 10 characters");
        }

        if (validateDigitsAndLetters(password)) {
            validChars = true;
        } else{
            console.log("Password must consist only of letters and digits");
        }

        if(validateCountOfDigits(password)){
            validCountOfDigits = true;
        } else{
            console.log("Password must have at least 2 digits");
        }

        return validCountOfDigits && validLength && validChars ? true : false;
    }

    function validateDigitsAndLetters(password){
        for (const char of password) {
            if (!isNaN(Number(char)) || (char.toLowerCase() != char.toUpperCase())) {
                continue;
            } else{
                return false;
            }
        }

        return true;
    }

    function validateCountOfDigits(password){
        let counter = 0;

        for (const char of password) {
            if (!isNaN(Number(char))) {
                counter++;
            }
        }

        return counter >= 2 ? true : false;
    }
}

solve('Pa$s$s');