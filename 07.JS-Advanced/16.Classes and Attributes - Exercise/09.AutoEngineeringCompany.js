function solve(input) {
    let brands = {};

    for (const line of input) {
        let [brand, model, producedCars] = line.split(' | ');    
        producedCars = Number(producedCars);

        if (!brands[brand]) {
            brands[brand] = {};
        }

        if (!brands[brand][model]) {
            brands[brand][model] = 0;
        }

        brands[brand][model] += producedCars;
    }

    let brandsKeys = Object.keys(brands);

    for (const brand of brandsKeys) {
        let models = Object.keys(brands[brand]);

        console.log(brand);
        for (const model of models) {
            console.log(`###${model} -> ${brands[brand][model]}`);
        }
    }
}

solve(['Audi | Q7 | 1000',
'Audi | Q6 | 100',
'BMW | X5 | 1000',
'BMW | X6 | 100',
'Citroen | C4 | 123',
'Volga | GAZ-24 | 1000000',
'Lada | Niva | 1000000',
'Lada | Jigula | 1000000',
'Citroen | C4 | 22',
'Citroen | C5 | 10'])