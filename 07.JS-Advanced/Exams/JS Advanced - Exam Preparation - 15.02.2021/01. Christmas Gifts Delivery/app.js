function solution() {
    const [gifts, sent, discarded] = document.querySelectorAll('section ul');

    document.querySelector('.card > div > button').addEventListener('click', addGift);

    function addGift() {
        let input = document.querySelector('[placeholder="Gift name"]');
        let name = input.value;

        let liElement = e('li', name, 'gift');
        input.value = '';

        let sendButton = document.createElement('button');
        sendButton.textContent = 'Send';
        sendButton.setAttribute('id', 'sendButton');
        sendButton.addEventListener('click', () => moveGiftToSent(name, liElement));

        let discardButton = document.createElement('button');
        discardButton.textContent = 'Discard';
        discardButton.setAttribute('id', 'discardButton');
        discardButton.addEventListener('click', () => moveGiftToDiscarded(name, liElement));

        liElement.appendChild(sendButton);
        liElement.appendChild(discardButton);

        gifts.appendChild(liElement);

        sortList();
    }

    function moveGiftToDiscarded(name, gift) {
        gift.remove();

        let liElement = e('li', name, 'gift');

        discarded.appendChild(liElement);
    }

    function moveGiftToSent(name, gift) {
        gift.remove();

        let liElement = e('li', name, 'gift');

        sent.appendChild(liElement);
    }

    function e(type, text, className,) {
        let result = document.createElement(type);
        result.textContent = text;

        if (className) {
            result.className = className;
        }

        return result;
    }

    function sortList() {
        Array.from(gifts.children)
            .sort((a, b) => a.textContent.localeCompare(b.textContent))
            .forEach(g => gifts.appendChild(g));
    }
}