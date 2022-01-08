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
            let name = currCommand.split(" directedBy")[0];
            let director = currCommand.split("directedBy ")[1];

            for (const currMovie of movies) {
                if(currMovie.name === name){
                    currMovie.director = director;
                }
            }
        } else if(currCommand.includes("onDate")){
            let name = currCommand.split(" onDate")[0];
            let date = currCommand.split("onDate ")[1];

            for (const movie of movies) {
                if(movie.name === name){
                    movie.date = date;
                }
            }
        }
    }

    for (const currMovie of movies) {
        if (currMovie.director === undefined && currMovie.date === undefined) {
            continue;
        }

        console.log(JSON.stringify(currMovie));
    }
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