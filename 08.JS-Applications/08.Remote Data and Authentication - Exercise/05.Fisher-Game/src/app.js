let userData = null;
const logoutElement = document.getElementById('logout');
logoutElement.addEventListener('click', async () => {
    const url = 'http://localhost:3030/users/logout';

    const userObj = JSON.parse(sessionStorage.userData);
    const res = await fetch(url, {
        headers: {
            "X-Authorization": userObj.accessToken
        }
    });

    if (res.ok) {
        sessionStorage.clear();
        window.location = 'index.html';
    }
});

const loadButton = document.querySelector('.load');
loadButton.addEventListener('click', getAllCatches);

const addButton = document.querySelector('.add');
addButton.addEventListener('click', createCatch);

async function getAllCatches() {
    const url = 'http://localhost:3030/data/catches';
    const catchesResponse = await fetch(url, {
        headers: { 'X-Authorization': userData.accessToken }
    });
    const catchesResult = await catchesResponse.json();
    const catches = document.getElementById('catches');
    catches.innerHTML = '';
    catches.append(...catchesResult.map(c => createCatchHTML(c)));
};

async function createCatch(e) {
    e.preventDefault();

    if (!userData) {
        window.location = 'login.html';
        return;
    }

    const formElement = document.getElementById('addForm');
    const formData = new FormData(formElement);

    let angler = formData.get('angler');
    let weight = formData.get('weight');
    let species = formData.get('species');
    let location = formData.get('location');
    let bait = formData.get('bait');
    let captureTime = formData.get('captureTime');

    try {
        const url = 'http://localhost:3030/data/catches';
        const catchResponse = await fetch(url, {
            method: 'POST',
            headers: { 
                'Content-Type': 'application/json',
                'X-Authorization': userData.accessToken
            },
            body: JSON.stringify({ angler, weight, species, location, bait, captureTime })
        });

        if (catchResponse.ok != true) {
            const error = catchResponse.json();
            throw new Error(error.message);
        }

        getAllCatches();
        formElement.reset();
    } catch (err) {
        alert(err.message);
    }
}

function createCatchHTML(currCatch) {
    let shouldBeDisabled = null;
    if (userData && currCatch._ownerId == userData._id) {
        shouldBeDisabled = false;
    } else {
        shouldBeDisabled = true;
    }

    let anglerLabel = e('label', undefined, null, 'Angler');
    let anglerInput = e('input', { type: 'text', class: 'angler' }, shouldBeDisabled, currCatch.angler);
    let hr1 = e('hr');
    let weightLabel = e('label', undefined, null, 'Weight');
    let weightInput = e('input', { type: 'number', class: 'weight' }, shouldBeDisabled, currCatch.weight);
    let hr2 = e('hr');
    let speciesLabel = e('label', undefined, null, 'Species');
    let speciesInput = e('input', { type: 'text', class: 'species' }, shouldBeDisabled, currCatch.species);
    let hr3 = e('hr');
    let locationLabel = e('label', undefined, null, 'Location');
    let locationInput = e('input', { type: 'text', class: 'location' }, shouldBeDisabled, currCatch.location);
    let hr4 = e('hr');
    let baitLabel = e('label', undefined, null, 'Bait');
    let baitInput = e('input', { type: 'text', class: 'bait' }, shouldBeDisabled, currCatch.bait);
    let hr5 = e('hr');
    let captureTimeLabel = e('label', undefined, null, 'Capture Time');
    let captureTimeInput = e('input', { type: 'number', class: 'captureTime' }, shouldBeDisabled, currCatch.captureTime);
    let hr6 = e('hr');
    let updateButton = e('button', { class: 'update', id: currCatch._ownerId }, shouldBeDisabled, 'Update');
    let deleteButton = e('button', { class: 'delete', id: currCatch._ownerId }, shouldBeDisabled, 'Delete');

    let catchDiv = e('div', { class: 'catch' }, anglerLabel, anglerInput, hr1, weightLabel, weightInput, hr2, speciesLabel, speciesInput,
        hr3, locationLabel, locationInput, hr4, baitLabel, baitInput, hr5, captureTimeLabel, captureTimeInput, hr6, updateButton, deleteButton);

    return catchDiv;
}

function e(type, attributes, isDisabled, ...params) {
    const result = document.createElement(type);
    let firstValue = params[0];
    if (params.length === 1 && typeof (firstValue) !== 'object') {
        if (['input', 'textarea'].includes(type)) {
            result.value = firstValue;
        } else {
            result.textContent = firstValue;
        }
    } else {
        result.append(...params);
    }

    if (attributes !== undefined) {
        Object.keys(attributes).forEach(key => {
            result.setAttribute(key, attributes[key]);
        });
    }

    if (isDisabled != null) {
        result.disabled = isDisabled;
    }

    return result;
}

window.onload = () => {
    if (sessionStorage.userData) {
        userData = JSON.parse(sessionStorage.userData);
        addButton.disabled = false;
        const userSpan = document.getElementById('user-span');
        userSpan.textContent = userData.username;
        const divGuestElement = document.getElementById('guest');
        divGuestElement.style.display = 'none';
        console.log(userData);
    } else {
        addButton.disabled = true;
        const userLogout = document.getElementById('user');
        userLogout.style.display = 'none';
    }
};