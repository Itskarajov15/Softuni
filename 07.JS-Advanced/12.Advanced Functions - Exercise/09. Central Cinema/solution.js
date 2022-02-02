function solve() {
    document.querySelector('#container').addEventListener('click', (e) => {
        e.preventDefault();

        if (e.target.tagName === 'BUTTON' && e.target.textContent === 'On Screen') {
            let nameHolderElement = document.querySelector('[placeholder="Name"]');
            let hallHolderElement = document.querySelector('[placeholder="Hall"]');
            let priceHolderElement = document.querySelector('[placeholder="Ticket Price"]');

            let name = nameHolderElement.value;
            let hall = hallHolderElement.value;
            let price = Number(priceHolderElement.value);

            if (name.length > 0 && hall.length > 0 && !isNaN(price)) {
                let ulElement = document.querySelector('#movies ul');

                let liElement = document.createElement('li');

                let spanElement = document.createElement('span');
                spanElement.textContent = name;

                let strongElement = document.createElement('strong');
                strongElement.textContent = `Hall: ${hall}`;

                let divElement = document.createElement('div');
                let priceStrongElement = document.createElement('strong');
                priceStrongElement.textContent = price.toFixed(2);

                let inputElement = document.createElement('input');
                inputElement.placeholder = 'Tickets Sold';

                let buttonElement = document.createElement('button');
                buttonElement.textContent = '[Archive]';

                divElement.appendChild(priceStrongElement);
                divElement.appendChild(inputElement);
                divElement.appendChild(buttonElement);

                liElement.appendChild(spanElement);
                liElement.appendChild(strongElement);
                liElement.appendChild(divElement);

                ulElement.appendChild(liElement);
                //clear the input



                document.querySelector('#movies ul').addEventListener('click', (e) => {
                    if (e.target.tagName === 'BUTTON' && e.target.textContent === '[Archive]') {
                        let ticketsSoldHolder = document.querySelector('[placeholder="Tickets Sold"]');

                        let ticketsSold = Number(ticketsSoldHolder.value);

                        if (!isNaN(ticketsSold)) {
                            let ulElement = document.querySelector('#archive ul');
                            let liElement = document.createElement('li');

                            let spanElement = document.createElement('span');
                            spanElement.textContent = name;
                            
                            let strongElement = document.createElement('strong');
                            strongElement.textContent = `Total amount: ${(price * ticketsSold).toFixed(2)}`;

                            let button = document.createElement('button');
                            button.textContent = 'Delete';

                            liElement.appendChild(spanElement);
                            liElement.appendChild(strongElement);
                            liElement.appendChild(button);

                            ulElement.appendChild(liElement);
                        }
                    }
                });
            }
        }
    });
}