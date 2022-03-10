async function solve() {
    const url = 'http://localhost:3030/jsonstore/phonebook';

    const newPhone = {
        person: 'Maya',
        phone: '0897572661'
    };

    const response = await fetch(url, { 
        method: 'POST',
        headers: { 'Content-Type': 'application/json'},
        body: JSON.stringify(newPhone)
    });

    const result = await response.json();
    console.log(result);
}

solve();