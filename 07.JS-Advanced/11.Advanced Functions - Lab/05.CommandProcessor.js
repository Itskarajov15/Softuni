function solution() {
    let result = '';

    return {
        append: function(string) {
            result += string;
        },

        removeStart: function(n) {
            result = result.substring(n);
        },

        removeEnd: function(n) {
            result = result.substring(0, result.length - n);
        },

        print: function() {
            console.log(result);
        }
    }
}

let firstZeroTest = solution();

firstZeroTest.append('hello');
firstZeroTest.append('again');
firstZeroTest.removeStart(3);
firstZeroTest.removeEnd(4);
firstZeroTest.print();