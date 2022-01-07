function cats(array){
    class Cat{
        constructor(name, age) {
            this.name = name;
            this.age = age;
        }

        meow(){
            console.log(`${this.name}, age ${this.age} says Meow`);
        }
    }

    let cats = [];

    for (let i = 0; i < array.length; i++) {
        let currCatInfo = array[i].split(" ");

        let [name, age] = currCatInfo;

        cats.push(new Cat(name, age));
    }

    for (const cat of cats) {
        cat.meow();
    }
}

cats(["Mellow 2 ", "Tom 5"]);