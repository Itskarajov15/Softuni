function tradeCommissions(input){
    let town = input[0];
    let sales = Number(input[1]);

    let comission = 0;

    if(sales < 0){
        console.log("error");
    }else{
        if(town === "Sofia"){
            if(sales >= 0 && sales <= 500){
                comission = 0.05;
            } else if(sales > 500 && sales <= 1000){
                comission = 0.07;
            } else if(sales > 1000 && sales <= 10000){
                comission = 0.08;
            } else if(sales > 10000){
                comission = 0.12;
            }
        } else if(town === "Varna"){
            if(sales >= 0 && sales <= 500){
                comission = 0.045;
            } else if(sales > 500 && sales <= 1000){
                comission = 0.075;
            } else if(sales > 1000 && sales <= 10000){
                comission = 0.1;
            } else if(sales > 10000){
                comission = 0.13;
            }
        } else if(town === "Plovdiv"){
            if(sales >= 0 && sales <= 500){
                comission = 0.055;
            } else if(sales > 500 && sales <= 1000){
                comission = 0.08;
            } else if(sales > 1000 && sales <= 10000){
                comission = 0.12;
            } else if(sales > 10000){
                comission = 0.145;
            }
        } else {
            console.log("error");
        }
    }

    if(comission != 0){
        console.log((sales * comission).toFixed(2));
    }
}

tradeCommissions(["Sofia", "1500"]);