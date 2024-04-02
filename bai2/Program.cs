using System;
using System.Collections.Generic;
using System.Text;

public class Program
{
    public struct ThongTinSinhVien
    {
        public string Ten { get; set; }
        public int Tuoi { get; set; }
        public double DiemTrungBinh { get; set; }

        public ThongTinSinhVien(string ten, int tuoi, double diemTrungBinh)
        {
            Ten = ten;
            Tuoi = tuoi;
            DiemTrungBinh = diemTrungBinh;
        }

        public override string ToString()
        {
            return $"Tên: {Ten}, Tuổi: {Tuoi}, Điểm Trung Bình: {DiemTrungBinh}";
        }
    }

    public static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        List<ThongTinSinhVien> danhSachSinhVien = DanhSachSinhVien();

        Console.WriteLine("==== Quản Lý Thông Tin Sinh Viên ====");
        int luaChon;
        do
        {
            Console.WriteLine("\n1. Thêm sinh viên mới");
            Console.WriteLine("2. Hiển thị danh sách sinh viên");
            Console.WriteLine("3. Tìm kiếm sinh viên theo tên");
            Console.WriteLine("4. Thoát chương trình");
            Console.Write("Nhập lựa chọn của bạn: ");
            luaChon = int.Parse(Console.ReadLine());

            switch (luaChon)
            {
                case 1:
                    ThemSinhVien(danhSachSinhVien);
                    break;
                case 2:
                    HienThiDanhSachSinhVien(danhSachSinhVien);
                    break;
                case 3:
                    TimKiemSinhVienTheoTen(danhSachSinhVien);
                    break;
                case 4:
                    Console.WriteLine("Thoát chương trình...");
                    break;
                default:
                    Console.WriteLine("Lựa chọn không hợp lệ! Vui lòng chọn lại.");
                    break;
            }
        } while (luaChon != 4);
    }

    public static List<ThongTinSinhVien> DanhSachSinhVien()
    {
        List<ThongTinSinhVien> ds = new List<ThongTinSinhVien>
        {
            new ThongTinSinhVien("Nguyen Van An", 20, 8.5),
            new ThongTinSinhVien("Tran Thi Binh", 21, 7.9),
            new ThongTinSinhVien("Hoang Van Viet", 19, 9.0),
            new ThongTinSinhVien("Le Thi Nhung", 22, 8.2)
        };

        return ds;
    }

    public static void ThemSinhVien(List<ThongTinSinhVien> danhSachSinhVien)
    {
        Console.WriteLine("\nThêm sinh viên mới:");
        Console.Write("Nhập tên sinh viên: ");
        string ten = Console.ReadLine();
        Console.Write("Nhập tuổi sinh viên: ");
        int tuoi = int.Parse(Console.ReadLine());
        Console.Write("Nhập điểm trung bình: ");
        double diemTrungBinh = double.Parse(Console.ReadLine());

        ThongTinSinhVien sinhVienMoi = new ThongTinSinhVien(ten, tuoi, diemTrungBinh);
        danhSachSinhVien.Add(sinhVienMoi);

        Console.WriteLine("Thêm sinh viên thành công!");
    }

    public static void HienThiDanhSachSinhVien(List<ThongTinSinhVien> danhSachSinhVien)
    {
        Console.WriteLine("\nDanh sách sinh viên:");
        foreach (ThongTinSinhVien sinhVien in danhSachSinhVien)
        {
            Console.WriteLine(sinhVien);
        }
    }

    public static void TimKiemSinhVienTheoTen(List<ThongTinSinhVien> danhSachSinhVien)
    {
        Console.Write("\nNhập tên sinh viên cần tìm kiếm: ");
        string tenCanTim = Console.ReadLine();

        bool timThay = false;
        foreach (ThongTinSinhVien sinhVien in danhSachSinhVien)
        {
            if (sinhVien.Ten.Equals(tenCanTim))
            {
                Console.WriteLine("Thông tin sinh viên cần tìm:");
                Console.WriteLine(sinhVien);
                timThay = true;
                break;
            }
        }

        if (!timThay)
        {
            Console.WriteLine("Không tìm thấy sinh viên có tên này.");
        }
    }
}
