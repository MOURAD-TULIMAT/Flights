var Weightl = -1;
function VActionWindow() {
    Weightl = -1
    const id = event.target.getAttribute("data-viewid");
    //document.getElementById("signup").style.display = "none";
    const regboxes = document.getElementsByClassName("regbox");
    Array.from(regboxes).forEach(x => x.style.display = "none");
    const regblock = document.querySelector("#blur");
    regblock.classList.add("blur");

    document.getElementById(id).style.display = "flex";
    if (id.split(' ')[0] == 'book') {
        const x = document.getElementsByName("Type " + id.split(' ')[1]);
        var i = 0;
        for (; i < x.length; i++) {
            if (x[i].checked == true) {
                break;
            }
        }
        const y = document.getElementsByName("tktT " + id.split(' ')[1]);
        var j = 0;
        for (; j < y.length; j++) {
            if (y[j].tagName == x[i].defaultValue) {
                break;
            }
        }

        document.getElementById("ticket " + id.split(' ')[1]).innerHTML = y[i].innerHTML + " (" + x[i].defaultValue + " type)"
    }
    window.scrollTo(0, 0);
    disableScroll();
}

function print() {
    console.log({ event });
}

function unVActionWindow() {
    Weightl = -1
    const regblock = document.querySelector("#blur");
    regblock.classList.remove("blur");
    const regboxes = document.getElementsByClassName("regbox");
    Array.from(regboxes).forEach(x => x.style.display = "none");
    enableScroll();
}
function sub() {
    const id = event.target.getAttribute("data-viewid").split(' ')[1];
    const x = document.getElementById("Weight " + id);
    const y = document.getElementById("total " + id);
    const pr = x.value.substr(0, x.value.length - 2);
    const pry = y.innerHTML.substr(0, y.innerHTML.length - 1);
    if (Weightl == -1) {
        Weightl = parseInt(pr);
    }
    if (parseInt(pr) - 5 >= Weightl) {
        x.value = "" + (parseInt(pr) - 5) + "kg";
        y.innerHTML = "" + (parseInt(pry) - 20) + "$";
    }
}
function add() {
    const id = event.target.getAttribute("data-viewid").split(' ')[1];
    console.log(id);
    const x = document.getElementById("Weight " + id);
    const y = document.getElementById("total " + id);
    const pr = x.value.substr(0, x.value.length - 2);
    const pry = y.innerHTML.substr(0, y.innerHTML.length - 1);
    if (Weightl == -1) {
        Weightl = parseInt(pr);
    }
    x.value = "" + (parseInt(pr) + 5) + "kg";
    y.innerHTML = "" + (parseInt(pry) + 20) + "$";
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

function laoding(status) {
    if (String(status) === "false") {
        const id = "login";
        const regboxes = document.getElementsByClassName("regbox");
        Array.from(regboxes).forEach(x => x.style.display = "none");
        const regblock = document.querySelector("#blur");
        regblock.classList.add("blur");

        document.getElementById(id).style.display = "flex";
        if (id.split(' ')[0] == 'book') {
            const x = document.getElementsByName("Type " + id.split(' ')[1]);
            var i = 0;
            for (; i < x.length; i++) {
                if (x[i].checked == true) {
                    break;
                }
            }
            const y = document.getElementsByName("tktT " + id.split(' ')[1]);
            var j = 0;
            for (; j < y.length; j++) {
                if (y[j].tagName == x[i].defaultValue) {
                    break;
                }
            }

            document.getElementById("ticket " + id.split(' ')[1]).innerHTML = y[i].innerHTML + " (" + x[i].defaultValue + " type)"
        }
        window.scrollTo(0, 0);
        disableScroll();
        document.getElementById("cred").innerHTML = "Invalid Credentials!";
        TempData["Message"] = "";
    }
    else
        document.getElementById("cred").innerHTML = "";
}

function prefillname(user) {

}