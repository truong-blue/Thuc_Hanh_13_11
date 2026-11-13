-- phpMyAdmin SQL Dump
-- version 5.2.3
-- https://www.phpmyadmin.net/
--
-- Máy chủ: 127.0.0.1
-- Thời gian đã tạo: Th10 13, 2026 lúc 11:55 AM
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
-- Cơ sở dữ liệu: `librarydb`
--

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `chitietmuon`
--

CREATE TABLE `chitietmuon` (
  `MaPhieu` int(11) NOT NULL,
  `MaSach` int(11) NOT NULL,
  `SoLuong` int(11) NOT NULL CHECK (`SoLuong` > 0)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Đang đổ dữ liệu cho bảng `chitietmuon`
--

INSERT INTO `chitietmuon` (`MaPhieu`, `MaSach`, `SoLuong`) VALUES
(1, 1, 2),
(2, 3, 1),
(3, 2, 1);

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `dausach`
--

CREATE TABLE `dausach` (
  `MaSach` int(11) NOT NULL,
  `TenSach` varchar(200) NOT NULL,
  `TheLoai` varchar(50) NOT NULL,
  `SoLuongCon` int(11) NOT NULL DEFAULT 0 CHECK (`SoLuongCon` >= 0)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Đang đổ dữ liệu cho bảng `dausach`
--

INSERT INTO `dausach` (`MaSach`, `TenSach`, `TheLoai`, `SoLuongCon`) VALUES
(1, 'An toàn Mạng & Hệ thống SCADA', 'Công nghệ thông tin', 15),
(2, 'Lập trình C# & Kiến trúc 3-Tier', 'Công nghệ thông tin', 20),
(3, 'Kinh tế Vi mô Đại cương', 'Kinh tế', 12),
(4, 'Nhà Giả Kim', 'Văn học', 18);

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `docgia`
--

CREATE TABLE `docgia` (
  `MaDocGia` int(11) NOT NULL,
  `HoTen` varchar(100) NOT NULL,
  `Email` varchar(100) NOT NULL,
  `NgayHetHanThe` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Đang đổ dữ liệu cho bảng `docgia`
--

INSERT INTO `docgia` (`MaDocGia`, `HoTen`, `Email`, `NgayHetHanThe`) VALUES
(1, 'Nguyễn Hữu Trường', 'truong.nh@epu.edu.vn', '2027-12-31 00:00:00'),
(2, 'Trần Văn Nam', 'nam.tv@epu.edu.vn', '2026-12-30 00:00:00'),
(3, 'Lê Thị Mai (Thẻ hết hạn)', 'mai.lt@epu.edu.vn', '2025-10-01 00:00:00');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `phieumuon`
--

CREATE TABLE `phieumuon` (
  `MaPhieu` int(11) NOT NULL,
  `MaDocGia` int(11) NOT NULL,
  `NgayMuon` datetime DEFAULT current_timestamp(),
  `HanTra` datetime NOT NULL,
  `TrangThai` varchar(50) DEFAULT 'Đang mượn'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Đang đổ dữ liệu cho bảng `phieumuon`
--

INSERT INTO `phieumuon` (`MaPhieu`, `MaDocGia`, `NgayMuon`, `HanTra`, `TrangThai`) VALUES
(1, 1, '2026-11-01 00:00:00', '2026-11-20 00:00:00', 'Đang mượn'),
(2, 2, '2026-10-15 00:00:00', '2026-10-30 00:00:00', 'Đang mượn'),
(3, 1, '2026-10-01 00:00:00', '2026-10-10 00:00:00', 'Đã trả');

--
-- Chỉ mục cho các bảng đã đổ
--

--
-- Chỉ mục cho bảng `chitietmuon`
--
ALTER TABLE `chitietmuon`
  ADD PRIMARY KEY (`MaPhieu`,`MaSach`),
  ADD KEY `MaSach` (`MaSach`);

--
-- Chỉ mục cho bảng `dausach`
--
ALTER TABLE `dausach`
  ADD PRIMARY KEY (`MaSach`);

--
-- Chỉ mục cho bảng `docgia`
--
ALTER TABLE `docgia`
  ADD PRIMARY KEY (`MaDocGia`),
  ADD UNIQUE KEY `Email` (`Email`);

--
-- Chỉ mục cho bảng `phieumuon`
--
ALTER TABLE `phieumuon`
  ADD PRIMARY KEY (`MaPhieu`),
  ADD KEY `MaDocGia` (`MaDocGia`);

--
-- AUTO_INCREMENT cho các bảng đã đổ
--

--
-- AUTO_INCREMENT cho bảng `dausach`
--
ALTER TABLE `dausach`
  MODIFY `MaSach` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT cho bảng `docgia`
--
ALTER TABLE `docgia`
  MODIFY `MaDocGia` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT cho bảng `phieumuon`
--
ALTER TABLE `phieumuon`
  MODIFY `MaPhieu` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- Ràng buộc đối với các bảng kết xuất
--

--
-- Ràng buộc cho bảng `chitietmuon`
--
ALTER TABLE `chitietmuon`
  ADD CONSTRAINT `chitietmuon_ibfk_1` FOREIGN KEY (`MaPhieu`) REFERENCES `phieumuon` (`MaPhieu`) ON DELETE CASCADE,
  ADD CONSTRAINT `chitietmuon_ibfk_2` FOREIGN KEY (`MaSach`) REFERENCES `dausach` (`MaSach`) ON DELETE CASCADE;

--
-- Ràng buộc cho bảng `phieumuon`
--
ALTER TABLE `phieumuon`
  ADD CONSTRAINT `phieumuon_ibfk_1` FOREIGN KEY (`MaDocGia`) REFERENCES `docgia` (`MaDocGia`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
