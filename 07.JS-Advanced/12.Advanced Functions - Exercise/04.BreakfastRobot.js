function solution() {
    let robot = {
        protein: 0,
        carbohydrate: 0,
        fat: 0,
        flavour: 0
    }

    return function(input) {
        function validateQuantity(element, quantity){
            return robot[element] - quantity < 0;
        }

        let command = input.split(' ').shift();
        let result = '';

        if (command === 'restock') {
            let [element, quantity] = input.split(' ');

            if (robot[element]) {
                robot[element] += Number(quantity);
                
                result = `Success`;
            }
        } else if (command === 'prepare') {
            let [product, quantity] = input.split(' ');

            if (product === 'apple') {
                if (!validateQuantity('carbohydrate', quantity)) {
                    return `Error: not enough carbohydrate in stock`;
                } else if (!validateQuantity('flavour', quantity)) {
                    return `Error: not enough flavour in stock`;
                } else {
                    result = 'Success';
                    robot[carbohydrate] -= 1;
                    robot[flavour] -= 2;
                }
            }
        } else if (command === 'report') {

        }

        return result;
    }
}

let manager = solution (); 
console.log (manager ("restock flavour 50")); // Success 
console.log (manager ("prepare apple 4")); // Error: not enough carbohydrate in stock 