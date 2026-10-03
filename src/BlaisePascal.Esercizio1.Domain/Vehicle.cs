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
        // Properietà
        private int _actualKm;
        private double _dailyRate;
        private double _fuelPercentage;
        public string plate { get; private set; }
        public int actualKms { get { return _actualKm; } private set; }
        public double dailyRate { get { return _dailyRate;  } private set; }
        public double fuelPercentage { get { return _fuelPercentage; } private set; }

        // Costruttore
        public Vehicle(string plateV, int actualKmsV, double dailyRateV, double fuelPercentageV) {
            require(plateV.Length == 7);
            require(validatePlate(plateV));
            plate = plateV.ToUpper();
            require(actualKmsV >= 0);
            actualKms = actualKmsV;
            require(dailyRateV >= 0);
            dailyRate = dailyRateV;
            require(fuelPercentageV >= 0);
            fuelPercentage = fuelPercentageV;

        }

        public Vehicle(string plateV)
        {
            require(plateV.Length == 7);
            require(validatePlate(plateV));
        }

        // Require (aggiuntivo)
        private void require(bool value)
        {
            if (!value)
            {
                throw new ArgumentException();
            }
        }

        // Validatore di targa (aggiuntivo)
        public bool validatePlate(string plate)
        {
            return Regex.IsMatch(plate.ToUpper(), @"^[A-Z]{2}\d{3}[A-Z]{2}$");
        }

        // Registra i dati di viaggio
        public void recordDataTrip(int kms, double tripDailyRate, double tripFuelPercentage)
        {
            require(kms >= 0);
            actualKms = kms;
            require(tripDailyRate >= 0);
            dailyRate = tripDailyRate;
            require(tripFuelPercentage >= 0);
            fuelPercentage = tripFuelPercentage;
        }

        // Funzione per il rifornmento
        public void refill(int toPercentage) {
            require(fuelPercentage < toPercentage);
            require(toPercentage >= 0 && toPercentage<=100);
            fuelPercentage = toPercentage;
        }
    }
}
