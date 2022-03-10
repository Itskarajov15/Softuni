const views = [...document.querySelectorAll('.view-section')];

function hideAll() {
    views.forEach(s => s.style.display = 'none');
}

export function showView(section) {
    hideAll();
    section.style.display = 'block';
}

export function updateNav() {
    let user = JSON.parse(localStorage.getItem('user'));
    
    if (user) {
        let email = user.email;
        document.querySelector('.nav-link').textContent = `Welcome, ${email}`;
        document.querySelectorAll('.user').forEach(e => e.style.display = 'block');
        document.querySelectorAll('.guest').forEach(e => e.style.display = 'none');
    } else {
        document.querySelectorAll('.user').forEach(e => e.style.display = 'none');
        document.querySelectorAll('.guest').forEach(e => e.style.display = 'block');
    }
}