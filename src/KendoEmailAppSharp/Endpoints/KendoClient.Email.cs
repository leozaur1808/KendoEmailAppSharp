using KendoEmailAppSharp.Models;

namespace KendoEmailAppSharp;

public partial class KendoClient 
{
    public Task<KendoEmail?> EmailByLinkedin(string linkedin, KendoType? type = null)
    {
        Dictionary<string, string> queryParams = new() { { "linkedin", linkedin } };
        if (type is not null) queryParams.Add("type", Enum.GetName(typeof(KendoType), type)!.ToLower());
        return GetAsync<KendoEmail>("/emailbylinkedin", queryParams);
    }

    public Task<KendoEmail?> EmailByName(string name, string domain)
    {
        Dictionary<string, string> queryParams = new() { { "name", name }, { "domain", domain } };
        return GetAsync<KendoEmail>("/emailbyname", queryParams);
    }

    public Task<string> NameByEmail(string email)
    {
        Dictionary<string, string> queryParams = new() { { "email", email } };
        return GetAsync<KendoName>("/namebyemail", queryParams).ContinueWith(t => string.Join(" ", t.Result?.First, t.Result?.Last));
    }

    public Task<List<KendoLead>?> CompanyLeads(string domain, int maxResults, KendoType? type = null, string[]? keywords = null, bool executive = false)
    {
        Dictionary<string, string> queryParams = new() { { "domain", domain }, { "maxresults", maxResults.ToString() } };
        if (type is not null) queryParams.Add("type", Enum.GetName(typeof(KendoType), type)!.ToLower());
        if (keywords is not null) queryParams.Add("keywords", string.Join(",", keywords));
        if (executive) queryParams.Add("executive", "yes");
        return GetAsync<List<KendoLead>>("/companyleads", queryParams);
    }

    public Task<KendoLeadsInfo?> CompanyLeadsInfo(string domain, KendoType? type = null, string[]? keywords = null, bool executive = false)
    {
        Dictionary<string, string>? queryParams = new() { { "domain", domain } };
        if (type is not null) queryParams?.Add("type", Enum.GetName(typeof(KendoType), type)!.ToLower());
        if (keywords is not null) queryParams?.Add("keywords", string.Join(",", keywords));
        if (executive) queryParams?.Add("executive", "yes");
        return GetAsync<KendoLeadsInfo>("/companyleadsinfo", queryParams);
    }
}