-- phpMyAdmin SQL Dump
-- version 5.2.3
-- https://www.phpmyadmin.net/
--
-- Máy chủ: 127.0.0.1
-- Thời gian đã tạo: Th10 13, 2026 lúc 03:22 PM
-- Phiên bản máy phục vụ: 10.11.16-MariaDB
-- Phiên bản PHP: 8.5.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Cơ sở dữ liệu: `billiardsdb`
--

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `banbida`
--

CREATE TABLE `banbida` (
  `MaBan` int(11) NOT NULL,
  `TenBan` varchar(50) NOT NULL,
  `LoaiBan` varchar(30) NOT NULL,
  `GiaTheoGio` decimal(18,2) NOT NULL CHECK (`GiaTheoGio` > 0),
  `TrangThai` varchar(20) DEFAULT 'Trống'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Đang đổ dữ liệu cho bảng `banbida`
--

INSERT INTO `banbida` (`MaBan`, `TenBan`, `LoaiBan`, `GiaTheoGio`, `TrangThai`) VALUES
(1, 'Bàn Pool 01', 'Pool (Lỗ)', 60000.00, 'Trống'),
(2, 'Bàn Pool 02', 'Pool (Lỗ)', 60000.00, 'Trống'),
(3, 'Bàn Carom 01', 'Carom (Phăng)', 50000.00, 'Trống'),
(4, 'Bàn Carom 02', 'Carom (Phăng)', 50000.00, 'Trống'),
(5, 'Bàn Snooker VIP 01', 'Snooker', 90000.00, 'Trống'),
(6, 'Bàn Snooker VIP 02', 'Snooker', 90000.00, 'Trống');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `chitiethoadon`
--

CREATE TABLE `chitiethoadon` (
  `MaHD` int(11) NOT NULL,
  `MaDV` int(11) NOT NULL,
  `SoLuong` int(11) NOT NULL CHECK (`SoLuong` > 0),
  `DonGia` decimal(18,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `hoadon`
--

CREATE TABLE `hoadon` (
  `MaHD` int(11) NOT NULL,
  `MaBan` int(11) NOT NULL,
  `GioBatDau` datetime NOT NULL,
  `GioKetThuc` datetime DEFAULT NULL,
  `TienGioChoi` decimal(18,2) DEFAULT 0.00,
  `TienDichVu` decimal(18,2) DEFAULT 0.00,
  `TrangThai` tinyint(1) DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `menudichvu`
--

CREATE TABLE `menudichvu` (
  `MaDV` int(11) NOT NULL,
  `TenDV` varchar(100) NOT NULL,
  `DonGia` decimal(18,2) NOT NULL CHECK (`DonGia` >= 0),
  `TonKho` int(11) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Đang đổ dữ liệu cho bảng `menudichvu`
--

INSERT INTO `menudichvu` (`MaDV`, `TenDV`, `DonGia`, `TonKho`) VALUES
(1, 'Nước tăng lực Sting', 15000.00, 100),
(2, 'Bia Tiger Bạc (Lon)', 22000.00, 120),
(3, 'Mì xào bò trứng', 40000.00, 30),
(4, 'Khăn lạnh', 5000.00, 200),
(5, 'Thuê gậy Carbon Pro', 30000.00, 999);

--
-- Chỉ mục cho các bảng đã đổ
--

--
-- Chỉ mục cho bảng `banbida`
--
ALTER TABLE `banbida`
  ADD PRIMARY KEY (`MaBan`);

--
-- Chỉ mục cho bảng `chitiethoadon`
--
ALTER TABLE `chitiethoadon`
  ADD PRIMARY KEY (`MaHD`,`MaDV`),
  ADD KEY `MaDV` (`MaDV`);

--
-- Chỉ mục cho bảng `hoadon`
--
ALTER TABLE `hoadon`
  ADD PRIMARY KEY (`MaHD`),
  ADD KEY `MaBan` (`MaBan`);

--
-- Chỉ mục cho bảng `menudichvu`
--
ALTER TABLE `menudichvu`
  ADD PRIMARY KEY (`MaDV`);

--
-- AUTO_INCREMENT cho các bảng đã đổ
--

--
-- AUTO_INCREMENT cho bảng `banbida`
--
ALTER TABLE `banbida`
  MODIFY `MaBan` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT cho bảng `hoadon`
--
ALTER TABLE `hoadon`
  MODIFY `MaHD` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT cho bảng `menudichvu`
--
ALTER TABLE `menudichvu`
  MODIFY `MaDV` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- Ràng buộc đối với các bảng kết xuất
--

--
-- Ràng buộc cho bảng `chitiethoadon`
--
ALTER TABLE `chitiethoadon`
  ADD CONSTRAINT `chitiethoadon_ibfk_1` FOREIGN KEY (`MaHD`) REFERENCES `hoadon` (`MaHD`) ON DELETE CASCADE,
  ADD CONSTRAINT `chitiethoadon_ibfk_2` FOREIGN KEY (`MaDV`) REFERENCES `menudichvu` (`MaDV`);

--
-- Ràng buộc cho bảng `hoadon`
--
ALTER TABLE `hoadon`
  ADD CONSTRAINT `hoadon_ibfk_1` FOREIGN KEY (`MaBan`) REFERENCES `banbida` (`MaBan`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
