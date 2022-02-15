window.addEventListener('load', solution);

function solution() {
  let btnSubmit = document.getElementById('submitBTN');
  let editBtn = document.getElementById('editBTN');
  let continueBtn = document.getElementById('continueBTN');
  let previewUlElement = document.getElementById('infoPreview');
  let divBlockElement = document.getElementById('block');

  btnSubmit.disabled = false;
  editBtn.disabled = true;
  continueBtn.disabled = true;

  const inputValues = Array.from(document.getElementById('form').querySelectorAll('input'));
  const labelValues = Array.from(document.getElementById('form').querySelectorAll('label'));
  inputValues.pop();

  btnSubmit.addEventListener('click', (e) => {
    const fullName = inputValues[0];
    const email = inputValues[1];

    if (fullName.value && email.value) {
      for (let i = 0; i < inputValues.length; i++) {
        const liElement = document.createElement('li');
        liElement.textContent = `${labelValues[i].textContent} ${inputValues[i].value}`;
        previewUlElement.appendChild(liElement);
      }

      for (const input of inputValues) {
        input.value = '';
      }

      e.target.disabled = true;
      editBtn.disabled = false;
      continueBtn.disabled = false;
    }
  });

  editBtn.addEventListener('click', () => {
    const listItems = Array.from(previewUlElement.childNodes);
    for (let i = 0; i < listItems.length; i++) {
      inputValues[i].value = listItems[i].textContent.split(': ')[1];
      listItems[i].remove();
    }

    btnSubmit.disabled = false;
    editBtn.disabled = true;
    continueBtn.disabled = true;
  });

  continueBtn.addEventListener('click', () => {
    divBlockElement.innerHTML = '';

    const h3 = document.createElement('h3');
    h3.textContent = 'Thank you for your reservation!';
    divBlockElement.appendChild(h3);
  })
}