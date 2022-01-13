function solve(input){
    function GetSumOfAllElements(numbers){
        return numbers.reduce(function(acumulator, element){
            return acumulator + element;
        })
    }

    function CalculateInverseValues(numbers){
        let sum = 0;

        for (const number of numbers) {
            sum += 1 / number;
        }

        return sum;
    }

    function Concat(numbers){
        let output = '';

        for (const number of numbers) {
            output += number;
        }

        return output;
    }

    console.log(GetSumOfAllElements(input));
    console.log(CalculateInverseValues(input));
    console.log(Concat(input));
}

solve([1, 2, 3]);