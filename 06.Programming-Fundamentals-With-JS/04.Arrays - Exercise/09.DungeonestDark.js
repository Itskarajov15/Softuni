function solve(input){
    let rooms = input[0].split("|");
    let health = 100;
    let coins = 0;
    let room = 1;
    
    for (const room of rooms) {
        if (room[0] === "potion") {
            let healthPoints = Number(room[1]);
            health += healthPoints;
            if (health > 100) {
                healthPoints = 100 - health;
                health = 100;
            }

            console.log(`You healed for ${healthPoints} hp.`); ////////////////////////////
            console.log(`Current health: ${health} hp.`);
        } else if(room[0] === "chest"){
            let coinsFound = Number(room[1]);
            coins += coinsFound;

            console.log(`You found ${coinsFound} coins.`);
        } else{
            let nameOfMonster = room[0];
            let attackOfMonster = Number(room[1]);

            health -= attackOfMonster;

            if(health <= 0){
                console.log(`You died! Killed by ${nameOfMonster}.`);
                console.log(`Best room: ${room}`);
            } else{
                console.log(`You slayed ${nameOfMonster}.`);
            }
        }

        room++;
    }

    if (health > 0) {
        console.log("You've made it!");
        console.log(`Coins: ${coins}`);
        console.log(`Health: ${health}`);
    }
}

solve(["rat 10|bat 20|potion 10|rat 10|chest 100|boss 70|chest 1000"]);