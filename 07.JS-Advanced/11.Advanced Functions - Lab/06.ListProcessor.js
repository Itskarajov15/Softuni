function solve(input) {
    let result = [];
    
    const obj = {
        add,
        remove,
        print
    }

    function add(string) {
        result.push(string);
    }

    function remove(string){
        result = result.filter(x => x !== string);
    }

    function print(){
        console.log(result.join(','));
    }

    input.forEach(i => {
        let [command, text] = i.split(' ');

        if (command === 'add') {
            obj.add(text);
        } else if (command === 'remove') {
            obj.remove(text);
        } else if (command === 'print') {
            obj.print();
        }
    })
}

solve(['add hello', 'add again', 'remove hello', 'add again', 'print']);