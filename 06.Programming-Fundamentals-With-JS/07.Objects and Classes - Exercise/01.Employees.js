function solve(input){
    class Employee{
        constructor(name, personalNum){
            this.name = name;
            this.personalNum = personalNum;
        }

        printInfo(){
            console.log(`Name: ${this.name} -- Personal Number: ${this.personalNum}`);
        }
    }

    let employees = [];

    for (let i = 0; i < input.length; i++) {
        let name = input[i];
        let num = name.length;
        
        employees.push(new Employee(name, num));
    }

    employees.
        forEach((e) => e.printInfo());
}

solve(["Asen Karadzhov", "Ivan Mihaylov"]);