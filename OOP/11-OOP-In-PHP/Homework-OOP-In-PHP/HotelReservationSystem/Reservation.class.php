<?php
/**
 * Created by PhpStorm.
 * User: Ale
 * Date: 10/19/14
 * Time: 4:39 PM
 */
namespace HotelReservationSystem;

include_once('Guest.class.php');

class Reservation {
    private $startDate;
    private $endDate;
    private $guest;

    function __construct($startDate, $endDate, $guest) {
        $this->setStartDate($startDate);
        $this->setEndDate($endDate);
        $this->setGuest($guest);
    }

    public function setGuest($guest)
    {
        if($guest != null){
            $this->guest = $guest;
        }
        else
        {
            throw new \Exception("Guest variable : $guest can't be null !");
        }
    }

    public function getGuest()
    {
        return $this->guest;
    }

    public function setEndDate($endDate)
    {
        $dateNow = date('d-m-Y');
        if($endDate > $dateNow){
            $transStr = strtotime($endDate);
            $this->endDate = date('d-m-Y', $transStr);
        }
        else
        {
            throw new \Exception("Start date of Reservation can't be before today !");
        }
        $transStr = strtotime($endDate);
        $this->endDate = date('d-m-Y', $transStr);
    }

    public function getEndDate()
    {
        return $this->endDate;
    }

    public function setStartDate($startDate)
    {
        $dateNow = date('d-m-Y');
        if($startDate > $dateNow){
            $transStr = strtotime($startDate);
            $this->startDate = date('d-m-Y', $transStr);
        }
        else
        {
            throw new \Exception("Start date of Reservation can't be before today !");
        }
    }

    public function getStartDate()
    {
        return $this->startDate;
    }

    function __toString()
    {
        return "\nReservation :\n"
            . $this->getGuest() .
            "Start date : " . $this->getStartDate() . "\n" .
            "End date : " . $this->getEndDate() . "\n";
    }
}
//    $date = new DateTime();
//    $date->setDate(2014,02,03);
//    echo $date->format('d-m-Y');