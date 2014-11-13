function processEstatesAgencyCommands(commands) {

    'use strict';

    Object.prototype.extends = function (parent) {
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

    var extensions = (function(){

        var MAX_FLOOR_ROOM = 10;
        var MIN_FLOOR_ROOM = 1;
        var MAX_HIGHT_WIDTH = 500;
        var MIN_HIGHT_WIDTH = 1; 

        function string(stringIn) {
            if (stringIn) {
                return stringIn;
            } else {
                throw new RangeError('Invalid String!' + string);
            }
        }

        function area(areaIn) {
            if ((typeof(areaIn) === 'number') &&
                (areaIn > 0) && (areaIn <= 10000)) {
                return areaIn;
            } else {
                throw new RangeError('Area have to be valid Numbrer'+
                    ' in range 1 - 10000 ! Entered : ' + areaIn);
            }
        }

        function boolToString(boolValue) {
            if (boolValue === true){
                return 'Yes';
            } else {
                return 'No';
            }
        }

        function floorsRooms(number){
            if((number < MIN_FLOOR_ROOM) || 
                (number > MAX_FLOOR_ROOM)){
                throw new RangeError('Floors and Rooms number have'+
                    ' to be valid number in range ' + MIN_FLOOR_ROOM + ' to ' + MAX_FLOOR_ROOM + ' !');
            } else {
                return number;
            }
        }

        function widthHeight(number) {
            if((number < MIN_HIGHT_WIDTH) || 
                (number > MAX_HIGHT_WIDTH)){
                throw new RangeError('Floors and Rooms number have'+
                    ' to be valid number in range ' + MIN_HIGHT_WIDTH +
                     ' to ' + MAX_HIGHT_WIDTH + ' !');
            } else {
                return number;
            }
        }

        function price(number) {
            var isInt = ((number%1) === 0);
            if ((isInt) && number > 0) {
                return number;
            } else {
                throw new RangeError('Price have to be positive integer number !');
            }
        }

        function intCheck(number) {
            var isInt = ((number%1) === 0);
            if (isInt) {
                return number;
            } else {
                throw new RangeError('Price have to be integer number !');
            }
        }

        return {
            string: string,
            area: area,
            floorsRooms: floorsRooms,
            boolToString: boolToString,
            widthHeight: widthHeight,
            price: price,
            intCheck: intCheck
        };
    }());

    var Estate = (function() {
        function Estate(name, area, location, isFurnished) {
            this._name = extensions.string(name);
            this._area = extensions.area(area);
            this._location = extensions.string(location);
            this._isFurnished = extensions.boolToString(isFurnished);
        } 

        Estate.prototype.getName = function() {
            return this._name;
        };

        Estate.prototype.getLocation = function() {
            return this._location;
        };

        Estate.prototype.toString = function() {
            return ' Name = '+ this._name +
            ', Area = '+ this._area +
            ', Location = '+ this._location +
            ', Furnitured = ' + this._isFurnished;
        };

        return Estate;
    }());

    var BuildingEstate = (function() {
        function BuildingEstate(name, area, location, isFurnitured, numberOfRooms, hasElevator) {
            Estate.apply(this, arguments);
            this._numberOfRooms = extensions.floorsRooms(numberOfRooms);
            this._hasElevator = extensions.boolToString(hasElevator);
        }

        BuildingEstate.extends(Estate);

        BuildingEstate.prototype.toString = function() {
            return  Estate.prototype.toString.call(this) +
            ', Rooms: ' + this._numberOfRooms +
            ', Elevator: ' + this._hasElevator;
        };

        return BuildingEstate;
    }());

    var Apartment = (function() {
        function Apartment(name, area, location, isFurnitured, numberOfRooms, hasElevator) {
            BuildingEstate.apply(this, arguments);
            this._type = 'Apartment';
        } 

        Apartment.extends(BuildingEstate);

        Apartment.prototype.toString = function() {
            return this._type + ':' +
            BuildingEstate.prototype.toString.call(this);
        };

        return Apartment;
    }());


    var Office = (function() {
        function Office(name, area, location, isFurnitured, numberOfRooms, hasElevator) {
            BuildingEstate.apply(this, arguments);
            this._type = 'Office';
        } 

        Office.extends(BuildingEstate);

        Office.prototype.toString = function() {
            return this._type + ':' +
            BuildingEstate.prototype.toString.call(this);
        };

        return Office;
    }());

    var House = (function() {
        function House(name, area, location, isFurnitured, numberOfFloors) {
            Estate.apply(this, arguments);
            this._numberOfFloors = extensions.floorsRooms(numberOfFloors);
            this._type = 'House';
        }

        House.extends(Estate);

        House.prototype.toString = function() {
            return this._type + ':' +
            Estate.prototype.toString.call(this) +
            ', Floors: ' + this._numberOfFloors;
        };

        return House;        
    }());

    var Garage = (function() {
        function Garage(name, area, location, isFurnitured, width, height) {
            Estate.apply(this, arguments);
            this._width = extensions.widthHeight(width);
            this._height = extensions.widthHeight(height);
            this._type = 'Garage';
        }

        Garage.extends(Estate);

        Garage.prototype.toString = function() {
            return this._type + ':' +
            Estate.prototype.toString.call(this) +
            ', Width: ' + this._width +
            ', Height: ' + this._height;
        };

        return Garage;        
    }());

    var Offer = (function() {
        function Offer(estate, price) {
            this._estate = estate;
            this._price = extensions.price(price);
        } 

        Offer.prototype.getEstate = function() {
            return this._estate;
        };

        Offer.prototype.getPrice = function() {
            return this._price;
        };

        Offer.prototype.toString = function() {
            return ' Estate = ' + this._estate.getName() +
            ', Location = ' + this._estate.getLocation() +
            ', Price = ' + this._price;
        };

        return Offer;
    }());


    var RentOffer = (function() {
        function RentOffer(estate, price) {
            Offer.apply(this, arguments);
            this._type = 'Rent';
        } 

        RentOffer.extends(Offer);

        RentOffer.prototype.toString = function() {
            return this._type + ':' +
            Offer.prototype.toString.call(this);
        };

        return RentOffer;         
    }());


    var SaleOffer = (function() {
        function SaleOffer(estate, price) {
            Offer.apply(this, arguments);
            this._type = 'Sale';
        } 

        SaleOffer.extends(Offer);

        SaleOffer.prototype.toString = function() {
            return this._type + ':' +
            Offer.prototype.toString.call(this);
        };

        return SaleOffer; 
    }());


    var EstatesEngine = (function() {
        var _estates;
        var _uniqueEstateNames;
        var _offers;

        function initialize() {
            _estates = [];
            _uniqueEstateNames = {};
            _offers = [];
        }

        function executeCommand(command) {
            var cmdParts = command.split(' ');
            var cmdName = cmdParts[0];
            var cmdArgs = cmdParts.splice(1);
            switch (cmdName) {
            case 'create':
                return executeCreateCommand(cmdArgs);
            case 'status':
                return executeStatusCommand();
            case 'find-sales-by-location':
                return executeFindSalesByLocationCommand(cmdArgs[0]);
            case 'find-rents-by-location':
                return executeFindRentsByLocationCommand(cmdArgs[0]); 
            case 'find-rents-by-price':
                return executeFindRentsByPrice(cmdArgs[0], cmdArgs[1]);
            default:
                throw new Error('Unknown command: ' + cmdName);
            }
        }

        function executeCreateCommand(cmdArgs) {
            var objType = cmdArgs[0];
            switch (objType) {
            case 'Apartment':
                var apartment = new Apartment(cmdArgs[1], Number(cmdArgs[2]), cmdArgs[3],
                    parseBoolean(cmdArgs[4]), Number(cmdArgs[5]), parseBoolean(cmdArgs[6]));
                addEstate(apartment);
                break;
            case 'Office':
                var office = new Office(cmdArgs[1], Number(cmdArgs[2]), cmdArgs[3],
                    parseBoolean(cmdArgs[4]), Number(cmdArgs[5]), parseBoolean(cmdArgs[6]));
                addEstate(office);
                break;
            case 'House':
                var house = new House(cmdArgs[1], Number(cmdArgs[2]), cmdArgs[3],
                    parseBoolean(cmdArgs[4]), Number(cmdArgs[5]));
                addEstate(house);
                break;
            case 'Garage':
                var garage = new Garage(cmdArgs[1], Number(cmdArgs[2]), cmdArgs[3],
                    parseBoolean(cmdArgs[4]), Number(cmdArgs[5]), Number(cmdArgs[6]));
                addEstate(garage);
                break;
            case 'RentOffer':
                var estate = findEstateByName(cmdArgs[1]);
                var rentOffer = new RentOffer(estate, Number(cmdArgs[2]));
                addOffer(rentOffer);
                break;
            case 'SaleOffer':
                estate = findEstateByName(cmdArgs[1]);
                var saleOffer = new SaleOffer(estate, Number(cmdArgs[2]));
                addOffer(saleOffer);
                break;
            default:
                throw new Error('Unknown object to create: ' + objType);
            }
            return objType + ' created.';
        }

        function parseBoolean(value) {
            switch (value) {
            case "true":
                return true;
            case "false":
                return false;
            default:
                throw new Error("Invalid boolean value: " + value);
            }
        }

        function findEstateByName(estateName) {
            for (var i = 0; i < _estates.length; i++) {
                if (_estates[i].getName() == estateName) {
                    return _estates[i];
                }
            }
            return undefined;
        }

        function addEstate(estate) {
            if (_uniqueEstateNames[estate.getName()]) {
                throw new Error('Duplicated estate name: ' + estate.getName());
            }
            _uniqueEstateNames[estate.getName()] = true;
            _estates.push(estate);
        }

        function addOffer(offer) {
            _offers.push(offer);
        }

        function executeStatusCommand() {
            var result = '', i;
            if (_estates.length > 0) {
                result += 'Estates:\n';
                for (i = 0; i < _estates.length; i++) {
                    result += "  " + _estates[i].toString() + '\n';
                }
            } else {
                result += 'No estates\n';
            }

            if (_offers.length > 0) {
                result += 'Offers:\n';
                for (i = 0; i < _offers.length; i++) {
                    result += "  " + _offers[i].toString() + '\n';
                }
            } else {
                result += 'No offers\n';
            }

            return result.trim();
        }

        function executeFindSalesByLocationCommand(location) {
            if (!location) {
                throw new Error("Location cannot be empty.");
            }
            var selectedOffers = _offers.filter(function(offer) {
                return offer.getEstate().getLocation() === location &&
                    offer instanceof SaleOffer;
            });
            selectedOffers.sort(function(a, b) {
                return a.getEstate().getName().localeCompare(b.getEstate().getName());
            });
            return formatQueryResults(selectedOffers);
        }

        function executeFindRentsByLocationCommand(location) {
            if (!location) {
                throw new Error("Location cannot be empty.");
            }
            var selectedOffers = _offers.filter(function(offer) {
                return offer.getEstate().getLocation() === location &&
                    offer instanceof RentOffer;
            });
            selectedOffers.sort(function(a, b) {
                return a.getEstate().getName().localeCompare(b.getEstate().getName());
            });
            return formatQueryResults(selectedOffers);
        }

        function executeFindRentsByPrice(minPrice, maxPrice) {
            var min = extensions.intCheck(minPrice);
            var max = extensions.intCheck(maxPrice);
            var selectedOffers = _offers.filter(function(offer) {
                var curentPrice = offer.getPrice();
                return  (curentPrice >= min) && (curentPrice <= max) &&
                        offer instanceof RentOffer;
            });

            selectedOffers.sort(function(a, b) {
                if ((a.getPrice() - b.getPrice()) === 0) {
                    return a.getEstate().getName().localeCompare(b.getEstate().getName());
                }
                return (a.getPrice() - b.getPrice());                
            });
            return formatQueryResults(selectedOffers);
        }

        function formatQueryResults(offers) {
            var result = '';
            if (offers.length === 0) {
                result += 'No Results\n';
            } else {
                result += 'Query Results:\n';
                for (var i = 0; i < offers.length; i++) {
                    var offer = offers[i];
                    result += '  [Estate: ' + offer.getEstate().getName() +
                        ', Location: ' + offer.getEstate().getLocation() +
                        ', Price: ' + offer.getPrice() + ']\n';
                }
            }
            return result.trim();
        }

        return {
            initialize: initialize,
            executeCommand: executeCommand
        };
    }());


    // Process the input commands and return the results
    var results = '';
    EstatesEngine.initialize();
    commands.forEach(function(cmd) {
        if (cmd !== '') {
            try {
                var cmdResult = EstatesEngine.executeCommand(cmd);
                results += cmdResult + '\n';
            } catch (err) {
                //console.log(err);
                results += 'Invalid command.\n';
            }
        }
    });
    return results.trim();

}
