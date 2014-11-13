function processRestaurantManagerCommands(commands) {
    'use strict';   

    Object.prototype.extend = function(parent) {
        if (!Object.create) {
            Object.prototype.create = function(proto) {
                function F(){}
                F.prototype = proto;
                return new F();
            };
        }
        this.prototype = Object.create(parent.prototype);
        this.prototype.constructor = this;
    };

    var Constants = (function(){

        var GRAMS = 'g';
        var MILILITERS = 'ml';

        return {
            GRAMS: GRAMS,
            MILILITERS: MILILITERS
        };
    }());

    var RestaurantEngine = (function () {
        var _restaurants, _recipes;

        function initialize() {
            _restaurants = [];
            _recipes = [];
        }

        var Restaurant = (function () {
            function Restaurant(name, location) {
                this.setName(name);
                this.setLocation(location);
                this._recipes = []; 
            }

            Restaurant.prototype.addRecipe = function (recipe) {
                this._recipes.push(recipe);
            };  

            Restaurant.prototype.removeRecipe = function(recipe) {
                var recName = recipe.getName();
                this._recipes = this._recipes.filter(function(recipe){
                    return recipe.getName() !== recName;
                });
            };

            Restaurant.prototype.getName = function() {
                return this._name;
            };

            Restaurant.prototype.setName = function(name) {
                if (name) {
                    this._name = name;
                } else {
                    throw new RangeError('The name is required.');
                }
            };

            Restaurant.prototype.setLocation = function(location) {
                if (location) {
                    this._location = location;
                } else {
                    throw new RangeError('The location is required.');
                }
            };

            Restaurant.prototype.getLocation = function() {
                return this._location;
            };

            Restaurant.prototype.filterRecipesByType = function(type) {
                var result, resultStr = '';
                result = this._recipes.filter(function(recipe){
                    return recipe instanceof type;
                });
                result = result.sort(function(a, b){
                    return a.getName().localeCompare(b.getName());
                });

                for (var i = 0; i < result.length; i++) {
                    resultStr += result[i].toString();
                }

                return resultStr;
            };

            Restaurant.prototype.printRestaurantMenu = function() {
                var result = '***** ' + this.getName() + ' - ' + this.getLocation() + ' *****' + '\n';
                if (this._recipes.length === 0) {
                    result += 'No recipes... yet' + '\n';
                }
                if (this.filterRecipesByType(Drink)) {
                    result += '~~~~~ DRINKS ~~~~~' + '\n' +
                     this.filterRecipesByType(Drink);
                }
                if (this.filterRecipesByType(Salad)) {
                    result += '~~~~~ SALADS ~~~~~' + '\n' +
                     this.filterRecipesByType(Salad);
                }
                if (this.filterRecipesByType(MainCourse)) {
                    result += '~~~~~ MAIN COURSES ~~~~~' + '\n' +
                     this.filterRecipesByType(MainCourse);
                }
                if (this.filterRecipesByType(Dessert)) {
                    result += '~~~~~ DESSERTS ~~~~~' + '\n' +
                     this.filterRecipesByType(Dessert);
                }

                return result;
            };
            
            
            return Restaurant;
        }());

        var Recipe = (function () {
            function Recipe(name, price, calories, quantity, timeToPrepare, unit) {
                this._name = name;
                this._price = this.setNumberValue('price', price);
                this._calories = this.setNumberValue('calories', calories);
                this._quantity = this.setNumberValue('quantity', quantity); 
                this._timeToPrepare = this.setNumberValue('time to prepare', timeToPrepare);
                this._unit = unit;
            }

            Recipe.prototype.getName = function() {
                return this._name;
            };

            Recipe.prototype.setName = function(name) {
                if (name) {
                    this._name = name;
                } else {
                    throw new RangeError('The name is required.');
                }
            };

            Recipe.prototype.setNumberValue = function(parameter, number) {
                if (number > 0) {
                    return number;
                } else {
                    throw new RangeError('The ' + parameter + ' must be positive.');
                }
            };

            Recipe.prototype.toggleSugar = function() {
                if (this._withSugar === true) {
                    this._withSugar = false;
                } else {
                    this._withSugar = true;
                }
            };

            Recipe.prototype.toggleVegan = function() {
                if (this._isVegan === true) {
                    this._isVegan = false;
                } else {
                    this._isVegan = true;
                }
            };
                
            Recipe.prototype.toString = function() {
                var result = '==  ' + this.getName() + ' == $' + this._price.toFixed(2) + '\n' +
                    'Per serving: ' + this._quantity + ' ' + this._unit + ', ' + this._calories + ' kcal' + '\n' +
                    'Ready in ' + this._timeToPrepare + ' minutes' + '\n';

                return result;
            };

            return Recipe;
        }());

        var Meal = (function () {
            function Meal(name, price, calories, quantity, timeToPrepare, unit, isVegan) {
                Recipe.call(this, name, price, calories, quantity, timeToPrepare, unit);
                this._isVegan = isVegan;
            }

            Meal.extend(Recipe);    

            Meal.prototype.toString = function() {
                var vegan = this._isVegan ? '[VEGAN] ' : '';
                var result = vegan + Recipe.prototype.toString.call(this);

                return result;
            };

            return Meal;
        }());

        var Drink = (function () {
            function Drink(name, price, calories, quantity, timeToPrepare, isCarbonated) {
                Recipe.call(this, name, price, calories, quantity, timeToPrepare, Constants.MILILITERS);
                this._isCarbonated = isCarbonated;
            }         

            Drink.extend(Recipe);

            Drink.prototype.setCalories = function(calories) {
                if (calories <= 100) {
                    this._calories = calories;
                } else {
                    throw new RangeError('The calories must be positive.');
                }
            };

            Drink.prototype.setTime = function(time) {
                if (time <= 20) {
                    this._time = time;
                } else {
                    throw new RangeError('The time to prepare must be positive.');
                }
            };

            Drink.prototype.setIsCarbonated = function(input) {
                if (input) {
                    this._isCarbonated = input;
                } else {
                    this._isCarbonated = 'no';
                }
            };

            Drink.prototype.toString = function() {
                var carbonated = this._isCarbonated ? 'yes' : 'no';

                var result = Recipe.prototype.toString.call(this) +
                'Carbonated: ' + carbonated + '\n';

                return result;
            };

            return Drink;
        }());

        var MainCourse = (function () {
            function MainCourse(name, price, calories, quantity, timeToPrepare, isVegan, type) {
                Meal.call(this, name, price, calories, quantity, timeToPrepare, Constants.GRAMS, isVegan);
                this._type = type;
            }

            MainCourse.extend(Meal);

            MainCourse.prototype.toString = function() {
                var result = Meal.prototype.toString.call(this) +
                    'Type: ' + this._type + '\n';

                return result;
            };

            return MainCourse;
        }());
      
        var Salad = (function () {
            function Salad(name, price, calories, quantity, timeToPrepare, containsPasta) {
                Meal.call(this, name, price, calories, quantity, timeToPrepare, Constants.GRAMS, 'yes');
                this._containsPasta = containsPasta;
            }

            Salad.extend(Meal);

            Salad.prototype.toString = function() {
                var pasta = this._containsPasta ? 'yes' : 'no';
                var result = Meal.prototype.toString.call(this) +
                'Contains pasta: ' + pasta + '\n';

                return result;
            };
            
            return Salad;
        }());

        var Dessert = (function () {
            function Dessert(name, price, calories, quantity, timeToPrepare, isVegan) {
                Meal.call(this, name, price, calories, quantity, timeToPrepare, Constants.GRAMS, isVegan);
                this._withSugar = true;
            }

            Dessert.extend(Meal);

            Dessert.prototype.toString = function() {
                var sugar = this._withSugar ? '' : '[NO SUGAR] ';
                var result = sugar + Meal.prototype.toString.call(this);  

                return result;              
            };

            return Dessert;
        }());

        var Command = (function () {

            function Command(commandLine) {
                this._params = new Array();
                this.translateCommand(commandLine);
            }

            Command.prototype.translateCommand = function (commandLine) {
                var self, paramsBeginning, name, parametersKeysAndValues;
                self = this;
                paramsBeginning = commandLine.indexOf("(");

                this._name = commandLine.substring(0, paramsBeginning);
                name = commandLine.substring(0, paramsBeginning);
                parametersKeysAndValues = commandLine
                    .substring(paramsBeginning + 1, commandLine.length - 1)
                    .split(";")
                    .filter(function (e) { return true; });

                parametersKeysAndValues.forEach(function (p) {
                    var split = p
                        .split("=")
                        .filter(function (e) { return true; });
                    self._params[split[0]] = split[1];
                });
            };

            return Command;
        }());

        function createRestaurant(name, location) {
            _restaurants[name] = new Restaurant(name, location);
            return "Restaurant " + name + " created\n";
        }

        function createDrink(name, price, calories, quantity, timeToPrepare, isCarbonated) {
            _recipes[name] = new Drink(name, price, calories, quantity, timeToPrepare, isCarbonated);
            return "Recipe " + name + " created\n";
        }

        function createSalad(name, price, calories, quantity, timeToPrepare, containsPasta) {
            _recipes[name] = new Salad(name, price, calories, quantity, timeToPrepare, containsPasta);
            return "Recipe " + name + " created\n";
        }

        function createMainCourse(name, price, calories, quantity, timeToPrepare, isVegan, type) {
            _recipes[name] = new MainCourse(name, price, calories, quantity, timeToPrepare, isVegan, type);
            return "Recipe " + name + " created\n";
        }

        function createDessert(name, price, calories, quantity, timeToPrepare, isVegan) {
            _recipes[name] = new Dessert(name, price, calories, quantity, timeToPrepare, isVegan);
            return "Recipe " + name + " created\n";
        }

        function toggleSugar(name) {
            var recipe;

            if (!_recipes.hasOwnProperty(name)) {
                throw new Error("The recipe " + name + " does not exist");
            }
            recipe = _recipes[name];

            if (recipe instanceof Dessert) {
                recipe.toggleSugar();
                return "Command ToggleSugar executed successfully. New value: " + recipe._withSugar.toString().toLowerCase() + "\n";
            } else {
                return "The command ToggleSugar is not applicable to recipe " + name + "\n";
            }
        }

        function toggleVegan(name) {
            var recipe;

            if (!_recipes.hasOwnProperty(name)) {
                throw new Error("The recipe " + name + " does not exist");
            }

            recipe = _recipes[name];
            if (recipe instanceof Meal) {
                recipe.toggleVegan();
                return "Command ToggleVegan executed successfully. New value: " +
                    recipe._isVegan.toString().toLowerCase() + "\n";
            } else {
                return "The command ToggleVegan is not applicable to recipe " + name + "\n";
            }
        }

        function printRestaurantMenu(name) {
            var restaurant;

            if (!_restaurants.hasOwnProperty(name)) {
                throw new Error("The restaurant " + name + " does not exist");
            }

            restaurant = _restaurants[name];
            return restaurant.printRestaurantMenu();
        }

        function addRecipeToRestaurant(restaurantName, recipeName) {
            var restaurant, recipe;

            if (!_restaurants.hasOwnProperty(restaurantName)) {
                throw new Error("The restaurant " + restaurantName + " does not exist");
            }
            if (!_recipes.hasOwnProperty(recipeName)) {
                throw new Error("The recipe " + recipeName + " does not exist");
            }

            restaurant = _restaurants[restaurantName];
            recipe = _recipes[recipeName];
            restaurant.addRecipe(recipe);
            return "Recipe " + recipeName + " successfully added to restaurant " + restaurantName + "\n";
        }

        function removeRecipeFromRestaurant(restaurantName, recipeName) {
            var restaurant, recipe;

            if (!_recipes.hasOwnProperty(recipeName)) {
                throw new Error("The recipe " + recipeName + " does not exist");
            }
            if (!_restaurants.hasOwnProperty(restaurantName)) {
                throw new Error("The restaurant " + restaurantName + " does not exist");
            }

            restaurant = _restaurants[restaurantName];
            recipe = _recipes[recipeName];
            restaurant.removeRecipe(recipe);
            return "Recipe " + recipeName + " successfully removed from restaurant " + restaurantName + "\n";
        }

        function executeCommand(commandLine) {
            var cmd, params, result;
            cmd = new Command(commandLine);
            params = cmd._params;

            switch (cmd._name) {
                case 'CreateRestaurant':
                    result = createRestaurant(params["name"], params["location"]);
                    break;
                case 'CreateDrink':
                    result = createDrink(params["name"], parseFloat(params["price"]), parseInt(params["calories"]),
                        parseInt(params["quantity"]), params["time"], parseBoolean(params["carbonated"]));
                    break;
                case 'CreateSalad':
                    result = createSalad(params["name"], parseFloat(params["price"]), parseInt(params["calories"]),
                        parseInt(params["quantity"]), params["time"], parseBoolean(params["pasta"]));
                    break;
                case "CreateMainCourse":
                    result = createMainCourse(params["name"], parseFloat(params["price"]), parseInt(params["calories"]),
                        parseInt(params["quantity"]), params["time"], parseBoolean(params["vegan"]), params["type"]);
                    break;
                case "CreateDessert":
                    result = createDessert(params["name"], parseFloat(params["price"]), parseInt(params["calories"]),
                        parseInt(params["quantity"]), params["time"], parseBoolean(params["vegan"]));
                    break;
                case "ToggleSugar":
                    result = toggleSugar(params["name"]);
                    break;
                case "ToggleVegan":
                    result = toggleVegan(params["name"]);
                    break;
                case "AddRecipeToRestaurant":
                    result = addRecipeToRestaurant(params["restaurant"], params["recipe"]);
                    break;
                case "RemoveRecipeFromRestaurant":
                    result = removeRecipeFromRestaurant(params["restaurant"], params["recipe"]);
                    break;
                case "PrintRestaurantMenu":
                    result = printRestaurantMenu(params["name"]);
                    break;
                default:
                    throw new Error('Invalid command name: ' + cmdName);
            }

            return result;
        }

        function parseBoolean(value) {
            switch (value) {
                case "yes":
                    return true;
                case "no":
                    return false;
                default:
                    throw new Error("Invalid boolean value: " + value);
            }
        }

        return {
            initialize: initialize,
            executeCommand: executeCommand
        };
    }());


    // Process the input commands and return the results
    var results = '';
    RestaurantEngine.initialize();
    commands.forEach(function (cmd) {
        if (cmd != "") {
            try {
                var cmdResult = RestaurantEngine.executeCommand(cmd);
                results += cmdResult;
            } catch (err) {
                results += err.message + "\n";
            }
        }
    });

    return results.trim();
}


