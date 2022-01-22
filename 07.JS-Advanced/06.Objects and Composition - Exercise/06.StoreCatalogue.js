function solve(input) {
    let catalog = {};

    for (let i = 0; i < input.length; i++) {
        let [name, price] = input[i].split(' : ');
        let firstLetter = name[0];

        if (!catalog[firstLetter]) {
            catalog[firstLetter] = [];
        }

        catalog[firstLetter].push({name, price});
        catalog[firstLetter].sort((a, b) => (a.name).localeCompare(b.name));
    }

    let result = [];
    
    Object.entries(catalog).sort((a, b) => a[0].localeCompare(b[0])).forEach(entry => {
        console.log(entry[1]);
        let values = entry[1]
        .sort((a, b) => a.name.localeCompare(b.name))
        .map(product => `  ${product.name}: ${product.price}`)
        .join('\n');

        let string = `${entry[0]}\n${values}`;
        result.push(string);
    })

    console.log(result.join(`\n`));
}

solve(['Appricot : 20.4',
'Fridge : 1500',
'TV : 1499',
'Deodorant : 10',
'Boiler : 300',
'Apple : 1.25',
'Anti-Bug Spray : 15',
'T-Shirt : 10']);