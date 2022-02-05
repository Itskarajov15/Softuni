function solve(obj) {
    let uriPattern = /^[\w.]+$/;
    let messagesPattern = /^[^<>\\&'"]*$/;
    let validMethods = ['GET', 'POST', 'DELETE', 'CONNECT'];
    let validVersions = ['HTTP/0.9', 'HTTP/1.0', 'HTTP/1.1', 'HTTP/2.0'];

    if (!validMethods.includes(obj.method)) {
        throw new Error('Invalid request header: Invalid Method');
    }

    if (!(obj.uri && (uriPattern.test(obj.uri) || obj.uri === '*'))) {
        throw new Error('Invalid request header: Invalid URI');
    }

    if (!validVersions.includes(obj.version)) {
        throw new Error('Invalid request header: Invalid Version');
    }

    if (!(obj.hasOwnProperty('message') && (obj.message === '' || messagesPattern.test(obj.message)))) {
        throw new Error('Invalid request header: Invalid Message');
    }

    return obj;
}

console.log(solve({
    method: 'GET',
    uri: 'svn.public.catalog',
    version: 'HTTP/1.1',
    message: ''
}));