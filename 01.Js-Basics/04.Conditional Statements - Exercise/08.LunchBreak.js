function lunchBreak(input){
    let name = input[0];
    let durationOfEpisode = Number(input[1]);
    let durationOfBreak = Number(input[2]);

    let timeForLunch = durationOfBreak / 8;
    let timeForRest = durationOfBreak / 4;
    let timeLeft = durationOfBreak - timeForLunch - timeForRest;

    if(timeLeft >= durationOfEpisode){
        console.log(`You have enough time to watch ${name} and left with ${Math.ceil(timeLeft - durationOfEpisode)} minutes free time.`);
    } else{
        console.log(`You don't have enough time to watch ${name}, you need ${Math.ceil(durationOfEpisode - timeLeft)} more minutes.`);
    }
}

lunchBreak(["Game of Thrones", "60", "96"]);