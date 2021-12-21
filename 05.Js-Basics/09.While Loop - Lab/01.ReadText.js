function readText(input){
    let index = 0;

    let currText = input[index];
    index++;

    while(currText !== "Stop"){
        console.log(currText);

        currText = input[index]
        index++;
    }
}

readText(["Nakov",
"SoftUni",
"Sofia",
"Bulgaria",
"SomeText",
"Stop",
"AfterStop",
"Europe",
"HelloWorld"]);