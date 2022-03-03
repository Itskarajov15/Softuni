const viewButton = document.getElementById('btnViewPost');

function attachEvents() {
    const loadButton = document.getElementById('btnLoadPosts');
    loadButton.addEventListener('click', loadPosts);

    viewButton.addEventListener('click', viewPost);
    viewButton.disabled = true;
}

async function viewPost() {
    const posts = document.getElementById('posts');
    const currPostValue = posts.value;

    getCommentsByPostId(currPostValue);
}

async function getCommentsByPostId(postId) {
    const commentUl = document.getElementById('post-comments');
    commentUl.innerHTML = '';

    const postUrl = 'http://localhost:3030/jsonstore/blog/posts/' + postId;
    const commentsUrl = 'http://localhost:3030/jsonstore/blog/comments';

    const [postResponse, commentsResponse] = await Promise.all([
        fetch(postUrl),
        fetch(commentsUrl)
    ]);

    const postData = await postResponse.json();

    document.getElementById('post-title').textContent = postData.title;
    document.getElementById('post-body').textContent = postData.body;

    const commentsData = await commentsResponse.json();
    const comments = Object.values(commentsData).filter(c => c.postId == postId);


    comments.map(createComment).forEach(c => commentUl.appendChild(c));
}

function createComment(comment) {
    const result = document.createElement('li');
    result.textContent = comment.text;
    result.id = comment.id;
    return result;
}

async function loadPosts() {
    const url = `http://localhost:3030/jsonstore/blog/posts`;
    const result = await fetch(url);
    const data = await result.json();

    const select = document.getElementById('posts');
    select.innerHTML = '';

    const keys = Object.keys(data);
    keys.forEach(key => {
       let optionElement = document.createElement("option");
       optionElement.setAttribute("value", data[key].id);
       optionElement.textContent = data[key].title;
       
       select.appendChild(optionElement);
    });

    viewButton.disabled = false;
}

attachEvents();