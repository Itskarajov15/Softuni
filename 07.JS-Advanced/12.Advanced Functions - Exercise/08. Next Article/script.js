function getArticleGenerator(articles) {
    let arrOfArticles = Array.from(articles);

    return function() {
        let currArticle = arrOfArticles.shift();
        if (currArticle) {
            let divElement = document.getElementById('content');
        
            let articleElement = document.createElement('article');
            articleElement.textContent = currArticle;
            divElement.appendChild(articleElement);
        }
    }
}
