function Vlogin() {
    document.getElementById("signup").style.display = "none";
    const regblock = document.querySelector("#blur");
    regblock.classList.add("blur");
    document.getElementById("login").style.display = "flex";
}
function unVlogin() {
    const regblock = document.querySelector("#blur");
    regblock.classList.remove("blur");
    document.getElementById("login").style.display = "none";
}

function Vsignup() {
    document.getElementById("login").style.display = "none";
    const regblock = document.querySelector("#blur");
    regblock.classList.add("blur");
    document.getElementById("signup").style.display = "flex";
}
function unVsignup() {
    const regblock = document.querySelector("#blur");
    regblock.classList.remove("blur");
    document.getElementById("signup").style.display = "none";
}