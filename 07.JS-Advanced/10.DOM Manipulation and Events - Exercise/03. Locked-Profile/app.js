function lockedProfile() {
    document.querySelector('#main').addEventListener('click', (e) => {
        if (e.target.tagName == 'BUTTON') {
            if (e.target.parentNode.querySelector('input[type="radio"]:checked').value == 'unlock') {
                if (e.target.textContent === 'Show more') {
                    let profileElement = e.target.parentNode;
                    profileElement.querySelector('div').style.display = 'inline';

                    e.target.textContent = 'Hide it';
                } else {
                    let profileElement = e.target.parentNode;
                    profileElement.querySelector('div').style.display = 'none';

                    e.target.textContent = 'Show more';
                }
            }
        }
    });
}