function assemblyLine(){
    return {
        hasClima: (car) => {
            car.temp = 21;
            car.tempSettings = 21;
            car.adjustTemp = () => {
                if (car.temp < car.tempSettings){
                    car.temp++;
                } else if(car.temp > car.tempSettings){
                    car.temp--;
                }
            }
        },

        hasAudio: (car) => {
            car.currentTrack = {
                name: '',
                artist: ''
            },
            car.nowPlaying = () => {
                console.log(`Now playing '${currentTrack.name}' by ${currentTrack.artist}`);
            }
        },

        hasParktronic: (car) => {
            car.checkDistance = (distance) => {
                if (distance < 0.1) {
                    console.log("Beep! Beep! Beep!");
                } else if(distance >= 0.1 && distance < 0.25){
                    console.log("Beep! Beep!");
                } else if(distance >= 0.25 && distance < 0.50){
                    console.log("Beep!");
                } else{
                    console.log('');
                }
            }
        }
    }
}