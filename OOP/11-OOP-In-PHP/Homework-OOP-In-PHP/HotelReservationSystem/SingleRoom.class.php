<?php
/**
 * Created by PhpStorm.
 * User: Ale
 * Date: 10/19/14
 * Time: 9:56 PM
 */
namespace HotelReservationSystem;

include_once('Room.class.php');
include_once('RoomTypes.class.php');

class SingleRoom extends Room {
    function __construct($roomNumber, $roomPrice){
        parent::__construct($bedCount = 1,
            $extras = array("TV","air-conditioner"),
            $hasBalcony = "no",
            $hasRestRoom = "yes",
            $roomPrice,
            $roomNumber,
            $roomType = RoomTypes::STANDARD);
    }

    function __toString(){
        return parent::__toString();
    }
} 