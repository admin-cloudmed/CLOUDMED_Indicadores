//Load
jQuery(document).ready(function () {
    enterFirstView();
})

// Visions
//First
function enterFirstView() {
    $('#body').animate({ 'background-color': 'red' }, 1000);

    outSecondView();
    outThirdView();
    outFourthView();
    outFifthView();
    outSixthView();
    $('#firstView').removeClass('animated bounceInLeft');
    $('#firstView').removeClass('animated bounceOutRight');
    $('#firstView').addClass('animated bounceInLeft');
    setTimeout(function () { enterSecondView(); }, 5000);
}

function outFirstView() {
    $('#firstView').addClass('animated bounceOutRight');
}


//Second
function enterSecondView() {
    $('#body').animate({ 'background-color': 'purple' }, 1000);
    outFirstView();

    outThirdView();
    outFourthView();
    outFifthView();
    outSixthView();
    $('#secondView').removeClass('animated bounceInLeft');
    $('#secondView').removeClass('animated bounceOutRight');
    $('#secondView').addClass('animated bounceInDown');
    setTimeout(function () { enterThirdView(); }, 5000);
}

function outSecondView() {
    $('#secondView').addClass('animated bounceOutRight');
}


//Third
function enterThirdView() {
    $('#body').animate({ 'background-color': 'transparent' }, 1000);
    outFirstView();
    outSecondView();

    outFourthView();
    outFifthView();
    outSixthView();
    $('#thirdView').removeClass('animated bounceInLeft');
    $('#thirdView').removeClass('animated bounceOutRight');
    $('#thirdView').addClass('animated bounceInLeft');
    setTimeout(function () { enterFourthView(); }, 5000);
}

function outThirdView() {
    $('#thirdView').addClass('animated bounceOutRight');
}



//Fourth
function enterFourthView() {
    $('#body').animate({ 'background-color': 'transparent' }, 1000);
    outFirstView();
    outSecondView();
    outThirdView();

    outFifthView();
    outFifthView();
    outSixthView();
    $('#fourthView').removeClass('animated bounceInLeft');
    $('#fourthView').removeClass('animated bounceOutRight');
    $('#fourthView').addClass('animated bounceInLeft');
    setTimeout(function () { enterFifthView(); }, 5000);
}

function outFourthView() {
    $('#fourthView').addClass('animated bounceOutRight');
}



//Fifth
function enterFifthView() {
    $('#body').animate({ 'background-color': 'transparent' }, 1000);
    outFirstView();
    outSecondView();
    outThirdView();
    outFourthView();

    outSixthView();
    $('#fifthView').removeClass('animated bounceInLeft');
    $('#fifthView').removeClass('animated bounceOutRight');
    $('#fifthView').addClass('animated bounceInLeft');
    setTimeout(function () { enterSixthView(); }, 5000);
}

function outFifthView() {
    $('#fifthView').addClass('animated bounceOutRight');
}



//Sixth
function enterSixthView() {
    $('#body').animate({ 'background-color': 'transparent' }, 1000);
    outFirstView();
    outSecondView();
    outThirdView();
    outFourthView();
    outFifthView();

    $('#sixthView').removeClass('animated bounceInLeft');
    $('#sixthView').removeClass('animated bounceOutRight');
    $('#sixthView').addClass('animated bounceInLeft');
    setTimeout(function () { enterFirstView(); }, 5000); //O último sempre tem que ser enterFirstView
}

function outSixthView() {
    $('#sixthView').addClass('animated bounceOutRight');
}
