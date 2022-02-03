function solve() {
    let onScreenButton = document.querySelector("#container button");
    let clearButton = document.querySelector("#archive button");

    onScreenButton.addEventListener('click', onScreenHandler);
    clearButton.addEventListener('click', clearMoviesFromArchive);

    function onScreenHandler(e) {
        e.preventDefault();

        let nameHolderElement = document.querySelector('[placeholder="Name"]');
        let hallHolderElement = document.querySelector('[placeholder="Hall"]');
        let priceHolderElement = document.querySelector('[placeholder="Ticket Price"]');

        let name = nameHolderElement.value;
        let hall = hallHolderElement.value;
        let price = priceHolderElement.value.trim() !== '' ? Number(priceHolderElement.value) : NaN;

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
            buttonElement.textContent = 'Archive';
            buttonElement.addEventListener('click', archiveMovie);

            divElement.appendChild(priceStrongElement);
            divElement.appendChild(inputElement);
            divElement.appendChild(buttonElement);

            liElement.appendChild(spanElement);
            liElement.appendChild(strongElement);
            liElement.appendChild(divElement);

            ulElement.appendChild(liElement);

            nameHolderElement.value = '';
            hallHolderElement.value = '';
            priceHolderElement.value = '';
        }
    }

    function archiveMovie(e) {
        let liParentElement = e.target.parentNode.parentNode;
        let movieName = liParentElement.querySelector('span:first-of-type');
        let price = Number(liParentElement.querySelector('div strong').textContent);
        let ticketsSoldHolder = document.querySelector('[placeholder="Tickets Sold"]');

        let ticketsSold = ticketsSoldHolder.value.trim() !== '' ? Number(ticketsSoldHolder.value) : NaN;;

        if (!isNaN(ticketsSold)) {
            let ulElement = document.querySelector('#archive ul');
            let liElement = document.createElement('li');

            let spanElement = document.createElement('span');
            spanElement.value = movieName;

            let strongElement = document.createElement('strong');
            strongElement.textContent = `Total amount: ${(price * ticketsSold).toFixed(2)}`;

            let button = document.createElement('button');
            button.textContent = 'Delete';
            button.addEventListener('click', deleteFromArchive);

            liElement.appendChild(spanElement);
            liElement.appendChild(strongElement);
            liElement.appendChild(button);

            ulElement.appendChild(liElement);
        }
    }

    function deleteFromArchive(e) {
        let liElement = e.target.parentElement;
        liElement.remove();
    }

    function clearMoviesFromArchive(e) {
        let ulElement = e.target.previousElementSibling;
 
        Array.from(ulElement.children).forEach(li => li.remove());
    }
}