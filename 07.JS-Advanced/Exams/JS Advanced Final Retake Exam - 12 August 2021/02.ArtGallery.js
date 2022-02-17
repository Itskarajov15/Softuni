class ArtGallery {
    constructor(creator) {
        this.creator = creator;
        this.possibleArticles = {
            picture: 200,
            photo: 50,
            item: 250
        };
        this.listOfArticles = [];
        this.guests = [];
    }

    addArticle(articleModel, articleName, quantity) {
        articleModel = articleModel.toLowerCase();

        if (!this.possibleArticles.hasOwnProperty(articleModel)) {
            throw new Error('This article model is not included in this gallery!');
        }

        if (this.listOfArticles.find(a => a.articleName === articleName)) {
            let currArticle = this.listOfArticles.find(a => a.articleName === articleName);
            currArticle.quantity += quantity;
        } else {
            let article = {
                articleName,
                articleModel,
                quantity
            };

            this.listOfArticles.push(article);
        }

        return `Successfully added article ${articleName} with a new quantity- ${quantity}.`;
    }

    inviteGuest(guestName, personality) {
        if (this.guests.find(g => g.guestName === guestName)) {
            throw new Error(`${guestName} has already been invited.`);
        }
        
        let points = 0;

        if (personality === 'Vip') {
            points = 500;
        } else if (personality === 'Middle') {
            points = 250;
        } else {
            points = 50;
        }

        let guest = {
            guestName,
            points,
            purchaseArticle: 0
        }

        this.guests.push(guest);

        return `You have successfully invited ${guestName}!`;
    }

    buyArticle(articleModel, articleName, guestName) {
        articleModel = articleModel.toLowerCase();

        let currArticle = this.listOfArticles.find(a => a.articleName === articleName);

        if (!currArticle || currArticle.articleModel !== articleModel) {
            throw new Error('This article is not found.');   
        }

        if (currArticle.quantity <= 0) {
            return `The ${articleName} is not available.`;
        }

        if (!this.guests.find(g => g.guestName === guestName)) {
            return `This guest is not invited.`;
        }

        let guest = this.guests.find(g => g.guestName === guestName);

        if (guest.points < this.possibleArticles[currArticle.articleModel]) {
            return `You need to more points to purchase the article.`;
        } else {
            guest.points -= this.possibleArticles[currArticle.articleModel];
            guest.purchaseArticle++;
            currArticle.quantity--;
        }

        return `${guestName} successfully purchased the article worth ${this.possibleArticles[currArticle.articleModel]} points.`;
    }

    showGalleryInfo(criteria) {
        let result = [];

        if (criteria === 'article') {
            result.push('Articles information:');

            for (const article of this.listOfArticles) {
                result.push(`${article.articleModel} - ${article.articleName} - ${article.quantity}`);
            }
        } else if (criteria === 'guest') {
            result.push(`Guests information:`);

            for (const guest of this.guests) {
                result.push(`${guest.guestName} - ${guest.purchaseArticle}`);
            }
        }

        return result.join('\n');
    }
}

const artGallery = new ArtGallery('Curtis Mayfield'); 
artGallery.addArticle('picture', 'Mona Liza', 3);
artGallery.addArticle('Item', 'Ancient vase', 2);
artGallery.addArticle('picture', 'Mona Liza', 1);
artGallery.inviteGuest('John', 'Vip');
artGallery.inviteGuest('Peter', 'Middle');
artGallery.buyArticle('picture', 'Mona Liza', 'John');
artGallery.buyArticle('item', 'Ancient vase', 'Peter');
console.log(artGallery.showGalleryInfo('article'));
console.log(artGallery.showGalleryInfo('guest'));