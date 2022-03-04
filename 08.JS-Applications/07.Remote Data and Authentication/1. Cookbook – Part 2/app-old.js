function getRecipeList() {
    const url = `http://localhost:3030/jsonstore/cookbook/recipes`;

    const main = document.querySelector('main');

    fetch(url)
        .then(response => response.json())
        .then(recipes => {
            main.innerHTML = '';
            Object.values(recipes).forEach(r => {
                const article = document.createElement('article');
                article.classList.add('preview');

                const titleDiv = document.createElement('div');
                titleDiv.classList.add('title');

                const h2Element = document.createElement('h2');
                h2Element.textContent = r.name;
                titleDiv.appendChild(h2Element);

                const imgDiv = document.createElement('div');
                imgDiv.classList.add('small');
                
                const imgElement = document.createElement('img');
                imgElement.src = r.img;
                imgDiv.appendChild(imgElement);

                article.appendChild(titleDiv);
                article.appendChild(imgDiv);
                article.addEventListener('click', () => {
                    const currRecipeUrl = `http://localhost:3030/jsonstore/cookbook/details/${r._id}`;

                    fetch(currRecipeUrl)
                        .then(response => response.json())
                        .then(details => {
                            console.log(details);
                            main.innerHTML = '';
                            main.appendChild(renderDetailedRecipe(details));
                        })
                });

                main.appendChild(article);
            })
        })
        .catch(error => {
            alert(error.message);
        })
}

window.addEventListener('load', getRecipeList);

function renderDetailedRecipe(details) {
    const articleElement = document.createElement('article');

    const h2Element = document.createElement('h2');
    h2Element.textContent = 'Title';

    const bandDiv = document.createElement('div');
    bandDiv.classList.add('band');
    
    const thumbDiv = document.createElement('div');
    thumbDiv.classList.add('thumb');
    
    const imgElement = document.createElement('img');
    imgElement.src = details.img;

    thumbDiv.appendChild(imgElement);

    const ingredientsDiv = document.createElement('div');
    ingredientsDiv.classList.add('ingredients');

    const h3Ingredients = document.createElement('h3');
    h3Ingredients.textContent = 'Ingredients:';
    
    const ulIngredients = document.createElement('ul');

    ingredientsDiv.appendChild(h3Ingredients);
    ingredientsDiv.appendChild(ulIngredients);

    bandDiv.appendChild(thumbDiv);
    bandDiv.appendChild(ingredientsDiv);

    details.ingredients.forEach(i => {
        const liTag = document.createElement('li');
        liTag.textContent = i;
        ulIngredients.appendChild(liTag);
    });

    const descriptionDiv = document.createElement('div');
    descriptionDiv.classList.add('description');
    
    const h3Preparation = document.createElement('h3');
    h3Preparation.textContent = 'Preparation:';

    descriptionDiv.appendChild(h3Preparation);

    details.steps.forEach(s => {
        const p = document.createElement('p');
        p.textContent = s;
        descriptionDiv.appendChild(p);
    });

    articleElement.appendChild(h2Element);
    articleElement.appendChild(bandDiv);
    articleElement.appendChild(descriptionDiv);

    return articleElement;
}

function e(type, attributes, ...content) {
    const result = document.createElement(type);

    for (let [attr, value] of Object.entries(attributes || {})) {
        if (attr.substring(0, 2) == 'on') {
            result.addEventListener(attr.substring(2).toLocaleLowerCase(), value);
        } else {
            result[attr] = value;
        }
    }

    content = content.reduce((a, c) => a.concat(Array.isArray(c) ? c : [c]), []);

    content.forEach(e => {
        if (typeof e == 'string' || typeof e == 'number') {
            const node = document.createTextNode(e);
        } else {
            result.appendChild(e);
        }
    })

    return result;
}