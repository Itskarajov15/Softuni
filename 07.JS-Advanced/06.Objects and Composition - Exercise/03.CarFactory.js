function carFactory(object){
    function getEngine(power){
        const engines = [{ power: 90, volume: 1800 },
            { power: 120, volume: 2400 },
            { power: 200, volume: 3500 }
        ];

        return engines.find(el => el.power >= power);
    };

    function getCarriage(carriageType, color){
        return {type: carriageType, color: color};
    };

    function getWheels(size){
        if (size % 2 === 0) {
            size--; 
        }

        return [size, size, size, size];
    };

    return {
        model: object.model,
        engine: getEngine(object.power),
        carriage: getCarriage(object.carriage, object.color),
        wheels: getWheels(object.wheelsize)
    };
}

console.log(carFactory({ model: 'VW Golf II',
power: 90,
color: 'blue',
carriage: 'hatchback',
wheelsize: 14 }));