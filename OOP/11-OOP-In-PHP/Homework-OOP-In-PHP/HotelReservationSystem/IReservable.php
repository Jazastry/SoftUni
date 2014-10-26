<?php
/**
 * Created by PhpStorm.
 * User: Ale
 * Date: 10/19/14
 * Time: 4:53 PM
 */
    namespace HotelReservationSystem;

interface IReservable {
    function  addReservation($reservation);
    function removeReservation($reservation);
//•	iReservable – holds methods addReservation($reservation) and removeReservation($reservation)
} 