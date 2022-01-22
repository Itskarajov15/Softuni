function solve(){
    return {
        mage(name) {
            return {
                name,
                health: 100,
                mana: 100,

                cast(spellName) {
                    this.mana--;
                    console.log(`${this.name} cast ${spellName}!`);
                }
            }
        }, 

        fighter(name) {
            return {
                name,
                health: 100,
                stamina:100,

                fight() {
                    this.stamina--;
                    console.log(`${this.name} slashes at the foe!`);
                }
            }
        }
    }
}

let create = solve();

const scorcher = create.mage("Scorcher");
scorcher.cast("fireball")
scorcher.cast("thunder")
scorcher.cast("light")
console.log(scorcher.mana);