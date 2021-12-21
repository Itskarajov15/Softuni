function oscars(input){
    let [name, points, numberOfPeople, ...rest] = input;
    numberOfPeople = Number(numberOfPeople);
    points = Number(points);

    for (let i = 0; i < numberOfPeople * 2; i += 2) {
        let jury = rest[i];
        let pointsOfJury = Number(rest[i + 1])
        points += (pointsOfJury * jury.length) / 2;

        if (points > 1250.5) {
            break;
        }
    }

    if(points > 1250.5){
        console.log(`Congratulations, ${name} got a nominee for leading role with ${points.toFixed(1)}!`)
    } else{
        console.log(`Sorry, ${name} you need ${(1250.5 - points).toFixed(1)} more!`)
    }
}

oscars(["Zahari Baharov", "205", "4", "Johnny Depp", "45", "Will Smith", "29", "Jet Lee", "10", "Matthew Mcconaughey", "39"]);