function solve(input){
    for (let i = 0; i < input.length; i++) {
        let currTownInfo = input[i].split(" | ");

        let[town, latitude, longitude] = currTownInfo;
        latitude = Number(latitude).toFixed(2);
        longitude = Number(longitude).toFixed(2);

        let obj = {
            town,
            latitude,
            longitude
        }

        console.log(obj);
    }
}

solve(["Sofia | 42 | 23", "Blagoevgrad | 15 | 40"]);