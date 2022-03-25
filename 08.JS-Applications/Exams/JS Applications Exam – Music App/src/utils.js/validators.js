export const validator = (albumData) => {
    const requiredFields = [
        'name',
        'imgUrl',
        'price',
        'releaseDate',
        'artist',
        'genre',
        'description'
    ];

    return requiredFields.some(x => !albumData[x]);
}