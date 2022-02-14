let { Repository } = require("./solution.js");
const expect = require('chai').expect;

describe('Repository tests', () => {
    let properties = {
        name: "string",
        age: "number",
        birthday: "object"
    };
    
    let repository = new Repository(properties);

    let entity = {
        name: "Pesho",
        age: 22,
        birthday: new Date(1998, 0, 7)
    };

    describe('Test count', () => {
        it('Count should be 0', () => {
            expect(repository.count).to.be.equal(0);
        })
    })

    describe('Test constructor', () => {
        it('Constructor should set props correctly', () => {
            expect(repository.props).to.be.equal(properties);
        });
    })

    describe('Test add method', () => {
        it('Add method should add valid entity correctly', () => {
            expect(repository.add(entity)).to.be.equal(0);
            expect(repository.add(entity)).to.be.equal(1);
        });
    })

    describe('Test getId method', () => {
        it('GetId method should return entity correctly', () => {
            expect(repository.getId(0)).to.be.equal(entity);
            expect(repository.getId(1)).to.be.equal(entity);
        });
    
        it('GetId method should throw exception when id does not exist', () => {
            expect(() => repository.getId(10)).to.throw(`Entity with id: 10 does not exist!`);
        });
    })

    describe('Test update method', () => {
        it('Update method should throw exception when id does not exist', () => {
            expect(() => repository.getId(10)).to.throw(`Entity with id: 10 does not exist!`);
        });
    
        it('Update method should update valid entity correctly', () => {
            let newEntity = {
                name: "Stamat",
                age: 23,
                birthday: new Date(1999, 0, 5)
            };
    
            repository.update(0, newEntity);
    
            expect(repository.getId(0)).to.be.equal(newEntity);
        });
    
        it('Update method should throw exeption when entity is missing a property', () => {
            let newEntity = {
                name: "Stamat",
                age: 23,
            };
    
            expect(() => repository.update(0, newEntity)).to.throw('Property birthday is missing from the entity!');
        });
    
        it('Update method should throw exeption when property\'s type is not correct', () => {
            let newEntity = {
                name: "Stamat",
                age: "23",
                birthday: new Date(1999, 0, 5)
            };
    
            expect(() => repository.update(0, newEntity)).to.throw('Property age is not of correct type!');
        });
    })

    describe('Test del method', () => {
        it('Del method should throw exeption when id is invalid', () => {
            expect(() => repository.del(10)).to.throw('Entity with id: 10 does not exist!');
        });
    
        it('Del method should throw exeption when id is negative number', () => {
            expect(() => repository.del(-1)).to.throw('Entity with id: -1 does not exist!');
        });
    
        it('Del method should del entity correctly', () => {
            repository.del(1);
    
            expect(() => repository.getId(1)).to.throw('Entity with id: 1 does not exist!');
            expect(repository.count).to.be.equal(1);
        });
    })
});