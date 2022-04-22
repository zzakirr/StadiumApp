using StadiumApp.Data.DAL;
using StadiumApp.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StadiumApp
{
    internal class Program
    {
       
        static void Main(string[] args)
        {
            StadiumsDbContext dbContext = new StadiumsDbContext();
            string answer;
            do
            {
                Console.WriteLine("======MENU======");
                Console.WriteLine("1. Stadion elave et\n2.Stadionları göster\n3.Verilmiş id - li stadionu göster\n4.Verilmiş id - li stadionu sil\n5.İstifadeçi elave et\n6.İstifadeçileri göster\n7.Rezervasiya yarat\n8.Rezervasiyalari goster\n9.Verilmiş id - li stadionun rezervasiyalarını göster\n0.Proqramdan cix");
                Console.WriteLine("seciminizi edin:");
                answer = Console.ReadLine();
                switch (answer)
                {
                    case "1":
                        Console.WriteLine("stadionun adini daxil edin: ");
                        string name = Console.ReadLine();
                        Console.WriteLine("stadionun saatliq qiymetini daxil edin: ");
                        decimal hourlyPrice = GetDecimal();
                        Console.WriteLine("stadionun capacity'sini daxil edin: ");
                        byte capacity = GetByte();
                        Stadiums stadion = new Stadiums()
                        {
                            Name = name,
                            HourlyPrice = hourlyPrice,
                            Capacity = capacity
                        };
                        dbContext.Stadiums.Add(stadion);
                        dbContext.SaveChanges();
                        break;
                    case "2":
                        List<Stadiums> data = dbContext.Stadiums.ToList();
                        foreach (var item in data)
                        {
                            Console.WriteLine($"id: {item.Id} - name: {item.Name} - capacity: {item.Capacity} - hourlyPrice: {item.HourlyPrice}");
                        }
                        break;
                    case "3":
                        Console.WriteLine("id daxil edin: ");
                        int id = GetInt();
                        var result = dbContext.Stadiums.Find(id);
                        if (result != null)
                        {
                            Console.WriteLine($"id: {result.Id} - name: {result.Name} - capacity: {result.Capacity} - hourlyPrice: {result.HourlyPrice}");
                        }
                        else
                        {
                            Console.WriteLine($"bu id'li stadion yoxdur");
                        }
                        break;
                    case "4":
                        Console.WriteLine("id daxil edin: ");
                        int idForRemove = GetInt();
                        var dataForRemove = dbContext.Stadiums.Find(idForRemove);
                        if (dataForRemove != null)
                        {
                            dbContext.Stadiums.Remove(dataForRemove);
                        }
                        dbContext.SaveChanges();
                        break;
                    case "5":
                        Console.WriteLine("userin adini ve soyadini daxil edin: ");
                        string fullname = Console.ReadLine();
                        Console.WriteLine("userin emailini daxil edin: ");
                        string email = Console.ReadLine();
                        Users user = new Users()
                        {
                            Fullname = fullname,
                            Email = email
                        };
                        dbContext.Users.Add(user);
                        dbContext.SaveChanges();
                        break;
                    case "6":
                        List<Users> userData = dbContext.Users.ToList();
                        foreach (var item in userData)
                        {
                            Console.WriteLine($"id: {item.Id} - fullname: {item.Fullname} - email: {item.Email}");
                        }
                        break;
                    case "7":

                        Console.WriteLine("reservasiyanin baslama saatini daxil edin: ");
                        DateTime startDate = GetDatetime();
                        Console.WriteLine("reservasiyanin bitme saatini daxil edin: ");
                        DateTime endDate = GetDatetime();
                        Console.WriteLine("stadionId daxil edin: ");
                        int stadionId = GetStadionId(dbContext);
                        Console.WriteLine("userId daxil edin: ");
                        int userId = GetUserId(dbContext);
                        Reservations reservation = new Reservations()
                        {
                            StadionId = stadionId,
                            UserId = userId,
                            StartDate = startDate,
                            EndDate = endDate
                        };
                        dbContext.Reservations.Add(reservation);
                        dbContext.SaveChanges();
                        break;
                    case "8":
                        List<Reservations> reservations = dbContext.Reservations.ToList();
                        foreach (var item in reservations)
                        {
                            Console.WriteLine($"userId: {item.UserId} - stadionId: {item.StadionId} - startdate: {item.StartDate} - enddate: {item.EndDate}");
                        }
                        break;
                    case "9":
                        Console.WriteLine("istediyiniz stadionun id'sini daxil edin: ");
                        int stadionIdForSearch = GetStadionId(dbContext);
                        List<Reservations> stadionReserv = dbContext.Reservations.Where(x => x.StadionId == stadionIdForSearch).ToList();
                        foreach (var item in stadionReserv)
                        {
                            Console.WriteLine($"userId: {item.UserId} - stadionId: {item.StadionId} - startdate: {item.StartDate} - enddate: {item.EndDate}");
                        }
                        break;
                    case "0":
                        Console.WriteLine("proqram bitdi");
                        break;
                    default:
                        Console.WriteLine("menuda bele secim yoxdur");
                        break;
                }
            } while (answer != "0");
        }

        static decimal GetDecimal()
        {
            string decStr = Console.ReadLine();
            decimal dec;
            while (!decimal.TryParse(decStr, out dec))
            {
                Console.WriteLine("eded daxil edin");
                decStr = Console.ReadLine();
            }
            return dec;
        }
        static int GetInt()
        {
            string intStr = Console.ReadLine();
            int number;
            while (!int.TryParse(intStr, out number))
            {
                Console.WriteLine("eded daxil edin");
                intStr = Console.ReadLine();
            }
            return number;
        }
        static byte GetByte()
        {
            string byteStr = Console.ReadLine();
            byte number;
            while (!byte.TryParse(byteStr, out number))
            {
                Console.WriteLine("eded daxil edin");
                byteStr = Console.ReadLine();
            }
            return number;
        }
        static DateTime GetDatetime()
        {
            string dateTimeStr = Console.ReadLine();
            DateTime date;
            while (!DateTime.TryParse(dateTimeStr, out date))
            {
                Console.WriteLine("tarix daxil edin");
                dateTimeStr = Console.ReadLine();
            }
            return date;
        }

        static int GetStadionId(StadiumsDbContext dbContext)
        {
            int id = GetInt();
            while (dbContext.Stadiums.Find(id) == null)
            {
                Console.WriteLine("bu id'de stadion yoxdur. Yeni deyer daxil edin");
                id = GetInt();
            }
            return id;
        }
        static int GetUserId(StadiumsDbContext dbContext)
        {
            int id = GetInt();
            while (dbContext.Users.Find(id) == null)
            {
                Console.WriteLine("bu id'de user yoxdur. Yeni deyer daxil edin");
                id = GetInt();
            }
            return id;
        }

    }
}
