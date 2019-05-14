function tabClick(produto, tabBtn) {
    var tabContent = document.querySelectorAll('.tabcontent');
    tabContent.forEach(function (element) { element.style.display = "none" });
    document.querySelector('.' + produto).style.display = "block";
}