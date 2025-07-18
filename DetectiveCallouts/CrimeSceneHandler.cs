using Rage;
using System.Collections.Generic;
using System.IO;

namespace DetectiveCallouts.Handlers
{
    internal static class CrimeSceneHandler
    {
        // Scene locations
        public static readonly Dictionary<string, Vector3> CrimeSceneLocations = new Dictionary<string, Vector3>()
        {
            { "SandyShores", new Vector3(1850.0f, 3680.0f, 34.0f) },
            { "MountChilliad", new Vector3(-1500.0f, 5000.0f, 63.0f) },
            { "PaletoBay", new Vector3(-440.0f, 6040.0f, 31.0f) }
        };

        // Vehicle models from .ini
        public static string Vehicle1Model = Settings.PoliceVehicle1;
        public static string Vehicle2Model = Settings.PoliceVehicle2;
        public static string Vehicle3Model = Settings.PoliceVehicle3;
        public static string Vehicle4Model = Settings.PoliceVehicle4;

        // Vehicle references
        public static Vehicle vehicle1;
        public static Vehicle vehicle2;
        public static Vehicle vehicle3;
        public static Vehicle vehicle4;

        // Cop references
        public static Ped cop1;
        public static Ped cop2;
        public static Ped cop3;
        public static Ped cop4;
        public static Ped cop5;
        public static Ped cop6;
        public static Ped cop7;
        public static Ped cop8;


        public static void SpawnCrimeScene(string location)
        {
            if (location == "SandyShores")
            {
                // Vehicles
                vehicle1 = new Vehicle(Vehicle1Model, new Vector3(1848.0f, 3682.0f, 33.5f), 90f);
                vehicle2 = new Vehicle(Vehicle2Model, new Vector3(1846.0f, 3684.0f, 33.5f), 180f);
                vehicle3 = new Vehicle(Vehicle3Model, new Vector3(1844.0f, 3682.0f, 33.5f), 270f);
                vehicle4 = new Vehicle(Vehicle4Model, new Vector3(1846.0f, 3680.0f, 33.5f), 0f);

                // Cops
                cop1 = new Ped("s_m_y_cop_01", new Vector3(1849.0f, 3683.0f, 33.5f), 90f);
                cop2 = new Ped("s_m_y_cop_01", new Vector3(1847.0f, 3685.0f, 33.5f), 180f);
                cop3 = new Ped("s_m_y_cop_01", new Vector3(1846.0f, 3683.5f, 33.5f), 0f);
                cop4 = new Ped("s_m_y_cop_01", new Vector3(1845.0f, 3681.5f, 33.5f), 45f);
                cop5 = new Ped("s_m_y_cop_01", new Vector3(1847.5f, 3680.5f, 33.5f), 135f);
                cop6 = new Ped("s_m_y_cop_01", new Vector3(1848.0f, 3684.5f, 33.5f), 60f);
                cop7 = new Ped("s_m_y_cop_01", new Vector3(1844.5f, 3683.0f, 33.5f), 120f);
                cop8 = new Ped("s_m_y_cop_01", new Vector3(1846.5f, 3682.0f, 33.5f), 300f);

                // Vehicle setup
                vehicle1.IsPersistent = true; vehicle1.IsEngineOn = true; vehicle1.IsSirenOn = true;
                vehicle2.IsPersistent = true; vehicle2.IsEngineOn = true; vehicle2.IsSirenOn = true;
                vehicle3.IsPersistent = true; vehicle3.IsEngineOn = true; vehicle3.IsSirenOn = true;
                vehicle4.IsPersistent = true; vehicle4.IsEngineOn = true; vehicle4.IsSirenOn = true;

                // Cop setup
                cop1.IsPersistent = true; cop1.BlockPermanentEvents = true;
                cop2.IsPersistent = true; cop2.BlockPermanentEvents = true;
                cop3.IsPersistent = true; cop3.BlockPermanentEvents = true;
                cop4.IsPersistent = true; cop4.BlockPermanentEvents = true;
                cop5.IsPersistent = true; cop5.BlockPermanentEvents = true;
                cop6.IsPersistent = true; cop6.BlockPermanentEvents = true;
                cop7.IsPersistent = true; cop7.BlockPermanentEvents = true;
                cop8.IsPersistent = true; cop8.BlockPermanentEvents = true;
            }

            else if (location == "MountChilliad")
            {
                // Incorporate later
            }

            else if (location == "PaletoBay")
            {
                // Incorporate later
            }
        }

        public static void CreateMurderCase(string location)
        {
            if (!CrimeSceneLocations.ContainsKey(location)) return;
            Vector3 pos = CrimeSceneLocations[location];

            // Incorporate later
        }

        public static void CreateKidnappingCase(string location)
        {
            if (!CrimeSceneLocations.ContainsKey(location)) return;
            Vector3 pos = CrimeSceneLocations[location];

            // Incorporate later
        }

        public static void CreateRobberyCase(string location)
        {
            if (!CrimeSceneLocations.ContainsKey(location)) return;
            Vector3 pos = CrimeSceneLocations[location];
        }

        public static void CreateDrugSmugglingCase(string location)
        {
            if (!CrimeSceneLocations.ContainsKey(location)) return;
            Vector3 pos = CrimeSceneLocations[location];
        }
    }
}
