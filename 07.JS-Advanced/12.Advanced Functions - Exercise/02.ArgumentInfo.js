function solve(...params) {
    let obj = {};

    params.forEach(p => {
        if (!obj[typeof p]) {
            obj[typeof p] = 0;
        }

        obj[typeof p] ++;

        console.log(`${typeof p}: ${p}`);
    })

    Object.keys(obj)
        .sort((a, b) => obj[b] - obj[a])
        .forEach(key => {
            console.log(`${key} = ${obj[key]}`);
        })
}

solve('cat', 42, function () { console.log('Hello world!'); });