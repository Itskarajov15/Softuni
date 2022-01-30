function solve() {
  let furnitureListTextareaElement = document.querySelector('#exercise textarea:first-of-type');

  document.querySelector('#exercise').addEventListener('click', (e) => {
    if (e.target.tagName == 'BUTTON' && e.target.textContent == 'Generate') {
      let arrOfFurniture = JSON.parse(furnitureListTextareaElement.value);

      for (const element of arrOfFurniture) {
        let row = document.createElement('tr');
        let imgTd = document.createElement('td');
        let nameTd = document.createElement('td');
        let priceTd = document.createElement('td');
        let decorationTd = document.createElement('td');
        let markTd = document.createElement('td');

        let img = document.createElement('img');
        img.src = element['img'];
        imgTd.appendChild(img);

        nameTd.textContent = element['name'];
        
        priceTd.textContent = Number(element['price']);

        decorationTd.textContent = Number(element['decFactor']);

        let inputElement = document.createElement('input');
        inputElement.type = 'checkbox';
        markTd.appendChild(inputElement);

        
        row.appendChild(imgTd);
        row.appendChild(nameTd);
        row.appendChild(priceTd);
        row.appendChild(decorationTd);
        row.appendChild(markTd);

        document.getElementsByClassName('table')[0].appendChild(row);
      }
    };
  });

  document.querySelector('#exercise').addEventListener('click', (e) => {
    if (e.target.tagName == 'BUTTON' && e.target.textContent == 'Buy') {
      let inputElements = document.querySelectorAll('input[type="checkbox"]');

      let totalPrice = 0;
      let averageDecFac = 0;
      let furniture = [];

      for (const element of inputElements) {
        if (element.checked) {
          let parentRow = element.parentElement.parentElement;

          let nameElement = parentRow.children[1];
          let priceElement = parentRow.children[2];
          let decFacElement = parentRow.children[3];

          totalPrice += Number(priceElement.textContent);
          averageDecFac += Number(decFacElement.textContent);
          furniture.push(nameElement.textContent);
        }
      }

      averageDecFac /= furniture.length;

      let result = `Bought furniture: ${furniture.join(', ')}\n`;
      result += `Total price: ${totalPrice.toFixed(2)}\n`;
      result += `Average decoration factor: ${averageDecFac.toFixed(2)}`;

      document.querySelector('textarea:nth-of-type(2)').textContent = result;
    };
  });
}