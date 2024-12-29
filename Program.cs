using System.Drawing;

namespace OdevNurettinBeratSahin
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Kaç öğrenci kaydetmek istiyorsunuz? ");
            int ogrenciSayisi;
            while (!int.TryParse(Console.ReadLine(), out ogrenciSayisi) || ogrenciSayisi <= 0)
            {
                Console.WriteLine("Lütfen 0'dan büyük geçerli bir sayı girin!");
                Console.Write("Kaç öğrenci kaydetmek istiyorsunuz? ");
            }

            string[,] ogrenciBilgileri = new string[ogrenciSayisi, 7]; 
            double[] ortalamalar = new double[ogrenciSayisi];
            double sınıfOrt = 0;
            double endusuknotvize = 101;
            double enyukseknotvize = -1;
            double endusuknotfinal = 101;
            double enyukseknotfinal = -1;

            try
            {
                for (int i = 0; i < ogrenciSayisi; i++)
                {
                    Console.WriteLine($"\n{i + 1}. Öğrenci bilgilerini girin:");

                    int ogrenciNo;
                    Console.Write("Öğrenci No: ");
                    while (!int.TryParse(Console.ReadLine(), out ogrenciNo) || ogrenciNo <= 0)
                    {
                        Console.WriteLine("Lütfen 0'dan büyük geçerli bir sayı girin!");
                        Console.Write("Öğrenci No: ");
                    }
                    ogrenciBilgileri[i, 0] = ogrenciNo.ToString();

                    Console.Write("Ad: ");
                    while (true)
                    {
                        string ad = Console.ReadLine();
                        if (double.TryParse(ad, out _))
                        {
                            Console.WriteLine("Lütfen sayısal bir değer girmeyin. Adınızı tekrar girin!");
                        }
                        else
                        {
                            ogrenciBilgileri[i, 1] = ad;
                            break;
                        }
                    }

                    Console.Write("Soyad: ");
                    while (true)
                    {
                        string soyad = Console.ReadLine();
                        if (double.TryParse(soyad, out _))
                        {
                            Console.WriteLine("Lütfen sayısal bir değer girmeyin. Soyadınızı tekrar girin!");
                        }
                        else
                        {
                            ogrenciBilgileri[i, 2] = soyad;
                            break;
                        }
                    }

                    double vizeNotu;
                    Console.Write("Vize Notu (0-100): ");
                    while (!double.TryParse(Console.ReadLine(), out vizeNotu) || vizeNotu < 0 || vizeNotu > 100)
                    {
                        Console.WriteLine("Vize notu 0 ile 100 arasında ve sayısal olmalıdır!");
                        Console.Write("Vize Notu (0-100): ");
                    }
                    ogrenciBilgileri[i, 3] = vizeNotu.ToString();

                    double finalNotu;
                    Console.Write("Final Notu (0-100): ");
                    while (!double.TryParse(Console.ReadLine(), out finalNotu) || finalNotu < 0 || finalNotu > 100)
                    {
                        Console.WriteLine("Final notu 0 ile 100 arasında ve sayısal olmalıdır!");
                        Console.Write("Final Notu (0-100): ");
                    }
                    ogrenciBilgileri[i, 4] = finalNotu.ToString();

                    double ortalama = (vizeNotu * 0.4) + (finalNotu * 0.6);
                    ogrenciBilgileri[i, 5] = ortalama.ToString("F2");
                    ortalamalar[i] = ortalama;
                    if (ortalama >= 85)
                    {
                        ogrenciBilgileri[i, 6] = " - AA";
                    }
                    else if (ortalama >= 75)
                    {
                        ogrenciBilgileri[i, 6] = " - BA";
                    }
                    else if (ortalama >= 60)
                    {
                        ogrenciBilgileri[i, 6] = " - BB";
                    }
                    else if (ortalama >= 50)
                    {
                        ogrenciBilgileri[i, 6] = " - CB";
                    }
                    else if (ortalama >= 40)
                    {
                        ogrenciBilgileri[i, 6] = " - CC";
                    }
                    else if (ortalama >= 30)
                    {
                        ogrenciBilgileri[i, 6] = " - DC";
                    }
                    else if (ortalama >= 20)
                    {
                        ogrenciBilgileri[i, 6] = " - DD";
                    }
                    else if (ortalama >= 10)
                    {
                        ogrenciBilgileri[i, 6] = " - FD";
                    }
                    else
                    {
                        ogrenciBilgileri[i, 6] = " - FF";
                    }
                    sınıfOrt += ortalama;

                    if (vizeNotu < endusuknotvize)
                    {
                        endusuknotvize = vizeNotu;
                    }
                    if (vizeNotu > enyukseknotvize)
                    {
                        enyukseknotvize = vizeNotu;
                    }
                    if (finalNotu < endusuknotfinal)
                    { 
                        endusuknotfinal = finalNotu;
                    }
                    if (finalNotu > enyukseknotfinal)
                    {
                        enyukseknotfinal = finalNotu;
                    }
                }

                sınıfOrt /= ogrenciSayisi;
            }
            catch (Exception)
            {
                Console.WriteLine("Bilinmeyen bir hata oluştu");
                throw;
            }

            try
            {
                Console.WriteLine("\n\nKaydedilen Öğrenciler:");
                Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("{0,-10}{1,-30}{2,-30}{3,-10}{4,-10}{5,-20}{6,-10}", "No", "Ad", "Soyad", "Vize", "Final", "Ortalama", "Harf Notu");
                Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------");

                for (int i = 0; i < ogrenciSayisi; i++)
                {
                    Console.WriteLine("{0,-10}{1,-30}{2,-30}{3,-10}{4,-10}{5,-20}{6,-10}", ogrenciBilgileri[i, 0], ogrenciBilgileri[i, 1], ogrenciBilgileri[i, 2], ogrenciBilgileri[i, 3], ogrenciBilgileri[i, 4], ogrenciBilgileri[i, 5], ogrenciBilgileri[i, 6]);
                }

                double enDusukOrt = ortalamalar.Min();
                double enYuksekOrt = ortalamalar.Max();

                Console.WriteLine($"\nSınıf Ortalaması: {sınıfOrt:F2}");
                Console.WriteLine($"En düşük vize notu: {endusuknotvize}");
                Console.WriteLine($"En yüksek vize notu: {enyukseknotvize}");
                Console.WriteLine($"En düşük final notu: {endusuknotfinal}");
                Console.WriteLine($"En yüksek final notu: {enyukseknotfinal}");
                Console.WriteLine($"En düşük ortalama: {enDusukOrt:F2}");
                Console.WriteLine($"En yüksek ortalama: {enYuksekOrt:F2}");
            }
            catch (Exception)
            {
                Console.WriteLine("Bilinmeyen bir hata oluştu.");
                throw;
            }
        }
    }
}









