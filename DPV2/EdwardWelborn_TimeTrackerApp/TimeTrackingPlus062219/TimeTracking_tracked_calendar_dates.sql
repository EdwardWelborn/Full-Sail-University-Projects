-- MySQL dump 10.13  Distrib 8.0.16, for macos10.14 (x86_64)
--
-- Host: localhost    Database: TimeTracking
-- ------------------------------------------------------
-- Server version	5.7.25

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
 SET NAMES utf8 ;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `tracked_calendar_dates`
--

DROP TABLE IF EXISTS `tracked_calendar_dates`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tracked_calendar_dates` (
  `calendar_date_id` int(11) NOT NULL AUTO_INCREMENT,
  `calendar_date` varchar(45) NOT NULL,
  PRIMARY KEY (`calendar_date_id`)
) ENGINE=InnoDB AUTO_INCREMENT=29 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tracked_calendar_dates`
--

LOCK TABLES `tracked_calendar_dates` WRITE;
/*!40000 ALTER TABLE `tracked_calendar_dates` DISABLE KEYS */;
INSERT INTO `tracked_calendar_dates` VALUES (1,'2019-06-03'),(2,'2019-06-04'),(3,'2019-06-05'),(4,'2019-06-06'),(5,'2019-06-07'),(6,'2019-06-08'),(7,'2019-06-09'),(8,'2019-06-10'),(9,'2019-06-11'),(10,'2019-06-12'),(11,'2019-06-13'),(12,'2019-06-14'),(13,'2019-06-15'),(14,'2019-06-16'),(15,'2019-06-17'),(16,'2019-06-18'),(17,'2019-06-19'),(18,'2019-06-20'),(19,'2019-06-21'),(20,'2019-06-22'),(21,'2019-06-23'),(22,'2019-06-24'),(23,'2019-06-25'),(24,'2019-06-26'),(25,'2019-06-27'),(26,'2019-06-28'),(27,'2019-06-29'),(28,'2019-06-30');
/*!40000 ALTER TABLE `tracked_calendar_dates` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-06-22 12:48:22
