using System;
using System.Collections.Generic;
using System.Text;

internal class Sach
{
    public struct Thongtinsach
    {
        public string Tieude { get; set; }
        public string Tacgia { get; set; }
        public DateTime NamXB { get; set; }

        public Thongtinsach(string _tieude, string _tacgia, DateTime _namXB)
        {
            Tieude = _tieude;
            Tacgia = _tacgia;
            NamXB = _namXB;
        }

        public bool KiemTraThongTin()
        {
            if (string.IsNullOrEmpty(Tieude) || string.IsNullOrEmpty(Tacgia))
            {
                Console.WriteLine("Thông tin nhập vào không hợp lệ!");
                return false;
            }
            return true;
        }
    }

    public static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        List<Thongtinsach> dsSach = DanhSachthongtin();
        QuanLyThongTinSach(dsSach);
    }

    public static List<Thongtinsach> DanhSachthongtin()
    {
        List<Thongtinsach> ds = new List<Thongtinsach>
        {
            new Thongtinsach("Java", "Nguyen Anh", new DateTime(2012, 1, 1)),
            new Thongtinsach("Python", "Quang Huy", new DateTime(2013, 2, 2)),
            new Thongtinsach("SQL", "Minh Anh", new DateTime(2014, 3, 3)),
            new Thongtinsach("C#", "Van Tinh", new DateTime(2015, 4, 4))
        };

        return ds;
    }

    public static void QuanLyThongTinSach(List<Thongtinsach> ds)
    {
        Console.WriteLine("=================================Quản lý thông tin sách=====================");
        Console.WriteLine("1. Thêm sách");
        Console.WriteLine("2. Hiển thị danh sách");
        Console.WriteLine("3. Tìm sách");
        Console.WriteLine("4. Exit");

        int luaChon;
        do
        {
            Console.WriteLine("Nhập lựa chọn:");
            luaChon = int.Parse(Console.ReadLine());

            switch (luaChon)
            {
                case 1:
                    ThemSach(ds);
                    break;
                case 2:
                    HienThiDS(ds);
                    break;
                case 3:
                    TimSach(ds);
                    break;
                case 4:
                    Console.WriteLine("Exit!");
                    break;
                default:
                    Console.WriteLine("Lua chon khong hop le! Vui long chon lai");
                    break;
            }
        } while (luaChon != 4);
    }

    public static void ThemSach(List<Thongtinsach> ds)
    {
        Thongtinsach sachMoi = new Thongtinsach();
        Console.WriteLine("Nhập thông tin sách mới: ");
        Console.WriteLine("Nhập tiêu đề: ");
        sachMoi.Tieude = Console.ReadLine();
        Console.WriteLine("Nhập tác giả: ");
        sachMoi.Tacgia = Console.ReadLine();
        Console.WriteLine("Nhập năm xuất bản: ");
        sachMoi.NamXB = DateTime.Parse(Console.ReadLine());

        if (sachMoi.KiemTraThongTin())
        {
            ds.Add(sachMoi);
            Console.WriteLine("Thông tin sách đã được thêm!");
        }
    }

    public static void HienThiDS(List<Thongtinsach> ds)
    {
        Console.WriteLine("Hiển thị danh sách: ");
        foreach (var sach in ds)
        {
            Console.WriteLine($"Tiêu đề: {sach.Tieude}, Tác giả: {sach.Tacgia}, Năm xuất bản: {sach.NamXB:yyyy}");
        }
    }

    public static void TimSach(List<Thongtinsach> ds)
    {
        Console.Write("Nhập tiêu đề sách mà bạn cần tìm kiếm: ");
        string search = Console.ReadLine();
        int k = 0;
        for (int i = 0; i < ds.Count; i++)
        {
            if (ds[i].Tieude.Equals(search))
            {
                Console.WriteLine($"Tiêu đề: {ds[i].Tieude}, Tác giả: {ds[i].Tacgia}, Năm xuất bản: {ds[i].NamXB:yyyy}");
                k++;
            }
        }
        if (k == 0)
            Console.WriteLine("Không tìm thấy sách nào có tiêu đề trên!!!");
    }

}
