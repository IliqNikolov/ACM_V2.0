window.TargetedPaid = "All";
window.TargetedOwner = "All";
function HideAll() {
    let all = document.getElementsByTagName("tr");
    for (let i = 1; i < all.length; i++) {
        all[i].style.display = "none";
    }
}
function ShowAllFromList(list) {
    for (let i = 0; i < list.length; i++) {
        list[i].style.display = "table-row"
    }
}
function HideAndShowRows() {
    HideAll();
    if (TargetedPaid === "All" && TargetedOwner === "All") {
        ShowAllFromList(document.getElementsByTagName("tr"));
    } else if (TargetedPaid === "All" && TargetedOwner === "Me") {
        ShowAllFromList(document.getElementsByClassName("MyBill"))
    } else if (TargetedPaid === "Paid" && TargetedOwner === "All") {
        ShowAllFromList(document.getElementsByClassName("Paid"))
    } else if (TargetedPaid === "Paid" && TargetedOwner === "Me") {
        ShowAllFromList(document.getElementsByClassName("MyBill Paid"))
    } else if (TargetedPaid === "Unpaid" && TargetedOwner === "All") {
        ShowAllFromList(document.getElementsByClassName("NotPaid"))
    } else if (TargetedPaid === "Unpaid" && TargetedOwner === "Me") {
        ShowAllFromList(document.getElementsByClassName("NotPaid MyBill"))
    }

}
document.getElementById("All").addEventListener("click", () => {
    window.TargetedPaid = "All";
    HideAndShowRows()
})
document.getElementById("Paid").addEventListener("click", () => {
    window.TargetedPaid = "Paid";
    HideAndShowRows()
})
document.getElementById("Unpaid").addEventListener("click", () => {
    window.TargetedPaid = "Unpaid";
    HideAndShowRows()
})
document.getElementById("AllOwners").addEventListener("click", () => {
    window.TargetedOwner = "All";
    HideAndShowRows()
})
document.getElementById("MyBills").addEventListener("click", () => {
    window.TargetedOwner = "Me";
    HideAndShowRows()
})