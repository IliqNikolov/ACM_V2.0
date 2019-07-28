function OnToggle(e) {
    if (e.target.textContent === "▼") {
        e.target.innerHTML = "&#9650;";
        if (e.target.attributes.goodtable.value === "true") {
            e.target.parentNode.parentNode.style.backgroundColor = "lightgreen";
        }
        else {
            e.target.parentNode.parentNode.style.backgroundColor = "#ff9999";
        }
        e.target.parentNode.parentNode.getElementsByClassName("table")[0].style.display = "table";
    }
    else {
        e.target.innerHTML = "&#9660;";
        e.target.parentNode.parentNode.style.backgroundColor = "";
        e.target.parentNode.parentNode.getElementsByClassName("table")[0].style.display = "none";
    }
}
let arrows = document.getElementsByClassName("toggleArror");
for (var i = 0; i < arrows.length; i++) {
    arrows[i].addEventListener("click", OnToggle);
}