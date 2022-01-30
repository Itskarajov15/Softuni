function attachEventsListeners() {
    let [inputField, outputField] = document.querySelectorAll('input[type="text"]');

    let fromOption = document.getElementById('inputUnits');
    let toOption = document.getElementById('outputUnits');
    let convertBtn = document.getElementById('convert');

    convertBtn.addEventListener('click', operation);

    function operation() {
        let convertValue = Number(inputField.value);
        let result = 0;

        switch (fromOption.value) {
            case 'km': 
                convertValue *= 1000;
                break;
            case 'm':
                convertValue = convertValue;
                break;
            case 'cm':
                convertValue *= 0.01;
                break;
            case 'mm':
                convertValue *= 0.001;
                break;
            case 'mi':
                convertValue *= 1609.34;
                break;
            case 'yrd':
                convertValue *= 0.9144;
                break;
            case 'ft':
                convertValue *= 0.3048;
                break;
            case 'in':
                convertValue *= 0.0254;
                break;
        }

        switch (toOption.value) {
            case 'km': 
                result = convertValue / 1000;
                break;
            case 'm':
                result = convertValue;
                break;
            case 'cm':
                result = convertValue / 0.01;
                break;
            case 'mm':
                result = convertValue / 0.001;
                break;
            case 'mi':
                result = convertValue / 1609.34;
                break;
            case 'yrd':
                result = convertValue / 0.9144;
                break;
            case 'ft':
                result = convertValue / 0.3048;
                break;
            case 'in':
                result = convertValue / 0.0254;
                break;
        }

        outputField.value = result;
    }
}