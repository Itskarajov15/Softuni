function solve() {
    const url = 'http://localhost:3030/jsonstore/collections/students';
    const formElement = document.getElementById('form');

    formElement.addEventListener('submit', submitData);

    async function submitData(e) {
        e.preventDefault();

        const formData = new FormData(e.currentTarget);

        let firstName = formData.get('firstName');
        let lastName = formData.get('lastName');
        let facultyNumber = formData.get('facultyNumber');
        let grade = formData.get('grade');
        grade = Number(grade);
        e.currentTarget.reset();

        if (firstName && lastName && facultyNumber && grade && !isNaN(grade)) {
            const response = await fetch(url, {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({ firstName, lastName, facultyNumber, grade })
            });
        }
        renderStudents();
    }

    async function renderStudents() {
        const response = await fetch(url);
        const data = await response.json();

        const tableBody = document.querySelector('#results tbody');
        tableBody.innerHTML = '';

        Object.values(data).forEach(s => {
            let row = document.createElement('tr');
            let firstNameTh = document.createElement('td');
            firstNameTh.textContent = s.firstName;
            let lastNameTh = document.createElement('td');
            lastNameTh.textContent = s.lastName;
            let facultyNumberTh = document.createElement('td');
            facultyNumberTh.textContent = s.facultyNumber;
            let gradeTh = document.createElement('td');
            gradeTh.textContent = s.grade;

            row.appendChild(firstNameTh);
            row.appendChild(lastNameTh);
            row.appendChild(facultyNumberTh);
            row.appendChild(gradeTh);

            tableBody.appendChild(row);
        });
    }

    renderStudents()
}

solve()