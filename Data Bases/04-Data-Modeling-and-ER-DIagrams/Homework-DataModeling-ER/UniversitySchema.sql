-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema UniversitySchema
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema UniversitySchema
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `UniversitySchema` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci ;
USE `UniversitySchema` ;

-- -----------------------------------------------------
-- Table `UniversitySchema`.`Departments`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `UniversitySchema`.`Departments` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE INDEX `Id_UNIQUE` (`Id` ASC))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `UniversitySchema`.`Facilities`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `UniversitySchema`.`Facilities` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE INDEX `Id_UNIQUE` (`Id` ASC))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `UniversitySchema`.`Courses`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `UniversitySchema`.`Courses` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE INDEX `Id_UNIQUE` (`Id` ASC))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `UniversitySchema`.`Professors`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `UniversitySchema`.`Professors` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`Id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `UniversitySchema`.`ProfessorsCourses`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `UniversitySchema`.`ProfessorsCourses` (
  `ProfessorId` INT NOT NULL,
  `CourseId` INT NOT NULL,
  INDEX `fk_ProfessorsCourses_Professors_idx` (`ProfessorId` ASC),
  INDEX `fk_ProfessorsCourses_Courses1_idx` (`CourseId` ASC),
  CONSTRAINT `fk_ProfessorsCourses_Professors`
    FOREIGN KEY (`ProfessorId`)
    REFERENCES `UniversitySchema`.`Professors` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_ProfessorsCourses_Courses1`
    FOREIGN KEY (`CourseId`)
    REFERENCES `UniversitySchema`.`Courses` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `UniversitySchema`.`Titles`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `UniversitySchema`.`Titles` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`Id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `UniversitySchema`.`ProfessorsTitles`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `UniversitySchema`.`ProfessorsTitles` (
  `ProfessorId` INT NOT NULL,
  `TitleId` INT NOT NULL,
  INDEX `fk_ProfessorsTitles_Titles1_idx` (`TitleId` ASC),
  INDEX `fk_ProfessorsTitles_Professors1_idx` (`ProfessorId` ASC),
  CONSTRAINT `fk_ProfessorsTitles_Titles1`
    FOREIGN KEY (`TitleId`)
    REFERENCES `UniversitySchema`.`Titles` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_ProfessorsTitles_Professors1`
    FOREIGN KEY (`ProfessorId`)
    REFERENCES `UniversitySchema`.`Professors` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `UniversitySchema`.`DepartmentProfessors`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `UniversitySchema`.`DepartmentProfessors` (
  `DepartmentId` INT NOT NULL,
  `ProfessorId` INT NOT NULL,
  INDEX `fk_DepartmentProfessors_Professors1_idx` (`ProfessorId` ASC),
  INDEX `fk_DepartmentProfessors_Departments1_idx` (`DepartmentId` ASC),
  CONSTRAINT `fk_DepartmentProfessors_Professors1`
    FOREIGN KEY (`ProfessorId`)
    REFERENCES `UniversitySchema`.`Professors` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_DepartmentProfessors_Departments1`
    FOREIGN KEY (`DepartmentId`)
    REFERENCES `UniversitySchema`.`Departments` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `UniversitySchema`.`DepartmentCourses`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `UniversitySchema`.`DepartmentCourses` (
  `DepartmentId` INT NOT NULL,
  `CourseId` INT NOT NULL,
  INDEX `fk_DepartmentCourses_Courses1_idx` (`CourseId` ASC),
  INDEX `fk_DepartmentCourses_Departments1_idx` (`DepartmentId` ASC),
  CONSTRAINT `fk_DepartmentCourses_Courses1`
    FOREIGN KEY (`CourseId`)
    REFERENCES `UniversitySchema`.`Courses` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_DepartmentCourses_Departments1`
    FOREIGN KEY (`DepartmentId`)
    REFERENCES `UniversitySchema`.`Departments` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `UniversitySchema`.`FacilitiesDepartments`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `UniversitySchema`.`FacilitiesDepartments` (
  `FacilitieId` INT NOT NULL,
  `DepartmentId` INT NOT NULL,
  INDEX `fk_FacilitiesDepartments_Departments1_idx` (`DepartmentId` ASC),
  INDEX `fk_FacilitiesDepartments_Facilities1_idx` (`FacilitieId` ASC),
  CONSTRAINT `fk_FacilitiesDepartments_Departments1`
    FOREIGN KEY (`DepartmentId`)
    REFERENCES `UniversitySchema`.`Departments` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_FacilitiesDepartments_Facilities1`
    FOREIGN KEY (`FacilitieId`)
    REFERENCES `UniversitySchema`.`Facilities` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `UniversitySchema`.`Faculties`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `UniversitySchema`.`Faculties` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(100) NOT NULL,
  PRIMARY KEY (`Id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `UniversitySchema`.`Students`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `UniversitySchema`.`Students` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(50) NOT NULL,
  `FacultyId` INT NOT NULL,
  PRIMARY KEY (`Id`),
  INDEX `fk_Students_Faculties1_idx` (`FacultyId` ASC),
  CONSTRAINT `fk_Students_Faculties1`
    FOREIGN KEY (`FacultyId`)
    REFERENCES `UniversitySchema`.`Faculties` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `UniversitySchema`.`StudentCourses`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `UniversitySchema`.`StudentCourses` (
  `StudentId` INT NOT NULL,
  `CourseId` INT NOT NULL,
  INDEX `fk_StudentCourses_Students1_idx` (`StudentId` ASC),
  INDEX `fk_StudentCourses_Courses1_idx` (`CourseId` ASC),
  CONSTRAINT `fk_StudentCourses_Students1`
    FOREIGN KEY (`StudentId`)
    REFERENCES `UniversitySchema`.`Students` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_StudentCourses_Courses1`
    FOREIGN KEY (`CourseId`)
    REFERENCES `UniversitySchema`.`Courses` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
