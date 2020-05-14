using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZealandDrive.Fuck
{
    class Car
    {
        private int _id;
        private int _userId;

        public string Color { get => Color; set => Color = value; }

    
        public string Brand { get => Brand; set => Brand = value; }

    
        public string Model { get => Model; set => Model = value; }

   
        public int Year { get => Year; set => Year = value; }
   
        public int Seats{ get => Seats; set => Seats = value; }
       

   
        public Car()
        {

    
        }

   
        public Car(int id, string color, string brand, string model, int seats, int userId)
  
        {
            Color = color;
        Brand = brand;
        Model = model;
        Seats = seats;
   
        }

  
        public override string ToString()
   
        {
            return $"Id = {_id}, color = {Color}, brand = {Brand}, model = {Model}, year = {Year}, seats = {Seats}, userId = {_userId}";

        }
    }
}
