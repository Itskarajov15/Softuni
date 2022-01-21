function solve(input) {
    let catalog = {};

    for (let i = 0; i < input.length; i++) {
        let [name, price] = input[i].split(' : ');
        catalog[name] = price;
    }

    catalog.sort((a,b) => a.localeCompare(b));

    console.log(catalog);
}

solve(['Appricot : 20.4',
'Fridge : 1500',
'TV : 1499',
'Deodorant : 10',
'Boiler : 300',
'Apple : 1.25',
'Anti-Bug Spray : 15',
'T-Shirt : 10']);