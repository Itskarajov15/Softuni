export function renderPostDetails(post) {
    let element = `
    <div class="topic-title">
    <div class="topic-content">
    </div>
    <div class="comment">
    <header class="header">
    <p><span>${post.username}</span> posted on <time>${post.date}</time></p>
    <p>${post.topicName}</p>
    </header>
        <div class="comment-main">
        <div class="userdetails">
        <img src="./static/profile.png" alt="avatar">
        </div>
        <div class="post-content">
        <p>${post.postText}</p>
        </div>
    </div>
    <div id="user-comment"></div>
    </div>
    <div class="answer-comment">
    <p class="notification"></p>
    <p><span>currentUser</span> comment:</p>
    <div class="answer">
        <form class="comment-form">
            <textarea name="commentContent" id="comment" cols="30" rows="5"></textarea>
            <div>
                <label for="username">Username <span class="red">*</span></label>
                <input type="text" name="commentUsername" id="username">
            </div>
            <button>Post</button>
        </form>
    </div>
    </div>`;

    return element;
}

export function renderComment(comment) {
    let result = document.createElement('div');
    result.className = 'topic-name-wrapper';
    result.innerHTML = `<div class="topic-name">
    <p><strong>${comment.username}</strong> commented on <time>${comment.date}</time></p>
    <div class="post-content">
        <p>${comment.comment}</p>
    `;

    return result;
}