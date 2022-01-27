function deleteByEmail() {
    let emailElement = document.querySelector('input[name="email"]');
    let emailTdElementsArr = Array.from(document.querySelectorAll('tr td:nth-of-type(2)'));
    let divElement = document.getElementById('result');

    let email = emailElement.value;
    let targetElement = emailTdElementsArr.find(x => x.textContent === email);

    if (targetElement) {
        targetElement.parentNode.remove();
        divElement.textContent = 'Deleted.';
    } else {
        divElement.textContent = 'Not found.';
    }

    emailElement.value = '';
}