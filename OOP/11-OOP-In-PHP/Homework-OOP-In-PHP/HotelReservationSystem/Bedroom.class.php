<?php
/**
 * Created by PhpStorm.
 * User: Ale
 * Date: 10/20/14
 * Time: 10:52 AM
 */

namespace HotelReservationSystem;


class Bedroom extends Room {

    function __construct($roomNumber, $roomPrice){
        parent::__construct($bedCount = 2,
            $extras = array("TV","air-conditioner", "refrigerator", "mini-bar", "bathtub"),
            $hasBalcony = "yes",
            $hasRestRoom = "yes",
            $roomPrice,
            $roomNumber,
            $roomType = RoomTypes::GOLD);
    }

    function __toString(){
        return parent::__toString();
    }
}
// o	Bedroom – 2 beds, Gold room, with restroom and balcony,
//      extras – TV, air-conditioner, refrigerator, mini-bar, bathtub