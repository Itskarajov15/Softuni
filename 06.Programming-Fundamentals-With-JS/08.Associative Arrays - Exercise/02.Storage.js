function solve(input){
    let storage = new Map();

    for (const line of input) {
        let splittedLine = line.split(" ");

        let product = splittedLine[0];
        let quantity = Number(splittedLine[1]);

        if (!storage.has(product)) {
            storage.set(product, quantity);
        } else{
            let currQuantity = storage.get(product);
            let newQuantity = currQuantity + quantity;
            storage.set(product, newQuantity);
        }
    }

    let keys = storage.keys();

    for (const key of keys) {
        console.log(`${key} -> ${storage.get(key)}`);
    }
}

solve(["tomato 10", "coffee 5", "coffee 10"]);