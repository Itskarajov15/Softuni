function areaOfFigures(input){
    let figure = input[0];

    let result = 0;

    if(figure === "square"){
        let side = Number(input[1]);

        result = side * side;
    } else if(figure === "rectangle"){
        let firstSide = Number(input[1]);
        let secondSide = Number(input[2]);
        
        result = firstSide * secondSide;
    } else if(figure === "circle"){
        let radius = Number(input[1]);

        result = Math.PI * Math.pow(radius, 2);
    } else if(figure === "triangle") {
        let side = Number(input[1]);
        let height = Number(input[2]);

        result = (side * height) / 2;
    }

    console.log(result.toFixed(3));
}

areaOfFigures(["rectangle", "7", "2.5"]);
