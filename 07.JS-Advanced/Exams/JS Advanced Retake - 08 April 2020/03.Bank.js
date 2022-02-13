class Bank {
    #bankName;
    #transactions;

    constructor(bankName) {
        this.#bankName = bankName;
        this.allCustomers = [];
        this.#transactions = {};
    }

    newCustomer(customer) {
        let { firstName, lastName, personalId } = customer;

        if (this.allCustomers.find(c => c.personalId === personalId)) {
            throw new Error(`${firstName} ${lastName} is already our customer!`);
        }

        this.allCustomers.push(customer);
        this.#transactions[personalId] = [];
        return customer
    }

    depositMoney(personalId, amount) {
        if (!this.allCustomers.find(c => c.personalId === personalId)) {
            throw new Error(`We have no customer with this ID!`);
        }

        const currCustomer = this.allCustomers.find(c => c.personalId === personalId);
        currCustomer.totalMoney = isNaN(currCustomer.totalMoney) ? 0 : currCustomer.totalMoney;
        currCustomer.totalMoney += amount;

        this.#transactions[personalId].push(`${currCustomer.firstName} ${currCustomer.lastName} made deposit of ${amount}$!`);
        return `${currCustomer.totalMoney}$`;
    }

    withdrawMoney(personalId, amount) {
        if (!this.allCustomers.find(c => c.personalId === personalId)) {
            throw new Error(`We have no customer with this ID!`);
        }

        const currCustomer = this.allCustomers.find(c => c.personalId === personalId);

        if (currCustomer.totalMoney < amount) {
            throw new Error(`${currCustomer.firstName} ${currCustomer.lastName} does not have enough money to withdraw that amount!`);
        }

        currCustomer.totalMoney -= amount;
        this.#transactions[personalId].push(`${currCustomer.firstName} ${currCustomer.lastName} withdrew ${amount}$!`);
        return `${currCustomer.totalMoney}$`;
    }

    customerInfo(personalId) {
        if (!this.allCustomers.find(c => c.personalId === personalId)) {
            throw new Error(`We have no customer with this ID!`);
        }

        const currCustomer = this.allCustomers.find(c => c.personalId === personalId);
        let result = [];
        let transactions = this.#transactions[personalId].reverse();

        result.push(`Bank name: ${this.#bankName}`);
        result.push(`Customer name: ${currCustomer.firstName} ${currCustomer.lastName}`);
        result.push(`Customer ID: ${currCustomer.personalId}`);
        result.push(`Total Money: ${currCustomer.totalMoney}$`);
        result.push('Transactions:');

        let counter = transactions.length;
        
        for (const transaction of transactions) {
            result.push(`${counter}. ${transaction}`);

            counter--;
        }

        return result.join('\n').trim();
    }
}

let bank = new Bank(`SoftUni Bank`);

console.log(bank.newCustomer({firstName: `Svetlin`, lastName: `Nakov`, personalId: 6233267}));
console.log(bank.newCustomer({firstName: `Mihaela`, lastName: `Mileva`, personalId: 4151596}));

bank.depositMoney(6233267, 250);
console.log(bank.depositMoney(6233267, 250));
bank.depositMoney(4151596,555);

console.log(bank.withdrawMoney(6233267, 125));

console.log(bank.customerInfo(6233267));