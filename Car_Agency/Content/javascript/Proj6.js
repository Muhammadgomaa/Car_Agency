
//[1] Change Skills Behavior

let ourSkils = document.querySelector(".numbers");

window.onscroll = function () {

    let allSkills = document.querySelectorAll(".numbers-box .numbers-progress span");

    allSkills.forEach(numbers => {

        numbers.style.width = numbers.dataset.progress;

    })
};


//___________________________________________________________________________________________

//[2] Select Down Payment Value  

var DownPay = {
    12: ["50%"],
    18: ["40%"],
    24: ["30%"],
    30: ["20%"]
}

var Duration = document.getElementById("Duration");

var Down = document.getElementById("Down");

var Price = document.getElementById("Price");

var Calc = 0.00;

Duration.addEventListener("change", function Check1 () {

    var selected = DownPay[this.value];

    while (Down.options.length > 0) {
        Down.options.remove(0);
    }

    Array.from(selected).forEach(function (el) {

        let option = new Option(el, el);

        Down.appendChild(option);

        if (option.value == "50%") {
            Calc = 0.15;
            Price.value = parseFloat(Price.value) - (parseFloat(Price.value) * 0.5);
            Price.value = (parseFloat(Price.value) + (parseFloat(Price.value) * Calc)) / 12;
            Duration.style.visibility = "hidden";
            Down.style.visibility = "hidden";
        }
        else if (option.value == "40%") {
            Calc = 0.2;
            Price.value = parseFloat(Price.value) - (parseFloat(Price.value) * 0.4);
            Price.value = (parseFloat(Price.value) + (parseFloat(Price.value) * Calc)) / 18;
            Duration.style.visibility = "hidden";
            Down.style.visibility = "hidden";
        }
        else if (option.value == "30%") {
            Calc = 0.25;
            Price.value = parseFloat(Price.value) - (parseFloat(Price.value) * 0.3);
            Price.value = (parseFloat(Price.value) + (parseFloat(Price.value) * Calc)) / 24;
            Duration.style.visibility = "hidden";
            Down.style.visibility = "hidden";
        }
        else {
            Calc = 0.35;
            Price.value = parseFloat(Price.value) - (parseFloat(Price.value) * 0.2);
            Price.value = (parseFloat(Price.value) + (parseFloat(Price.value) * Calc)) / 30;
            Duration.style.visibility = "hidden";
            Down.style.visibility = "hidden";
        } 
    });

});

//___________________________________________________________________________________________
