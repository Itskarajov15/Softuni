function solve(width, height, color){
    const rect = {
        width,
        height,
        color: color[0].toUpperCase() + color.slice(1),

        calcArea() {
            return width * height;
        }
    }

    console.log(rect.width);
    console.log(rect.height);
    console.log(rect.color);
    console.log(rect.calcArea());
}

solve(4, 5, 'red');