HTMLCollection.prototype.indexOf = [].indexOf;

$(document).ready(function () {
    $("#write-review").click(showReviewForm);
    var stars = $(".review-star");
    stars.click(setStars);
    stars.mouseenter(starHover);
    stars.mouseleave(returnStarState);
    setStars.call(stars[2]);
});

/**
 * Highlights the stars up to the one where the mouse cursor is located
 */
function starHover() {
    var stars = $(".review-star");
    var selectedStars = this.parentElement.children.indexOf(this) + 1;
    stars.addClass("glyphicon-star-empty");
    stars.removeClass("glyphicon-star");
    for (var i = 0; i < selectedStars; i++) {
        $(stars[i]).removeClass("glyphicon-star-empty");
        $(stars[i]).addClass("glyphicon-star");
    }
}

/**
 * Dims the stars so that the original state (clicked value) is displayed
 */
function returnStarState() {
    var stars = $(".review-star");
    stars.addClass("glyphicon-star-empty");
    stars.removeClass("glyphicon-star");

    for (var i = 0; i < $("#rating")[0].value; i++) {
        $(stars[i]).removeClass("glyphicon-star-empty");
        $(stars[i]).addClass("glyphicon-star");
    }
}

/**
 * Stores the clicked value of the stars in a hidden field
 */
function setStars() {
    var selectedStars = this.parentElement.children.indexOf(this);
    $("#rating")[0].value = selectedStars + 1;

    returnStarState();
}

/**
 * Displays/hides the review form
 */
function showReviewForm() {
    $("#review-form").slideToggle(500);
}