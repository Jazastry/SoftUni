<?php
/**
 * Created by PhpStorm.
 * User: Ale
 * Date: 10/19/14
 * Time: 4:48 PM
 */

namespace HotelReservationSystem;

include_once('IReservable.php');
include_once('Guest.class.php');
include_once('EReservationException.class.php');

abstract class Room implements IReservable {

    private $roomType;
    private $hasRestroom;
    private $hasBalcony;
    private $bedCount;
    private $roomNumber;
    private $extras;
    private $price;
    private $reservations = array();

    protected function __construct($bedCount, $extras, $hasBalcony, $hasRestRoom, $price, $roomNumber, $roomType)
    {
        $this->setBedCount($bedCount);
        $this->setExtras($extras);
        $this->setHasBalcony($hasBalcony);
        $this->setHasRestRoom($hasRestRoom);
        $this->setPrice($price);
        $this->roomNumber = $roomNumber;
        $this->roomType = $roomType;
    }

    /**
     * @param mixed $bedCount
     */
    public function setBedCount($bedCount)
    {
        $this->bedCount = $bedCount;
    }

    /**
     * @return mixed
     */
    public function getBedCount()
    {
        return $this->bedCount;
    }

    /**
     * @param mixed $extras
     */
    public function setExtras($extras)
    {
        $this->extras = $extras;
    }

    /**
     * @return mixed
     */
    public function getExtras()
    {
        return $this->extras;
    }

    /**
     * @param mixed $hasBalcony
     */
    public function setHasBalcony($hasBalcony)
    {
        $this->hasBalcony = $hasBalcony;
    }

    /**
     * @return mixed
     */
    public function getHasBalcony()
    {
        return $this->hasBalcony;
    }

    /**
     * @param mixed $hasRestroom
     */
    public function setHasRestRoom($hasRestroom)
    {
        $this->hasRestroom = $hasRestroom;
    }

    /**
     * @return mixed
     */
    public function getHasRestroom()
    {
        return $this->hasRestroom;
    }

    /**
     * @param mixed $price
     */
    public function setPrice($price)
    {
        $this->price = $price;
    }

    /**
     * @return mixed
     */
    public function getPrice()
    {
        return $this->price;
    }

    /**
     * @param mixed $roomNumber
     */
    public function setRoomNumber($roomNumber)
    {
        $this->roomNumber = $roomNumber;
    }

    /**
     * @return mixed
     */
    public function getRoomNumber()
    {
        return $this->roomNumber;
    }

    /**
     * @param mixed $roomType
     */
    public function setRoomType($roomType)
    {
        $this->roomType = $roomType;
    }

    /**
     * @return mixed
     */
    public function getRoomType()
    {
        return $this->roomType;
    }

//    private function setReservations($reservation)
//    {
//        array_push($this->reservations, $reservation);
//    }
//
//    public function getReservations()
//    {
//        return $this->reservations;
//    }

    function  addReservation($reservation)
    {
        $reservationInStartDate = $reservation->getStartDate();

        for($i = 0; $i < sizeof($this->reservations); $i = $i + 1){
            $thisReservationEndDate = $this->reservations[$i]->getEndDate();
            if($thisReservationEndDate > $reservationInStartDate){
                throw new \EReservationException($reservation, $this->reservations[$i]);
                break;
            }
        }
        array_push($this->reservations, $reservation);
    }

    function removeReservation($resertvation)
    {
        $reservationInStartDate = $resertvation->getStartDate();

        for($i = 0; $i < sizeof($this->reservations); $i = $i + 1){
            $thisReservationStartDate = $this->reservations[$i]->getStartDate();
            if($thisReservationStartDate == $reservationInStartDate){
                unset($this->reservations[$i]);
                $this->reservations = array_values($this->reservations);
            }
        }
    }

    function __toString(){
        $extras = implode(",",$this->getExtras());
        return("Room number : " . $this->getRoomNumber() . "\n"
            . "Room type : " . $this->getRoomType() . "\n"
            . "Has restroom : " . $this->getHasRestRoom() . "\n"
            . "Hes balcony : " . $this->getHasBalcony() . "\n"
            . "Bed Count : " . $this->getBedCount() . "\n"
            . "Extras : " . $extras . "\n"
            . "Price : " . $this->getPrice() . "\n"
            . "\nReservations List :\n" . implode("", $this->reservations));
    }
}
// o	Single room – 1 bed, Standard room, with restroom, no balcony, extras – TV, air-conditioner

// : room type (can be Standard, Gold or Diamond), has restroom, has balcony,
//    bed count, room number, extras (e.g. TV, air-conditioner, refrigerator, etc.) and price