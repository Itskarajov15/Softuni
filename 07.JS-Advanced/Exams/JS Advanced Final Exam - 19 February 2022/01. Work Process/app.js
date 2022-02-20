function solve() {
    let firstNameElement = document.getElementById('fname');
    let lastNameElement = document.getElementById('lname');
    let emailElement = document.getElementById('email');
    let birthElement = document.getElementById('birth');
    let positionElement = document.getElementById('position');
    let salaryElement = document.getElementById('salary');

    let tBody = document.getElementById('tbody');
    let sum = document.getElementById('sum');

    const inputValues = Array.from(document.querySelector('#signup > form').querySelectorAll('input'));

    let hireButton = document.getElementById('add-worker');
    hireButton.addEventListener('click', addWorker);

    function addWorker(e) {
        e.preventDefault();

        if (firstNameElement.value && lastNameElement.value && emailElement.value && birthElement.value && positionElement.value 
            && salaryElement.value) {
            let trElement = document.createElement('tr');

            for (let i = 0; i < inputValues.length; i++) {
                const tdElement = document.createElement('td');
                tdElement.textContent = inputValues[i].value;
                trElement.appendChild(tdElement);
            }

            let buttonsTd = document.createElement('td');
            let firedButton = document.createElement('button');
            firedButton.textContent = 'Fired';
            firedButton.className = 'fired';
            firedButton.addEventListener('click', (e) => {
                e.target.parentElement.parentElement.remove();
                let tdCollection = Array.from(e.target.parentElement.parentElement.querySelectorAll('td'));
                sum.textContent = (Number(sum.textContent) - Number(tdCollection[5].textContent)).toFixed(2);
            })
            let editButton = document.createElement('button');
            editButton.textContent = 'Edit';
            editButton.className = 'edit';
            editButton.addEventListener('click', () => {
                const tdItems = Array.from(trElement.childNodes);
                
                for (let i = 0; i < tdItems.length - 1; i++) {
                    inputValues[i].value = tdItems[i].textContent;
                }

                trElement.remove();

                sum.textContent = (Number(sum.textContent) - Number(inputValues[5].value)).toFixed(2);
            })

            buttonsTd.appendChild(firedButton);
            buttonsTd.appendChild(editButton);
            trElement.appendChild(buttonsTd);

            tBody.appendChild(trElement);
            sum.textContent = (Number(sum.textContent) + Number(salaryElement.value)).toFixed(2);

            for (const input of inputValues) {
                input.value = '';
            }
        }
    }
}
solve()