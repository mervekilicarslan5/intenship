var controller = function() {
  var states = {
    open: {
      open: function() {},
      close: function() {
        document.getElementById("theImage").src = "https://cdn.pixabay.com/photo/2018/02/10/19/19/goal-3144351_1280.jpg";
        this.currentState = states.close;
        document.getElementById("but1").value ="ttt2222";
      }
    },
    close: {
      open: function() {
        document.getElementById("theImage").src = "https://cdn.pixabay.com/photo/2019/03/30/21/03/space-4092053_1280.jpg";
        document.getElementById("but1").value ="ttt";
        this.currentState = states.open;
      },
      close: function() {}
    }
  }

  this.currentState = states.close;

  this.open = () => this.currentState.open();
  this.close = () => this.currentState.close();

}
var c1 = new controller();

function x() {
  c1.close();
}

function y() {

  c1.open();
}
