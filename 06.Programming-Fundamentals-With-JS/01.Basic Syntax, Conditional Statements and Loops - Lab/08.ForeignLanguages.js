function foreignLanguages(country){
    let spokenLanguage = "";

    switch(country){
        case "England":
        case "USA":
            spokenLanguage = "English";
            break;
        case "Spain":
        case "Argentina":
        case "Mexico":
            spokenLanguage = "Spanish";
            break;
        default:
            spokenLanguage = "unknown";
    }

    console.log(spokenLanguage);
}

foreignLanguages("England");