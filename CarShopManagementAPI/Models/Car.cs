﻿namespace CarShopManagementAPI.Models
{
    public class Car
    {
        public Guid Id { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public int Year { get; set; }
        public int Mileage { get; set; }
        public string? LicensePlate { get; set; }
    }
}
