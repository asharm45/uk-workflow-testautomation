using Microsoft.Playwright;
using WorkflowSpecflowTests.Driver;

namespace WorkflowSpecflowTests.Pages
{
    internal class ContactCreation
    {
        private readonly IPage _page;
        public ContactCreation(IPlaywrightDriver driver)
        {
            _page = driver.Page.Result;

        }

        private ILocator selContactType => _page.Locator("//*[@id='s2id_IDITForm@entityTypeVO@id']");
        private ILocator inpSurname => _page.Locator("//*[@id='LastName']");

        private ILocator selCountry => _page.Locator("//*[@id='s2id_IDITForm@primaryAddressForDisplay@addressCompoundCountryId']");
        private ILocator inpPostcode => _page.Locator("//*[@id='LastName']");
        private ILocator inpHouseNr => _page.Locator("//*[@id='IDITForm@primaryAddressForDisplay@GB@addressVO@houseNr']");
        private ILocator inpStreetName => _page.Locator("//*[@id='IDITForm@primaryAddressForDisplay@GB@addressVO@streetName']");
        private ILocator inpCity => _page.Locator("//*[@id='IDITForm@primaryAddressForDisplay@GB@addressVO@cityName']");
        private ILocator inpTelephoneNumber => _page.Locator("//*[@id='IDITForm@primaryTelephoneForDisplaytelephoneNumber']");
        

    }
}
