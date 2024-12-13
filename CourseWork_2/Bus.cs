using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CourseWork_2
{
    public class Bus
    {
        public string BoardNumber { get; set; }
        public string Brand { get; set; }
        public string RouteNumber { get; set; }
    }

    public class BusData
    {
        public List<Bus> Buses { get; set; } = new List<Bus>();

        public static BusData LoadFromJson(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return new BusData(); 
            }

            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<BusData>(json);
        }

        public void SaveToJson(string filePath)
        {
            string json = JsonConvert.SerializeObject(this, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        public void AddBus(Bus newBus)
        {
            if (!Buses.Any(b => b.BoardNumber == newBus.BoardNumber))
            {
                Buses.Add(newBus);
            }
            else
            {
                throw new InvalidDataException("јвтобус с таким бортовым номером уже существует.");
            }
        }

        public void RemoveBus(string boardNumber)
        {
            var busToRemove = Buses.FirstOrDefault(b => b.BoardNumber == boardNumber);
            if (busToRemove != null)
            {
                Buses.Remove(busToRemove);
            }
            else
            {
                throw new KeyNotFoundException("јвтобус с указанным бортовым номером не найден.");
            }
        }

        public void UpdateBus(string boardNumber, string newBrand, string newRouteNumber)
        {
            var busToUpdate = Buses.FirstOrDefault(b => b.BoardNumber == boardNumber);
            if (busToUpdate != null)
            {
                busToUpdate.Brand = newBrand;
                busToUpdate.RouteNumber = newRouteNumber;
            }
            else
            {
                throw new KeyNotFoundException("јвтобус с указанным бортовым номером не найден.");
            }
        }

        public Bus GetBusByBoardNumber(string boardNumber)
        {
            return Buses.FirstOrDefault(b => b.BoardNumber == boardNumber);
        }

        public List<Bus> GetBusesByBrand(string brand)
        {
            return Buses.Where(b => b.Brand == brand).ToList();
        }

        public List<Bus> GetBusesByRoute(string routeNumber)
        {
            return Buses.Where(b => b.RouteNumber == routeNumber).ToList();
        }
    }
}
