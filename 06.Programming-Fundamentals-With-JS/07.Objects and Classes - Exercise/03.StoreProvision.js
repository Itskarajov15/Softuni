function solve(firstArr, secondArr){
    class Product{
        constructor(name, quantity){
            this.name = name;
            this.quantity = quantity;
        }

        printInfo(){
            console.log(`${this.name} -> ${this.quantity}`);
        }
    }

    let products = [];

    for (let i = 0; i < firstArr.length; i += 2) {
        let name = firstArr[i];
        let quantity = Number(firstArr[i + 1]);

        products.push(new Product(name, quantity));
    }

    for (let i = 0; i < secondArr.length; i += 2) {
        let isInTheStore = false;
        let name = secondArr[i];
        let quantity = Number(secondArr[i + 1]);

        for (const product of products) {
            if(product.name === name){
                isInTheStore = true;
                product.quantity += quantity;
            }
        }

        if (!isInTheStore) {
            products.push(new Product(name, quantity));
        }
    }

    for (const product of products) {
        product.printInfo();
    }
}

solve(["Chips", "5", "CocaCola", "9", "Bananas", "14", "Pasta", "4", "Beer", "2"],
["Flour", "44", "Oil", "12", "Pasta", "7", "Tomatoes", "70", "Bananas", "30"]);