import * as authService from './authService.js';

const request = async (method, url, data) => {
    let options = {};

    let token = authService.getAccessToken();

    if (method != 'GET') {
        options.method = method;
        options.headers = {
            'Content-Type': 'application/json'
        };

        if (token) {
            options.headers['X-Authorization'] = token;
        }

        options.body = JSON.stringify(data);
    }

    const res = await fetch(url, options);
    return res.json();
}

export const get = request.bind({}, 'GET');
export const put = request.bind({}, 'PUT');
export const post = request.bind({}, 'POST');
export const del = request.bind({}, 'DELETE');