function solve(input) {
    let juices = {};
    let bottles = {};

    for (const line of input) {
        let [juice, quantity] = line.split(' => ');
        quantity = Number(quantity);
        
        if(!juices[juice]) {
            juices[juice] = 0;
        }

        juices[juice] += quantity;

        while (juices[juice] >= 1000) {
            juices[juice] -= 1000;

            if (!bottles[juice]) {
                bottles[juice] = 0;   
            }

            bottles[juice] += 1;
        }
    }

    Object.keys(bottles).forEach(j => console.log(`${j} => ${bottles[j]}`));
}

solve(['Orange => 2000',
'Peach => 1432',
'Banana => 450',
'Peach => 600',
'Strawberry => 549']);

solve(['Kiwi => 234',
'Pear => 2345',
'Watermelon => 3456',
'Kiwi => 4567',
'Pear => 5678',
'Watermelon => 6789']);