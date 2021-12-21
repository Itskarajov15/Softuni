function worldSwimmingRecord(input){
    let recordInSeconds = Number(input[0]);
    let distance = Number(input[1]);
    let timeForOneMeter = Number(input[2]);

    let time = distance * timeForOneMeter;
    let delay = Math.floor(distance / 15) * 12.5;
    let neededTime = time + delay;

    if(recordInSeconds > neededTime){
        console.log(`Yes, he succeeded! The new world record is ${neededTime.toFixed(2)} seconds.`)
    } else{
        console.log(`No, he failed! He was ${(neededTime - recordInSeconds).toFixed(2)} seconds slower.`)
    }
}

worldSwimmingRecord(["55555.67", "3017", "5.03"]);