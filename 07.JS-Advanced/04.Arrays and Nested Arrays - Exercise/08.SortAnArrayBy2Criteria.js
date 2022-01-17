function solve(array){
    array.sort((a, b) => a.length - b.length || a.localeCompare(b))
         .forEach(a => console.log(a));
}

solve(['alpha', 
'beta', 
'gamma']);