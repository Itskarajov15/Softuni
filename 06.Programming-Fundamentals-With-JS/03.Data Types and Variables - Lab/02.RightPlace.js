function rightPlace(firstWord, char, secondWord){
    firstWord = firstWord.replace("_", char);

    if(firstWord === secondWord){
        console.log("Matched");
    } else(
        console.log("Not Matched")
    )
}

rightPlace("Str_ng", "I", "Strong");