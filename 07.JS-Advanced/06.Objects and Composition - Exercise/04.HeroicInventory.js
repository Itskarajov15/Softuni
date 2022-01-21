function solve(input){
    let allHeroes = [];
    for (let i = 0; i < input.length; i++) {
        let [name, level, items] = input[i].split(' / ');

        level = Number(level);
        items = items ? items.split(', ') : [];

        allHeroes.push({name, level, items});
    }

    let outputInJSON = JSON.stringify(allHeroes);

    console.log(outputInJSON);
}

solve(['Isacc / 25 / Apple, GravityGun',
'Derek / 12 / BarrelVest, DestructionSword',
'Hes / 1 / Desolator, Sentinel, Antara']);