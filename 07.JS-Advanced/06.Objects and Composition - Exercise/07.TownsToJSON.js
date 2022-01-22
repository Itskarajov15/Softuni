function solve(input){
    let firstLine = input.shift();

    let firstLineSplitted = firstLine.split('|');
    let town = firstLineSplitted[1].trim();
    let latitude = firstLineSplitted[2].trim();
    let longitude = firstLineSplitted[3].trim();

    let towns = [];

    for (const line of input) {
        let splitted = line.split('|');
        let currTown = splitted[1].trim();
        let currLatitude = Number(splitted[2].trim()).toFixed(2);
        let currLongitude = Number(splitted[3].trim()).toFixed(2);
        
        towns.push({[town]: currTown, [latitude]: Number(currLatitude), [longitude]: Number(currLongitude)});
    }

    let outputInJSON = JSON.stringify(towns);

    console.log(outputInJSON);
}

solve(['| Town | Latitude | Longitude |',
'| Sofia | 42.696552 | 23.32601 |',
'| Beijing | 39.913818 | 116.363625 |']);