function solve(city){
    let properties = Object.keys(city);

    for (const property of properties) {
        console.log(`${property} -> ${city[property]}`);   
    }
}

solve({
    name: "Sofia",
    area: 492,
    population: 1238438,
    country: "Bulgaria",
    postCode: "1000"
});