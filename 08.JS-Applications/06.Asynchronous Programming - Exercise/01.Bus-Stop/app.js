async function getInfo() {
    const stopId = document.getElementById('stopId');
    const url = `http://localhost:3030/jsonstore/bus/businfo/${stopId.value}`;

    const stopNameElement = document.getElementById('stopName');
    const busesElement = document.getElementById('buses');

    try {
        const result = await fetch(url);
        busesElement.innerHTML = '';
        if (result.status !== 200) {
            throw new Error('Stop ID not found!')
        }
    
        const data = await result.json();
    
        const stopName = data.name;
        stopNameElement.textContent = stopName;
    
        Object.entries(data.buses).forEach(b => {
            const liElement = document.createElement('li');
            liElement.textContent = `Bus ${b[0]} arrives in ${b[1]}`;
            busesElement.appendChild(liElement);
        });
    } catch (error) {
        stopNameElement.textContent = 'Error';
    }
}