function SignalRViewModel(args) {
    var self = this;

    self._addGrocery = $(args.AddGrocery);
    self._removeGrocery = $(args.RemoveGrocery);

    self.__hub = $.connection.groceriesHub;

    //self._groceries = new GroceryViewModel($(args.Groceries));
    //self._groceryList = new GroceryListViewModel($(args.CurrentGroceryList));
    //self._recipes = new RecipeViewModel($(args.Recipes));
};

SignalRViewModel.prototype.Initialize = function() {
    var self = this;
    self.__hub.start().done(function() {
        console.log("signalr started");
    });
};