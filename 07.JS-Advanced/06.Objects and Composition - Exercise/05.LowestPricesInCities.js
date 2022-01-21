function solve(input){
    let log = {};

    for (let i = 0; i < input.length; i++) {
        let [town, nameOfProduct, price] = input[i].split(' | ');
        price = Number(price);
        
        if (!log[nameOfProduct]) {
            log[nameOfProduct] = {town, price};
        } else{
            log[nameOfProduct] = log[nameOfProduct].price > price ? {town, price} : log[nameOfProduct];
        }
    }

    for (const product in log) {
        console.log(`${product} -> ${log[product].price} (${log[product].town})`);
    }
}

solve(['Sample Town | Sample Product | 1000',
'Sample Town | Orange | 2',
'Sample Town | Peach | 1',
'Sofia | Orange | 3',
'Sofia | Peach | 2',
'New York | Sample Product | 1000.1',
'New York | Burger | 10']);