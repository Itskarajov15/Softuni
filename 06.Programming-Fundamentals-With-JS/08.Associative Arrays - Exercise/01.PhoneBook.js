function solve(input){
    let phoneBook = {};

    for (const line of input) {
        let splittedLine = line.split(" ");
        let name = splittedLine[0];
        let phoneNumber = splittedLine[1];

        phoneBook[name] = phoneNumber;
    }

    for (const key in phoneBook) {
        console.log(`${key} -> ${phoneBook[key]}`)
    }
}

solve(["Asen 123123412", "Ivan 1232134124"]);