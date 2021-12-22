function examPreparation(input){
    let neededCountOfBadGrades = Number(input[0]);
    let countOfBadGrades = 0;
    let countOfProblems = 0;
    let allGrades = 0;

    let indexOfProblem = 1;
    let indexOfGrade = 2;

    let currLine = input[indexOfProblem];
    let nameOfProblem = "";
    while(countOfBadGrades < neededCountOfBadGrades && currLine !== "Enough"){
        nameOfProblem = currLine;
        let grade = Number(input[indexOfGrade]);

        if(grade <= 4){
            countOfBadGrades++;
        } 

        countOfProblems++;
        allGrades += grade;
        
        indexOfProblem += 2;
        indexOfGrade += 2;

        currLine = input[indexOfProblem];
    }

    if(countOfBadGrades === neededCountOfBadGrades){
        console.log(`You need a break, ${countOfBadGrades} poor grades.`);
    } else{
        console.log(`Average score: ${(allGrades / countOfProblems).toFixed(2)}`);
        console.log(`Number of problems: ${countOfProblems}`);
        console.log(`Last problem: ${nameOfProblem}`);
    }
}

examPreparation(["3",
"Money",
"6",
"Story",
"4",
"Spring Time",
"5",
"Bus",
"6",
"Enough"]);