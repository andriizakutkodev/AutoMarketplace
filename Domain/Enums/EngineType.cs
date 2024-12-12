namespace Domain.Enums;

/// <summary>
/// Represents the different types of vehicle engines.
/// </summary>
public enum EngineType
{
    /// <summary>
    /// Gasoline internal combustion engine.
    /// </summary>
    Petrol = 1,

    /// <summary>
    /// Diesel internal combustion engine.
    /// </summary>
    Diesel = 2,

    /// <summary>
    /// Fully electric motor powered by batteries.
    /// </summary>
    Electric = 3,

    /// <summary>
    /// Combination of internal combustion and electric motor.
    /// </summary>
    Hybrid = 4,

    /// <summary>
    /// Hydrogen fuel cell engine.
    /// </summary>
    Hydrogen = 5,

    /// <summary>
    /// Engine powered by compressed or liquefied natural gas (CNG/LNG).
    /// </summary>
    NaturalGas = 6,

    /// <summary>
    /// Engine powered by liquefied petroleum gas (LPG), also known as propane.
    /// </summary>
    Propane = 7,

    /// <summary>
    /// Engine powered by ethanol-based fuel, an alternative to petrol.
    /// </summary>
    Ethanol = 8,

    /// <summary>
    /// Engine powered by methanol-based fuel.
    /// </summary>
    Methanol = 9,

    /// <summary>
    /// Historical steam engines, primarily used in antique or collector vehicles.
    /// </summary>
    Steam = 10,

    /// <summary>
    /// Wankel rotary combustion engine.
    /// </summary>
    Rotary = 11,

    /// <summary>
    /// Engine powered by solar energy.
    /// </summary>
    Solar = 12,

    /// <summary>
    /// Air-compressed engine, used in some industrial or experimental vehicles.
    /// </summary>
    Pneumatic = 13,

    /// <summary>
    /// Dual-fuel engine capable of running on two different fuel types, such as petrol and CNG.
    /// </summary>
    BiFuel = 14,

    /// <summary>
    /// Non-motorized vehicles or systems with no engine (e.g., bicycles).
    /// </summary>
    None = 15,
}
