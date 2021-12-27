function solve(year){
    if(year % 4 === 0){
        if(year % 100 === 0){
            if(year % 400 === 0){
                console.log("yes");
            } else{
                console.log("no");
            }
        } else{
            console.log("yes");
        }
    } else{
        console.log("no");
    }
}

solve(1984);