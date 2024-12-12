namespace Domain.Enums;

/// <summary>
/// Represents the different types of vehicle engines.
/// </summary>
public enum EngineType
{
    /// <summary>
    /// Gasoline internal combustion engine.
    /// </summary>
    Petrol,

    /// <summary>
    /// Diesel internal combustion engine.
    /// </summary>
    Diesel,

    /// <summary>
    /// Fully electric motor powered by batteries.
    /// </summary>
    Electric,

    /// <summary>
    /// Combination of internal combustion and electric motor.
    /// </summary>
    Hybrid,

    /// <summary>
    /// Hydrogen fuel cell engine.
    /// </summary>
    Hydrogen,

    /// <summary>
    /// Engine powered by compressed or liquefied natural gas (CNG/LNG).
    /// </summary>
    NaturalGas,

    /// <summary>
    /// Engine powered by liquefied petroleum gas (LPG), also known as propane.
    /// </summary>
    Propane,

    /// <summary>
    /// Engine powered by ethanol-based fuel, an alternative to petrol.
    /// </summary>
    Ethanol,

    /// <summary>
    /// Engine powered by methanol-based fuel.
    /// </summary>
    Methanol,

    /// <summary>
    /// Historical steam engines, primarily used in antique or collector vehicles.
    /// </summary>
    Steam,

    /// <summary>
    /// Wankel rotary combustion engine.
    /// </summary>
    Rotary,

    /// <summary>
    /// Engine powered by solar energy.
    /// </summary>
    Solar,

    /// <summary>
    /// Air-compressed engine, used in some industrial or experimental vehicles.
    /// </summary>
    Pneumatic,

    /// <summary>
    /// Dual-fuel engine capable of running on two different fuel types, such as petrol and CNG.
    /// </summary>
    BiFuel,

    /// <summary>
    /// Non-motorized vehicles or systems with no engine (e.g., bicycles).
    /// </summary>
    None,
}
