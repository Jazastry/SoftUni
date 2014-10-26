<?php
/**
 * Created by PhpStorm.
 * User: Ale
 * Date: 10/20/14
 * Time: 4:15 PM
 */

namespace HotelReservationSystem;


class Apartment extends Room {
    function __construct($roomNumber, $roomPrice){
        parent::__construct($bedCount = 4,
            $extras = array("TV","air-conditioner", "refrigerator",
                "kitchen box", "mini-bar", "bathtub", "free Wi-fi"),
            $hasBalcony = "yes",
            $hasRestRoom = "yes",
            $roomPrice,
            $roomNumber,
            $roomType = RoomTypes::DIAMOND);
    }

    function __toString(){
        return parent::__toString();
    }
}
 // o	Apartment – 4 beds, Diamond room, with restroom and balcony, extras – TV,
//      air-conditioner, refrigerator, kitchen box, mini-bar, bathtub, free Wi-fi