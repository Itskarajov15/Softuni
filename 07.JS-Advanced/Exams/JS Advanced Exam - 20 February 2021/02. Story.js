class Story {
    #comments;
    #likes;

    constructor(title, creator) {
        this.title = title;
        this.creator = creator;
        this.#comments = [];
        this.#likes = [];
    }

    get likes() {
        if (this.#likes.length <= 0) {
            return `${this.title} has 0 likes`;
        } else if(this.#likes.length === 1) {
            return `${this.#likes[0]} likes this story!`;
        } else {
            return `${this.#likes[0]} and ${this.#likes.length - 1} others like this story!`;
        }
    }

    like(username) {
        if (this.#likes.includes(username)) {
            throw new Error('You can\'t like the same story twice!');
        } else if (username === this.creator) {
            throw new Error('You can\'t like your own story!');
        } else {
            this.#likes.push(username);
            return `${username} liked ${this.title}!`;
        }
    }

    dislike (username) {
        if (!this.#likes.includes(username)) {
            throw new Error(`You can't dislike this story!`);
        } else {
            this.#likes = this.#likes.filter(u => u != username);

            return `${username} disliked ${this.title}`;
        }
    }

    comment (username, content, id) {
        if (!id) {
            id = this.#comments.length === 0 ? 1 : this.#comments.length + 1;
        }

        if (this.#comments.find(c => c.id === id)) {
            let currComment = this.#comments.find(c => c.id === id);
            let replyId = Number(`${currComment.id}.${currComment.replies.length === 0 ? 1 : currComment.replies.length + 1}`);
            currComment.replies.push({replyId, username, content});
            return "You replied successfully";
        } else {
            this.#comments.push({id, username, content, replies: []});
            return `${username} commented on ${this.title}`;
        }
    }

    toString(sortingType) {
        const sortVersion = {
            asc: (a, b) => a.Id - b.id,
            desc: (a, b) => b.id - a.id,
            username: (a, b) => a.username.localeCompare(b.username)
        }

        let comments = this.#comments.sort(sortVersion[sortingType]);
        comments.forEach(c => c.replies.sort(sortVersion[sortingType]));

        let result = [];
        result.push('\n');

        result.push(`Title: ${this.title}`);
        result.push(`Creator: ${this.creator}`);
        result.push(`Likes: ${this.#likes.length}`);
        result.push(`Comments:`);

        for (const comment of comments) {
            result.push(`-- ${comment.id}, ${comment.username}: ${comment.content}`);

            for (const reply of comment.replies) {
                result.push(`--- ${reply.replyId}, ${reply.username}: ${reply.content}`);       
            }
        }

        result.push('\n');
        
        return result.join('\n');
    }
}

let art = new Story("My Story", "Anny");
art.like("John");
console.log(art.likes);
art.dislike("John");
console.log(art.likes);
art.comment("Sammy", "Some Content");
console.log(art.comment("Ammy", "New Content"));
art.comment("Zane", "Reply", 1);
art.comment("Jessy", "Nice :)");
console.log(art.comment("SAmmy", "Reply@", 1));
console.log()
console.log(art.toString('username'));
console.log()
art.like("Zane");
console.log(art.toString('desc'));