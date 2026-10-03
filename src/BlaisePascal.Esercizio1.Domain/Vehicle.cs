using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace BlaisePascal.Esercizio1.Domain
{
    /* Veicolo
ATTRIBUTI O PROPRIETA' 
    ID
    TARGA
    KM ATTUALE
    TARIFFA GIORNALIERA
    LIVELLO DI CARBURANTE ATTUALE DI PERCENTUALE

METODI
    REGISTRARE DATI VIAGGIO
        \- AGGIORNARE I DATI DEL VEICOLO
    FARE RIFORNIMENTO
        \- AUMENTO DI UNA CERTA PERCENTUALE
*/
    public class Vehicle
    {
        private int _id;
        private string _plate;
        private int _actualKms;
        private double _dailyRate;
        private double _fuelPercentage;

        // Get plate
        public string getLicensePlate()
        {
            return _plate;
        }

        // Constructor
        public Vehicle(int id, string plate, int actualKms, double dailyRate, double fuelPercentage) {
            
            require(id>=0);
            _id = id;

            require(plate.Length==7);
            require(validatePlate(plate));
            _plate = plate.ToUpper();

            require(actualKms>=0);
            _actualKms = actualKms;

            require(dailyRate >= 0);
            _dailyRate = dailyRate;

            require(fuelPercentage >= 0);
            _fuelPercentage = fuelPercentage;

        }

        // Require function. Like kotlin.
        private void require(bool value)
        {
            if (!value)
            {
                throw new ArgumentException();
            }
        }

        // Plate validator plate
        public bool validatePlate(string plate)
        {
            return Regex.IsMatch(plate.ToUpper(), @"^[A-Z]{2}\d{3}[A-Z]{2}$");
        }
    }
}
