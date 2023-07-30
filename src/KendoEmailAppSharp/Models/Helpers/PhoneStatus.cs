namespace KendoEmailAppSharp;

/// <summary>
/// Specifies the status of a phone number.
/// </summary>
public enum PhoneStatus : byte
{
    /// <summary>
    /// The phone number is fixed.
    /// </summary>
    Fixed,

    /// <summary>
    /// The phone number is mobile.
    /// </summary>
    Mobile,

    /// <summary>
    /// The phone number is invalid.
    /// </summary>
    Invalid,


    /// <summary>
    /// The phone number is unknown.
    /// </summary>
    Unknown,
}
