window.addEventListener('beforeunload', function (e) {
    e.preventDefault(); //per the standard
    e.returnValue = ''; //required for Chrome
    this.alert("WAAAIT")
});