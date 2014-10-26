<?php
/**
 * Created by PhpStorm.
 * User: Ale
 * Date: 10/20/14
 * Time: 2:22 PM
 */

namespace HotelReservationSystem;

use HotelReservationSystem\SingleRoom;
use HotelReservationSystem\Guest;
use HotelReservationSystem\Reservation;

include_once('Reservation.class.php');
include_once('Guest.class.php');
include_once('Reservation.class.php');

class BookingManager {
    public static function bookRoom($room, $reservation, $guest){

        $result = array("successfully", "unsuccessfully");
        $currentResult = $result[0];
        $roomNumber = $room->getRoomNumber();
        $guestFirstName = $guest->getFirstName();
        $guestLastName = $guest->getLastName();
        $reservationStartDate = $reservation->getStartDate();
        $reservationEndDate = $reservation->getEndDate();

        try{
            $room->addReservation($reservation);
        }
        catch (\EReservationException $reservationException){
            $currentResult = $result[1];
        }
        catch (\Exception $e){
            echo($e);
        }

        $outString = "Room <strong>$roomNumber</strong>"
            ." $currentResult booked for <strong>$guestFirstName $guestLastName</strong>"
            ." from <time>$reservationStartDate</time> to <time>$reservationEndDate</time>!";
        echo($outString);
    }
} 