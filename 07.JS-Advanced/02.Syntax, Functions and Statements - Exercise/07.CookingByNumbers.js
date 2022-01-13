function solve(numberAsString, operation1, operation2, operation3, operation4, operation5){
    let number = Number(numberAsString);
    let commandsInArr = [operation1, operation2, operation3, operation4, operation5];

    for (const command of commandsInArr) {
        if(command === 'chop'){
            number /= 2;
        } else if(command === 'dice'){
            number = Math.sqrt(number);
        } else if(command === 'spice'){
            number++;
        } else if(command === 'bake'){
            number *= 3;
        } else if(command === 'fillet'){
            number -= number * 0.2;
        }
        
        console.log(number);
    }
}

solve('32', 'chop', 'chop', 'chop', 'chop', 'chop')