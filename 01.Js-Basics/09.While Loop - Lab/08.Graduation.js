function graduation(input){
    let index = 0;
    let name = input[index];
    let grade = 1;
    let allGrades = 0;
    let countOfFailures = 0;
    let hasFailed = false;

    while(grade <= 12){
        index++;

        let currGrade = Number(input[index]);

        if(currGrade >= 4){
            grade++;
            allGrades += currGrade;
        } else{
            countOfFailures++;

            if(countOfFailures >= 1){
                hasFailed = true;
                break;
            }
             
            continue;
        }
    }

    if(!hasFailed){
        console.log(`${name} graduated. Average grade: ${(allGrades / 12).toFixed(2)}`);
    } else{
        console.log(`${name} has been excluded at ${grade} grade`);
    }
}

graduation(["Gosho", 
"5",
"5.5",
"6",
"5.43",
"5.5",
"6",
"5.55",
"5",
"6",
"6",
"5.43",
"5"]);