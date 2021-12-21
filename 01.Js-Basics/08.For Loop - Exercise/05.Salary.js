function salary(input){
    let numberOfTabs = Number(input[0]);
    let salary = Number(input[1])

    let takenMoney = 0;
    let isTaken = false;

    for (let i = 2; i < numberOfTabs + 2; i++) {
        let currTab = input[i];

        switch (currTab){
            case "Facebook":
                takenMoney += 150;
                break;
            case "Instagram":
                takenMoney += 100;
                break;
            case "Reddit":
                takenMoney += 50;
                break;
        }

        if(takenMoney >= salary){
            isTaken = true;
            break;
        }
    }

    if(isTaken){
        console.log("You have lost your salary.");
    } else{
        console.log(salary - takenMoney);
    }
}

salary(["10", "750", "Facebook", "Dev.bg", "Instagram", "Facebook", "Reddit", "Facebook", "Facebook"]);