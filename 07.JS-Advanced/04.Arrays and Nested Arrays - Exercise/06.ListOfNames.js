function solve(names){
    names.sort((a, b) => a.localeCompare(b))
         .map((name, index) => `${index + 1}.${name}`)
         .forEach(name => console.log(name));
}

solve(["John", "Bob", "Christina", "Ema"]);