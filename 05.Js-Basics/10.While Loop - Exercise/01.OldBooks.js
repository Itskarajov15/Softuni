function oldBooks(input){
    let index = 0;
    let favouriteBook = input[index];
    index++;

    let isFound = false;
    let numberOfCheckedBooks = 0;

    let currLine = input[index];
    while(!isFound && currLine != "No More Books"){
        index++;
        let currBook = currLine; 

        if(currBook === favouriteBook){
            isFound = true;
        } else{
            numberOfCheckedBooks++;
        }

        currLine = input[index];
    }

    if(isFound){
        console.log(`You checked ${numberOfCheckedBooks} books and found it.`)
    } else{
        console.log(`The book you search is not here!`);
        console.log(`You checked ${numberOfCheckedBooks} books.`);
    }
}

oldBooks(["Troy",
"Stronger",
"Life Style",
"Troy"]);