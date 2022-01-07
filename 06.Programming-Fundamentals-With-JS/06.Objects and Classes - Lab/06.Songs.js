function solve(input){
    class Song{
        constructor(typeList, name, time){
            this.typeList = typeList;
            this.name = name;
            this.time = time;
        }
    }

    let numberOfSongs = Number(input.shift());
    let songs = [];

    for (let i = 0; i < numberOfSongs; i++) {
        let currLine = input.shift();

        let [typeList, name, time] = currLine.split("_");
        songs.push(new Song(typeList, name, time));
    }

    let searchedType = input.shift();

    if (searchedType === "all") {
        printSongs(songs);
    } else{
        let sorted = songs.filter((s) => s.typeList === searchedType);
        printSongs(sorted);
    }

    function printSongs(array){
        for (const song of array) {
            console.log(song.name);
        }
    }
}

solve([4,
    "favourite_DownTown_3:14",
    "listenLater_Andalouse_3:24",
    "favourite_In To The Night_3:58",
    "favourite_Live It Up_3:48",
    "listenLater"]);