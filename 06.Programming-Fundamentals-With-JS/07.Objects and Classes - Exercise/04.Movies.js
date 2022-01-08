function solve(input){
    let movies = [];

    for (let i = 0; i < input.length; i++) {
        let currCommand = input[i];

        if(currCommand.includes("addMovie")){
            let name = currCommand.split("addMovie ")[1];

            let movie = {
                name
            }

            movies.push(movie);
        } else if(currCommand.includes("directedBy")){
            let [name, director] = currCommand.split(" directedBy ");

            let neededMovie = movies.find(m => m.name === name);

            if (neededMovie) {
                neededMovie.director = director;
            }
        } else if(currCommand.includes("onDate")){
            let [name, date] = currCommand.split(" onDate ");

            let neededMovie = movies.find(m => m.name === name);

            if (neededMovie) {
                neededMovie.date = date;
            }
        }
    }

    movies.forEach(m => {
        if(m.name && m.date && m.director){
            console.log(JSON.stringify(m));
        }
    })
}

solve([
    'addMovie Fast and Furious',
    'addMovie Godfather',
    "addMovie Superman",
    'Inception directedBy Christopher Nolan',
    'Godfather directedBy Francis Ford Coppola',
    'Godfather onDate 29.07.2018',
    'Fast and Furious onDate 30.07.2018',
    'Batman onDate 01.08.2018',
    'Fast and Furious directedBy Rob Cohen'
    ]);