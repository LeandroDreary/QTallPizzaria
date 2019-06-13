function tabClick(produto, tabBtn) {
    var tabContent = document.querySelectorAll('.tabcontent');
    tabContent.forEach(function (element) { element.style.display = "none" });
    document.querySelector('.' + produto).style.display = "block";
}

document.body.onscroll = function () {
    if (window.pageYOffset > 110) {
        document.getElementById("menuIcon").style.top = "20px";
        document.getElementById("nav").style.top = "0px";
        document.getElementById("nav").style.backgroundColor = "rgb(30,30,30)";
        document.querySelector(".ulNav").style.padding = "5px 0px 5px 50px";
    }
    else {
        document.getElementById("menuIcon").style.top = "60px";
        document.getElementById("nav").style.top = "40px";
        document.getElementById("nav").style.backgroundColor = "rgba(1,1,1,0.5)";
        document.querySelector(".ulNav").style.padding = "15px 0px 15px 190px";
    }
}