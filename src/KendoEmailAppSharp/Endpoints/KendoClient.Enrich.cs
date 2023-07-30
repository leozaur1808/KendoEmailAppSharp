using KendoEmailAppSharp.Utils;
using KendoEmailAppSharp.Models;

namespace KendoEmailAppSharp;

public partial class KendoClient
{
    public Task<KendoCompany?> CompanyByDomain(string domain)
    {
        return GetAsync<KendoCompany>("/companybydomain", new Dictionary<string, string> { { "domain", domain } });
    }

    public Task<KendoCompany?> CompanyByName(string name)
    {
        return GetAsync<KendoCompany>("/companybyname", new Dictionary<string, string> { { "name", name } });
    }

    public Task<string?> LinkedinByName(string first, string last, string domain)
    {
        Dictionary<string, string> queryParams = new() { { "first", first }, { "last", last }, { "domain", domain } };
        return GetAsync<string>("/linkedinbyname", queryParams);
    }
}
