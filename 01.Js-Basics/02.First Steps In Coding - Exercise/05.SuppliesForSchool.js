function suppliesForSchool(input){
    let priceOfPackageOfPens = 5.80;
    let priceOfPackageOfMarkers = 7.20;
    let priceOfDetergentPerLiter = 1.20;
    
    let numberOfPackagesOfPens = Number(input[0]);
    let numberOfPackagesOfMarkers = Number(input[1]);
    let litersOfDetergent = Number(input[2]);
    let percentageOfDiscount = Number(input[3]);

    let priceWithoutDiscount = (numberOfPackagesOfPens * priceOfPackageOfPens) 
    + (numberOfPackagesOfMarkers * priceOfPackageOfMarkers) + (priceOfDetergentPerLiter * litersOfDetergent);

    let finalPrice = priceWithoutDiscount - (priceWithoutDiscount * percentageOfDiscount / 100);

    console.log(finalPrice);
}

suppliesForSchool(["2","3","4","25"]);