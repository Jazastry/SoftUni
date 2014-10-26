<?php

    function __autoload($className) {
        include_once("./" . $className . ".class.php");
    }

    use HotelReservationSystem\Apartment;
    use HotelReservationSystem\Bedroom;
    use HotelReservationSystem\SingleRoom;
    use HotelReservationSystem\Guest;
    use HotelReservationSystem\Reservation;
    use HotelReservationSystem\BookingManager;

    include_once('SingleRoom.class.php');
    include_once('Bedroom.class.php');
    include_once('Apartment.class.php');
    include_once('Guest.class.php');
    include_once('Reservation.class.php');
    include_once('BookingManager.class.php');

    $room1 = new SingleRoom(101,99);
    $room2 = new SingleRoom(102,99);
    $room3 = new Bedroom(103,180);
    $room4 = new Bedroom(104,180);
    $room5 = new Apartment(105,300);
    $room6 = new Apartment(106,300);

    $rooms = array($room1, $room2, $room3, $room4, $room5, $room6);
    // ::::::::::::::::: FILTER :::::::::::
    $roomsFilterByPrice = array_filter($rooms, function($room) {
        if($room->getPrice() <= 250){
            return $room;
        }
    });

    echo("Rooms FIltered by price under 250\n--------------------------\n");
    foreach($roomsFilterByPrice as $room) {
        echo($room);
    }

    // :::::::::::::::: FILTER :::::::::
    $roomsFilterByBalcony = array_filter($rooms, function($room) {
        if(strcmp($room->getHasBalcony(), "yes") == 0){
            return $room;
        }
    });

    echo("\nRooms FIltered by have Balcony \n--------------------------\n");
    foreach($roomsFilterByBalcony as $room) {
        echo($room);
    }

    // :::::::::::::::: FILTER :::::::::
    $roomsFilterByBathTub = array_filter($rooms, function($room) {
        $numbers = "";
       foreach($room->getExtras() as $value){
           /**
            * strcmp(string1, string2) return 0 if equals
            */
           if(strcmp($value, "bathtub") == 0){
               $numbers = $numbers. ", " . $room->getRoomNumber();
           }
       }
       return $numbers;
    });

    echo("\nRoom number filtered by have bathtub \n--------------------------\n");
    foreach($roomsFilterByBathTub as $room) {
        echo($room->getRoomNumber()."\n");
    }

    $ivan = new Guest("Ivan", "Ivanov", 123456789);
    $blagoi = new Guest("Blagoi", "Blagoev", 234567890);
    $reservationIvan = new Reservation("22.10.2014","24.10.2014",$ivan);
    $reservationBlagoi = new Reservation("25.10.2014","27.10.2014",$blagoi);
    $room1->addReservation($reservationIvan);
    $room1->addReservation($reservationBlagoi);

    echo("\nExample with guest and add reservation \n--------------------------\n");
    echo($room1 . "\n");

    $room1->removeReservation($reservationBlagoi);

    echo("\nExample with removing reservation \n--------------------------\n");
    echo($room1);

    echo("\nExample with booking Manager \n--------------------------\n");
    BookingManager::bookRoom($room1,$reservationBlagoi,$blagoi);


