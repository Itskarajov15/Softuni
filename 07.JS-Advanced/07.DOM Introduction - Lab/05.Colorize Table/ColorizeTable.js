function colorize() {
    let tdElements = document.querySelectorAll('tr:nth-of-type(2n)');

    let tdElementsArr = Array.from(tdElements);
    tdElementsArr.forEach(x => {
        x.style.backgroundColor = 'teal';
    });
}   