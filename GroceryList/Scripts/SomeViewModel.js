function SomeViewModel(initArguments) {
    var self = this;

    self._hub = $.connection.groceriesHub;

    self._addGrocery = $(initArguments.AddGrocery);
    self._removeGrocery = $(initArguments.RemoveGrocery);

    self._groceries = new GroceryViewModel($(initArguments.Groceries));
    self._groceryList = new GroceryListViewModel($(initArguments.CurrentGroceryList));
    self._recipes = new RecipeViewModel($(initArguments.Recipes));
};

SomeViewModel.prototype.Groceries = function() {
    var self = this;
    return self._groceries;
};

SomeViewModel.prototype.GroceryList = function() {
    var self = this;
    return self._groceryList;
};

SomeViewModel.prototype.Initialize = function() {
    var self = this;
    $.connection.hub.start();

    self._groceries.GetGroceries();
    self._groceryList.GetGroceries();
    self._recipes.GetRecipes();

    self.SetupEvents();
};

SomeViewModel.prototype.SetupEvents = function () {
    var self = this;
    self._hub.client.updateAvailableGroceries = function (groceries) {
        console.log("updateAvailableGroceries");
        self._groceries.RenderGroceries(groceries);
    };

    self._hub.client.updateGroceriesInGroceryList = function (groceries) {
        console.log("updateGroceriesInGroceryList");
        self._groceryList.RenderGroceries(groceries);
    };

    self._addGrocery.on("click", function () {
        var id = self.GetSelectedGroceryId();
        $.getJSON("Grocery/AddGroceryToGroceryList/" + id, function () {
            console.log("addGrocery");
        });
    });
    self._removeGrocery.on("click", function () {
        var id = self.GetSelectedGroceryIdFromGroceryList();
        $.getJSON("Grocery/RemoveGroceryFromGroceryList/" + id, function () {
            console.log("deleteGrocery");
        });
    });
};

SomeViewModel.prototype.GetSelectedGroceryId = function () {
    var self = this;
    return self._groceries.Groceries().find("li.active:first").attr("id");
};

SomeViewModel.prototype.GetSelectedGroceryIdFromGroceryList = function () {
    var self = this;
    return self._groceryList.GroceryList().find("li.active:first").attr("id");
};

/********************************************
* Matvarulistan                              *
 ********************************************/

function GroceryViewModel(args) {
    var self = this;

    self._groceries = args;
};

GroceryViewModel.prototype.Groceries = function() {
    var self = this;
    return self._groceries;
};

GroceryViewModel.prototype.GetGroceries = function () {
    var self = this;
    $.getJSON("Grocery/GetAvailableGroceries").done(function (groceries) {
        self.RenderGroceries(groceries);
    });
};

GroceryViewModel.prototype.RenderGroceries = function (groceries) {
    var self = this;
    self.ClearGroceries();
    $.each(groceries, function (key, value) {
        var list = $("<li>");
        list.html(value.Name).attr("id", value.Id);
        list.on("click", function () {
            list.addClass("active").siblings().removeClass("active");
        });
        self._groceries.append(list);
    });
};

GroceryViewModel.prototype.ClearGroceries = function () {
    var self = this;
    self._groceries.find("li").remove();
};


/********************************************
* Inköpslistan                               *
 ********************************************/

function GroceryListViewModel(args) {
    var self = this;

    self._groceryList = args;
};

GroceryListViewModel.prototype.GroceryList = function() {
    var self = this;
    return self._groceryList;
};

GroceryListViewModel.prototype.GetGroceries = function () {
    var self = this;
    $.getJSON("Grocery/GetGroceriesByGroceryListId").done(function (groceries) {
        self.RenderGroceries(groceries);
    });
};

GroceryListViewModel.prototype.RenderGroceries = function (groceries) {
    var self = this;
    self.ClearGroceries();
    $.each(groceries, function (key, value) {
        var list = $("<li>");
        list.html(value.Name).attr("id", value.Id);
        list.on("click", function () {
            list.addClass("active").siblings().removeClass("active");
        });
        self._groceryList.append(list);
    });
};

GroceryListViewModel.prototype.ClearGroceries = function () {
    var self = this;
    self._groceryList.find("li").remove();
};

/********************************************
* Receptlistan                               *
 ********************************************/

function RecipeViewModel(args) {
    var self = this;

    self._recipes = args;
};

RecipeViewModel.prototype.Recipes = function() {
    var self = this;
    return self._recipes;
};

RecipeViewModel.prototype.GetRecipes = function () {
    var self = this;
    $.getJSON("Grocery/GetRecipes").done(function (recipes) {
        self.RenderRecipes(recipes);
    });
};

RecipeViewModel.prototype.RenderRecipes = function(recipes) {
    var self = this;
    self.ClearRecipes();
    $.each(recipes, function (key, value) {
        var list = $("<li>");
        list.html(value.Name).attr("id", value.Id);
        list.on("click", function () {
            list.addClass("active").siblings().removeClass("active");
        });
        self._recipes.append(list);
    });
};

RecipeViewModel.prototype.ClearRecipes = function () {
    var self = this;
    self._recipes.find("li").remove();
};