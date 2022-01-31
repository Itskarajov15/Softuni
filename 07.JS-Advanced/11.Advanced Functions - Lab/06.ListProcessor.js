function solve(input) {
    let result = [];

    return {
        add: function(string) {
            result.push(string);
        },

        remove: function(string) {
            result = result
                        .filter(x => x !== string);
        },

        print: function() {
            console.log(result.join(','));
        }
    }
}

