function loadRepos() {
	let username = document.getElementById('username');

	let url = `https://api.github.com/users/${username.value}/repos`;

	fetch(url)
		.then(response => response.json())
		.then(data => {
			let ulElement = document.getElementById('repos');
			ulElement.innerHTML = '';

			data.forEach(r => {
				let liElement = document.createElement('li');
				let content = `${r.full_name}`;
				liElement.textContent = content;
				ulElement.appendChild(liElement);
			});
		});
}