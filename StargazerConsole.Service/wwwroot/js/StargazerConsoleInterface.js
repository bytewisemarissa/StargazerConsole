function UpdateLedDisplay(displayName, value) {
    var display = $('#' + displayName);

    ClearSymbols(display);

    var displayValue = value;

    var displayDigits = displayValue.replace(/[^:.'"°]/, '');
    if (displayDigits.length > 9) {
        throw "Display value too big.";
    }

    var displayObject;
    var symbolCorrection = 0;
    for (var i = 0; i < 9; i++) {
        var character;
        if (i > displayValue.length - 1) {
            character = null;
        } else {
            character = displayValue.charAt(i);
        }
        
        switch (character) {
            case ':':
                displayObject = FindDisplaySymbol(display, i - 1 - symbolCorrection);
                ClearDisplayClass(displayObject);
                AddDisplayClass(displayObject, 'symbol-colon');
                symbolCorrection++;
                break;
            case '°':
                displayObject = FindDisplaySymbol(display, i - 1 - symbolCorrection);
                ClearDisplayClass(displayObject);
                AddDisplayClass(displayObject, 'symbol-degree');
                symbolCorrection++;
                break;
            case '.':
                displayObject = FindDisplaySymbol(display, i - 1 - symbolCorrection);
                ClearDisplayClass(displayObject);
                AddDisplayClass(displayObject, 'symbol-dot');
                symbolCorrection++;
                break;
            case '\'':
                displayObject = FindDisplaySymbol(display, i - 1 - symbolCorrection);
                ClearDisplayClass(displayObject);
                AddDisplayClass(displayObject, 'symbol-minutes');
                symbolCorrection++;
                break;
            case '"':
                displayObject = FindDisplaySymbol(display, i - 1 - symbolCorrection);
                ClearDisplayClass(displayObject);
                AddDisplayClass(displayObject, 'symbol-seconds');
                symbolCorrection++;
                break;
            case 'N':
                displayObject = FindDisplayCharacter(display, i - symbolCorrection);
                ClearDisplayClass(displayObject);
                AddDisplayClass(displayObject, 'digit-n');
                break;
            case 'S':
                displayObject = FindDisplayCharacter(display, i - symbolCorrection);
                ClearDisplayClass(displayObject);
                AddDisplayClass(displayObject, 'digit-s');
                break;
            case 'E':
                displayObject = FindDisplayCharacter(display, i - symbolCorrection);
                ClearDisplayClass(displayObject);
                AddDisplayClass(displayObject, 'digit-e');
                break;
            case 'W':
                displayObject = FindDisplayCharacter(display, i - symbolCorrection);
                ClearDisplayClass(displayObject);
                AddDisplayClass(displayObject, 'digit-w');
                break;
            case 'R':
                displayObject = FindDisplayCharacter(display, i - symbolCorrection);
                ClearDisplayClass(displayObject);
                AddDisplayClass(displayObject, 'digit-r');
                break;
            case '0':
                displayObject = FindDisplayCharacter(display, i - symbolCorrection);
                ClearDisplayClass(displayObject);
                AddDisplayClass(displayObject, 'digit-zero');
                break;
            case '1':
                displayObject = FindDisplayCharacter(display, i - symbolCorrection);
                ClearDisplayClass(displayObject);
                AddDisplayClass(displayObject, 'digit-one');
                break;
            case '2':
                displayObject = FindDisplayCharacter(display, i - symbolCorrection);
                ClearDisplayClass(displayObject);
                AddDisplayClass(displayObject, 'digit-two');
                break;
            case '3':
                displayObject = FindDisplayCharacter(display, i - symbolCorrection);
                ClearDisplayClass(displayObject);
                AddDisplayClass(displayObject, 'digit-three');
                break;
            case '4':
                displayObject = FindDisplayCharacter(display, i - symbolCorrection);
                ClearDisplayClass(displayObject);
                AddDisplayClass(displayObject, 'digit-four');
                break;
            case '5':
                displayObject = FindDisplayCharacter(display, i - symbolCorrection);
                ClearDisplayClass(displayObject);
                AddDisplayClass(displayObject, 'digit-five');
                break;
            case '6':
                displayObject = FindDisplayCharacter(display, i - symbolCorrection);
                ClearDisplayClass(displayObject);
                AddDisplayClass(displayObject, 'digit-six');
                break;
            case '7':
                displayObject = FindDisplayCharacter(display, i - symbolCorrection);
                ClearDisplayClass(displayObject);
                AddDisplayClass(displayObject, 'digit-seven');
                break;
            case '8':
                displayObject = FindDisplayCharacter(display, i - symbolCorrection);
                ClearDisplayClass(displayObject);
                AddDisplayClass(displayObject, 'digit-eight');
                break;
            case '9':
                displayObject = FindDisplayCharacter(display, i - symbolCorrection);
                ClearDisplayClass(displayObject);
                AddDisplayClass(displayObject, 'digit-nine');
                break;
            case '-':
                displayObject = FindDisplayCharacter(display, i - symbolCorrection);
                ClearDisplayClass(displayObject);
                AddDisplayClass(displayObject, 'digit-negation');
                break;
            case '/':
                displayObject = FindDisplayCharacter(display, i - symbolCorrection);
                ClearDisplayClass(displayObject);
                AddDisplayClass(displayObject, 'digit-forward-slash');
                break;
            default:
                displayObject = FindDisplayCharacter(display, i - symbolCorrection);
                ClearDisplayClass(displayObject);
                AddDisplayClass(displayObject, 'digit-null');
                break;
        }
    }
}

function UpdateMiniLedDisplay(displayName, value) {
    var display = $('#' + displayName);

    ClearSymbolsMini(display);

    var displayValue = value;

    var displayDigits = displayValue.replace(/[^:.'"°]/, '');
    if (displayDigits.length > 9) {
        throw "Display value too big.";
    }

    var displayObject;
    var symbolCorrection = 0;
    for (var i = 0; i < 9; i++) {
        var character;
        if (i > displayValue.length - 1) {
            character = null;
        } else {
            character = displayValue.charAt(i);
        }

        switch (character) {
            case ':':
                displayObject = FindDisplaySymbol(display, i - 1 - symbolCorrection);
                ClearDisplayClass(displayObject);
                AddDisplayClass(displayObject, 'mini-symbol-colon');
                symbolCorrection++;
                break;
            case '°':
                displayObject = FindDisplaySymbol(display, i - 1 - symbolCorrection);
                ClearDisplayClass(displayObject);
                AddDisplayClass(displayObject, 'mini-symbol-degree');
                symbolCorrection++;
                break;
            case '.':
                displayObject = FindDisplaySymbol(display, i - 1 - symbolCorrection);
                ClearDisplayClass(displayObject);
                AddDisplayClass(displayObject, 'mini-symbol-dot');
                symbolCorrection++;
                break;
            case '\'':
                displayObject = FindDisplaySymbol(display, i - 1 - symbolCorrection);
                ClearDisplayClass(displayObject);
                AddDisplayClass(displayObject, 'mini-symbol-minutes');
                symbolCorrection++;
                break;
            case '"':
                displayObject = FindDisplaySymbol(display, i - 1 - symbolCorrection);
                ClearDisplayClass(displayObject);
                AddDisplayClass(displayObject, 'mini-symbol-seconds');
                symbolCorrection++;
                break;
            case 'N':
                displayObject = FindDisplayCharacter(display, i - symbolCorrection);
                ClearDisplayClass(displayObject);
                AddDisplayClass(displayObject, 'mini-digit-n');
                break;
            case 'S':
                displayObject = FindDisplayCharacter(display, i - symbolCorrection);
                ClearDisplayClass(displayObject);
                AddDisplayClass(displayObject, 'mini-digit-s');
                break;
            case 'E':
                displayObject = FindDisplayCharacter(display, i - symbolCorrection);
                ClearDisplayClass(displayObject);
                AddDisplayClass(displayObject, 'mini-digit-e');
                break;
            case 'W':
                displayObject = FindDisplayCharacter(display, i - symbolCorrection);
                ClearDisplayClass(displayObject);
                AddDisplayClass(displayObject, 'mini-digit-w');
                break;
            case 'R':
                displayObject = FindDisplayCharacter(display, i - symbolCorrection);
                ClearDisplayClass(displayObject);
                AddDisplayClass(displayObject, 'mini-digit-r');
                break;
            case '0':
                displayObject = FindDisplayCharacter(display, i - symbolCorrection);
                ClearDisplayClass(displayObject);
                AddDisplayClass(displayObject, 'mini-digit-zero');
                break;
            case '1':
                displayObject = FindDisplayCharacter(display, i - symbolCorrection);
                ClearDisplayClass(displayObject);
                AddDisplayClass(displayObject, 'mini-digit-one');
                break;
            case '2':
                displayObject = FindDisplayCharacter(display, i - symbolCorrection);
                ClearDisplayClass(displayObject);
                AddDisplayClass(displayObject, 'mini-digit-two');
                break;
            case '3':
                displayObject = FindDisplayCharacter(display, i - symbolCorrection);
                ClearDisplayClass(displayObject);
                AddDisplayClass(displayObject, 'mini-digit-three');
                break;
            case '4':
                displayObject = FindDisplayCharacter(display, i - symbolCorrection);
                ClearDisplayClass(displayObject);
                AddDisplayClass(displayObject, 'mini-digit-four');
                break;
            case '5':
                displayObject = FindDisplayCharacter(display, i - symbolCorrection);
                ClearDisplayClass(displayObject);
                AddDisplayClass(displayObject, 'mini-digit-five');
                break;
            case '6':
                displayObject = FindDisplayCharacter(display, i - symbolCorrection);
                ClearDisplayClass(displayObject);
                AddDisplayClass(displayObject, 'mini-digit-six');
                break;
            case '7':
                displayObject = FindDisplayCharacter(display, i - symbolCorrection);
                ClearDisplayClass(displayObject);
                AddDisplayClass(displayObject, 'mini-digit-seven');
                break;
            case '8':
                displayObject = FindDisplayCharacter(display, i - symbolCorrection);
                ClearDisplayClass(displayObject);
                AddDisplayClass(displayObject, 'mini-digit-eight');
                break;
            case '9':
                displayObject = FindDisplayCharacter(display, i - symbolCorrection);
                ClearDisplayClass(displayObject);
                AddDisplayClass(displayObject, 'mini-digit-nine');
                break;
            case '-':
                displayObject = FindDisplayCharacter(display, i - symbolCorrection);
                ClearDisplayClass(displayObject);
                AddDisplayClass(displayObject, 'mini-digit-negation');
                break;
            case '/':
                displayObject = FindDisplayCharacter(display, i - symbolCorrection);
                ClearDisplayClass(displayObject);
                AddDisplayClass(displayObject, 'mini-digit-forward-slash');
                break;
            default:
                displayObject = FindDisplayCharacter(display, i - symbolCorrection);
                ClearDisplayClass(displayObject);
                AddDisplayClass(displayObject, 'mini-digit-null');
                break;
        }
    }
}

function ClearSymbols(display) {
    var symbolDisplay;
    for (var i = 0; i < 9; i++) {
        symbolDisplay = FindDisplaySymbol(display, i);
        ClearDisplayClass(symbolDisplay);
        AddDisplayClass(symbolDisplay, 'digit-null');
    }
}

function ClearSymbolsMini(display) {
    var symbolDisplay;
    for (var i = 0; i < 9; i++) {
        symbolDisplay = FindMiniDisplaySymbol(display, i);
        ClearDisplayClass(symbolDisplay);
        AddDisplayClass(symbolDisplay, 'digit-null');
    }
}

function FindDisplayCharacter(display, id) {
    switch (id) {
    case 0:
        return display.children('.digit-place-zero')[0];
    case 1:
        return display.children('.digit-place-one')[0];
    case 2:
        return display.children('.digit-place-two')[0];
    case 3:
        return display.children('.digit-place-three')[0];
    case 4:
        return display.children('.digit-place-four')[0];
    case 5:
        return display.children('.digit-place-five')[0];
    case 6:
        return display.children('.digit-place-six')[0];
    case 7:
        return display.children('.digit-place-seven')[0];
    case 8:
        return display.children('.digit-place-eight')[0];
    default:
        throw "Can't find desired character display item.";
    }
}

function FindMiniDisplayCharacter(display, id) {
    switch (id) {
    case 0:
        return display.children('.mini-digit-place-zero')[0];
    case 1:
        return display.children('.mini-digit-place-one')[0];
    case 2:
        return display.children('.mini-digit-place-two')[0];
    case 3:
        return display.children('.mini-digit-place-three')[0];
    case 4:
        return display.children('.mini-digit-place-four')[0];
    case 5:
        return display.children('.mini-digit-place-five')[0];
    case 6:
        return display.children('.mini-digit-place-six')[0];
    case 7:
        return display.children('.mini-digit-place-seven')[0];
    case 8:
        return display.children('.mini-digit-place-eight')[0];
    default:
        throw "Can't find desired character display item.";
    }
}

function FindDisplaySymbol(display, id) {
    switch (id) {
    case 0:
        return display.children('.symbol-place-zero')[0];
    case 1:
        return display.children('.symbol-place-one')[0];
    case 2:
        return display.children('.symbol-place-two')[0];
    case 3:
        return display.children('.symbol-place-three')[0];
    case 4:
        return display.children('.symbol-place-four')[0];
    case 5:
        return display.children('.symbol-place-five')[0];
    case 6:
        return display.children('.symbol-place-six')[0];
    case 7:
        return display.children('.symbol-place-seven')[0];
    case 8:
        return display.children('.symbol-place-eight')[0];
    default:
        throw "Can't find desired symbol display item.";
    }
}

function FindMiniDisplaySymbol(display, id) {
    switch (id) {
    case 0:
        return display.children('.mini-symbol-place-zero')[0];
    case 1:
        return display.children('.mini-symbol-place-one')[0];
    case 2:
        return display.children('.mini-symbol-place-two')[0];
    case 3:
        return display.children('.mini-symbol-place-three')[0];
    case 4:
        return display.children('.mini-symbol-place-four')[0];
    case 5:
        return display.children('.mini-symbol-place-five')[0];
    case 6:
        return display.children('.mini-symbol-place-six')[0];
    case 7:
        return display.children('.mini-symbol-place-seven')[0];
    case 8:
        return display.children('.mini-symbol-place-eight')[0];
    default:
        throw "Can't find desired symbol display item.";
    }
}

function ClearDisplayClass(displayObject) {
    var appliedClasses = displayObject.className.split(/\s+/);
    displayObject.className = appliedClasses[0];
}

function AddDisplayClass(displayObject, className) {
    displayObject.className = displayObject.className + ' ' + className;
}

function SetupSystemClock() {
    setInterval(function() {
        var currentMoment = moment();
        var currentDate = currentMoment.format('DD[/]MM[/]YY');
        var currentTime = currentMoment.format('HH:mm:ss');
        UpdateLedDisplay("system-date-display", currentDate);
        UpdateLedDisplay("system-time-display", currentTime);
        },
        1000);
}

function ConnectTelescope() {
    alert('Connect Telescope');
}

function ConnectFocuser() {
    alert('Connect Focuser');
}

$(document).ready(function () {
    console.log("Document Ready. Starting Interface.");

    SetupSystemClock();
});