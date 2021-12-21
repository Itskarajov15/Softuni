function tennisRanklist(input){
    let [numberOfTournaments, points, ...rest] = input;

    numberOfTournaments = Number(numberOfTournaments);
    points = Number(points);
    let pointsFromTournaments = 0;
    let numberOfWonTournaments = 0;

    for (let i = 0; i < numberOfTournaments; i++) {
        let info = rest[i];

        switch (info){
            case "W":
                points += 2000;
                pointsFromTournaments += 2000;
                numberOfWonTournaments++;
                break;
            case "F":
                points += 1200;
                pointsFromTournaments += 1200;
                break;
            case "SF":
                points += 720;
                pointsFromTournaments += 720;
                break;
        }
    }

    console.log(`Final points: ${points}`);
    console.log(`Average points: ${Math.floor(pointsFromTournaments / numberOfTournaments)}`);
    console.log(`${(numberOfWonTournaments / numberOfTournaments * 100).toFixed(2)}%`);
}

tennisRanklist(["5", "1400", "F", "SF", "W", "W", "SF"]);