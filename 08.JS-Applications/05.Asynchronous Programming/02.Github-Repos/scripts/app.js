function loadRepos() {
	let username = document.getElementById('username');

	let url = `https://api.github.com/users/${username.value}/repos`;

	fetch(url)
		.then(response => {
			if (!response.ok) {
				throw new Error('Request error');
			}
			
			return response.json();
		})
		.then(data => {
			let ulElement = document.getElementById('repos');
			ulElement.innerHTML = '';

			data.forEach(r => {
				const {full_name, html_url} = r;
				let liElement = document.createElement('li');
				let urlElement = document.createElement('a');
				urlElement.textContent = full_name;
				urlElement.href = html_url;
				liElement.appendChild(urlElement);
				ulElement.appendChild(liElement);
			});
		});
}