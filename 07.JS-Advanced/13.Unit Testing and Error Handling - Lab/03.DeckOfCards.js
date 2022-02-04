function printDeckOfCards(cards) {
    let result = [];

    try {
        for (const card of cards) {
            const face = card.slice(0, card.length - 1);
            const suit = card.slice(card.length - 1);
    
            result.push(createCard(face, suit).toString());
        }

        console.log(result.join(' '));
    } catch (er) {
        console.log(er.message);
    }

    function createCard(face, suit) {
        const validInput = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];

        const suits = {
            'S': '\u2660',
            'H': '\u2665',
            'D': '\u2666',
            'C': '\u2663'
        }


        if (!validInput.includes(face) || !Object.keys(suits).includes(suit)) {
            throw new Error(`Invalid card: ${face}${suit}`);
        }

        return {
            face,
            suit: suits[suit],
            toString: function () {
                return `${this.face}${this.suit}`;
            }
        }
    }
}  

printDeckOfCards(['AS', '10D', 'KH', '2C']);
printDeckOfCards(['5S', '3D', 'QD', '1C']);