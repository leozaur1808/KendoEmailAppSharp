using Moq;
using Moq.Protected;


namespace KendoEmailAppSharp.Tests
{
    public class KendoTests
    {
        private readonly Mock<HttpMessageHandler> _httpMessageHandlerMock;
        private readonly KendoClient _kendo;

        public KendoTests()
        {
            _httpMessageHandlerMock = new Mock<HttpMessageHandler>();
            _kendo = new KendoClient("test-api-key", _httpMessageHandlerMock.Object);
        }

        [Fact]
        public async Task CompanyByDomain_ReturnsCompany()
        {
            // Arrange
            var expectedCompany = new KendoCompany { Name = "Test Company", Credit = 10 };
            var response = new HttpResponseMessage();
            response.Content = new JsonContent(expectedCompany);
            _httpMessageHandlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(response);

            // Act
            var company = await _kendo.CompanyByDomain("test-domain.com");

            // Assert
            Assert.True(company?.Credit == expectedCompany.Credit);
            Assert.Equal(expectedCompany.Name, company?.Name);
        }

        [Fact]
        public async Task CompanyByName_ReturnsCompany()
        {
            // Arrange
            var expectedCompany = new KendoCompany { Name = "Test Company", Credit = 10 };
            var response = new HttpResponseMessage();
            response.Content = new JsonContent(expectedCompany);
            _httpMessageHandlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(response);

            // Act
            var company = await _kendo.CompanyByName("Test Company");

            // Assert
            Assert.True(company?.Credit == expectedCompany.Credit);
            Assert.Equal(expectedCompany.Name, company?.Name);
        }

        [Fact]
        public async Task CompanyLeads_ReturnsLeads()
        {
            // Arrange
            var expectedLeads = new List<KendoLead> { new KendoLead { FirstName = "Test Lead" } };
            var response = new HttpResponseMessage();
            response.Content = new JsonContent(expectedLeads);
            _httpMessageHandlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(response);

            // Act
            var leads = await _kendo.CompanyLeads("test-domain.com", 10);

            // Assert
            Assert.Equal(expectedLeads.Count, leads?.Count);
            Assert.Equal(expectedLeads[0].FirstName, leads?[0]?.FirstName);
        }

        [Fact]
        public async Task CompanyLeadsInfo_ReturnsLeadsInfo() 
        {
            // Arrange
            var expectedLeadsInfo = new KendoLeadsInfo { LeadCount = 10, CompanyName = "Test Company"  };
            var response = new HttpResponseMessage();
            response.Content = new JsonContent(expectedLeadsInfo);
            _httpMessageHandlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(response);

            // Act
            var leadsInfo = await _kendo.CompanyLeadsInfo("test-domain.com");

            // Assert
            Assert.Equal(expectedLeadsInfo.CompanyName, leadsInfo?.CompanyName);
            Assert.Equal(expectedLeadsInfo.LeadCount, leadsInfo?.LeadCount);
        }

        [Fact]
        public async Task EmailByLinkedin_ReturnsEmail()
        {
            // Arrange
            var expectedEmail = new KendoEmail { WorkEmail = "mail@example.com" };
            var response = new HttpResponseMessage();
            response.Content = new JsonContent(expectedEmail);
            _httpMessageHandlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(response);

            // Act
            var email = await _kendo.EmailByLinkedin("https://www.linkedin.com/in/test");

            // Assert
            Assert.Equal(expectedEmail.WorkEmail, email?.WorkEmail);
        }

        [Fact]
        public async Task EmailByName_ReturnsEmail()
        {
            // Arrange
            var expectedEmail = new KendoEmail { WorkEmail = "mail@example.com" };
            var response = new HttpResponseMessage();
            response.Content = new JsonContent(expectedEmail);
            _httpMessageHandlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(response);

            // Act
            var email = await _kendo.EmailByName("Test Name", "test-domain.com");

            // Assert
            Assert.Equal(expectedEmail.WorkEmail, email?.WorkEmail);
        }

        [Fact]
        public async Task GetCredit_ReturnsCredit() 
        {
            // Arrange
            uint expectedCredit = 10;
            var response = new HttpResponseMessage();
            response.Content = new JsonContent(new Dictionary<string, uint> { { "credit", expectedCredit } });
            _httpMessageHandlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(response);

            // Act
            var credit = await _kendo.GetCredit();

            // Assert
            Assert.Equal(expectedCredit, credit);
        }

        [Fact]
        public async Task LinkedinByName_Returns() 
        {
            // Arrange
            var expectedLinkedin = "https://www.linkedin.com/in/test";
            var response = new HttpResponseMessage();
            response.Content = new JsonContent(expectedLinkedin);
            _httpMessageHandlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(response);

            // Act
            var linkedin = await _kendo.LinkedinByName("TestFirst", "TestLast", "test-domain.com");

            // Assert
            Assert.Equal(expectedLinkedin, linkedin);
        }

        [Fact]
        public async Task MobileByLinkedin_ReturnsPhoneNumber() 
        {
            // Arrange
            var expectedMobile = new KendoPhone { PhoneNumber = "+123456789" };
            var response = new HttpResponseMessage();
            response.Content = new JsonContent(expectedMobile);
            _httpMessageHandlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(response);

            // Act
            var mobile = await _kendo.MobileByLinkedin("https://www.linkedin.com/in/test");

            // Assert
            Assert.Equal(expectedMobile.PhoneNumber, mobile);
        }

        [Fact]
        public async Task NameByEmail_ReturnsName() 
        {
            // Arrange
            var expectedName = new KendoName { First = "TestFirst", Last = "TestLast" };
            var expectedNameString = $"{expectedName.First} {expectedName.Last}";
            var response = new HttpResponseMessage();
            response.Content = new JsonContent(expectedName);
            _httpMessageHandlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(response);
            
            // Act
            var name = await _kendo.NameByEmail("mail@example.com");

            // Assert
            Assert.Equal(expectedNameString, name);
        }

        [Fact]
        public async Task VerifyPhoneNumber_ReturnsPhoneNumberStatus() 
        {
            // Arrange
            var expectedPhoneNumberStatus = new KendoPhoneVerification { Results = "FIXED", Credit = 10};
            var response = new HttpResponseMessage();
            response.Content = new JsonContent(expectedPhoneNumberStatus);
            _httpMessageHandlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(response);
            
            // Act
            var phoneNumberStatus = await _kendo.VerifyPhoneNumber("1234567890");

            // Assert
            Assert.Equal(expectedPhoneNumberStatus.Results, phoneNumberStatus?.ToString().ToUpper());
        }
    }
}