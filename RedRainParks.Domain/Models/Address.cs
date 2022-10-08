﻿namespace RedRainParks.Domain.Models
{
    public class Address
    {
        public string StreetLine1 { get; set; } = string.Empty;

        public string StreetLine2 { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public string State { get; set; }

        public string PostalCode { get; set; } = string.Empty;

        public Address(string? streetLine1, string? streetLine2, string? city, string? state, string? postalCode)
        {
            StreetLine1 = streetLine1 ?? string.Empty;
            StreetLine2 = streetLine2 ?? string.Empty;
            PostalCode = postalCode ?? string.Empty;
            City = city ?? string.Empty;
            State = state ?? string.Empty;
        }       
    }
}