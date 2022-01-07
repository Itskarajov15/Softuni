function convertToObject(json){
    let person = JSON.parse(json);

    for (const key in person) {
        console.log(`${key}: ${person[key]}`);
    }
}

convertToObject('{"name": "George", "age": 40, "town": "Sofia"}');