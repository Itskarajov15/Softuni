function attachEventsListeners() {
    let daysBtn = document.getElementById('daysBtn');
    let hoursBtn = document.getElementById('hoursBtn');
    let minutesBtn = document.getElementById('minutesBtn');
    let secondsBtn = document.getElementById('secondsBtn');

    let daysElement = document.getElementById('days');
    let hoursElement = document.getElementById('hours');
    let minutesElement = document.getElementById('minutes');
    let secondsElement = document.getElementById('seconds');

    daysBtn.addEventListener('click', (e) => {
        let days = Number(daysElement.value);

        hoursElement.value = days * 24;
        minutesElement.value = days * 1440;
        secondsElement.value = days * 86400;
    });

    hoursBtn.addEventListener('click', (e) => {
        let hours = Number(hoursElement.value);

        daysElement.value = hours / 24;
        minutesElement.value = hours * 60;
        secondsElement.value = hours * 3600;
    });

    minutesBtn.addEventListener('click', (e) => {
        let minutes = Number(minutesElement.value);

        daysElement.value = minutes / 1440;
        hoursElement.value = minutes / 60;
        secondsElement.value = minutes * 60;
    });

    secondsBtn.addEventListener('click', (e) => {
        let seconds = Number(secondsElement.value);

        daysElement.value = seconds / 86400;
        hoursElement.value = seconds / 3600;
        minutesElement.value = seconds / 60;
    });
}