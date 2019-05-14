if (window.innerWidth <= 740)
    document.getElementById("forma").setAttribute('d', 'M0,0 0,0 100,0 100,65 0,65  z');
else {
    document.getElementById("forma").setAttribute('d', 'M0,0 0,0 40,0 100,65 0,65  z');
    document.querySelector(".ulSide").style.right = '-300px';
}
window.onresize = function MudarBanner() {
    if (window.innerWidth <= 740)
        document.getElementById("forma").setAttribute('d', 'M0,0 0,0 100,0 100,65 0,65  z');
    else {
        document.getElementById("forma").setAttribute('d', 'M0,0 0,0 40,0 100,65 0,65  z');
        document.querySelector(".ulSide").style.right = '-300px';
    }
}
function myFunction(x) {
    x.classList.toggle("change");
}