function solve() {
    const arriveButton = document.getElementById('arrive');
    const departButton = document.getElementById('depart');
    const banner = document.querySelector('#info span');

    let stop = {
        next: 'depot'
    }

    async function depart() {
        arriveButton.disabled = false;
        departButton.disabled = true;
        
        const url = `http://localhost:3030/jsonstore/bus/schedule/${stop.next}`;

        const result = await fetch(url);
        const data = await result.json();
        stop = data;
        
        banner.textContent = `Next stop ${stop.name}`;
    }

    function arrive() {
        arriveButton.disabled = true;
        departButton.disabled = false;

        banner.textContent = `Arriving at ${stop.name}`;
    }

    return {
        depart,
        arrive
    };
}

let result = solve();