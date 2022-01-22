function createSortedList(){
    return {
        elements: [],

        add(element) {
            this.elements.push(element);
            this.elements.sort((a, b) => a - b);
        },

        remove(index){
            if (this.validateIndex(index)) {
                this.elements.splice(index, 1);
            }
        },

        get(index){
            if (this.validateIndex(index)) {
                return this.elements[index];
            }
        },

        get size(){
            return this.elements.length;
        },

        validateIndex(index){
            return index >= 0 && index < this.elements.length;
        }
    }
}

let sortedList = createSortedList();

sortedList.add(5);
sortedList.add(10);
sortedList.add(2);
sortedList.add(1);

console.log(sortedList.elements);

sortedList.remove(2);
console.log(sortedList.elements);

console.log(sortedList.size);