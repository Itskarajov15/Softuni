function encodeAndDecodeMessages() {
    let senderTextareaElement = document.querySelector('#main div:first-of-type textarea');
    let receiverTextareaElement = document.querySelector('#main div:nth-child(2) textarea');

    document.querySelector('#main div:first-of-type').addEventListener('click', (e) => {
        if (e.target.tagName == 'BUTTON') {
            let inputText = senderTextareaElement.value;
            let result = '';
            
            console.log(inputText.charCodeAt(0));

            for (let i = 0; i < inputText.length; i++) {
                let currCharCode = inputText.charCodeAt(i);
                currCharCode++;
                result += String.fromCharCode(currCharCode);
            }

            senderTextareaElement.value = '';
            receiverTextareaElement.value = result;
        };
    });

    document.querySelector('#main div:nth-child(2)').addEventListener('click', (e) => {
        if (e.target.tagName == 'BUTTON') {
            let receiverText = receiverTextareaElement.value;
            let result = '';
            
            console.log(receiverText.charCodeAt(0));

            for (let i = 0; i < receiverText.length; i++) {
                let currCharCode = receiverText.charCodeAt(i);
                currCharCode--;
                result += String.fromCharCode(currCharCode);
            }
            
            receiverTextareaElement.value = result;
        };
    });
}