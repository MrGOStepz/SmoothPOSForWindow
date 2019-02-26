CREATE DATABASE  IF NOT EXISTS `smoothdb` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `smoothdb`;
-- MySQL dump 10.13  Distrib 8.0.13, for Win64 (x86_64)
--
-- Host: localhost    Database: smoothdb
-- ------------------------------------------------------
-- Server version	8.0.13

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
-- Table structure for table `tb_cook_status`
--

DROP TABLE IF EXISTS `tb_cook_status`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tb_cook_status` (
  `cook_status_id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`cook_status_id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_cook_status`
--

LOCK TABLES `tb_cook_status` WRITE;
/*!40000 ALTER TABLE `tb_cook_status` DISABLE KEYS */;
INSERT INTO `tb_cook_status` VALUES (1,'Cooking'),(2,'Done'),(3,'Break');
/*!40000 ALTER TABLE `tb_cook_status` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tb_customer`
--

DROP TABLE IF EXISTS `tb_customer`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tb_customer` (
  `customer_id` int(11) NOT NULL AUTO_INCREMENT,
  `first_name` varchar(45) NOT NULL,
  `last_name` varchar(45) DEFAULT NULL,
  `phone` varchar(45) NOT NULL,
  `address` mediumtext,
  `total_order` int(11) DEFAULT '0',
  `last_active` date DEFAULT NULL,
  `dob` datetime DEFAULT NULL,
  `card` longtext,
  `email` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`customer_id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_customer`
--

LOCK TABLES `tb_customer` WRITE;
/*!40000 ALTER TABLE `tb_customer` DISABLE KEYS */;
INSERT INTO `tb_customer` VALUES (1,'NONE','NONE','NONE','NONE',0,NULL,NULL,NULL,NULL);
/*!40000 ALTER TABLE `tb_customer` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tb_delete_popup`
--

DROP TABLE IF EXISTS `tb_delete_popup`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tb_delete_popup` (
  `pop_up_id` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_delete_popup`
--

LOCK TABLES `tb_delete_popup` WRITE;
/*!40000 ALTER TABLE `tb_delete_popup` DISABLE KEYS */;
/*!40000 ALTER TABLE `tb_delete_popup` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tb_delete_product`
--

DROP TABLE IF EXISTS `tb_delete_product`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tb_delete_product` (
  `product_id` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_delete_product`
--

LOCK TABLES `tb_delete_product` WRITE;
/*!40000 ALTER TABLE `tb_delete_product` DISABLE KEYS */;
/*!40000 ALTER TABLE `tb_delete_product` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tb_employee`
--

DROP TABLE IF EXISTS `tb_employee`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tb_employee` (
  `employee_id` int(11) NOT NULL AUTO_INCREMENT,
  `first_name` varchar(45) NOT NULL,
  `last_name` varchar(45) DEFAULT NULL,
  `phone` varchar(45) DEFAULT NULL,
  `email` varchar(45) DEFAULT NULL,
  `level_id` int(11) DEFAULT '3',
  `status_id` int(11) DEFAULT '2',
  `password` longtext NOT NULL,
  `nick_name` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`employee_id`),
  KEY `FK_level_employee` (`level_id`),
  KEY `FK_status_employee` (`status_id`),
  CONSTRAINT `FK_level_employee` FOREIGN KEY (`level_id`) REFERENCES `tb_level` (`level_id`),
  CONSTRAINT `FK_status_employee` FOREIGN KEY (`status_id`) REFERENCES `tb_employee_status` (`tb_status_id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_employee`
--

LOCK TABLES `tb_employee` WRITE;
/*!40000 ALTER TABLE `tb_employee` DISABLE KEYS */;
INSERT INTO `tb_employee` VALUES (6,'1',NULL,NULL,NULL,3,2,'1234',NULL),(7,'22',NULL,NULL,NULL,3,2,'22',NULL),(8,'3',NULL,NULL,NULL,3,2,'3',NULL),(9,'4',NULL,NULL,NULL,3,2,'4',NULL),(10,'Bom',NULL,NULL,NULL,3,2,'1234',NULL);
/*!40000 ALTER TABLE `tb_employee` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tb_employee_status`
--

DROP TABLE IF EXISTS `tb_employee_status`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tb_employee_status` (
  `tb_status_id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  PRIMARY KEY (`tb_status_id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_employee_status`
--

LOCK TABLES `tb_employee_status` WRITE;
/*!40000 ALTER TABLE `tb_employee_status` DISABLE KEYS */;
INSERT INTO `tb_employee_status` VALUES (1,'In'),(2,'Out'),(3,'Holiday'),(4,'Quit');
/*!40000 ALTER TABLE `tb_employee_status` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tb_employee_time_sheet`
--

DROP TABLE IF EXISTS `tb_employee_time_sheet`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tb_employee_time_sheet` (
  `employee_time_sheet_id` int(11) NOT NULL AUTO_INCREMENT,
  `employee_id` int(11) NOT NULL,
  `clockin_time` datetime DEFAULT NULL,
  `clockout_time` datetime DEFAULT NULL,
  PRIMARY KEY (`employee_time_sheet_id`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_employee_time_sheet`
--

LOCK TABLES `tb_employee_time_sheet` WRITE;
/*!40000 ALTER TABLE `tb_employee_time_sheet` DISABLE KEYS */;
/*!40000 ALTER TABLE `tb_employee_time_sheet` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tb_ingredient`
--

DROP TABLE IF EXISTS `tb_ingredient`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tb_ingredient` (
  `ingredient_id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) NOT NULL,
  PRIMARY KEY (`ingredient_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_ingredient`
--

LOCK TABLES `tb_ingredient` WRITE;
/*!40000 ALTER TABLE `tb_ingredient` DISABLE KEYS */;
/*!40000 ALTER TABLE `tb_ingredient` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tb_level`
--

DROP TABLE IF EXISTS `tb_level`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tb_level` (
  `level_id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  PRIMARY KEY (`level_id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_level`
--

LOCK TABLES `tb_level` WRITE;
/*!40000 ALTER TABLE `tb_level` DISABLE KEYS */;
INSERT INTO `tb_level` VALUES (1,'Admin'),(2,'Manager'),(3,'Staff'),(4,'Trainee'),(5,'Guest');
/*!40000 ALTER TABLE `tb_level` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tb_location_menu`
--

DROP TABLE IF EXISTS `tb_location_menu`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tb_location_menu` (
  `tb_location_menu_id` int(11) NOT NULL AUTO_INCREMENT,
  `product_id` int(11) DEFAULT NULL,
  `tb_location_tab_id` int(11) DEFAULT NULL,
  `column_no` int(11) DEFAULT NULL,
  `row_no` int(11) DEFAULT NULL,
  PRIMARY KEY (`tb_location_menu_id`),
  KEY `FK_locationmenu_locationtab_idx` (`tb_location_tab_id`),
  CONSTRAINT `FK_locationmenu_locationtab` FOREIGN KEY (`tb_location_tab_id`) REFERENCES `tb_location_tab` (`tb_location_tab_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_location_menu`
--

LOCK TABLES `tb_location_menu` WRITE;
/*!40000 ALTER TABLE `tb_location_menu` DISABLE KEYS */;
/*!40000 ALTER TABLE `tb_location_menu` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tb_location_tab`
--

DROP TABLE IF EXISTS `tb_location_tab`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tb_location_tab` (
  `location_tab_id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) DEFAULT NULL,
  `is_active` int(11) DEFAULT '1',
  PRIMARY KEY (`location_tab_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_location_tab`
--

LOCK TABLES `tb_location_tab` WRITE;
/*!40000 ALTER TABLE `tb_location_tab` DISABLE KEYS */;
/*!40000 ALTER TABLE `tb_location_tab` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tb_order`
--

DROP TABLE IF EXISTS `tb_order`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tb_order` (
  `order_id` int(11) NOT NULL AUTO_INCREMENT,
  `order_at` datetime DEFAULT NULL,
  `order_type_id` int(11) DEFAULT '5',
  `employee_id` int(11) DEFAULT '1',
  `table` int(11) NOT NULL DEFAULT '0',
  `order_status_id` int(11) DEFAULT '1',
  `payment_id` int(11) DEFAULT '1',
  `customer_id` int(11) DEFAULT '1',
  PRIMARY KEY (`order_id`),
  KEY `FK_orderstatus_order` (`order_status_id`),
  KEY `FK_ordertype_order` (`order_type_id`),
  KEY `FK_payment_order` (`payment_id`),
  KEY `FK_customer_order` (`customer_id`),
  KEY `FK_employy_order_idx` (`employee_id`),
  CONSTRAINT `FK_customer_order` FOREIGN KEY (`customer_id`) REFERENCES `tb_customer` (`customer_id`),
  CONSTRAINT `FK_employy_order` FOREIGN KEY (`employee_id`) REFERENCES `tb_employee` (`employee_id`),
  CONSTRAINT `FK_orderstatus_order` FOREIGN KEY (`order_status_id`) REFERENCES `tb_order_status` (`order_status_id`),
  CONSTRAINT `FK_ordertype_order` FOREIGN KEY (`order_type_id`) REFERENCES `tb_order_type` (`tb_order_type_id`),
  CONSTRAINT `FK_payment_order` FOREIGN KEY (`payment_id`) REFERENCES `tb_payment_type` (`payment_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_order`
--

LOCK TABLES `tb_order` WRITE;
/*!40000 ALTER TABLE `tb_order` DISABLE KEYS */;
/*!40000 ALTER TABLE `tb_order` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tb_order_detail`
--

DROP TABLE IF EXISTS `tb_order_detail`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tb_order_detail` (
  `order_detail_id` int(11) NOT NULL AUTO_INCREMENT,
  `product_id` int(11) DEFAULT NULL,
  `popup_item_id` int(11) DEFAULT '1',
  `order_id` int(11) NOT NULL,
  `product_qty` int(11) DEFAULT '0',
  `amount` float DEFAULT '0',
  `comment` mediumtext,
  `cook_status` int(11) DEFAULT '1',
  PRIMARY KEY (`order_detail_id`),
  KEY `FK_product_orderdetail` (`product_id`),
  KEY `FK_popupitem_orderdetail` (`popup_item_id`),
  KEY `FK_order` (`order_id`),
  CONSTRAINT `FK_order` FOREIGN KEY (`order_id`) REFERENCES `tb_order` (`order_id`),
  CONSTRAINT `FK_popupitem_orderdetail` FOREIGN KEY (`popup_item_id`) REFERENCES `tb_popup_item` (`popup_item_id`),
  CONSTRAINT `FK_product_orderdetail` FOREIGN KEY (`product_id`) REFERENCES `tb_product` (`product_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_order_detail`
--

LOCK TABLES `tb_order_detail` WRITE;
/*!40000 ALTER TABLE `tb_order_detail` DISABLE KEYS */;
/*!40000 ALTER TABLE `tb_order_detail` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tb_order_status`
--

DROP TABLE IF EXISTS `tb_order_status`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tb_order_status` (
  `order_status_id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  PRIMARY KEY (`order_status_id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_order_status`
--

LOCK TABLES `tb_order_status` WRITE;
/*!40000 ALTER TABLE `tb_order_status` DISABLE KEYS */;
INSERT INTO `tb_order_status` VALUES (1,'Cooking'),(2,'Eating'),(3,'Done');
/*!40000 ALTER TABLE `tb_order_status` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tb_order_type`
--

DROP TABLE IF EXISTS `tb_order_type`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tb_order_type` (
  `tb_order_type_id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  PRIMARY KEY (`tb_order_type_id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_order_type`
--

LOCK TABLES `tb_order_type` WRITE;
/*!40000 ALTER TABLE `tb_order_type` DISABLE KEYS */;
INSERT INTO `tb_order_type` VALUES (1,'Eat-In'),(2,'Takeaway'),(3,'Delivery');
/*!40000 ALTER TABLE `tb_order_type` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tb_payment_type`
--

DROP TABLE IF EXISTS `tb_payment_type`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tb_payment_type` (
  `payment_id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  PRIMARY KEY (`payment_id`)
) ENGINE=InnoDB AUTO_INCREMENT=67 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_payment_type`
--

LOCK TABLES `tb_payment_type` WRITE;
/*!40000 ALTER TABLE `tb_payment_type` DISABLE KEYS */;
INSERT INTO `tb_payment_type` VALUES (1,'NONE'),(2,'Cash'),(3,'Visa'),(4,'Master'),(5,'Eftpos'),(6,'Amex');
/*!40000 ALTER TABLE `tb_payment_type` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tb_popup`
--

DROP TABLE IF EXISTS `tb_popup`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tb_popup` (
  `popup_id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  PRIMARY KEY (`popup_id`)
) ENGINE=InnoDB AUTO_INCREMENT=38 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_popup`
--

LOCK TABLES `tb_popup` WRITE;
/*!40000 ALTER TABLE `tb_popup` DISABLE KEYS */;
INSERT INTO `tb_popup` VALUES (1,'NONE'),(2,'Miang'),(3,'Spring Roll'),(4,'Fish Cake'),(5,'Money Bag'),(6,'Satay'),(7,'Stuffed Chicken'),(8,'SaltAndPeper'),(9,'Soup'),(10,'Curry Puff'),(11,'Four Season Tofu'),(12,'Duck Pan Cake'),(13,'Prawn Cake'),(14,'Emerald Prawn'),(15,'Dim Sim'),(16,'Meal'),(17,'Stir Fried Eggplant'),(18,'Massamam Curry'),(19,'Choo Chee'),(20,'Crispy Prok'),(21,'Golden Whole Snapper'),(22,'Larb'),(23,'Salad'),(24,'Som Tam'),(25,'Tamarind Sauce'),(26,'Celery'),(27,'Soft Drinks'),(28,'Thai Drink'),(29,'Tea (T2)'),(30,'Juice'),(31,'Spirits'),(32,'White Wine Glass'),(33,'White Wine Bottle'),(34,'Red Wine Glass'),(35,'Red Wine Bottle'),(36,'Beer'),(37,'Desserts');
/*!40000 ALTER TABLE `tb_popup` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tb_popup_item`
--

DROP TABLE IF EXISTS `tb_popup_item`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tb_popup_item` (
  `popup_item_id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) DEFAULT NULL,
  `popup_id` int(11) NOT NULL,
  `price` float DEFAULT '0',
  `image_path` longtext,
  PRIMARY KEY (`popup_item_id`),
  KEY `FK_popup_popupitem` (`popup_id`),
  CONSTRAINT `FK_popup_popupitem` FOREIGN KEY (`popup_id`) REFERENCES `tb_popup` (`popup_id`)
) ENGINE=InnoDB AUTO_INCREMENT=158 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_popup_item`
--

LOCK TABLES `tb_popup_item` WRITE;
/*!40000 ALTER TABLE `tb_popup_item` DISABLE KEYS */;
INSERT INTO `tb_popup_item` VALUES (1,'Goong (Serving)',2,0,'C:\\Images\\636805893454349495_0.jpg'),(2,'Goong (Pieces)',2,0,'C:\\Images\\636805893454464113_1.jpg'),(3,'Tofu (Serving)',2,0,'C:\\Images\\636805893454494055_2.jpg'),(4,'Tofu (Pieces)',2,0,'C:\\Images\\636805893454524131_3.jpg'),(5,'Crab Roll (Serving)',3,0,'C:\\Images\\636805896261200390_0.jpg'),(6,'Crab Roll (Pieces)',3,0,'C:\\Images\\636805896261260282_1.jpg'),(7,'Veg Roll (Serving)',3,0,'C:\\Images\\636805896261325161_2.jpg'),(8,'Veg Roll (Pieces)',3,0,'C:\\Images\\636805896261390043_3.jpg'),(9,'Fish Cake (Serving)',4,0,'C:\\Images\\636805897269478602_0.jpg'),(10,'Fish Cake (Pieces)',4,0,'C:\\Images\\636805897269518533_1.jpg'),(11,'Money Bag (Serving)',5,0,'C:\\Images\\636805898539506788_0.jpg'),(12,'Money Bag (Pieces)',5,0,'C:\\Images\\636805898539536730_1.jpg'),(13,'Chicken (Serving)',6,0,'C:\\Images\\636805899326434255_0.jpg'),(14,'Chicken (Pieces)',6,0,'C:\\Images\\636805899326459241_1.jpg'),(15,'Prawn (Serving)',6,0,'C:\\Images\\636805899326489189_2.jpg'),(16,'Prawn (Pieces)',6,0,'C:\\Images\\636805899326529081_3.jpg'),(17,'Stuffed Chicken (Serving)',7,0,'C:\\Images\\636805899814771081_0.jpg'),(18,'Stuffed Chicken (Pieces)',7,0,'C:\\Images\\636805899814835955_1.jpg'),(19,'Squid',8,0,'C:\\Images\\636805900763387091_0.jpg'),(20,'Tofu',8,0,'C:\\Images\\636805900763412031_1.jpg'),(21,'Eggplant',8,0,'C:\\Images\\636805900763437170_2.jpg'),(22,'Tofu&Eggplant',8,0,'C:\\Images\\636805900763465910_3.jpg'),(23,'Soft Shell Crab',8,0,'C:\\Images\\636805900763531682_4.jpg'),(24,'Prawn',8,0,'C:\\Images\\636805900763566625_5.jpg'),(25,'Tom Yum Prawn (Main)',9,0,'C:\\Images\\636805902264838279_0.jpg'),(26,'Tom Yum Prawn (Entree)',9,0,'C:\\Images\\636805902264868236_1.jpg'),(27,'Po Tak (Main)',9,0,'C:\\Images\\636805902264903161_2.jpg'),(28,'Po Tak (Entree)',9,0,'C:\\Images\\636805902264948077_3.jpg'),(29,'Tom Yum Veg  (Entree)',9,0,'C:\\Images\\636805902264988008_4.jpg'),(30,'Tom Kha Kai  (Entree)',9,0,'C:\\Images\\636805902265017951_5.jpg'),(31,'Tom Yum Chicken  (Entree)',9,0,'C:\\Images\\636805902265052885_6.jpg'),(32,'Tom Yum Mushroom  (Entree)',9,0,'C:\\Images\\636805902265087820_7.jpg'),(33,'Curry Puff (Serving)',10,0,'C:\\Images\\636805902886355507_0.jpg'),(34,'Curry Puff (Pieces)',10,0,'C:\\Images\\636805902886378076_1.jpg'),(35,'Veg Chicken (Serving)',6,0,'C:\\Images\\636805902265087820_7.jpg'),(36,'Veg Chicken (Pieces)',6,0,'C:\\Images\\636805902265087820_7.jpg'),(37,'Four Season Tofu (Serving)',11,0,'C:\\Images\\636805904127008647_0.jpg'),(38,'Four Season Tofu (Pieces)',11,0,'C:\\Images\\636805904127030248_1.jpg'),(39,'Duck Pan Cake (Serving)',12,0,'C:\\Images\\636805904747460056_0.jpg'),(40,'Duck Pan Cake (Pieces)',12,0,'C:\\Images\\636805904747480161_1.jpg'),(41,'Veg Duck Pan Cake (Serving)',12,0,'C:\\Images\\636805904747546441_2.jpg'),(42,'Veg Duck Pan Cake (Pieces)',12,0,'C:\\Images\\636805904747576191_3.jpg'),(43,'Prawn Cake (Serving)',13,0,'C:\\Images\\636805905099502543_0.jpg'),(44,'Prawn Cake (Pieces)',13,0,'C:\\Images\\636805905099563811_1.jpg'),(45,'Emerald Prawn (Serving)',14,0,'C:\\Images\\636805905337200343_0.jpg'),(46,'Emerald Prawn (Entree)',14,0,'C:\\Images\\636805905337222348_1.jpg'),(47,'Dim Sim (Serving)',15,0,'C:\\Images\\636805905542173785_0.jpg'),(48,'Dim Sim (Pieces)',15,0,'C:\\Images\\636805905542198986_1.jpg'),(49,'Vegetable',16,0,'C:\\Images\\636805907416928787_0.jpg'),(50,'Chicken',16,0,'C:\\Images\\636805907417038629_1.jpg'),(51,'Pork',16,0,'C:\\Images\\636805907417088531_2.jpg'),(52,'Beef',16,0,'C:\\Images\\636805907417153218_3.jpg'),(53,'Prawn',16,0,'C:\\Images\\636805907417213101_4.jpg'),(54,'Squid',16,0,'C:\\Images\\636805907417243046_5.jpg'),(55,'Crab',16,0,'C:\\Images\\636805907417282976_6.jpg'),(56,'Seafood',16,0,'C:\\Images\\636805907417317927_7.jpg'),(57,'Duck',16,0,'C:\\Images\\636805907417352865_8.jpg'),(58,'Veg Duck',16,0,'C:\\Images\\636805907417382787_9.jpg'),(59,'Veg Chicken',16,0,'C:\\Images\\636805907417412757_10.jpg'),(60,'Crispy Pork',16,0,'C:\\Images\\636805907417442674_11.jpg'),(61,'Tofu',17,0,'C:\\Images\\636805907701105367_0.jpg'),(62,'Beef',17,0,'C:\\Images\\636805907701130289_1.jpg'),(63,'Beef',18,0,'C:\\Images\\636805907949945623_0.jpg'),(64,'Lamb with Roti',18,0,'C:\\Images\\636805907949965787_1.jpg'),(65,'Tofu',19,0,'C:\\Images\\636805909913744624_0.jpg'),(66,'King Prawn',19,0,'C:\\Images\\636805909913774415_1.jpg'),(67,'Barramundi Fillet',19,0,'C:\\Images\\636805909913809356_2.jpg'),(68,'Whole Snapper',19,0,'C:\\Images\\636805909913859258_3.jpg'),(69,'Salmon',19,0,'C:\\Images\\636805909913904183_4.jpg'),(70,'Chinese Broc',20,0,'C:\\Images\\636805912715403392_0.jpg'),(71,'Cashew Nut',20,0,'C:\\Images\\636805912715468283_1.jpg'),(72,'Chilli Basil',20,0,'C:\\Images\\636805912715498209_2.jpg'),(73,'Prik Kning',20,0,'C:\\Images\\636805912715530346_3.jpg'),(74,'Garlic Peper Sauce',21,0,'C:\\Images\\636805913204949352_0.jpg'),(75,'Three Flavoured Sauce',21,0,'C:\\Images\\636805913204984295_1.jpg'),(76,'Chilli Sauce',21,0,'C:\\Images\\636805913205024216_2.jpg'),(77,'Tofu',22,0,'C:\\Images\\636805913601862159_0.jpg'),(78,'Chicken',22,0,'C:\\Images\\636805913601892081_1.jpg'),(79,'Pork',22,0,'C:\\Images\\636805913601922224_2.jpg'),(80,'Beef',22,0,'C:\\Images\\636805913601989317_3.jpg'),(81,'Duck',22,0,'C:\\Images\\636805913602029202_4.jpg'),(82,'Duck',23,0,'C:\\Images\\636805914121829407_0.jpg'),(83,'Beef',23,0,'C:\\Images\\636805914121859352_1.jpg'),(84,'Barramundi Fillet',23,0,'C:\\Images\\636805914121894061_2.jpg'),(85,'Banana',23,0,'C:\\Images\\636805914121919241_3.jpg'),(86,'Veg Duck',23,0,'C:\\Images\\636805914121948990_4.jpg'),(87,'Plain',24,0,'C:\\Images\\636805914889202753_0.jpg'),(88,'King Prawn',24,0,'C:\\Images\\636805914889237718_1.jpg'),(89,'Crab',24,0,'C:\\Images\\636805914889282618_2.jpg'),(90,'Barramundi',24,0,'C:\\Images\\636805914889312412_3.jpg'),(91,'Duck',25,0,'C:\\Images\\636805915248315915_0.jpg'),(92,'Prawn',25,0,'C:\\Images\\636805915248341044_1.jpg'),(93,'Veg Duck',25,0,'C:\\Images\\636805915248370787_2.jpg'),(94,'Crab',26,0,'C:\\Images\\636805915822569170_0.jpg'),(95,'Barramundi',26,0,'C:\\Images\\636805915822599138_1.jpg'),(96,'Coke',27,0,'C:\\Images\\636805916556486461_0.jpg'),(97,'Coke Zero',27,0,'C:\\Images\\636805916556511565_1.jpg'),(98,'Fanta',27,0,'C:\\Images\\636805916556546526_2.jpg'),(99,'Lemon Squash',27,0,'C:\\Images\\636805916556576268_3.jpg'),(100,'Lemonade',27,0,'C:\\Images\\636805916556606213_4.jpg'),(101,'Ginger Beer',27,0,'C:\\Images\\636805916556636366_5.jpg'),(102,'Thai Milk Tea',28,0,'C:\\Images\\636805917744855082_0.jpg'),(103,'Thai Lemon Tea',28,0,'C:\\Images\\636805917744904983_1.jpg'),(104,'Thai Tea (Cha Dam Yen)',28,0,'C:\\Images\\636805917744959886_2.jpg'),(105,'Thai Coffee',28,0,'C:\\Images\\636805917745019773_3.jpg'),(106,'Ginger Lemongrass',29,0,'C:\\Images\\636805918241522257_0.jpg'),(107,'English Breakfast',29,0,'C:\\Images\\636805918241562190_1.jpg'),(108,'Pepermint',29,0,'C:\\Images\\636805918241592139_2.jpg'),(109,'Earl Grey',29,0,'C:\\Images\\636805918241627061_3.jpg'),(110,'Jasmine',29,0,'C:\\Images\\636805918241666982_4.jpg'),(111,'Green Tea',29,0,'C:\\Images\\636805918241716890_5.jpg'),(112,'Apple',30,0,'C:\\Images\\636805918880708570_0.jpg'),(113,'Orange',30,0,'C:\\Images\\636805918880748522_1.jpg'),(114,'Watermelon',30,0,'C:\\Images\\636805918880848503_2.jpg'),(115,'Lime and Mint Juice',30,0,'C:\\Images\\636805918880888235_3.jpg'),(116,'Lychee, Lime and Mint Juice',30,0,'C:\\Images\\636805918880923324_4.jpg'),(117,'JW Black',31,0,'C:\\Images\\636805919389546685_0.jpg'),(118,'Jack Daniels',31,0,'C:\\Images\\636805919389596606_1.jpg'),(119,'Jum Beam',31,0,'C:\\Images\\636805919389656481_2.jpg'),(120,'Absolut Vodka',31,0,'C:\\Images\\636805919389706383_3.jpg'),(121,'Barcardi Rum',31,0,'C:\\Images\\636805919389766282_4.jpg'),(122,'Gordon Gin',31,0,'C:\\Images\\636805919389811194_5.jpg'),(123,'Stonefish Sauvignon Blanc (Glass)',32,0,'C:\\Images\\636805920586358086_0.jpg'),(124,'Sheel Bay Semillon Sauvignon (Glass)',32,0,'C:\\Images\\636805920586452922_1.jpg'),(125,'Lawson Dry Hills Sauvignon (Glass)',32,0,'C:\\Images\\636805920586527772_2.jpg'),(126,'Mout Trio Chardonnay (Glass)',32,0,'C:\\Images\\636805920586567695_3.jpg'),(127,'DiGiorgio Kongorong Riesling (Glass)',32,0,'C:\\Images\\636805920586597639_4.jpg'),(128,'Garfish Pinot Grigio (Glass)',32,0,'C:\\Images\\636805920586632587_5.jpg'),(129,'Stonefish Sauvignon Blanc (Bottle)',33,0,'C:\\Images\\636805921167129801_0.jpg'),(130,'Sheel Bay Semillon Sauvignon (Bottle)',33,0,'C:\\Images\\636805921167159722_1.jpg'),(131,'Lawson Dry Hills Sauvignon (Bottle)',33,0,'C:\\Images\\636805921167194668_2.jpg'),(132,'Mout Trio Chardonnay (Bottle)',33,0,'C:\\Images\\636805921167229609_3.jpg'),(133,'DiGiorgio Kongorong Riesling (Bottle)',33,0,'C:\\Images\\636805921167259557_4.jpg'),(134,'Garfish Pinot Grigio (Bottle)',33,0,'C:\\Images\\636805921167294476_5.jpg'),(135,'GarfishCabernet Sauvingon (Glass)',34,0,'C:\\Images\\636805921596442695_0.jpg'),(136,'Scarpantoni Shiraz (Glass)',34,0,'C:\\Images\\636805921596472469_1.jpg'),(137,'Stonefish Merlot (Glass)',34,0,'C:\\Images\\636805921596507401_2.jpg'),(138,'Wicked Thorn Pinot Noir (Glass)',34,0,'C:\\Images\\636805921596542344_3.jpg'),(139,'Shell Bay Shiraz Cabernet (Glass)',34,0,'C:\\Images\\636805921596577450_4.jpg'),(140,'GarfishCabernet Sauvingon (Bottle)',35,0,'C:\\Images\\636805922089210732_0.jpg'),(141,'Scarpantoni Shiraz (Bottle)',35,0,'C:\\Images\\636805922089240472_1.jpg'),(142,'Stonefish Merlot (Bottle)',35,0,'C:\\Images\\636805922089265426_2.jpg'),(143,'Wicked Thorn Pinot Noir (Bottle)',35,0,'C:\\Images\\636805922089300368_3.jpg'),(144,'Shell Bay Shiraz Cabernet (Bottle)',35,0,'C:\\Images\\636805922089350277_4.jpg'),(145,'Singha',36,0,'C:\\Images\\636805922628986395_0.jpg'),(146,'Chang',36,0,'C:\\Images\\636805922629021310_1.jpg'),(147,'Corona',36,0,'C:\\Images\\636805922629055119_2.jpg'),(148,'Cascade Premium',36,0,'C:\\Images\\636805922629087487_3.jpg'),(149,'Coppers',36,0,'C:\\Images\\636805922629117428_4.jpg'),(150,'Crushed Cider',36,0,'C:\\Images\\636805922629147392_5.jpg'),(151,'Sticky Rice Mango',37,0,'C:\\Images\\636806994975130268_0.jpg'),(152,'Black Sticky Rice Icecream',37,0,'C:\\Images\\636806994975280013_1.jpg'),(153,'Banana In Coconut Milk',37,0,'C:\\Images\\636806994975329900_2.jpg'),(154,'Sago Pudding',37,0,'C:\\Images\\636806994975364847_3.jpg'),(155,'Taro Custard',37,0,'C:\\Images\\636806994975404755_4.jpg'),(156,'Banana in Pajamas',37,0,'C:\\Images\\636806994975439697_5.jpg'),(157,'Pancake',37,0,'C:\\Images\\636806994975474626_6.jpg');
/*!40000 ALTER TABLE `tb_popup_item` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tb_printer`
--

DROP TABLE IF EXISTS `tb_printer`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tb_printer` (
  `printer_id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  `printer_ip` varchar(45) DEFAULT NULL,
  `printer_port` varchar(45) DEFAULT NULL,
  `is_active` int(11) DEFAULT '1',
  PRIMARY KEY (`printer_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_printer`
--

LOCK TABLES `tb_printer` WRITE;
/*!40000 ALTER TABLE `tb_printer` DISABLE KEYS */;
/*!40000 ALTER TABLE `tb_printer` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tb_printer_log`
--

DROP TABLE IF EXISTS `tb_printer_log`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tb_printer_log` (
  `printer_log_id` int(11) NOT NULL AUTO_INCREMENT,
  `printer_id` int(11) NOT NULL,
  `print_dt` datetime NOT NULL,
  `printer_detail` json NOT NULL,
  PRIMARY KEY (`printer_log_id`),
  KEY `FK_printerlog_printer_idx` (`printer_id`),
  CONSTRAINT `FK_printerlog_printer` FOREIGN KEY (`printer_id`) REFERENCES `tb_printer` (`printer_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_printer_log`
--

LOCK TABLES `tb_printer_log` WRITE;
/*!40000 ALTER TABLE `tb_printer_log` DISABLE KEYS */;
/*!40000 ALTER TABLE `tb_printer_log` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tb_printer_product`
--

DROP TABLE IF EXISTS `tb_printer_product`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tb_printer_product` (
  `printer_product_id` int(11) NOT NULL AUTO_INCREMENT,
  `product_id` int(11) NOT NULL,
  `printer_id` int(11) NOT NULL,
  PRIMARY KEY (`printer_product_id`),
  KEY `FK_printer_printerproduct` (`printer_id`),
  KEY `FK_product_printerproudct` (`product_id`),
  CONSTRAINT `FK_printer_printerproduct` FOREIGN KEY (`printer_id`) REFERENCES `tb_printer` (`printer_id`),
  CONSTRAINT `FK_product_printerproudct` FOREIGN KEY (`product_id`) REFERENCES `tb_product` (`product_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_printer_product`
--

LOCK TABLES `tb_printer_product` WRITE;
/*!40000 ALTER TABLE `tb_printer_product` DISABLE KEYS */;
/*!40000 ALTER TABLE `tb_printer_product` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tb_product`
--

DROP TABLE IF EXISTS `tb_product`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tb_product` (
  `product_id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) NOT NULL,
  `short_name` varchar(45) DEFAULT NULL,
  `description` longtext,
  `avaliable` tinyint(4) DEFAULT '1',
  `product_ingredient_id` int(11) DEFAULT '1',
  `popup_id` int(11) DEFAULT '1',
  `stock` int(11) DEFAULT '0',
  `price` float DEFAULT '0',
  `image_path` longtext,
  `type_food_id` int(11) DEFAULT '2',
  PRIMARY KEY (`product_id`),
  KEY `FK_popup_product` (`popup_id`),
  CONSTRAINT `FK_popup_product` FOREIGN KEY (`popup_id`) REFERENCES `tb_popup` (`popup_id`)
) ENGINE=InnoDB AUTO_INCREMENT=78 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_product`
--

LOCK TABLES `tb_product` WRITE;
/*!40000 ALTER TABLE `tb_product` DISABLE KEYS */;
INSERT INTO `tb_product` VALUES (2,'Miang','mg','',1,0,2,0,0,NULL,2),(3,'Spring Roll','','',1,0,3,0,0,NULL,1),(4,'Fish Cake','','',1,0,4,0,0,NULL,1),(5,'Money Bag','','',1,0,5,0,0,NULL,1),(6,'Satay','','',1,0,6,0,0,NULL,1),(7,'Stuffed Chicken','','',1,0,7,0,0,NULL,1),(8,'Salt&Pepper','','',1,0,8,0,0,NULL,1),(9,'Soup','','',1,0,9,0,0,NULL,1),(10,'Curry Puff','','',1,0,10,0,0,NULL,1),(11,'Four Season Tofu','','',1,0,11,0,0,NULL,1),(12,'Duck Pan Cake','','',1,0,12,0,0,NULL,1),(13,'Steamed Veggies','','',1,0,1,0,0,NULL,2),(14,'Tofu Tamarind','','',1,0,1,0,0,NULL,1),(15,'Prawn Cake','','',1,0,13,0,0,NULL,1),(16,'Emerald Prawn','','',1,0,14,0,0,NULL,1),(17,'Dim Sim','','',1,0,15,0,0,NULL,1),(18,'Prawn Crakers','','',1,0,1,0,0,NULL,1),(19,'Hot Chilli Basil','','',1,0,16,0,0,NULL,2),(20,'Cashew Nut','','',1,0,16,0,0,NULL,2),(21,'Black Pepper','','',1,0,16,0,0,NULL,2),(22,'Lemon Grass','','',1,0,16,0,0,NULL,2),(23,'Oyster','','',1,0,16,0,0,NULL,2),(24,'Garlic','','',1,0,16,0,0,NULL,2),(25,'Ginger','','',1,0,16,0,0,NULL,2),(26,'Stir Fried Eggplant','','',1,0,17,0,0,NULL,2),(27,'Stir Stay Sauce','','',1,0,16,0,0,NULL,2),(28,'Red Curry','','',1,0,16,0,0,NULL,2),(29,'Green Curry','','',1,0,16,0,0,NULL,2),(30,'Panang Curry','','',1,0,16,0,0,NULL,2),(31,'Massaman Curry','','',1,0,18,0,0,NULL,2),(32,'Yellow Curry Chicken with Roti','','',1,0,1,0,0,NULL,2),(33,'Country Curry','','',1,0,16,0,0,NULL,2),(34,'Choo Chee','','',1,0,19,0,0,NULL,2),(35,'Crispy Pork','','',1,0,20,0,0,NULL,2),(36,'Coconut Prawn','','',1,0,1,0,0,NULL,2),(37,'Golden Whole Snapper','','',1,0,21,0,0,NULL,2),(38,'Barramundi Red Curry','','',1,0,1,0,0,NULL,2),(39,'Larb','','',1,0,22,0,0,NULL,2),(40,'Salad','','',1,0,23,0,0,NULL,2),(41,'Crying Tiger','','',1,0,1,0,0,NULL,2),(42,'Pad Cha Seafood','','',1,0,1,0,0,NULL,2),(43,'Som Tam','','',1,0,24,0,0,NULL,2),(44,'Steamed Fish','','',1,0,1,0,0,NULL,2),(45,'Whole Barramundi','','',1,0,1,0,0,NULL,2),(46,'Soft Shell Crab','','',1,0,1,0,0,NULL,2),(47,'Tamarind Sauce','','',1,0,25,0,0,NULL,2),(48,'Tom Yum Fried Rice','','',1,0,16,0,0,NULL,2),(49,'Pad Thai','','',1,0,16,0,0,NULL,2),(50,'Kee Mao','','',1,0,16,0,0,NULL,2),(51,'See ew','','',1,0,16,0,0,NULL,2),(52,'Hokkien Noodle','','',1,0,16,0,0,NULL,2),(53,'Fried Rice','','',1,0,16,0,0,NULL,2),(54,'Laksa','','',1,0,16,0,0,NULL,2),(55,'Cashew Nut Noodle','','',1,0,16,0,0,NULL,2),(56,'Tom Yum Noodle Soup','','',1,0,16,0,0,NULL,2),(57,'Hot Chilli Basil Fried Rice','','',1,0,16,0,0,NULL,2),(58,'Roti','','',1,0,1,0,0,NULL,2),(59,'Brown Rice','','',1,0,1,0,0,NULL,2),(60,'Coconut Rice','','',1,0,1,0,5,NULL,2),(61,'Jasmine Rice','','',1,0,1,0,3,NULL,2),(62,'Steamed Noodles','','',1,0,1,0,0,NULL,2),(63,'Celery','','',1,0,26,0,0,NULL,2),(64,'Sparkling Mineral','','',1,0,26,0,0,NULL,3),(65,'Soft Drinks','','',1,0,27,0,0,NULL,3),(66,'Desserts','','',1,0,37,0,0,NULL,4),(67,'Thai Drink','','',1,0,28,0,0,NULL,3),(68,'Tea (T2)','','',1,0,29,0,4.9,NULL,3),(69,'Lemon Lime Bitter','','',1,0,1,0,0,NULL,3),(70,'Spring Water','','',1,0,1,0,0,NULL,3),(71,'Spirits','','',1,0,31,0,0,NULL,3),(72,'White Wine Glass','','',1,0,32,0,0,NULL,3),(73,'White Wine Bottle','','',1,0,33,0,0,NULL,3),(74,'Red Wine Glass','','',1,0,34,0,0,NULL,3),(75,'Red Wine Bottle','','',1,0,35,0,0,NULL,3),(76,'Tempus Two Varietal Sparkling','','',1,0,1,0,0,NULL,3),(77,'Beer','','',1,0,36,0,0,NULL,3);
/*!40000 ALTER TABLE `tb_product` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tb_product_ingredient`
--

DROP TABLE IF EXISTS `tb_product_ingredient`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tb_product_ingredient` (
  `product_id` int(11) NOT NULL,
  `ingredient_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_product_ingredient`
--

LOCK TABLES `tb_product_ingredient` WRITE;
/*!40000 ALTER TABLE `tb_product_ingredient` DISABLE KEYS */;
/*!40000 ALTER TABLE `tb_product_ingredient` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tb_section`
--

DROP TABLE IF EXISTS `tb_section`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tb_section` (
  `section_id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) DEFAULT NULL,
  `is_active` int(11) DEFAULT '1',
  PRIMARY KEY (`section_id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_section`
--

LOCK TABLES `tb_section` WRITE;
/*!40000 ALTER TABLE `tb_section` DISABLE KEYS */;
INSERT INTO `tb_section` VALUES (1,'Front',1),(2,'Main',1),(3,'Back',1);
/*!40000 ALTER TABLE `tb_section` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tb_setting`
--

DROP TABLE IF EXISTS `tb_setting`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tb_setting` (
  `setting_id` int(11) NOT NULL AUTO_INCREMENT,
  `key` varchar(45) NOT NULL,
  `value` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`setting_id`),
  UNIQUE KEY `key_UNIQUE` (`key`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_setting`
--

LOCK TABLES `tb_setting` WRITE;
/*!40000 ALTER TABLE `tb_setting` DISABLE KEYS */;
/*!40000 ALTER TABLE `tb_setting` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tb_table_section`
--

DROP TABLE IF EXISTS `tb_table_section`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tb_table_section` (
  `table_section_id` int(11) NOT NULL AUTO_INCREMENT,
  `u_name` varchar(45) NOT NULL,
  `name` varchar(45) DEFAULT NULL,
  `section_id` int(11) DEFAULT NULL,
  `margin_top` float DEFAULT NULL,
  `margin_bottom` float DEFAULT NULL,
  `margin_right` float DEFAULT NULL,
  `margin_left` float DEFAULT NULL,
  `height` float DEFAULT '50',
  `width` float DEFAULT '50',
  `is_active` int(11) DEFAULT '1',
  PRIMARY KEY (`table_section_id`),
  UNIQUE KEY `u_name_UNIQUE` (`u_name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_table_section`
--

LOCK TABLES `tb_table_section` WRITE;
/*!40000 ALTER TABLE `tb_table_section` DISABLE KEYS */;
/*!40000 ALTER TABLE `tb_table_section` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tb_type_food`
--

DROP TABLE IF EXISTS `tb_type_food`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `tb_type_food` (
  `type_food_id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) NOT NULL,
  PRIMARY KEY (`type_food_id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_type_food`
--

LOCK TABLES `tb_type_food` WRITE;
/*!40000 ALTER TABLE `tb_type_food` DISABLE KEYS */;
INSERT INTO `tb_type_food` VALUES (1,'Entree'),(2,'Main'),(3,'Dessert'),(4,'Beverage'),(5,'Other');
/*!40000 ALTER TABLE `tb_type_food` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-02-26 23:40:15
