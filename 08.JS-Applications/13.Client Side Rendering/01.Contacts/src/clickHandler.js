export function clickHandler(e) {
    const divElement = e.target.parentElement.parentElement;
    if (e.target.textContent == 'Details') {
        e.target.textContent = 'Hide';
        divElement.querySelector('.details').style.display = 'block';
    } else {
        e.target.textContent = 'Details';
        divElement.querySelector('.details').style.display = 'none';
    }
}