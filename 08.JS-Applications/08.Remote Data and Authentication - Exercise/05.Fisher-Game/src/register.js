const formElement = document.querySelector('form');
formElement.addEventListener('submit', register);

async function register(e) {
    e.preventDefault();

    const url = 'http://localhost:3030/users/register';
    const formData = new FormData(e.currentTarget);
    const email = formData.get('email');
    const password = formData.get('password');
    const rePass = formData.get('rePass');

    if (!email || !password || !rePass) {
        alert('All fields must be filled!');
    } else if (password !== rePass) {
        alert('Passwords don\'t match');
    }

    try {
        const registerRes = await fetch(url, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({email, password})
        });
    
        if (registerRes.ok != true) {
            const error = await registerRes.json();
            throw new Error(error.message);
        }

        const data = await registerRes.json();
        const username = email.split('@')[0];

        const userData = {
            email,
            username: username.charAt(0).toUpperCase() + username.slice(1),
            id: data._id,
            accessToken: data.accessToken
        };

        sessionStorage.setItem('userData', JSON.stringify(userData));
        window.location = 'index.html';
        formElement.reset();
    } catch (error) {
        alert(error.message);
    }
}

window.onload = () => {
    if (sessionStorage.userData) {
        const userObj = JSON.parse(sessionStorage.userData);

        const userSpan = document.getElementById('user-span');
        userSpan.textContent = userObj.username;
        const divGuestElement = document.getElementById('guest');
        divGuestElement.style.display = 'none';
    } else {
        const userLogout = document.getElementById('user');
        userLogout.style.display = 'none';
    }
};