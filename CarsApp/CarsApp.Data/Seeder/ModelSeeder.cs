namespace CarsApp.Data.Seeder
{
    using Models;

    using System.Linq;
    using System.Collections.Generic;

    public class ModelSeeder : ISeeder
    {
        private readonly CarsDbContext _data;
        private Dictionary<string, IEnumerable<string>> models;

        public ModelSeeder(CarsDbContext data) => _data = data;

        public void Seed()
        {
            if (_data.Models.Any())
            {
                return;
            }

            this.FillModels();
            this.SeedData();
        }

        private void SeedData()
        {
            var models = new List<Model>();

            foreach (KeyValuePair<string, IEnumerable<string>> element in this.models)
            {
                var brand = _data.Brands.Where(t => t.Title == element.Key).FirstOrDefault();

                if (brand == null)
                {
                    continue;
                }

                foreach (var model in element.Value)
                {
                    var newModel = new Model()
                    {
                        Title = model,
                        Brand = brand
                    };

                    models.Add(newModel);
                }
            }

            _data.Models.AddRange(models);
            _data.SaveChanges();
        }

        private void FillModels()
        {
            this.models = new Dictionary<string, IEnumerable<string>>();

            models.Add("Volkswagen", new List<string>()
            {
                "Arteon",
                "Arteon R-line",
                "Beetle",
                "Cabrio",
                "Cabriolet",
                "CC",
                "Corrado",
                "Dasher",
                "Eos",
                "Eurovan",
                "Fox",
                "GLI",
                "Golf R",
                "GTI",
                "Golf",
                "Rabbit",
                "Jetta",
                "Passat",
                "Phaeton",
                "Pickup",
                "Quantum",
                "R32",
                "Routan",
                "Scirocco",
                "Tiguan",
                "Touareg",
                "Vanagon"
            });

            models.Add("Mercedes-Benz", new List<string>()
            {
                "190D",
                "190E",
                "240D",
                "300CD",
                "300CE",
                "300D",
                "300E",
                "300TD",
                "300TE",
                "C220",
                "C230",
                "C240",
                "C250",
                "C280",
                "C300",
                "C320",
                "C32 AMG",
                "C350",
                "C36 AMG",
                "C43 AMG",
                "C55 AMG",
                "C63 AMG",
                "CL500",
                "CL550",
                "CL55 AMG",
                "CL600",
                "CL63 AMG",
                "CL65 AMG",
                "CLK320",
                "CLK350",
                "CLK430",
                "CLK500",
                "CLK550",
                "CLK55 AMG",
                "CLK63 AMG",
                "CLS500",
                "CLS550",
                "CLS55 AMG",
                "CLS63 AMG",
                "260E",
                "280CE",
                "280E",
                "400E",
                "500E",
                "E300",
                "E320",
                "E320 Bluetec",
                "E320 CDI",
                "E350",
                "E350 Bluetec",
                "E400 Hybrid",
                "E420",
                "E430",
                "E500",
                "E550",
                "E55 AMG",
                "E63 AMG",
                "G500",
                "G550",
                "G55 AMG",
                "G63 AMG",
                "GL320 Bluetec",
                "GL320 CDI",
                "GL350 Bluetec",
                "GL450",
                "GL550",
                "GLK350",
                "ML320",
                "ML320 Bluetec",
                "ML320 CDI",
                "ML350",
                "ML350 Bluetec",
                "ML430",
                "ML450 Hybrid",
                "ML500",
                "ML550",
                "ML55 AMG",
                "ML63 AMG",
                "R320 Bluetec",
                "R320 CDI",
                "R350",
                "R350 Bluetec",
                "R500",
                "R63 AMG",
                "300SD",
                "300SDL",
                "300SE",
                "300SEL",
                "350SD",
                "350SDL",
                "380SE",
                "380SEC",
                "380SEL",
                "400SE",
                "400SEL",
                "420SEL",
                "500SEC",
                "500SEL",
                "560SEC",
                "560SEL",
                "600SEC",
                "600SEL",
                "S320",
                "S350",
                "S350 Bluetec",
                "S400 Hybrid",
                "S420",
                "S430",
                "S500",
                "S550",
                "S55 AMG",
                "S600",
                "S63 AMG",
                "S65 AMG",
                "300SL",
                "380SL",
                "380SLC",
                "500SL",
                "560SL",
                "600SL",
                "SL320",
                "SL500",
                "SL550",
                "SL55 AMG",
                "SL600",
                "SL63 AMG",
                "SL65 AMG",
                "SLK230",
                "SLK250",
                "SLK280",
                "SLK300",
                "SLK320",
                "SLK32 AMG",
                "SLK350",
                "SLK55 AMG",
                "SLR",
                "SLS AMG",
                "Sprinter"
            });

            models.Add("BMW", new List<string>()
            {
                "114",
                "116",
                "118",
                "120",
                "123",
                "125",
                "128",
                "130",
                "135",
                "216",
                "218",
                "220",
                "228",
                "316",
                "318",
                "320",
                "323",
                "324",
                "325",
                "328",
                "330",
                "335",
                "340",
                "418",
                "420",
                "428",
                "430",
                "435",
                "435i",
                "518",
                "520",
                "523",
                "524",
                "525",
                "528",
                "530",
                "535",
                "540",
                "545",
                "550",
                "630",
                "633",
                "635",
                "640",
                "645",
                "650",
                "725",
                "728",
                "730",
                "735",
                "740",
                "745",
                "750",
                "750IL",
                "760",
                "840",
                "850",
                "Active Hybrid 7",
                "i3",
                "i8",
                "M135i",
                "M2",
                "M3",
                "M4",
                "M5",
                "M6",
                "X5 M",
                "X6 M",
                "X1",
                "X2",
                "X3",
                "X4",
                "X5",
                "X6",
                "X7",
                "Z3",
                "Z4"
            });

            models.Add("Audi", new List<string>()
            {
                "100",
                "200",
                "80",
                "90",
                "A1",
                "A1 Sportback",
                "A2",
                "A3",
                "A3 Sportback",
                "A4",
                "A4 Allroad",
                "A4 Avant",
                "A5",
                "A5 Sportback",
                "A6",
                "A6 Allroad",
                "A6 Avant",
                "A7",
                "A7 Sportback",
                "A8",
                "Allroad",
                "E-tron",
                "Q2",
                "Q3",
                "Q3 Sportback",
                "Q5",
                "Q5 Sportback",
                "Q7",
                "Q8",
                "R8",
                "RS3",
                "RS3 Sportback",
                "RS4",
                "RS5",
                "RS6",
                "RS6 Avant",
                "RS7",
                "RS7 Sportback",
                "RSQ8",
                "S2",
                "S3",
                "S3 Sportback",
                "S4",
                "S5",
                "S5 Sportback",
                "S6",
                "S7",
                "S7 Sportback",
                "S8",
                "SQ5",
                "SQ7",
                "SQ8",
                "TT",
                "TT Roadster"
            });

            models.Add("Opel", new List<string>()
            {
                "Adam",
                "Admiral",
                "Agila",
                "Ampera",
                "Antara",
                "Arena",
                "Ascona",
                "Astra",
                "Calibra",
                "Campo",
                "Combo",
                "Corsa",
                "Crossland X",
                "Frontera",
                "Grandland X",
                "GT",
                "Insignia",
                "Kadett",
                "Karl",
                "Manta",
                "Meriva",
                "Mokka",
                "Monterey",
                "New Meriva",
                "Omega",
                "Rekord",
                "Senator",
                "Signum",
                "Sintra",
                "Tigra",
                "Vectra",
                "Vivaro",
                "Zafira",
                "Zafira Tourer"
            });

            models.Add("Peugeot", new List<string>()
            {
                "1007",
                "104",
                "106",
                "107",
                "108",
                "2008",
                "205",
                "206",
                "206 CC",
                "206 Plus",
                "207",
                "207 CC",
                "207 SW",
                "208",
                "3008",
                "301",
                "305",
                "306",
                "307",
                "307 CC",
                "307 SW",
                "308",
                "308 CC",
                "308 SW",
                "309",
                "4007",
                "4008",
                "404",
                "405",
                "406",
                "407",
                "5008",
                "504",
                "505",
                "508",
                "508 RXH",
                "508 SW",
                "604",
                "605",
                "607",
                "806",
                "807",
                "Bipper",
                "Boxer",
                "Expert",
                "iOn",
                "Partner",
                "Ranch",
                "RCZ",
                "Rifter",
                "Traveller"
            });

            models.Add("Renault", new List<string>()
            {
                "11",
                "18",
                "19",
                "21",
                "25",
                "4",
                "5",
                "8",
                "9",
                "Alpine",
                "Avantime",
                "Captur",
                "Chamade",
                "Clio",
                "Espace",
                "Express",
                "Fluence",
                "Fuego",
                "Grand Espace",
                "Grand Modus",
                "Grand Scenic",
                "Kadjar",
                "Kangoo",
                "Koleos",
                "Laguna",
                "Latitude",
                "Master",
                "Megane",
                "Modus",
                "Rapid",
                "Safrane",
                "Scenic",
                "Symbol",
                "Talisman",
                "Trafic",
                "Twingo",
                "Twizy",
                "Vel Satis",
                "Wind",
                "Zoe"
            });

            models.Add("Ford", new List<string>()
            {
                "Aerostar",
                "Aspire",
                "Bronco",
                "Bronco II",
                "C-MAX",
                "Club Wagon",
                "Contour",
                "Courier",
                "Crown Victoria",
                "E-150 and Econoline 150",
                "E-250 and Econoline 250",
                "E-350 and Econoline 350",
                "Edge",
                "Escape",
                "Escort",
                "Excursion",
                "EXP",
                "Expedition",
                "Expedition EL",
                "Explorer",
                "Explorer Sport Trac",
                "F100",
                "F150",
                "F250",
                "F350",
                "F450",
                "Fairmont",
                "Festiva",
                "Fiesta",
                "Five Hundred",
                "Flex",
                "Focus",
                "Freestar",
                "Freestyle",
                "Fusion",
                "Granada",
                "GT",
                "LTD",
                "Mustang",
                "Probe",
                "Ranger",
                "Taurus",
                "Taurus X",
                "Tempo",
                "Thunderbird",
                "Transit Connect",
                "Windstar",
                "ZX2 Escort"
            });

            models.Add("Toyota", new List<string>()
            {
                "4Runner",
                "Avalon",
                "Camry",
                "Celica",
                "Corolla",
                "Corona",
                "Cressida",
                "Echo",
                "FJ Cruiser",
                "Highlander",
                "Land Cruiser",
                "Matrix",
                "MR2",
                "MR2 Spyder",
                "Paseo",
                "Pickup",
                "Previa",
                "Prius",
                "Prius C",
                "Prius V",
                "RAV4",
                "Sequoia",
                "Sienna",
                "Solara",
                "Starlet",
                "Supra",
                "T100",
                "Tacoma",
                "Tercel",
                "Tundra",
                "Van",
                "Venza",
                "Yaris"
            });

            models.Add("Citroen", new List<string>()
            {
                "2 CV",
                "AX",
                "Berlingo",
                "BerlingoFT",
                "BX",
                "C-Crosser",
                "C-Elysee",
                "C-Zero",
                "C1",
                "C15",
                "C2",
                "C3",
                "C3 Aircross",
                "C3 Picasso",
                "C4",
                "C4 Aircross",
                "C4 Cactus",
                "C4 NEW",
                "C4 Picasso",
                "C5",
                "C5 Aircross",
                "C5 NEW",
                "C6",
                "C8",
                "DS",
                "DS3",
                "DS4",
                "DS5",
                "Evasion",
                "Grand C4 Picasso",
                "Jumper",
                "Jumper II",
                "Jumpy",
                "Jumpy II",
                "Nemo",
                "SAXO",
                "Visa",
                "Xantia",
                "XM",
                "Xsara",
                "Xsara Picasso",
                "ZX"
            });

            models.Add("Fiat", new List<string>()
            {
                "125",
                "126",
                "127",
                "131",
                "1500",
                "500",
                "500L",
                "500X",
                "600",
                "750",
                "Albea",
                "Barchetta",
                "Brava",
                "Bravo",
                "Campagnola",
                "Cinquecento",
                "Coupe",
                "Croma",
                "Dino",
                "Doblo",
                "Ducato",
                "Fiorino",
                "Freemont",
                "Grande Punto",
                "Idea",
                "Linea",
                "Marea",
                "Multipla",
                "Palio",
                "Panda",
                "Punto",
                "Qubo",
                "Regata",
                "Scudo",
                "Sedici",
                "Seicento",
                "Stilo",
                "Strada",
                "Tempra",
                "Tipo",
                "Ulysse",
                "Uno"
            });

            models.Add("Mazda", new List<string>()
            {
                "121",
                "2",
                "3",
                "323",
                "5",
                "5 NEW",
                "6",
                "6 NEW",
                "626",
                "929",
                "BT-50",
                "CX 3",
                "CX 30",
                "CX 5",
                "CX 7",
                "CX 9",
                "Demio",
                "MPV",
                "MX-3",
                "MX-5",
                "MX-6",
                "Premacy",
                "RX-8",
                "Tribute",
                "Xedos"
            });

            models.Add("Honda", new List<string>()
            {
                "Accord",
                "Civic",
                "CR-V",
                "CR-Z",
                "CRX",
                "Accord Crosstour",
                "Crosstour",
                "Del Sol",
                "Element",
                "Fit",
                "Insight",
                "Odyssey",
                "Passport",
                "Pilot",
                "Prelude",
                "Ridgeline",
                "S2000"
            });

            models.Add("Nissan", new List<string>()
            {
                "200SX",
                "240SX",
                "300ZX",
                "350Z",
                "370Z",
                "Altima",
                "Armada",
                "Axxess",
                "Cube",
                "Frontier",
                "GT-R",
                "Juke",
                "Leaf",
                "Maxima",
                "Murano",
                "Murano CrossCabriolet",
                "NV",
                "NX",
                "Pathfinder",
                "Pickup",
                "Pulsar",
                "Quest",
                "Rogue",
                "Sentra",
                "Stanza",
                "Titan",
                "Van",
                "Versa",
                "Xterra"
            });

            models.Add("Seat", new List<string>()
            {
                "Alhambra",
                "Altea",
                "Arona",
                "Arosa",
                "Ateca",
                "Cordoba",
                "Exeo",
                "Ibiza",
                "Inca",
                "Leon",
                "Leon ST",
                "Marbella",
                "Mii",
                "Tarraco",
                "Terra",
                "Toledo",
                "Vario"
            });

            models.Add("Skoda", new List<string>()
            {
                "105",
                "120",
                "130",
                "Citigo",
                "Fabia",
                "Favorit",
                "Felicia",
                "Forman",
                "Karoq",
                "Kodiaq",
                "Octavia",
                "Pick-up",
                "Praktik",
                "Rapid",
                "Roomster",
                "Scala",
                "Superb",
                "Yeti"
            });

            models.Add("Mitsubishi", new List<string>()
            {
                "3000GT",
                "Cordia",
                "Diamante",
                "Eclipse",
                "Endeavor",
                "Expo",
                "Galant",
                "i",
                "Lancer",
                "Lancer Evolution",
                "Mighty Max",
                "Mirage",
                "Montero",
                "Montero Sport",
                "Outlander",
                "Outlander Sport",
                "Precis",
                "Raider",
                "Sigma",
                "Starion",
                "Tredia",
                "Van"
            });

            models.Add("Hyundai", new List<string>()
            {
                "Accent",
                "Azera",
                "Elantra",
                "Elantra Coupe",
                "Elantra Touring",
                "Entourage",
                "Equus",
                "Excel",
                "Genesis",
                "Genesis Coupe",
                "Santa Fe",
                "Scoupe",
                "Sonata",
                "Tiburon",
                "Tucson",
                "Veloster",
                "Veracruz",
                "XG300",
                "XG350"
            });

            models.Add("Kia", new List<string>()
            {
                "Avella Delta",
                "Cadenza",
                "Carens",
                "Carnival",
                "Ceed",
                "Cerato",
                "Clarus",
                "Joice",
                "K 5",
                "K2700",
                "Magentis",
                "Niro",
                "Opirus",
                "Optima",
                "Picanto",
                "Pregio",
                "Pride",
                "Retona",
                "Rio",
                "Sephia",
                "Shuma",
                "Sorento",
                "Soul",
                "Spectra",
                "Sportage",
                "Stonic",
                "Venga",
            });

            models.Add("Volvo", new List<string>()
            {
                "240",
                "260",
                "740",
                "760",
                "780",
                "850",
                "940",
                "960",
                "C30",
                "C70",
                "S40",
                "S60",
                "S70",
                "S80",
                "S90",
                "V40",
                "V50",
                "V70",
                "V90",
                "XC60",
                "XC70",
                "XC90"
            });

            models.Add("Subaru", new List<string>()
            {
                "Baja",
                "Brat",
                "BRZ",
                "Forester",
                "Impreza",
                "Impreza WRX",
                "Justy",
                "L Series",
                "Legacy",
                "Loyale",
                "Outback",
                "SVX",
                "Tribeca",
                "XT",
                "XV Crosstrek"
            });

            models.Add("Suzuki", new List<string>()
            {
                "Aerio",
                "Equator",
                "Esteem",
                "Forenza",
                "Grand Vitara",
                "Kizashi",
                "Reno",
                "Samurai",
                "Sidekick",
                "Swift",
                "SX4",
                "Verona",
                "Vitara",
                "X-90",
                "XL7"
            });

            models.Add("Alfa Romeo", new List<string>()
            {
                "145",
                "146",
                "147",
                "155",
                "156",
                "156 Sportwagon",
                "159",
                "159 SW",
                "164",
                "166",
                "33",
                "Arna",
                "Brera",
                "Crosswagon",
                "Giulia",
                "Giulietta",
                "GT",
                "GTV",
                "MiTo",
                "Spider",
                "Stelvio"
            });

            models.Add("Chevrolet", new List<string>()
            {
                "Astro",
                "Avalanche",
                "Aveo",
                "Aveo5",
                "Beretta",
                "Blazer",
                "Camaro",
                "Caprice",
                "Captiva Sport",
                "Cavalier",
                "Celebrity",
                "Chevette",
                "Citation",
                "Cobalt",
                "Colorado",
                "Corsica",
                "Corvette",
                "Cruze",
                "El Camino",
                "Equinox",
                "Express Van",
                "G Van",
                "HHR",
                "Impala",
                "Kodiak C4500",
                "Lumina",
                "Lumina APV",
                "LUV",
                "Malibu",
                "Metro",
                "Monte Carlo",
                "Nova",
                "Prizm",
                "S10 Blazer",
                "S10 Pickup",
                "Silverado and other C/K1500",
                "Silverado and other C/K2500",
                "Silverado and other C/K3500",
                "Sonic",
                "Spark",
                "Spectrum",
                "Sprint",
                "SSR",
                "Suburban",
                "Tahoe",
                "Tracker",
                "TrailBlazer",
                "TrailBlazer EXT",
                "Traverse",
                "Uplander",
                "Venture",
                "Volt"
            });

            models.Add("Land Rover", new List<string>()
            {
                "Defender",
                "Discovery",
                "Freelander",
                "LR2",
                "LR3",
                "LR4",
                "Range Rover",
                "Range Rover Evoque",
                "Range Rover Sport"
            });

            models.Add("Dacia", new List<string>()
            {
                "Dokker",
                "Duster",
                "Lodgy",
                "Logan",
                "Pick Up",
                "Sandero",
                "Solenza"
            });

            models.Add("Jeep", new List<string>()
            {
                "Cherokee",
                "CJ",
                "Comanche",
                "Commander",
                "Compass",
                "Grand Cherokee",
                "Grand Wagoneer",
                "Liberty",
                "Patriot",
                "Pickup",
                "Scrambler",
                "Wagoneer",
                "Wrangler"
            });

            models.Add("Mini", new List<string>()
            {
                "Cooper Clubman",
                "Cooper S Clubman",
                "Cooper Countryman",
                "Cooper S Countryman",
                "Cooper Coupe",
                "Cooper S Coupe",
                "Cooper",
                "Cooper S",
                "Cooper Roadster",
                "Cooper S Roadster"
            });

            models.Add("Lancia", new List<string>()
            {
                "Dedra",
                "Delta",
                "Flavia",
                "Fulvia",
                "Kappa",
                "Lybra",
                "MUSA",
                "Phedra",
                "Thema",
                "Thesis",
                "Y",
                "Ypsilon",
                "Zeta"
            });

            models.Add("Chrysler", new List<string>()
            {
                "300 M",
                "300C",
                "Crossfire",
                "Grand Voyager",
                "Le Baron",
                "Neon",
                "Pacifica",
                "PT Cruiser",
                "Sebring",
                "Stratus",
                "Vision",
                "Voyager"
            });

            models.Add("Daihatsu", new List<string>()
            {
                "Applause",
                "Charade",
                "Cuore",
                "Feroza/Sportrak",
                "Freeclimber",
                "Gran Move",
                "Hijet",
                "MATERIA",
                "Move",
                "Rocky/Fourtrak",
                "Sirion",
                "Terios",
                "TREVIS",
                "YRV"
            });

            models.Add("Smart", new List<string>()
            {
                "ForFour",
                "ForTwo",
                "Mc",
                "Micro",
                "Roadster"
            });

            models.Add("Ssangyong", new List<string>()
            {
                "Actyon",
                "Korando",
                "Kyron",
                "MUSSO",
                "REXTON",
                "Rodius",
                "TIVOLI"
            });

            models.Add("Jaguar", new List<string>()
            {
                "S-Type",
                "X-Type",
                "XF",
                "XJ12",
                "XJ6",
                "XJR",
                "XJR-S",
                "XJS",
                "XJ Vanden Plas",
                "XJ",
                "XJ8",
                "XJ8 L",
                "XJ Sport",
                "XK8",
                "XK",
                "XKR"
            });

            models.Add("Daewoo", new List<string>()
            {
                "Damas",
                "Espero",
                "Evanda",
                "Kalos",
                "Korando",
                "Lacetti",
                "Lanos",
                "Leganza",
                "Matiz",
                "Musso",
                "Nexia",
                "Nubira",
                "Rezzo",
                "Tacuma",
                "Tico"
            });

            models.Add("Rover", new List<string>()
            {
                "200",
                "214",
                "216",
                "218",
                "220",
                "25",
                "400",
                "414",
                "416",
                "420",
                "45",
                "600",
                "618",
                "620",
                "75",
                "820",
                "825",
                "827",
                "City Rover"
            });

            models.Add("Porsche", new List<string>()
            {
                "356",
                "911",
                "924",
                "928",
                "Boxster",
                "Boxter S",
                "Carrera",
                "Cayenne",
                "Cayman",
                "Macan",
                "Panamera",
                "Taycan"
            });

            models.Add("Lexus", new List<string>()
            {
                "CT 200h",
                "ES 250",
                "ES 300",
                "ES 300h",
                "ES 330",
                "ES 350",
                "GS 300",
                "GS 350",
                "GS 400",
                "GS 430",
                "GS 450h",
                "GS 460",
                "GX 460",
                "GX 470",
                "HS 250h",
                "IS 250",
                "IS 250C",
                "IS 300",
                "IS 350",
                "IS 350C",
                "IS F",
                "LFA",
                "LS 400",
                "LS 430",
                "LS 460",
                "LS 600h",
                "LX 450",
                "LX 470",
                "LX 570",
                "RX 300",
                "RX 330",
                "RX 350",
                "RX 400h",
                "RX 450h",
                "SC 300",
                "SC 400",
                "SC 430"
            });

            models.Add("Saab", new List<string>()
            {
                "9-2X",
                "9-3",
                "9-4X",
                "9-5",
                "9-7X",
                "900",
                "9000"
            });

            models.Add("Dodge", new List<string>()
            {
                "400",
                "600",
                "Aries",
                "Avenger",
                "Caliber",
                "Caravan",
                "Challenger",
                "Charger",
                "Colt",
                "Conquest",
                "D/W Truck",
                "Dakota",
                "Dart",
                "Daytona",
                "Diplomat",
                "Durango",
                "Dynasty",
                "Grand Caravan",
                "Intrepid",
                "Journey",
                "Lancer",
                "Magnum",
                "Mirada",
                "Monaco",
                "Neon",
                "Nitro",
                "Omni",
                "Raider",
                "Ram 1500 Truck",
                "Ram 2500 Truck",
                "Ram 3500 Truck",
                "Ram 4500 Truck",
                "Ram 50 Truck",
                "RAM C/V",
                "Ram SRT-10",
                "Ram Van",
                "Ram Wagon",
                "Ramcharger",
                "Rampage",
                "Shadow",
                "Spirit",
                "Sprinter",
                "SRT-4",
                "St. Regis",
                "Stealth",
                "Stratus",
                "Viper"
            });

            models.Add("Infiniti", new List<string>()
            {
                "EX35",
                "EX37",
                "FX35",
                "FX37",
                "FX45",
                "FX50",
                "G20",
                "G25",
                "G35",
                "G37",
                "I30",
                "I35",
                "J30",
                "JX35",
                "M30",
                "M35",
                "M35h",
                "M37",
                "M45",
                "M56",
                "Q45",
                "QX4",
                "QX56"
            });

            models.Add("Isuzu", new List<string>()
            {
                "Amigo",
                "Ascender",
                "Axiom",
                "Hombre",
                "i-280",
                "i-290",
                "i-350",
                "i-370",
                "I-Mark",
                "Impulse",
                "Oasis",
                "Pickup",
                "Rodeo",
                "Stylus",
                "Trooper",
                "Trooper II",
                "VehiCROSS"
            });

            models.Add("Tesla", new List<string>()
            {
                "Model 3",
                "Model S",
                "Model X"
            });

            models.Add("Range Rover", new List<string>()
            {
                "Discovery 4",
                "Evoque",
                "Freelander 2",
                "Sport"
            });

            models.Add("Cadillac", new List<string>()
            {
                "Allante",
                "ATS",
                "Brougham",
                "Catera",
                "Cimarron",
                "CTS",
                "De Ville",
                "DTS",
                "Eldorado",
                "Escalade",
                "Escalade ESV",
                "Escalade EXT",
                "Fleetwood",
                "Seville",
                "SRX",
                "STS",
                "XLR",
                "XTS"
            });

            models.Add("Lincoln", new List<string>()
            {
                "Aviator",
                "Blackwood",
                "Continental",
                "LS",
                "Mark LT",
                "Mark VI",
                "Mark VII",
                "Mark VIII",
                "MKS",
                "MKT",
                "MKX",
                "MKZ",
                "Navigator",
                "Navigator L",
                "Town Car",
                "Zephyr"
            });

            models.Add("Hummer", new List<string>()
            {
                "H1",
                "H2",
                "H3"
            });

            models.Add("Maserati", new List<string>()
            {
                "430",
                "Biturbo",
                "Coupe",
                "GranSport",
                "GranTurismo",
                "Quattroporte",
                "Spyder"
            });

            models.Add("MG", new List<string>()
            {
                "MGB",
                "MGF",
                "TF",
                "ZR",
                "ZS",
                "ZT"
            });

            models.Add("Bentley", new List<string>()
            {
                "Arnage",
                "Azure",
                "Brooklands",
                "Continental",
                "Corniche",
                "Eight",
                "Mulsanne",
                "Turbo R"
            });

            models.Add("Pontiac", new List<string>()
            {
                "1000",
                "6000",
                "Aztek",
                "Bonneville",
                "Catalina",
                "Fiero",
                "Firebird",
                "G3",
                "G5",
                "G6",
                "G8",
                "Grand Am",
                "Grand Prix",
                "GTO",
                "J2000",
                "Le Mans",
                "Montana",
                "Parisienne",
                "Phoenix",
                "Safari",
                "Solstice",
                "Sunbird",
                "Sunfire",
                "Torrent",
                "Trans Sport",
                "Vibe"
            });

            models.Add("Pagani", new List<string>()
            {
                "Zonda C12",
                "Zonda C12-S",
                "Zonda S",
                "Zonda S Roadster",
                "Zonda F",
                "Zonda Roadster F",
                "Zonda Cinque",
                "Zonda Cinque Roadster",
                "Huayra"
            });

            models.Add("Koenigsegg", new List<string>()
            {
                "Gemera",
                "Jesko Absolut",
                "Jesko",
                "Regera",
                "Agera Final Edition",
                "Agera RS",
                "One:1",
                "Agera S",
                "Agera R",
                "Agera",
                "Quant Concept",
                "Trevita",
                "CCXR Special",
                "CCXR Edition",
                "CCX Edition",
                "CCXR",
                "CCGT",
                "CCX",
                "CCR",
                "CC8S",
                "CC Prototype"
            });

            models.Add("Ferrari", new List<string>()
            {
                "308 GTB Quattrovalvole",
                "308 GTBI",
                "308 GTS Quattrovalvole",
                "308 GTSI",
                "328 GTB",
                "328 GTS",
                "348 GTB",
                "348 GTS",
                "348 Spider",
                "348 TB",
                "348 TS",
                "360",
                "456 GT",
                "456M GT",
                "458 Italia",
                "512 BBi",
                "512M",
                "512TR",
                "550 Maranello",
                "575M Maranello",
                "599 GTB Fiorano",
                "599 GTO",
                "612 Scaglietti",
                "812",
                "California",
                "Enzo",
                "F355",
                "F40",
                "F430",
                "F50",
                "FF",
                "Mondial",
                "Testarossa"
            });

            models.Add("Rolls Royce", new List<string>()
            {
                "Camargue",
                "Corniche",
                "Ghost",
                "Park Ward",
                "Phantom",
                "Silver Dawn",
                "Silver Seraph",
                "Silver Spirit",
                "Silver Spur"
            });

            models.Add("Datsun", new List<string>()
            {
                "200SX",
                "210",
                "280ZX",
                "300ZX",
                "310",
                "510",
                "720",
                "810",
                "Maxima",
                "Pickup",
                "Pulsar",
                "Sentra",
                "Stanza"
            });

            models.Add("Austin", new List<string>()
            {
                "Princess"
            });

            models.Add("Acura", new List<string>()
            {
                "2.2CL",
                "2.3CL",
                "3.0CL",
                "3.2CL",
                "ILX",
                "Integra",
                "Legend",
                "MDX",
                "NSX",
                "RDX",
                "3.5 RL",
                "RL",
                "RSX",
                "SLX",
                "2.5TL",
                "3.2TL",
                "TL",
                "TSX",
                "Vigor",
                "ZDX"
            });

            models.Add("Lamborghini", new List<string>()
            {
                "Aventador",
                "Countach",
                "Diablo",
                "Gallardo",
                "Jalpa",
                "LM002",
                "Murcielago",
                "Urus"
            });

            models.Add("Maybach", new List<string>()
            {
                "57",
                "62"
            });

            models.Add("Haval", new List<string>()
            {
                "H6"
            });

            models.Add("Oldsmobile", new List<string>()
            {
                "88",
                "Achieva",
                "Alero",
                "Aurora",
                "Bravada",
                "Custom Cruiser",
                "Cutlass",
                "Cutlass Calais",
                "Cutlass Ciera",
                "Cutlass Supreme",
                "Firenza",
                "Intrigue",
                "Ninety-Eight",
                "Omega",
                "Regency",
                "Silhouette",
                "Toronado"
            });

            models.Add("GMC", new List<string>()
            {
                "Acadia",
                "Caballero",
                "Canyon",
                "Envoy",
                "Envoy XL",
                "Envoy XUV",
                "Jimmy",
                "Rally Wagon",
                "S15 Jimmy",
                "S15 Pickup",
                "Safari",
                "Savana",
                "Sierra C/K1500",
                "Sierra C/K2500",
                "Sierra C/K3500",
                "Sonoma",
                "Suburban",
                "Syclone",
                "Terrain",
                "TopKick C4500",
                "Typhoon",
                "Vandura",
                "Yukon",
                "Yukon XL"
            });

            models.Add("Aston Martin", new List<string>()
            {
                "DB7",
                "DB9",
                "DBS",
                "Lagonda",
                "Rapide",
                "V12 Vantage",
                "V8 Vantage",
                "Vanquish",
                "Virage"
            });
        }
    }
}
