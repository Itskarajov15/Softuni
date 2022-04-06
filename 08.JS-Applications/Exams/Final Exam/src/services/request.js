import * as authService from '../services/authService.js';

const host = 'http://localhost:3030';

async function request(method, url, data) {
    let options = {
        method,
        headers: {}
    };

    const token = authService.getAccessToken();
    if (token) {
        options.headers['X-Authorization'] = token;
    }

    if (data) {
        options.headers['Content-Type'] = 'application/json';
        options.body = JSON.stringify(data);
    }

    try {
        const response = await fetch(host + url, options);
        if (response.ok != true) {
            const error = await response.json();
            throw new Error(error.message);
        }

        if (response.status == 204) {
            return response
        } else {
            console.log(response);
            return response.json();
        }
    } catch (err) {
        alert(err.message);
        throw err;
    }
}

export const get = request.bind(null, 'GET');
export const put = request.bind(null, 'PUT');
export const post = request.bind(null, 'POST');
export const del = request.bind(null, 'DELETE');