<?php

class EReservationException extends Exception {
    public function __construct($reservationNext, $reservationPrevious){
        parent::__construct("\n$reservationNext" .
            "\n OVERLAP DATE OF \n\n$reservationPrevious", 01);
    }
} 