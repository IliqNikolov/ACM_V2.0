// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function showMoney() {
    let target = document.getElementById("InnerMoneyTarget")
    target.classList.add("show")
}
function hideMoney() {
    let target = document.getElementById("InnerMoneyTarget")
    target.classList.remove("show")
}
function showAdmin() {
    let target = document.getElementById("InnerAdminTarget")
    target.classList.add("show")
}
function hideAdmin() {
    let target = document.getElementById("InnerAdminTarget")
    target.classList.remove("show")
}
document.getElementById("MoneyTarget").addEventListener("mouseover", showMoney)
document.getElementById("InnerMoneyTarget").addEventListener("mouseout", hideMoney)
document.getElementById("HomeownersTarget").addEventListener("mouseover", hideMoney)
document.getElementById("MeetingTarget").addEventListener("mouseover", hideMoney)
document.getElementById("AdminTarget").addEventListener("mouseover", showAdmin)
document.getElementById("InnerAdminTarget").addEventListener("mouseout", hideAdmin)
document.getElementById("HomeownersTarget").addEventListener("mouseover", hideAdmin)
document.getElementById("HomeTarget").addEventListener("mouseover", hideAdmin)
