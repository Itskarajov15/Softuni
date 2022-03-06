window.addEventListener('DOMContentLoaded', () => {
    const formElement = document.querySelector('form');
    formElement.addEventListener('submit', login);
});

async function login(e) {
    e.preventDefault();

    const url = 'http://localhost:3030/users/login';
    const formData = new FormData(e.currentTarget);
    let email = formData.get('email');
    let password = formData.get('password');

    try {
        const res = await fetch(url, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({email, password}) 
        });
    
        if (res.ok != true) {
            const error = await res.json();
            throw new Error(error.message);   
        }

        const data = await res.json();
        const user = {
            email: data.email,
            accessToken: data.accessToken,
            id: data._id
        }
    
        sessionStorage.setItem('userData', JSON.stringify(user));
        window.location = 'index.html';
    } catch (error) {
        alert(error.message);
    }
}