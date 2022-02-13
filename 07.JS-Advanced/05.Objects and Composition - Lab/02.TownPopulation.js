function solve(input){
    const registry = {};

    for (const tuple of input) {
        let splittedLine = tuple.split(' <-> ');
        let town = splittedLine[0];
        let population = Number(splittedLine[1]);

        if (registry.hasOwnProperty(town)) {
            registry[town] += population;
        } else {
            registry[town] = population;
        }
    }

    for (const key in registry) {
        console.log(`${key} : ${registry[key]}`);
    }
}

solve(['Istanbul <-> 100000',
'Honk Kong <-> 2100004',
'Jerusalem <-> 2352344',
'Mexico City <-> 23401925',
'Istanbul <-> 1000']);