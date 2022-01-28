function focused() {
    let inputElements = Array.from(document.querySelectorAll('input[type="text"]'));

    inputElements.forEach(element => {
        element.addEventListener('input', (e) => {
            let parent = e.target.parentNode;
            
            if (e.target.value.length <= 0) {
                parent.classList.remove('focused');
            } else {
                parent.classList.add('focused');
            }
        });
    });
}