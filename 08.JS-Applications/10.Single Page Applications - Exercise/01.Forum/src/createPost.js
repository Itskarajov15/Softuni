window.addEventListener('load', () => {
    renderPosts();
    const postButton = document.querySelector('.public');
    postButton.addEventListener('click', createPost);
    
    const ulList = document.querySelector('#list');
    ulList.addEventListener('click', redirect);
})

function redirect(e) {
    console.log(e.target.id);
}

async function createPost(e) {
    e.preventDefault();

    const url = 'http://localhost:3030/jsonstore/collections/myboard/posts';
    const formElement = document.querySelector('form');
    const formData = new FormData(formElement);

    let topicName = formData.get('topicName');
    let username = formData.get('username');
    let postText = formData.get('postText');

    try {
        if (!topicName || !username || !postText) {
            throw new Error('All fields must be filled!');
        }

        let today = new Date();
        let date = today.getFullYear()+'-'+(today.getMonth()+1)+'-'+today.getDate();

        const postRes = await fetch(url, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({topicName, username, postText, date})
        });

        if (postRes.ok != true) {
            const error = await postRes.json();
            throw new Error(error.message);
        }

        const postResult = await postRes.json();
        console.log(postResult);
        formElement.reset();
        renderPosts();
    } catch (error) {
        alert(error.message);
    }
}

async function renderPosts() {
    url = 'http://localhost:3030/jsonstore/collections/myboard/posts';
    
    const postsResponse = await fetch(url);
    const postsData = await postsResponse.json();
    
    Object.values(postsData).forEach(p => {
        let articleElement = document.createElement('article');

        let h3Element = document.createElement('h3');
        h3Element.textContent = p.topicName;
        h3Element.className = 'title';
        h3Element.href = 'page.html';

        let dataElement = document.createElement('p');
        dataElement.textContent = `Date: ${p.date}`;

        let usernameElement = document.createElement('p');
        usernameElement.textContent = `Username: ${p.username}`;

        articleElement.appendChild(h3Element);
        articleElement.appendChild(dataElement);
        articleElement.appendChild(usernameElement);
        articleElement.setAttribute('id', p._id);

        document.querySelector('#list').appendChild(articleElement);
    });
}