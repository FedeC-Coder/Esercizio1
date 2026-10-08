using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace BlaisePascal.Esercizio1.Domain
{
    /// <summary>
    /// Ogni veicolo è caratterizzato da:                                                                               # Attributi e proprietà
    /// Una targa(LicensePlate)                                                                                         √
    /// Il chilometraggio attuale(OdometerKm)                                                                           √
    /// La tariffa giornaliera di noleggio(DailyRate)                                                                   √
    /// Il livello percentuale di carburante nel serbatoio(FuelLevelPercentage)                                         √
    /// Il Modello deve:                                                                                                # Fuzioni e validazioni
    /// Impedire la creazione di veicoli con valori incoerenti(es.targa non valida, chilometri o tariffe negative).     √
    /// Permetta di registrare i viaggi effettuati, incrementando il chilometraggio e riducendo il carburante residuo.  √
    /// Consentire di effettuare il rifornimento fino a un massimo del 100 % della capienza del serbatoio.
    /// </summary>
    public class Vehicle
    {
        // Attributi interni
        private int _actualKm;
        private double _dailyRate;
        private double _fuelPercentage;

        // Proprietà
        public string Plate { 
            get;
            private set {
                require(value.Length == 7);
                require(validatePlate(value));
            } 
        }
        public int ActualKms { 
            get { return _actualKm; } 
            private set {
                require(value >= 0);
                _actualKm = value;
            } 
        }

        public double DailyRate
        {
            get { return _dailyRate; }
            private set
            {
                require(value >= 0);
                _dailyRate = value;
            }
        }

        public double FuelPercentage
        {
            get { return _fuelPercentage; }
            private set
            {
                require(value >= 0);
                _fuelPercentage = value;
            }
        }

        // Costruttore 1
        public Vehicle(string plate, int actualKms, double dailyRate, double fuelPercentage) {
            Plate = plate.ToUpper();
            ActualKms = actualKms;
            DailyRate = dailyRate;
            FuelPercentage = fuelPercentage;

        }

        // Costruttore 2 (overload)
        public Vehicle(string plate)
        {
            Plate = plate.ToUpper();
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
        public void recordDataTrip(int kmDone, double fuelPercentageUsed)
        {
            require(kmDone > 0 && fuelPercentageUsed > 0);
            ActualKms += kmDone;
            FuelPercentage -= fuelPercentageUsed;
        }

        // Funzione per il rifornmento
        public void refill(int toPercentage) {
            require(FuelPercentage < toPercentage);
            require(toPercentage >= 0 && toPercentage<=100);
            FuelPercentage = toPercentage;
        }
    }
}
