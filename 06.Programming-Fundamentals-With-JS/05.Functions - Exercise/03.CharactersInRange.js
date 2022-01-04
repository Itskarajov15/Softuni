function solve(firstChar, secondChar){
    let first = firstChar.charCodeAt(0);
    let last = secondChar.charCodeAt(0);
    let output = "";

    return first < last ? charsInLine(first, last) : charsInLine(last, first);

    function charsInLine(x, y){
        for (let i = x + 1; i < y; i++) {
            output += String.fromCharCode(i) + " ";
        }

        return output;
    }
}

console.log(solve('a', 'd'));