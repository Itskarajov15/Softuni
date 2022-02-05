function validate() {
    const emailPattern = /^[a-z0-9_\-]+@[a-z0-9_\-]+.[a-z0-9_\-]+$/;
    
    const emailInputElement = document.getElementById('email');
    emailInputElement.addEventListener('change', validateEmail);
    
    function validateEmail(e) {
        let email = emailInputElement.value;

        if (!emailPattern.test(email)) {
            emailInputElement.classList.add('error');
        } else {
            emailInputElement.classList.remove('error');
        }
    }
}