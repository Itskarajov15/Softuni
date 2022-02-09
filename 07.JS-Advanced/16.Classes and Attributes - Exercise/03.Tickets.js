function solve(input, criteria) {
    class Ticket {
        constructor(destination, price, status) {
            this.destination = destination;
            this.price = price;
            this.status = status;
        }
    }

    let tickets = []; 

    for (const ticket of input) {
        let[destination, price, status] = ticket.split('|');
        price = Number(price);

        tickets.push(new Ticket(destination, price, status));
    }

    return tickets.sort((a, b) => criteria !== 'price' ? a[criteria].localeCompare(b[criteria]) : a[criteria] - b[criteria]);
}

console.log(solve(['Philadelphia|94.20|available',
'New York City|95.99|available',
'New York City|95.99|sold',
'Boston|126.20|departed'],
'destination'));