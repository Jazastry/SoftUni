<?php
    namespace HotelReservationSystem;
class Guest {
    private $firstName;
    private $lastName;
    private $iD;

    function __construct($firstName, $lastName, $iD)
    {
        $this->setFirstName($firstName);
        $this->setLastName($lastName);
        $this->setID($iD);
    }

    public function setID($iD)
    {
        if($iD < 99999999){
            throw new \Exception("ID number can't be les than 999999999 !");
        }
        else {
            $this->iD = $iD;
        }
    }
    public function getID()
    {
        return $this->iD;
    }
    public function setLastName($lastName)
    {
        if(ctype_alpha($lastName)){
            $this->lastName = $lastName;
        }
        else
        {
            throw new \Exception("Guest last name : $lastName can consist only".
                " from alphabetic characters.");
        }
    }
    public function getLastName()
    {
        return $this->lastName;
    }
    public function setFirstName($firstName)
    {
        if(ctype_alpha($firstName)){
            $this->firstName = $firstName;
        }
        else
        {
            throw new \Exception("Guest last name : $firstName can consist only".
                " from alphabetic characters.");
        }
    }
    public function getFirstName()
    {
        return $this->firstName;
    }

    function __toString(){
        return "Guest ID : " . $this->getID() . "\n"
            . "First Name : " . $this->getFirstName() . "\n"
            . "Last name : " . $this->getLastName() . "\n";
    }
} 