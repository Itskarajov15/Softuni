function solve() {
    let taskElement = document.getElementById('task');
    let descriptionElement = document.getElementById('description');
    let dateElement = document.getElementById('date');
    let addBtn = document.getElementById('add');
    addBtn.addEventListener('click', addTask);

    function addTask(e) {
        e.preventDefault();

        if (taskElement.value && descriptionElement.value && dateElement.value) {
            let articleElement = createEl('article');
            let h3Element = createEl('h3', taskElement.value);
            let descriptionPElement = createEl('p', `Description: ${descriptionElement.value}`);
            let datePElement = createEl('p', `Due Date: ${dateElement.value}`);
            let divElement = createEl('div', '', 'flex');
            let startButton = createEl('button', 'Start', 'green');
            startButton.addEventListener('click', moveTaskToInProgress);
            let deleteButton = createEl('button', 'Delete', 'red');
            deleteButton.addEventListener('click', deleteTask);

            divElement.appendChild(startButton);
            divElement.appendChild(deleteButton);
            
            articleElement.appendChild(h3Element);
            articleElement.appendChild(descriptionPElement);
            articleElement.appendChild(datePElement);
            articleElement.appendChild(divElement);

            document.querySelector('section:nth-of-type(2) > div:nth-of-type(2)').appendChild(articleElement);
        }
    }

    function deleteTask(e) {
        e.target.parentElement.parentElement.remove();
    }

    function moveTaskToInProgress(e) {
        document.querySelector('#in-progress').appendChild(e.target.parentElement.parentElement);
        let divElement = e.target.parentElement;
        e.target.remove(); // remove Button
        
        let finishBtn = createEl('button', 'Finish', 'orange');
        finishBtn.addEventListener('click', finishTask);

        divElement.appendChild(finishBtn);
    }

    function finishTask(e) {
        document.querySelector('section:nth-of-type(4) > div:nth-of-type(2)').appendChild(e.target.parentElement.parentElement);
        e.target.parentElement.remove();
    }

    function createEl(type, text, className) {
        const result = document.createElement(type);
        result.textContent = text;
        if (className) {
            result.className = className;
        }
        return result;
    }
}