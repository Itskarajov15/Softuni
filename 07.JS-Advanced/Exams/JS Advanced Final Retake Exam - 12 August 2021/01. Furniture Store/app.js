window.addEventListener('load', solve);

function solve() {
    let addButton = document.getElementById('add');
    let modelElement = document.getElementById('model');
    let yearElement = document.getElementById('year');
    let descriptionElement = document.getElementById('description');
    let priceElement = document.getElementById('price');
    let furnitureList = document.getElementById('furniture-list');

    addButton.addEventListener('click', (e) => {
        e.preventDefault();

        let price = Number(priceElement.value);
        let year = Number(yearElement.value);

        if (modelElement.value && yearElement.value && descriptionElement.value && priceElement.value && price > 0 && year > 0) {
            let trElement = document.createElement('tr');
            trElement.classList.add('info');
            
            let modelTdElement = document.createElement('td');
            modelTdElement.textContent = modelElement.value;
            let priceTdElement = document.createElement('td');
            priceTdElement.textContent = price.toFixed(2);

            let tdActions = document.createElement('td');
            let moreInfoButton = document.createElement('button');
            moreInfoButton.textContent = 'More Info';
            moreInfoButton.classList.add('moreBtn');    
            moreInfoButton.addEventListener('click', toggleInfo);
            let buyButton = document.createElement('button');
            buyButton.textContent = 'Buy it';
            buyButton.classList.add('buyBtn');
            buyButton.addEventListener('click', buyProduct);

            let hiddenTr = document.createElement('tr');
            hiddenTr.classList.add('hide');
            let yearTdElement = document.createElement('td');
            yearTdElement.textContent = `Year: ${year}`;
            let descriptionTdElement = document.createElement('td');
            descriptionTdElement.textContent = `Description: ${descriptionElement.value}`;
            descriptionTdElement.colSpan = '3';

            hiddenTr.appendChild(yearTdElement);
            hiddenTr.appendChild(descriptionTdElement);

            tdActions.appendChild(moreInfoButton);
            tdActions.appendChild(buyButton);

            trElement.appendChild(modelTdElement);
            trElement.appendChild(priceTdElement);
            trElement.appendChild(tdActions);

            furnitureList.appendChild(trElement);
            furnitureList.appendChild(hiddenTr);

            modelElement.value = '';
            yearElement.value = '';
            descriptionElement.value = '';
            priceElement.value = '';
        }
    })

    function buyProduct(e) {
        let totalPrice = document.querySelector('.total-price');
        totalPrice.textContent = (Number(totalPrice.textContent) + Number(e.target.parentElement.parentElement.querySelector('td:nth-of-type(2)').textContent)).toFixed(2);
        e.target.parentElement.parentElement.remove();
    }

    function toggleInfo(e) {
        if (e.target.textContent === 'More Info') {
            e.target.textContent = 'Less Info';
            
            document.querySelector('.hide').style.display = 'contents';
        } else {
            e.target.textContent = 'More Info';

            document.querySelector('.hide').style.display = 'none';
        }
    }
}
