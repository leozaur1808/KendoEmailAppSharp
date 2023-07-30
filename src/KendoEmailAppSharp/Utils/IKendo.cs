using KendoEmailAppSharp.Models;

namespace KendoEmailAppSharp.Utils;

/// <summary>
/// Defines the interface for interacting with the KendoEmailApp API.
/// </summary>
internal interface IKendo
{
    /// <summary>
    /// Retrieves the LinkedIn profile ID of a person associated with the given name and company domain. Each profile found costs 1 credit.
    /// </summary>
    /// <param name="first">The first name of the person to retrieve the LinkedIn profile ID for.</param>
    /// <param name="last">The last name of the person to retrieve the LinkedIn profile ID for.</param>
    /// <param name="domain">The domain of the company the person is associated with.</param>
    /// <returns>The LinkedIn profile ID of the person associated with the given name and company domain.</returns>
    Task<string?> LinkedinByName(string first, string last, string domain);

    /// <summary>
    /// Retrieves the full company profile by company domain.
    /// </summary>
    /// <param name="domain">The company domain to look up.</param>
    /// <returns>A <see cref="KendoCompany"/> object containing the full profile of the company associated with the given domain.</returns>
    Task<KendoCompany?> CompanyByDomain(string domain);

    /// <summary>
    /// Retrieves the full company profile by company name.
    /// </summary>
    /// <param name="name">The company name to look up.</param>
    /// <returns>A <see cref="KendoCompany"/> object containing the full profile of the company associated with the given name.</returns>
    Task<KendoCompany?> CompanyByName(string name);

    /// <summary>
    /// Retrieves the email address of a person associated with the given LinkedIn profile ID. Each found email costs 1 credit.
    /// </summary>
    /// <param name="linkedin">The LinkedIn profile ID to retrieve the email address for.</param>
    /// <param name="type">Optional. Limits results to either "personal" or "work" emails.</param>
    /// <returns>A <see cref="KendoEmail"/> object containing the email address of the person associated with the given LinkedIn profile ID.</returns>
    Task<KendoEmail?> EmailByLinkedin(string linkedin, KendoType? type = null);

    /// <summary>
    /// Retrieves the email address of a person associated with the given name and company domain.
    /// </summary>
    /// <param name="name">The full name of the person to retrieve the email address for. Example: "Bill Gates".</param>
    /// <param name="domain">The domain of the company the person is associated with.</param>
    /// <returns>A <see cref="KendoEmail"/> object containing the email address of the person associated with the given name and company domain.</returns>
    Task<KendoEmail?> EmailByName(string name, string domain);

    /// <summary>
    /// Retrieves the first and last name of a person associated with the given email address. Each found name costs 0.2 credits
    /// </summary>
    /// <param name="email">The email address to retrieve the name for.</param>
    /// <returns>A string with first and last names correspondingly.</returns>
    Task<string> NameByEmail(string email);

    /// <summary>
    /// Retrieves a list of leads for a given company domain.
    /// </summary>
    /// <param name="domain">The domain of the company to retrieve leads for.</param>
    /// <param name="maxResults">The maximum number of leads to retrieve.</param>
    /// <param name="type">Optional. Limits results to either "personal" or "work" leads.</param>
    /// <param name="keywords">Optional. List of keywords to search for in lead titles.</param>
    /// <param name="executive">Optional. Set to true to search only for executive profiles.</param>
    /// <returns>A list of <see cref="KendoLead"/> objects containing information about the retrieved leads.</returns>
    Task<List<KendoLead>?> CompanyLeads(string domain, int maxResults, KendoType? type = null, string[]? keywords = null, bool executive = false);

    /// <summary>
    /// Retrieves information about leads for a given company domain.
    /// </summary>
    /// <param name="domain">The domain of the company to retrieve leads information for.</param>
    /// <param name="type">Optional. Limits results to either "personal" or "work" leads.</param>
    /// <param name="keywords">Optional. List of keywords to search for in lead titles.</param>
    /// <param name="executive">Optional. Set to true to search only for executive profiles.</param>
    /// <returns>A <see cref="KendoLeadsInfo"/> object containing information about the retrieved leads.</returns>
    Task<KendoLeadsInfo?> CompanyLeadsInfo(string domain, KendoType? type = null, string[]? keywords = null, bool executive = false);

    /// <summary>
    /// Retrieves the verified personal mobile phone number of a person associated with the given LinkedIn profile ID. Each found profile costs 5 credits.
    /// </summary>
    /// <param name="linkedin">The LinkedIn profile ID to retrieve the mobile phone number for.</param>
    /// <returns>A <see cref="KendoPhone"/> object containing the verified personal mobile phone number of the person associated with the given LinkedIn profile ID.</returns>
    Task<string?> MobileByLinkedin(string linkedin);

    /// <summary>
    /// Verifies a phone number and returns information about its classification as either cellular or landline.
    /// </summary>
    /// <param name="phoneNumber">The phone number to verify.</param>
    /// <returns>A <see cref="KendoPhoneVerification"/> object containing information about the classification of the phone number.</returns>
    Task<PhoneStatus?> VerifyPhoneNumber(string phoneNumber);

    /// <summary>
    /// Return current credit balance.
    /// </summary>
    /// <returns>Uint containing current credit balance.</returns>
    Task<uint?> GetCredit();

}
