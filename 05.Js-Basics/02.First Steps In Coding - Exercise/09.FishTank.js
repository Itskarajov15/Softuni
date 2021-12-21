function fishTank(input){
    let length = Number(input[0]);
    let width = Number(input[1]);
    let height = Number(input[2]);
    let occupiedSpace = Number(input[3]) / 100;

    let volume = length * width * height;
    let volumeInLiters = volume * 0.001;
    let neededLiters = volumeInLiters * (1 - occupiedSpace);

    console.log(neededLiters);
}

fishTank(["85", "75", "47", "17"]);