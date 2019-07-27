function AddMoreVotes(e) {
    e.outerHTML = '<div class="row">    <div class="col-md-6 Vote">        <form>                       <div class="form-group">                <label class="control-label" for="Text">Text</label>                <input class="form-control Text" type="text" id="Text" name="Text" value="">            </div>            <div class="form-group col-md-5" style="float:left;">                <label class="control-label" for="YesCount">Positive Votes</label>                <input class="form-control Yes" type="number" data-val="true" id="Yes" name="YesCount" float="left">   		  </div>                      <div class="form-group col-md-5" style="float:left;">                <label class="control-label" for="NoCount">Negative Votes</label>                <input class="form-control No" type="number" data-val="true" id="No" name="NoCount" value="">                </div>            <div class="form-group">                <input type="button" onclick="DeleteThisVote(this)" value="Delete this Vote" class="btn btn-primary">            </div>      </form>  </div></div><div>                <input type="button" onclick="AddMoreVotes(this)" value="Add More Votes" class="btn btn-primary col-md-6 AddVote"></div>'
}
function DeleteThisVote(e) {
    e.parentNode.parentNode.parentNode.outerHTML = ""
}
function CreateMeeting() {
    let Meeting = [];
    let meetings = document.getElementsByClassName("Vote");
    for (var i = 0; i < meetings.length; i++) {
        Meeting[i] = {}
        Meeting[i].Text = meetings[i].getElementsByClassName("Text")[0].value
        if (meetings[i].getElementsByClassName("Yes")[0].value == "") {
            Meeting[i].Yes = 0;
        }
        else {
            Meeting[i].Yes = meetings[i].getElementsByClassName("Yes")[0].value
        }
        if (meetings[i].getElementsByClassName("No")[0].value == "") {
            Meeting[i].No = 0;
        }
        else {
            Meeting[i].No = meetings[i].getElementsByClassName("No")[0].value
        }

    }
    document.getElementsByClassName("json")[0].value = JSON.stringify(Meeting);
    document.getElementsByClassName("send")[0].click();
}
window.addEventListener('DOMContentLoaded', (event) => {
    if (document.getElementsByClassName("json")[0].value !== "") {
        let votes = JSON.parse(document.getElementsByClassName("json")[0].value)
        for (var i = 0; i < votes.length; i++) {
            document.getElementsByClassName("AddVote")[0].click();
            let newvote = document.getElementsByClassName("Vote")[document.getElementsByClassName("Vote").length - 1];
            newvote.getElementsByClassName("Text")[0].value = votes[i].Text;
            newvote.getElementsByClassName("Yes")[0].value = votes[i].Yes;
            newvote.getElementsByClassName("No")[0].value = votes[i].No;
        }
    }
});