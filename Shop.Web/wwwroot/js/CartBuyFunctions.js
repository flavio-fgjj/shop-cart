function SetBtnUpdateTotalVisible(id, visible) {

    const updateTotalButton = document.querySelector("button[data-itemId='" + id + "']");

    if (visible == true) {
        updateTotalButton.style.display = "inline-block";
    }
    else {
        updateTotalButton.style.display = "none";
    }
}