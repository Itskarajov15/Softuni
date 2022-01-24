function subtract() {
    let firstNumberElement = document.getElementById('firstNumber');
    let secondNumberElement = document.getElementById('secondNumber');

    let firstNumber = Number(firstNumberElement.value);
    let secondNumber = Number(secondNumberElement.value);

    let sum = firstNumber - secondNumber;

    let resultElement = document.getElementById('result');
    resultElement.textContent = sum;
}