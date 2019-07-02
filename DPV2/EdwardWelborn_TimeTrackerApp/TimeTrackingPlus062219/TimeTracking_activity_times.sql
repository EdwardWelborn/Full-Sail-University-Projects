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
-- Table structure for table `activity_times`
--

DROP TABLE IF EXISTS `activity_times`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `activity_times` (
  `activity_time_id` int(11) NOT NULL AUTO_INCREMENT,
  `time_spent_on_activity` double NOT NULL,
  PRIMARY KEY (`activity_time_id`)
) ENGINE=InnoDB AUTO_INCREMENT=102 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `activity_times`
--

LOCK TABLES `activity_times` WRITE;
/*!40000 ALTER TABLE `activity_times` DISABLE KEYS */;
INSERT INTO `activity_times` VALUES (1,24),(2,23.75),(3,23.5),(4,23.25),(5,23),(6,22.75),(7,22.5),(8,22.25),(9,22),(10,21.75),(11,22.5),(12,22.25),(13,22),(14,21.75),(15,21.5),(16,21.25),(17,21),(18,20.75),(19,20.5),(20,20.25),(21,20),(22,19.75),(23,19.5),(24,19.25),(25,19),(26,18.75),(27,18.5),(28,18.25),(29,18),(30,17.75),(31,17.5),(32,17.25),(33,17),(34,16.75),(35,16.5),(36,16.25),(37,16),(38,15.75),(39,15.5),(40,15.25),(41,15),(42,14.75),(43,14.5),(44,14.25),(45,14),(46,13.75),(47,13.5),(48,13.25),(49,13),(50,12.75),(51,12.5),(52,12.25),(53,12),(54,11.75),(55,11.5),(56,11.25),(57,11),(58,10.75),(59,10.5),(60,10.25),(61,10),(62,9.75),(63,9.5),(64,9.25),(65,9),(66,8.75),(67,8.5),(68,8.25),(69,8),(70,7.75),(71,7.5),(72,7.25),(73,7),(74,6.75),(75,6.5),(76,6.25),(77,6),(78,5.75),(79,5.5),(80,5.25),(81,5),(82,4.75),(83,4.5),(84,4.25),(85,4),(86,3.75),(87,3.5),(88,3.25),(89,3),(90,2.75),(91,2.5),(92,2.25),(93,2),(94,1.75),(95,1.5),(96,1.25),(97,1),(98,0.75),(99,0.5),(100,0.25),(101,0);
/*!40000 ALTER TABLE `activity_times` ENABLE KEYS */;
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
