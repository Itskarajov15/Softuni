import { renderPostDetails, renderComment } from './details.js';

window.addEventListener('load', () => {
    renderPosts();
    const topicForm = document.querySelector('.new-topic');
    topicForm.addEventListener('click', (e) => {
        if (e.target.tagName == 'BUTTON') {
            e.preventDefault();

            if (e.target.textContent == 'Post') {
                createPost(e);
            } else if (e.target.textContent == 'Cancel') {
                topicForm.reset();
            }
        }
    });
    document.querySelector('.topic-container').addEventListener('click', (e) => showComments(e));

    const homeButton = document.getElementById('home-button');
    homeButton.addEventListener('click', () => {
        document.querySelector('.container').style.display = 'block';
        document.querySelector('.post-comments').style.display = 'none';
    });
})

async function showComments(e) {
    e.preventDefault();

    const postId = e.target.parentElement.parentElement.id;
    let allPosts = await getPosts();
    let neededPost = Object.values(allPosts).filter(p => p._id == postId)[0];
    document.querySelector('.container').style.display = 'none';
    document.querySelector('.post-comments').style.display = 'block';
    document.querySelector('footer').style.display = 'none';
    let element = renderPostDetails(neededPost);
    document.querySelector('.post-comments main').innerHTML= element;
    displayComments(postId);

    let commentForm = document.querySelector('.comment-form');
    commentForm.addEventListener('submit', (e) => postComment(e, postId))
}

async function postComment(e, postId) {
    e.preventDefault();

    const formData = new FormData(e.currentTarget);
    let comment = formData.get('commentContent');
    let username = formData.get('commentUsername');

    let today = new Date();
    let date = today.getFullYear()+'-'+(today.getMonth()+1)+'-'+today.getDate();

    if (!comment || !username) {
        alert('All fields must be filled!');
        return;
    }

    const res = await fetch('http://localhost:3030/jsonstore/collections/myboard/comments', {
    	method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({comment, username, date, postId})
    });

    const result = await res.json();
    e.target.reset();
    displayComments(postId);
}

async function displayComments(postId) {
    const res = await fetch('http://localhost:3030/jsonstore/collections/myboard/comments');
    const result = await res.json();
    let userCommentSeciton = document.querySelector('#user-comment');
    userCommentSeciton.replaceChildren();

    Object.values(result).filter(c => c.postId == postId).forEach(c => {
        userCommentSeciton.appendChild(renderComment(c));
    });
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
        formElement.reset();
        renderPosts();
    } catch (error) {
        alert(error.message);
    }
}

async function getPosts() {
    let res = await fetch('http://localhost:3030/jsonstore/collections/myboard/posts');
    let data = await res.json();

    return data;
}

async function renderPosts() {
    let postsData = await getPosts();
    const topicContainer = document.querySelector('.topic-container');
    topicContainer.replaceChildren();
    
    Object.values(postsData).forEach(p => {
        let articleElement = document.createElement('article');
        articleElement.classList.add('article');

        let aTag = document.createElement('a');
        aTag.href = '#';

        let h2Element = document.createElement('h2');
        h2Element.textContent = p.topicName;
        h2Element.className = 'article-title';

        aTag.appendChild(h2Element);

        let dateElement = document.createElement('p');
        dateElement.textContent = `Date: `;
        let spanDateElement = document.createElement('span');
        spanDateElement.textContent = p.date;
        spanDateElement.classList.add('bold');
        dateElement.appendChild(spanDateElement);

        let usernameElement = document.createElement('p');
        usernameElement.textContent = `Username: `;
        let spanUsernameElement = document.createElement('span');
        spanUsernameElement.textContent = p.username;
        spanUsernameElement.classList.add('bold');
        usernameElement.appendChild(spanUsernameElement);

        articleElement.appendChild(aTag);
        articleElement.appendChild(dateElement);
        articleElement.appendChild(usernameElement);
        articleElement.setAttribute('id', p._id);

        topicContainer.appendChild(articleElement);
    });
}