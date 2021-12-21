function repainting(input){
    let priceForNylon = 1.50;
    let priceForPaint = 14.50;
    let priceForDiluent = 5;

    let neededNylon = Number(input[0]) + 2;
    let neededLitersPaint = Number(input[1]) + (Number(input[1]) * 0.1);
    let neededLitersDiluent = Number(input[2]);
    let hours = Number(input[3]);

    let moneyForMaterials = (neededNylon * priceForNylon) + (neededLitersPaint * priceForPaint) 
    + (neededLitersDiluent * priceForDiluent) + 0.40;

    let moneyForWorkers = moneyForMaterials * 0.30 * hours;

    console.log(moneyForMaterials + moneyForWorkers);
}

repainting(["10", "11", "4", "8"]);