﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuemSou
{
    public class Game
    {
        public List<Category> categories = new List<Category>();

        public void StartGame()
        {
            categories.Add(new Category("Musicas nacionais","Musicas de artistas brasileiros"));

            categories.Add(new Category("Cantores e bandas nacionais", "Cantores e bandas famosas do Brasil"));

            categories.Add(new Category("Pokémons", "Monstros do jogo Pokémon"));

            categories.Add(new Category("Filmes","Filmes nacionais e internacionais"));

            categories.Add(new Category("Carros", "Carros nacionais"));

            categories.Add(new Category("Objetos", "Coisas que existem no dia a dia"));
                
            categories.Sort();
        }

        public string Play(String category)
        {
            var rand = new Random();
            int index;
            switch (category)
            {
                case "Musicas nacionais":
                    index = rand.Next(Music._list.Count);
                    return Music._list[index];
                case "Cantores e bandas nacionais":
                    index = rand.Next(NationalArtists._list.Count);
                    return NationalArtists._list[index];
                case "Pokémons":
                    index = rand.Next(Pokemon._list.Count);
                    return Pokemon._list[index];
                case "Filmes":
                    index = rand.Next(Movies._list.Count);
                    return Movies._list[index];
                case "Carros":
                    index = rand.Next(Cars._list.Count);
                    return Cars._list[index];
                case "Objetos":
                    index = rand.Next(Things._list.Count);
                    return Things._list[index];

                default:
                    return null;
            }
        }
    }

    public class Category : IComparable
    {
        public Category(string category, string description){
            this.category = category;
            this.description = description;
        }

        public String category { get; set; }
        public String description { get; set; }

        public int CompareTo(Object obj)
        {
            Category category = (Category)obj;
            return this.category.CompareTo(category.category);
        }
    }

    public static class Music
    {
        public static List<String> _list = new List<String>
        {
            "Robocop Gay",
            "A lenda dessa paixão",
            "Pelados em santos",
            "Só você sabe",
            "Ana Julia",
        };
    }

    public static class NationalArtists
    {
        public static List<String> _list = new List<String>
        {
            "Pitty",
            "Gabriel Tomaz",
            "Flávia Couri",
            "Lobão",
            "Dinho ouro Preto",
            "Falcão",
            "Malu Magalhães",
            "Marcelo Camelo",
            "Nando",
            "Thiaguinho",
            "Rita Lee",
            "Renato Russo",
            "CPM22",
            "Charlie Brown Jr",
            "Mamonas Assassinas",
            "Legião Urbana",
            "Rouge"
        };
    }

    public static class Movies
    {
        public static List<String> _list = new List<string>
        {
            "Carga Explosiva",
            "Taxi",
            "A era do gelo",
            "Toy Story",
            "De volta para o futuro",
            "Star Wars",
            "Her",
            "O Hobbit",
            "O senhor dos Anéis",
            "Harry Potter",
            "Sr e Sra Smith",
            "MIB",
            "A rede social",
            "Tenacious D",
            "Escola de Rock",
            "A lagoa azul"
        };
    }

    public static class Cars
    {
        public static List<String> _list = new List<string>
        {
            "Voyage",
            "Brasilia",
            "Fusca",
            "Passat",
            "Palio",
            "Fusion",
            "Civic",
            "147",
            "Corsa",
            "Celta"
        };
    }

    public static class Things
    {
        public static List<String> _list = new List<string>
        {
            "Garfo",
            "Colher",
            "Copo",
            "Prato",
            "Mesa",
            "Tampa",
            "Garrafa",
            "Caixa",
            "Tomada",
            "Papel",
            "Esponja",
            "Bacia",
            "Pote",
            "Panela",
            "Carregador",
            "Palito",
            "Escova",
            "Pano",
            "Cafeteira"
        };
    }


    //Thank you @WardoJ for this massive list of pokémons!
    public static class Pokemon
    {
        public static List<String> _list = new List<String>
        {
            "Bulbasaur",
            "Ivysaur",
            "Venusaur",
            "Charmander",
            "Charmeleon",
            "Charizard",
            "Squirtle",
            "Wartortle",
            "Blastoise",
            "Caterpie",
            "Metapod",
            "Butterfree",
            "Weedle",
            "Kakuna",
            "Beedrill",
            "Pidgey",
            "Pidgeotto",
            "Pidgeot",
            "Rattata",
            "Raticate",
            "Spearow",
            "Fearow",
            "Ekans",
            "Arbok",
            "Pikachu",
            "Raichu",
            "Sandshrew",
            "Sandslash",
            "Nidoran♀",
            "Nidorina",
            "Nidoqueen",
            "Nidoran♂",
            "Nidorino",
            "Nidoking",
            "Clefairy",
            "Clefable",
            "Vulpix",
            "Ninetales",
            "Jigglypuff",
            "Wigglytuff",
            "Zubat",
            "Golbat",
            "Oddish",
            "Gloom",
            "Vileplume",
            "Paras",
            "Parasect",
            "Venonat",
            "Venomoth",
            "Diglett",
            "Dugtrio",
            "Meowth",
            "Persian",
            "Psyduck",
            "Golduck",
            "Mankey",
            "Primeape",
            "Growlithe",
            "Arcanine",
            "Poliwag",
            "Poliwhirl",
            "Poliwrath",
            "Abra",
            "Kadabra",
            "Alakazam",
            "Machop",
            "Machoke",
            "Machamp",
            "Bellsprout",
            "Weepinbell",
            "Victreebel",
            "Tentacool",
            "Tentacruel",
            "Geodude",
            "Graveler",
            "Golem",
            "Ponyta",
            "Rapidash",
            "Slowpoke",
            "Slowbro",
            "Magnemite",
            "Magneton",
            "Farfetch'd",
            "Doduo",
            "Dodrio",
            "Seel",
            "Dewgong",
            "Grimer",
            "Muk",
            "Shellder",
            "Cloyster",
            "Gastly",
            "Haunter",
            "Gengar",
            "Onix",
            "Drowzee",
            "Hypno",
            "Krabby",
            "Kingler",
            "Voltorb",
            "Electrode",
            "Exeggcute",
            "Exeggutor",
            "Cubone",
            "Marowak",
            "Hitmonlee",
            "Hitmonchan",
            "Lickitung",
            "Koffing",
            "Weezing",
            "Rhyhorn",
            "Rhydon",
            "Chansey",
            "Tangela",
            "Kangaskhan",
            "Horsea",
            "Seadra",
            "Goldeen",
            "Seaking",
            "Staryu",
            "Starmie",
            "Mr. Mime",
            "Scyther",
            "Jynx",
            "Electabuzz",
            "Magmar",
            "Pinsir",
            "Tauros",
            "Magikarp",
            "Gyarados",
            "Lapras",
            "Ditto",
            "Eevee",
            "Vaporeon",
            "Jolteon",
            "Flareon",
            "Porygon",
            "Omanyte",
            "Omastar",
            "Kabuto",
            "Kabutops",
            "Aerodactyl",
            "Snorlax",
            "Articuno",
            "Zapdos",
            "Moltres",
            "Dratini",
            "Dragonair",
            "Dragonite",
            "Mewtwo",
            "Mew",
            "Chikorita",
            "Bayleef",
            "Meganium",
            "Cyndaquil",
            "Quilava",
            "Typhlosion",
            "Totodile",
            "Croconaw",
            "Feraligatr",
            "Sentret",
            "Furret",
            "Hoothoot",
            "Noctowl",
            "Ledyba",
            "Ledian",
            "Spinarak",
            "Ariados",
            "Crobat",
            "Chinchou",
            "Lanturn",
            "Pichu",
            "Cleffa",
            "Igglybuff",
            "Togepi",
            "Togetic",
            "Natu",
            "Xatu",
            "Mareep",
            "Flaaffy",
            "Ampharos",
            "Bellossom",
            "Marill",
            "Azumarill",
            "Sudowoodo",
            "Politoed",
            "Hoppip",
            "Skiploom",
            "Jumpluff",
            "Aipom",
            "Sunkern",
            "Sunflora",
            "Yanma",
            "Wooper",
            "Quagsire",
            "Espeon",
            "Umbreon",
            "Murkrow",
            "Slowking",
            "Misdreavus",
            "Unown",
            "Wobbuffet",
            "Girafarig",
            "Pineco",
            "Forretress",
            "Dunsparce",
            "Gligar",
            "Steelix",
            "Snubbull",
            "Granbull",
            "Qwilfish",
            "Scizor",
            "Shuckle",
            "Heracross",
            "Sneasel",
            "Teddiursa",
            "Ursaring",
            "Slugma",
            "Magcargo",
            "Swinub",
            "Piloswine",
            "Corsola",
            "Remoraid",
            "Octillery",
            "Delibird",
            "Mantine",
            "Skarmory",
            "Houndour",
            "Houndoom",
            "Kingdra",
            "Phanpy",
            "Donphan",
            "Porygon2",
            "Stantler",
            "Smeargle",
            "Tyrogue",
            "Hitmontop",
            "Smoochum",
            "Elekid",
            "Magby",
            "Miltank",
            "Blissey",
            "Raikou",
            "Entei",
            "Suicune",
            "Larvitar",
            "Pupitar",
            "Tyranitar",
            "Lugia",
            "Ho-oh",
            "Celebi",
            "Treecko",
            "Grovyle",
            "Sceptile",
            "Torchic",
            "Combusken",
            "Blaziken",
            "Mudkip",
            "Marshtomp",
            "Swampert",
            "Poochyena",
            "Mightyena",
            "Zigzagoon",
            "Linoone",
            "Wurmple",
            "Silcoon",
            "Beautifly",
            "Cascoon",
            "Dustox",
            "Lotad",
            "Lombre",
            "Ludicolo",
            "Seedot",
            "Nuzleaf",
            "Shiftry",
            "Taillow",
            "Swellow",
            "Wingull",
            "Pelipper",
            "Ralts",
            "Kirlia",
            "Gardevoir",
            "Surskit",
            "Masquerain",
            "Shroomish",
            "Breloom",
            "Slakoth",
            "Vigoroth",
            "Slaking",
            "Nincada",
            "Ninjask",
            "Shedinja",
            "Whismur",
            "Loudred",
            "Exploud",
            "Makuhita",
            "Hariyama",
            "Azurill",
            "Nosepass",
            "Skitty",
            "Delcatty",
            "Sableye",
            "Mawile",
            "Aron",
            "Lairon",
            "Aggron",
            "Meditite",
            "Medicham",
            "Electrike",
            "Manectric",
            "Plusle",
            "Minun",
            "Volbeat",
            "Illumise",
            "Roselia",
            "Gulpin",
            "Swalot",
            "Carvanha",
            "Sharpedo",
            "Wailmer",
            "Wailord",
            "Numel",
            "Camerupt",
            "Torkoal",
            "Spoink",
            "Grumpig",
            "Spinda",
            "Trapinch",
            "Vibrava",
            "Flygon",
            "Cacnea",
            "Cacturne",
            "Swablu",
            "Altaria",
            "Zangoose",
            "Seviper",
            "Lunatone",
            "Solrock",
            "Barboach",
            "Whiscash",
            "Corphish",
            "Crawdaunt",
            "Baltoy",
            "Claydol",
            "Lileep",
            "Cradily",
            "Anorith",
            "Armaldo",
            "Feebas",
            "Milotic",
            "Castform",
            "Kecleon",
            "Shuppet",
            "Banette",
            "Duskull",
            "Dusclops",
            "Tropius",
            "Chimecho",
            "Absol",
            "Wynaut",
            "Snorunt",
            "Glalie",
            "Spheal",
            "Sealeo",
            "Walrein",
            "Clamperl",
            "Huntail",
            "Gorebyss",
            "Relicanth",
            "Luvdisc",
            "Bagon",
            "Shelgon",
            "Salamence",
            "Beldum",
            "Metang",
            "Metagross",
            "Regirock",
            "Regice",
            "Registeel",
            "Latias",
            "Latios",
            "Kyogre",
            "Groudon",
            "Rayquaza",
            "Jirachi",
            "Deoxys",
            "Turtwig",
            "Grotle",
            "Torterra",
            "Chimchar",
            "Monferno",
            "Infernape",
            "Piplup",
            "Prinplup",
            "Empoleon",
            "Starly",
            "Staravia",
            "Staraptor",
            "Bidoof",
            "Bibarel",
            "Kricketot",
            "Kricketune",
            "Shinx",
            "Luxio",
            "Luxray",
            "Budew",
            "Roserade",
            "Cranidos",
            "Rampardos",
            "Shieldon",
            "Bastiodon",
            "Burmy",
            "Wormadam",
            "Mothim",
            "Combee",
            "Vespiquen",
            "Pachirisu",
            "Buizel",
            "Floatzel",
            "Cherubi",
            "Cherrim",
            "Shellos",
            "Gastrodon",
            "Ambipom",
            "Drifloon",
            "Drifblim",
            "Buneary",
            "Lopunny",
            "Mismagius",
            "Honchkrow",
            "Glameow",
            "Purugly",
            "Chingling",
            "Stunky",
            "Skuntank",
            "Bronzor",
            "Bronzong",
            "Bonsly",
            "Mime Jr.",
            "Happiny",
            "Chatot",
            "Spiritomb",
            "Gible",
            "Gabite",
            "Garchomp",
            "Munchlax",
            "Riolu",
            "Lucario",
            "Hippopotas",
            "Hippowdon",
            "Skorupi",
            "Drapion",
            "Croagunk",
            "Toxicroak",
            "Carnivine",
            "Finneon",
            "Lumineon",
            "Mantyke",
            "Snover",
            "Abomasnow",
            "Weavile",
            "Magnezone",
            "Lickilicky",
            "Rhyperior",
            "Tangrowth",
            "Electivire",
            "Magmortar",
            "Togekiss",
            "Yanmega",
            "Leafeon",
            "Glaceon",
            "Gliscor",
            "Mamoswine",
            "Porygon-Z",
            "Gallade",
            "Probopass",
            "Dusknoir",
            "Froslass",
            "Rotom",
            "Uxie",
            "Mesprit",
            "Azelf",
            "Dialga",
            "Palkia",
            "Heatran",
            "Regigigas",
            "Giratina",
            "Cresselia",
            "Phione",
            "Manaphy",
            "Darkrai",
            "Shaymin",
            "Arceus",
            "Victini",
            "Snivy",
            "Servine",
            "Serperior",
            "Tepig",
            "Pignite",
            "Emboar",
            "Oshawott",
            "Dewott",
            "Samurott",
            "Patrat",
            "Watchog",
            "Lillipup",
            "Herdier",
            "Stoutland",
            "Purrloin",
            "Liepard",
            "Pansage",
            "Simisage",
            "Pansear",
            "Simisear",
            "Panpour",
            "Simipour",
            "Munna",
            "Musharna",
            "Pidove",
            "Tranquill",
            "Unfezant",
            "Blitzle",
            "Zebstrika",
            "Roggenrola",
            "Boldore",
            "Gigalith",
            "Woobat",
            "Swoobat",
            "Drilbur",
            "Excadrill",
            "Audino",
            "Timburr",
            "Gurdurr",
            "Conkeldurr",
            "Tympole",
            "Palpitoad",
            "Seismitoad",
            "Throh",
            "Sawk",
            "Sewaddle",
            "Swadloon",
            "Leavanny",
            "Venipede",
            "Whirlipede",
            "Scolipede",
            "Cottonee",
            "Whimsicott",
            "Petilil",
            "Lilligant",
            "Basculin",
            "Sandile",
            "Krokorok",
            "Krookodile",
            "Darumaka",
            "Darmanitan",
            "Maractus",
            "Dwebble",
            "Crustle",
            "Scraggy",
            "Scrafty",
            "Sigilyph",
            "Yamask",
            "Cofagrigus",
            "Tirtouga",
            "Carracosta",
            "Archen",
            "Archeops",
            "Trubbish",
            "Garbodor",
            "Zorua",
            "Zoroark",
            "Minccino",
            "Cinccino",
            "Gothita",
            "Gothorita",
            "Gothitelle",
            "Solosis",
            "Duosion",
            "Reuniclus",
            "Ducklett",
            "Swanna",
            "Vanillite",
            "Vanillish",
            "Vanilluxe",
            "Deerling",
            "Sawsbuck",
            "Emolga",
            "Karrablast",
            "Escavalier",
            "Foongus",
            "Amoonguss",
            "Frillish",
            "Jellicent",
            "Alomomola",
            "Joltik",
            "Galvantula",
            "Ferroseed",
            "Ferrothorn",
            "Klink",
            "Klang",
            "Klinklang",
            "Tynamo",
            "Eelektrik",
            "Eelektross",
            "Elgyem",
            "Beheeyem",
            "Litwick",
            "Lampent",
            "Chandelure",
            "Axew",
            "Fraxure",
            "Haxorus",
            "Cubchoo",
            "Beartic",
            "Cryogonal",
            "Shelmet",
            "Accelgor",
            "Stunfisk",
            "Mienfoo",
            "Mienshao",
            "Druddigon",
            "Golett",
            "Golurk",
            "Pawniard",
            "Bisharp",
            "Bouffalant",
            "Rufflet",
            "Braviary",
            "Vullaby",
            "Mandibuzz",
            "Heatmor",
            "Durant",
            "Deino",
            "Zweilous",
            "Hydreigon",
            "Larvesta",
            "Volcarona",
            "Cobalion",
            "Terrakion",
            "Virizion",
            "Tornadus",
            "Thundurus",
            "Reshiram",
            "Zekrom",
            "Landorus",
            "Kyurem",
            "Keldeo",
            "Meloetta",
            "Genesect",
            "Chespin",
            "Quilladin",
            "Chesnaught",
            "Fennekin",
            "Braixen",
            "Delphox",
            "Froakie",
            "Frogadier",
            "Greninja",
            "Bunnelby",
            "Diggersby",
            "Fletchling",
            "Fletchinder",
            "Talonflame",
            "Scatterbug",
            "Spewpa",
            "Vivillon",
            "Litleo",
            "Pyroar",
            "Flabébé",
            "Floette",
            "Florges",
            "Skiddo",
            "Gogoat",
            "Pancham",
            "Pangoro",
            "Furfrou",
            "Espurr",
            "Meowstic",
            "Honedge",
            "Doublade",
            "Aegislash",
            "Spritzee",
            "Aromatisse",
            "Swirlix",
            "Slurpuff",
            "Inkay",
            "Malamar",
            "Binacle",
            "Barbaracle",
            "Skrelp",
            "Dragalge",
            "Clauncher",
            "Clawitzer",
            "Helioptile",
            "Heliolisk",
            "Tyrunt",
            "Tyrantrum",
            "Amaura",
            "Aurorus",
            "Sylveon",
            "Hawlucha",
            "Dedenne",
            "Carbink",
            "Goomy",
            "Sliggoo",
            "Goodra",
            "Klefki",
            "Phantump",
            "Trevenant",
            "Pumpkaboo",
            "Gourgeist",
            "Bergmite",
            "Avalugg",
            "Noibat",
            "Noivern",
            "Xerneas",
            "Yveltal",
            "Zygarde",
            "Diancie"
        };
    }
}
