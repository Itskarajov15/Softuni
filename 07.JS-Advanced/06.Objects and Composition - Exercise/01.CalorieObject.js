function calorieObject(input){
    const myObj = {};

    for (let i = 0; i < input.length; i += 2) {
        let name = input[i];
        let calories = Number(input[i + 1]);

        myObj[name] = calories;
    }

    console.log(myObj);
}

calorieObject(['Yoghurt', '48', 'Rise', '138', 'Apple', '52']);