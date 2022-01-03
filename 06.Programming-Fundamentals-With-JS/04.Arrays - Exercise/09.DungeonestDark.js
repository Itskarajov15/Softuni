function solve(input){
    let rooms = input[0].split("|");
    let health = 100;
    let coins = 0;
    let roomCount = 1;
    
    for (const room of rooms) {
        let roomArr = room.split(" ");
        if (roomArr[0] === "potion") {
            let healthPoints = Number(roomArr[1]);
            health += healthPoints;
            if (health > 100) {
                healthPoints = healthPoints - (health - 100);
                health = 100;
            }

            console.log(`You healed for ${healthPoints} hp.`); ////////////////////////////
            console.log(`Current health: ${health} hp.`);
        } else if(roomArr[0] === "chest"){
            let coinsFound = Number(roomArr[1]);
            coins += coinsFound;

            console.log(`You found ${coinsFound} coins.`);
        } else{
            let nameOfMonster = roomArr[0];
            let attackOfMonster = Number(roomArr[1]);

            health -= attackOfMonster;

            if(health <= 0){
                console.log(`You died! Killed by ${nameOfMonster}.`);
                console.log(`Best room: ${roomCount}`);
                break;
            } else{
                console.log(`You slayed ${nameOfMonster}.`);
            }
        }

        roomCount++;
    }

    if (health > 0) {
        console.log("You've made it!");
        console.log(`Coins: ${coins}`);
        console.log(`Health: ${health}`);
    }
}

solve(["rat 10|potion 30|orc 10|chest 10|boss 25|chest 110"]);