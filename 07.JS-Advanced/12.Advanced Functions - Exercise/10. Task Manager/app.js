function solve() {
    let addButton = document.getElementById('add');
    addButton.addEventListener('click', addFunction);

    function addFunction(e) {
        e.preventDefault();

        let taskInputElement = document.getElementById('task');
        let descriptionInputElement = document.getElementById('description');
        let dateInputElement = document.getElementById('date');

        let task = taskInputElement.value;
        let description = descriptionInputElement.value;
        let date = dateInputElement.value;

        if (task.trim() !== '' && description.trim() !== '' && date.trim() !== '') {
            let divParentElement = document.querySelector('.wrapper > section:nth-of-type(2) > div:nth-of-type(2)');

            let articleElement = createElement('article');
            let h3Element = createElement('h3', task);
            let descriptionPElement = createElement('p', `Description: ${description}`);
            let datePElement = createElement('p', `Due Date: ${date}`);
            let divElement = createElement('div', '', 'flex');
            let startButton = createElement('button', 'Start', 'green');
            startButton.addEventListener('click', startTask);
            let deleteButton = createElement('button', 'Delete', 'red');
            deleteButton.addEventListener('click', deleteTask);

            divElement.appendChild(startButton);
            divElement.appendChild(deleteButton);

            articleElement.appendChild(h3Element);
            articleElement.appendChild(descriptionPElement);
            articleElement.appendChild(datePElement);
            articleElement.appendChild(divElement);

            divParentElement.appendChild(articleElement);
        }
    }

    function createElement(type, text, className) {
        let currElement = document.createElement(type);
        currElement.textContent = text;

        if (className) {
            currElement.className = className;
        }

        return currElement;
    }

    function startTask(e) {
        let articleElement = e.target.parentElement.parentElement;
        let flexDivElement = articleElement.querySelector('.flex');

        let startButton = articleElement.querySelectorAll('button')[0];
        startButton.remove();

        let finishButton = createElement('button', 'Finish', 'orange');
        finishButton.addEventListener('click', finishTask);
        flexDivElement.appendChild(finishButton);

        let divInProgress = document.getElementById('in-progress');

        divInProgress.appendChild(articleElement);
    }

    function deleteTask(e) {
        let articleElement = e.target.parentElement.parentElement;

        articleElement.remove();
    }

    function finishTask(e) {
        let articleElement = e.target.parentElement.parentElement;
        let flexDivElement = e.target.parentElement;
        let completeDivElement = document.querySelector('.green').parentElement.parentElement.querySelector('div:nth-of-type(2)');

        flexDivElement.remove();
        
        completeDivElement.appendChild(articleElement);
    }
}