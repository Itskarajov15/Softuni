function projectsCreation(input){
    let name = input[0];
    let numberOfProjects = Number(input[1]);

    let neededHours = numberOfProjects * 3;

    console.log(`The architect ${name} will need ${neededHours} hours to complete ${numberOfProjects} project/s.`);
}

projectsCreation(["George", "4"])