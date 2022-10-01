function VActionWindow() {
    const id = event.target.getAttribute("data-viewid");
    //document.getElementById("signup").style.display = "none";
    const regboxes = document.getElementsByClassName("regbox");
    Array.from(regboxes).forEach(x => x.style.display = "none");
    const regblock = document.querySelector("#blur");
    regblock.classList.add("blur");
    document.getElementById(id).style.display = "flex";

    window.scrollTo(0, 0);
    disableScroll();
}
function unVActionWindow() {
    const regblock = document.querySelector("#blur");
    regblock.classList.remove("blur");
    const regboxes = document.getElementsByClassName("regbox");
    Array.from(regboxes).forEach(x => x.style.display = "none");
    enableScroll();
}

// left: 37, up: 38, right: 39, down: 40,
// spacebar: 32, pageup: 33, pagedown: 34, end: 35, home: 36
var keys = { 37: 1, 38: 1, 39: 1, 40: 1 };

function preventDefault(e) {
    e.preventDefault();
}

function preventDefaultForScrollKeys(e) {
    if (keys[e.keyCode]) {
        preventDefault(e);
        return false;
    }
}

function verifyPassword() {
    var pw = document.getElementById("pwd").value;
    var repw = document.getElementById("repwd").value;
    var btn = document.getElementById("btn");
    if (pw != repw) {
        btn.disabled = true;
        document.getElementById("message").innerHTML = "Confirmation Password should match the Password";
        return false;
    }
    else {
        btn.disabled = false;
        document.getElementById("message").innerHTML = "";
        return true;
    }
}

// modern Chrome requires { passive: false } when adding event
var supportsPassive = false;
try {
    window.addEventListener("test", null, Object.defineProperty({}, 'passive', {
        get: function () { supportsPassive = true; }
    }));
} catch (e) { }

var wheelOpt = supportsPassive ? { passive: false } : false;
var wheelEvent = 'onwheel' in document.createElement('div') ? 'wheel' : 'mousewheel';


function disableScroll() {
    window.addEventListener('DOMMouseScroll', preventDefault, false); // older FF
    window.addEventListener(wheelEvent, preventDefault, wheelOpt); // modern desktop
    window.addEventListener('touchmove', preventDefault, wheelOpt); // mobile
    window.addEventListener('keydown', preventDefaultForScrollKeys, false);
}

function enableScroll() {
    window.removeEventListener('DOMMouseScroll', preventDefault, false);
    window.removeEventListener(wheelEvent, preventDefault, wheelOpt);
    window.removeEventListener('touchmove', preventDefault, wheelOpt);
    window.removeEventListener('keydown', preventDefaultForScrollKeys, false);
}