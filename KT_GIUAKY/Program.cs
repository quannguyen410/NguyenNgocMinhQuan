using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KT_GIUAKY
{
    class GiangVien
    {
        public string MaSo { get; set; }
        public string HoTen { get; set; }
        public int NamSinh { get; set; }
        public GiangVien() { }
        public GiangVien (string maso, 
                          string hoten,
                          int namsinh)
        {
            MaSo = maso;
            HoTen = hoten;
            NamSinh = namsinh;
        }

        public virtual void Nhap()
        {
            Console.Write("Nhập mã số: ");
            MaSo = Console.ReadLine();
            Console.Write("Nhập họ tên: ");
            HoTen = Console.ReadLine();
            Console.Write("Nhập năm sinh: ");
            NamSinh = int.Parse(Console.ReadLine());
        }

        public virtual int tinhluong()
        {
            return 0;
        }
    }

    class GiangVienCH : GiangVien
    {
        public float HeSoLuong { get; set; }
        public GiangVienCH() { }
        public GiangVienCH(string maso, string hoten, int namsinh, float hesoluong)
        {
            HeSoLuong = hesoluong;
        }
        public override void Nhap()
        {
            base.Nhap();
            Console.Write("Nhập hệ số lương: ");
            HeSoLuong = float.Parse(Console.ReadLine());
        }
        public override int tinhluong()
        {
            return base.tinhluong()+(int) (HeSoLuong*234000);
        }
    }

    class GiangVienTG : GiangVien
    {
        public int SoTietDay { get; set; }
        public GiangVienTG() { }
        public GiangVienTG(string maso, string hoten, int namsinh, int sotietday)
        {
            SoTietDay = sotietday;
        }
        public override void Nhap()
        {
            base.Nhap();
            Console.Write("Nhập số tiết dạy: ");
            SoTietDay = int.Parse(Console.ReadLine());
        }
        public override int tinhluong()
        {
            return base.tinhluong()+SoTietDay*120000;
        }

    }

    class QuanLyGV
    {
        public List<GiangVien> dsGV = new List<GiangVien>();
        public QuanLyGV() { }
        public void NhapDS()
        {
            Console.Write("Nhập số lượng giáo viên: ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i<n; i++)
            {
                Console.WriteLine($"Nhập giảng viên {i + 1}: ");
                Console.Write("Chọn loại(1-Giảng viên cơ hữu, 2-Giảng viên thỉnh giảng): ");
                int loai = int.Parse(Console.ReadLine());
                GiangVien gv;
                if (loai==1)
                {
                    gv = new GiangVienCH();
                }    
                else
                {
                    gv = new GiangVienTG();
                }
                gv.Nhap();
                dsGV.Add(gv);
            }    
        }
        public void XuatDS()
        {
            Console.WriteLine("Danh sách giảng viên: ");
            foreach (var gv in dsGV)
            {
                Console.WriteLine(gv);
            }    
        }
        public int tinhtongluong()
        {
            int tongluong = 0;
            foreach (var gv in dsGV)
            {
                tongluong += gv.tinhluong();
            }
            return tongluong;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            QuanLyGV qlgv = new QuanLyGV();
            int chon;
            do
            {
                Console.WriteLine("QUẢN LÝ GIẢNG VIÊN");
                Console.WriteLine("1.Nhập danh sách giảng viên");
                Console.WriteLine("2.Hiển thị danh sách giảng viên");
                Console.WriteLine("3.Tính tổng tiền lương");
                Console.WriteLine("0.Thoát");
                Console.Write("Chọn chức năng:");
                chon = int.Parse(Console.ReadLine());

                switch (chon)
                {
                    case 1:
                        qlgv.NhapDS();
                        break;
                    case 2:
                        qlgv.XuatDS();
                        break;
                    case 3:
                        Console.WriteLine($"Tổng tiền lương: {qlgv.tinhtongluong()}");
                        break;
                    case 0:
                        Console.WriteLine("Thoát chương trình");
                        break;
                    default:
                        Console.WriteLine("Chọn sai! Vui lòng chọn lại.");
                        break;
                }

            } while (chon != 0);
        }
    }
}
