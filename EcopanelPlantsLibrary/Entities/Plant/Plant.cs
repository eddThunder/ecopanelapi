using System;
using System.Collections.Generic;

namespace EcopanelPlantsLibrary.Entities.Plant
{
    public class Plant
    {
        public int Id { get; set; } 
        public string CommonName { get; set; }
        public bool CompleteData { get; set; }
        public Category Order { get; set; }
        public string CientificName { get; set; }
        public IEnumerable<Images> Images { get; set; }
        public string FamilyCommonName { get; set; }
        public Family Family { get; set; }
        public string Duration { get; set; }
        public Category Division { get; set; }
        public Category Class { get; set; }
        public Category Genus { get; set; }
        public MainSpecies MainSpecies { get; set; }
    }

    public class MainSpecies
    {
        public int Year { get; set; }
        public string Type { get; set; }
        public bool Synonym { get; set; }
        public string Status { get; set; }
        public Specification Specifications { get; set; }
        public IEnumerable<Source> Sources { get; set; }
        public SoilsAdaptation SoilsAdaptaion { get; set; }
        public string Slug { get; set; }
        public Seed Seed { get; set; }
        public string ScientificName { get; set; }
        public Propagation Propagation { get; set; }
        public Products Products { get; set; }
        public bool IsMainSpecies { get; set; }
        public IEnumerable<Images> Images { get; set; }
        public Growth Growth { get; set; }
        public FruitOrSeed FruitOrSeed { get; set; }
        public Foliage Foliage { get; set; }
        public Flower Flower { get; set; }
        public bool CompleteData { get; set; }
        public string Biography { get; set; }
        public string Author { get; set; }
    }

    public class Flower
    {
        public bool Conspicuous { get; set; }
        public string Color { get; set; }
    }

    public class FruitOrSeed
    {
        public bool SeedPersistence { get; set; }
        public string SeedPeriodEnd { get; set; }
        public string SeedPeriodBegin { get; set; }
        public string SeedAbundance { get; set; }
        public bool Conspicuous { get; set; }
        public string Color { get; set; }
    }

    public class Foliage
    {
        public string Texture { get; set; }
        public string PorosityWinter { get; set; }
        public string PorositySummer { get; set; }
        public string Color { get; set; }
    }

    public class Growth
    {
        public Temperature TemperatureMinimum { get; set; }
        public string ShadeTolerance { get; set; }
        public string SalinityTolerance { get; set; }
        public Measure RootDepthMinimum { get; set; }
        public bool ResproutAbility { get; set; }
        public Measure PrecipitationMinimum { get; set; }
        public Measure PrecipitationMaximum { get; set; }
        public Measure PlantingDensityMinimum { get; set; }
        public Measure PlantingDensityMaximum { get; set; }
        public float PhMinimum { get; set; }
        public float PhMaximum { get; set; }
        public string MoistureUse { get; set; }
        public string HedgeTorelance { get; set; }
        public string FireTorelance { get; set; }
        public string FertilityRequirement { get; set; }
        public string DroughtTolerance { get; set; }
        public bool ColdStratificationRequired { get; set; }
        public string Caco3Tolerance { get; set; }
        public string AnaerobicTolerance { get; set; }
        public float FrostFreeDaysMinimum { get; set; }
    }

    public class Temperature
    {
        public float DegF { get; set; }
        public float DegC { get; set; }
    }


    public class Products
    {
        public bool Veneer { get; set; }
        public bool Pulpwood { get; set; }
        public string ProteinPotential { get; set; }
        public bool Post { get; set; }
        public bool PalatableHuman { get; set; }
        public bool PalatableBrowseAnimal { get; set; }
        public string PalatableGrazeAnimal { get; set; }
        public bool NurseryStock { get; set; }
        public bool NavalStore { get; set; }
        public bool Lumber { get; set; }
        public string Fuelwood { get; set; }
        public bool Fodder { get; set; }
        public bool ChristmasTree { get; set; }
        public bool BerryNutSeed { get; set; }
    }


public class Seed
    {
        public string VegetativeSpreaDrate { get; set; }
        public bool SmallGrain { get; set; }
        public int SeedsPerPound { get; set; }
        public string SeedlingVigor { get; set; }
        public string SeedSpreadRate { get; set; }
        public string CommercialAvailability { get; set; }
        public string BloomPeriod { get; set; }
    }

    public class Propagation
    {
        public bool Tubers { get; set; }
        public bool Sprigs { get; set; }
        public bool Sod { get; set; }
        public bool Seed { get; set; }
        public bool Cuttings { get; set; }
        public bool Corms { get; set; }
        public bool Container { get; set; }
        public bool Bulbs { get; set; }
        public bool BareRoot { get; set; }
    }

    public class Specification
    {
        public string Toxicity { get; set; }
        public string ShapeAndOrientation { get; set; }
        public string RegrouthRate { get; set; }
        public string NitrogenFixation { get; set; }
        public Height MaxHeightAtBaseAge { get; set; }
        public Height MatureHeight { get; set; }
        public bool LowGrowingGrass { get; set; }
        public string LifeSpan { get; set; }
        public bool LeafRetention { get; set; }
        public bool KnownAllElopath { get; set; }
        public string GrowthRate { get; set; }
        public string GrowthPeriod { get; set; }
        public string GrowthHabit { get; set; }
        public string GrowthForm { get; set; }
        public bool FireResistance { get; set; }
        public bool Fallconspicuous { get; set; }
        public bool Coppicepotential { get; set; }
        public string Cnratio { get; set; }
        public string Bloat { get; set; }
       

    }
    public class Height
    {
        public float Ft { get; set; }
        public float Cm { get; set; }
    }

    public class Measure
    {
        public float Inches { get; set; }
        public float Cm { get; set; }
    }

    public class Images
    {
        public string Url { get; set; }
    }

    public class Family
    {
        public Category Category { get; set; }
        public string CommonName { get; set; }
    }

    public class SoilsAdaptation
    {
        public bool Medium { get; set; }
        public bool Fine { get; set; }
        public bool Coarse { get; set; }
    }

    public class Source
    {
        public int SpecieId { get; set; }
        public string SourceUrl { get; set; }
        public string Name { get; set; }
        public DateTime LastUpdate { get; set; }

    }

    public class Category
    {
        public string Slug { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public int Id { get; set; }
    }
}
