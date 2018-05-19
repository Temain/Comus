var CallViewModel = function (app, dataModel) {
    var self = this;

    Sammy(function () {
        this.get('#call', function () {
            app.markLinkAsActive('call');
        });
    });

    return self;
}
 
app.addViewModel({
    name: "Call",
    bindingMemberName: "call",
    factory: CallViewModel
});