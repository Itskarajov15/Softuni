function walking(input){
    let steps = 0;

    let index = 0;
    let currLine = input[index];

    while(currLine !== "Going home" && steps < 10000){
        index++;
        steps += Number(currLine);
        
        currLine = input[index];
    }

    if(currLine === "Going home"){
        steps += Number(input[index + 1]);
    }

    if(steps >= 10000){
        console.log(`Goal reached! Good job!`);
        console.log(`${steps - 10000} steps over the goal!`);
    } else{
        console.log(`${10000 - steps} more steps to reach goal.`);
    }
}

walking(["10000",
"Going home",
"1"]);