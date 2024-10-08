using Microsoft.Extensions.Logging;
using Microsoft.Playwright;
using WorkflowSpecflowTests.Driver;

namespace WorkflowSpecflowTests.Pages
{
    public interface IUnderwriterAuthorityPage
    {
        Task CreateNewBookableResourceAsync(string ResourceType, string User, string Name, string TimeZone);
        Task ClickDeleteAsync();
        Task ClickConfirmDelete();
        Task ClickNewAsync();
        Task ClickRefreshAsync();
        Task ClickUnderwriterAuthoritiesAsync();
        Task ClickSaveAsync();
        Task ClickSaveAndCloseAsync();
        Task ClickDeactiveAsync();
        Task ClickDeactiveConfirmAsync();
        Task EnterAgentAsync(string agent);
        Task EnterPropertyOnlyAsync(string propertyOnly);
        Task EnterMotorOnlyAsync(string motorOnly);
        Task EnterMotorTotalAsync(string motorTotal);
        Task ClickNewlyCreateUWAuthoritiesAsync(string agent);
        Task ClickAgentAsync();
        Task ClickFilterByAsync();
        Task EnterAgentNameAsync(string agent);
        Task ClickApplyAsync();
        Task<string> GetProprtyOnlyAsync();
        Task<string> GetMotorOnlyAsync();
        Task<string> GetMotorTotalAsync();
        Task ClickClearFilterAsync();
        Task SelectAgentAsync();
        Task ClickCreatedOnAsync();
        Task ClickNewerToOlderAsync();
        Task ClickClearKeyboadFilterAsync();
        Task<string> GetAgentNameAsync();
        Task RemoveAgentAsync();
        Task<string> GetLabel(string label);
        Task ClickOnNewBookableResourceAsync();
        Task ClickShareAsync();
        Task ClickManageAccessAsync();
        Task ClickAddUserOrTeamAsync(string userOrTeam);
        Task ClickReadPermissionAsync();
        Task ClickWritePermissionAsync();
        Task ClickDeletePermissionAsync();
        Task ClickAppendPermissionAsync();
        Task ClickAppendToPermissionAsync();
        Task ClickAssignPermissionAsync();
        Task ClickSharePermissionAsync();
        Task ClickShareBtnAsync();
        Task SelectUserAsync();
        Task<string> GetMessageAsync();
        Task ClickCloseAsync();
        Task<ILocator> IsFieldVisible(string fieldname);
        Task ClickAssignAsync();
        Task ClickAssignBtnAsync();
        Task SelectAssignToAsync(string userOrTeam);
        Task SelectUserOrTeamAsync(string userOrTeam);
    }

    public class UnderwriterAuthorityPage : IUnderwriterAuthorityPage
    {
        private readonly IPage _page;
        private readonly IBasePage _basePage;
        private readonly ILogger<UnderwriterAuthorityPage> _logger;
        public UnderwriterAuthorityPage(IPlaywrightDriver driver, IBasePage basePage, ILogger<UnderwriterAuthorityPage> logger)
        {
            _page = driver.Page.Result;
            _basePage = basePage;
            _logger = logger;
        }
        private ILocator DiscardChanges => _page.Locator("//div[text()='Discard changes']");
        private ILocator BackBtn => _page.Locator("//button[@title='Go back']");
        private ILocator UnderwriterAuthorities => _page.Locator("//span[text()='Underwriter Authorities']");
        private ILocator New => _page.Locator("//span[text()='New']");
        private ILocator Delete => _page.Locator("//span[text()='Delete']");
        private ILocator ConfirmDelete => _page.Locator("//div[text()='Delete']");
        private ILocator Refresh => _page.Locator("//span[text()='Refresh']");
        private ILocator Save => _page.Locator("//span[text()='Save']");
        private ILocator SaveAndClose => _page.Locator("//span[text()='Save & Close']");
        private ILocator Deactivate => _page.Locator("//span[text()='Deactivate']");
        private ILocator ConfirmDeactivate => _page.Locator("//button[@title='Deactivate']");
        private ILocator Assign => _page.Locator("//span[text()='Assign']");
        private ILocator Extra => _page.Locator(".MoreVertical-symbol");
        private ILocator AgentField => _page.Locator("//input[@aria-label='Agent, Lookup']");
        private ILocator PropertyOnlyField => _page.Locator("//input[@aria-label='Property only']");
        private ILocator MotorOnly => _page.Locator("//input[@aria-label='Motor only single vehicle']");
        private ILocator MotorTotal => _page.Locator("//input[@aria-label='Motor total accumulation']");
        private ILocator AgentFilter => _page.Locator("(//div[text()='Agent'])[1]");
        private ILocator FilterBy => _page.Locator("//span[text()='Filter by']");
        private ILocator ClearFilter => _page.Locator("//span[text()='Clear filter']");
        private ILocator FilterField => _page.Locator("//input[@aria-label='Filter by value']");
        private ILocator Apply => _page.Locator("//span[text()='Apply']");
        private ILocator AgentName => _page.Locator("(//div[@col-id='ntt_lookup_agent']//span)[1]");
        private ILocator PropertyOnlyValue => _page.Locator("(//div[@col-id='ntt_decimal_propertyonly']//label)[2]");
        private ILocator MotorOnlyValue => _page.Locator("(//div[@col-id='ntt_decimal_motoronlysinglevehicle']//label)[2]");
        private ILocator MotorTotalValue => _page.Locator("(//div[@col-id='ntt_decimal_otortotalaccumulation']//label)[2]");
        private ILocator SelectAgent => _page.Locator("(//span[@data-automationid='splitbuttonprimary']/div)[1]");
        private ILocator CreatedOn => _page.Locator("//div[@data-testid='createdon']//label/div");
        private ILocator NewerToOlder => _page.Locator("//span[text()='Newer to older']");
        private ILocator ClearKeyboadFilter => _page.Locator("//button[@title='Clear search']//i");
        private ILocator RemoveAgent => _page.Locator("//button[@data-id='ntt_lookup_agent.fieldControl-LookupResultsDropdown_ntt_lookup_agent_selected_tag_delete']");
        private ILocator NewBookableResource => _page.Locator("//span[text()='New Bookable Resource']");
        private ILocator UserField => _page.Locator("//label[text()='User']//following::input[1]");
        private ILocator NameField => _page.Locator("//label[text()='Name']//following::input[1]");
        private ILocator TimeZoneField => _page.Locator("//label[text()='Time Zone']//following::button[1]");
        private ILocator ResouceTypeField => _page.Locator("//label[text()='Resource Type']//following::button[1]");
        private ILocator Share => _page.Locator("//button[text()='Share']");
        private ILocator AssignBtn => _page.Locator("//button[@data-id='ok_id']");
        private ILocator ManageAccess => _page.Locator("//span[text()='Manage access']");
        private ILocator AddUserOrTeam => _page.Locator("//input[@aria-label='User or team to share with, Multiple Selection Lookup']");
        private ILocator ReadPermission => _page.Locator("//span[text()='Read']/preceding-sibling::div");
        private ILocator WritePermission => _page.Locator("//span[text()='Write']/preceding-sibling::div");
        private ILocator DeletePermission => _page.Locator("//span[text()='Delete']/preceding-sibling::div");
        private ILocator AppendPermission => _page.Locator("//span[text()='Append']/preceding-sibling::div");
        private ILocator AppendToPermission => _page.Locator("//span[text()='Append to']/preceding-sibling::div");
        private ILocator AssignPermission => _page.Locator("//span[text()='Assign']/preceding-sibling::div");
        private ILocator SharePermission => _page.Locator("//span[text()='Share']/preceding-sibling::div");
        private ILocator ShareBtn => _page.Locator("(//span[text()='Share'])[2]");
        private ILocator SelectUser => _page.Locator("//i[@data-icon-name='StatusCircleCheckmark']");
        private ILocator Close => _page.Locator("//*[@data-testid='dialogCloseIcon']");
        private ILocator AssignTo => _page.Locator("//button[@aria-label='Assign to']");
        private ILocator UserOrTeam => _page.Locator("//input[@aria-label='User or team, Lookup']");
        public async Task<string> GetLabel(string label)
        {
            return await _page.Locator("//div[@title='" + label + "']/label").TextContentAsync();
        }
        public async Task ClickUnderwriterAuthoritiesAsync()
        {
            await _basePage.ClickElementAsync(UnderwriterAuthorities);
            _logger.LogInformation($"Clicked UnderwriterAuthorities button");
        }
        public async Task ClickNewAsync()
        {
            await _basePage.ClickElementAsync(New);
            _logger.LogInformation($"Clicked new button");
        }
        public async Task ClickCreatedOnAsync()
        {
            //await _page.Mouse.WheelAsync(150, 0);
            await _basePage.ClickElementAsync(CreatedOn);
            _logger.LogInformation($"Clicked createdOn button");
        }
        public async Task RemoveAgentAsync()
        {
            await _basePage.ClickElementAsync(RemoveAgent);
            _logger.LogInformation($"Clicked remove agent button");
        }
        public async Task ClickNewerToOlderAsync()
        {
            await _basePage.ClickElementAsync(NewerToOlder);
            //await _page.Mouse.WheelAsync(-150, 0);
            _logger.LogInformation($"Clicked newer to older button");
        }
        public async Task ClickDeleteAsync()
        {
            await _basePage.ClickElementAsync(Delete);
            _logger.LogInformation($"Clicked delete button");
        }
        public async Task ClickRefreshAsync()
        {
            await _basePage.ClickElementAsync(Refresh);
            _logger.LogInformation($"Clicked refresh button");
        }
        public async Task ClickSaveAsync()
        {
            await _basePage.ClickElementAsync(Save);
            _logger.LogInformation($"Clicked save button");
        }
        public async Task ClickClearKeyboadFilterAsync()
        {
            await _basePage.ClickElementAsync(ClearKeyboadFilter);
            _logger.LogInformation($"Clicked clear keyboard option");
        }
        public async Task ClickSaveAndCloseAsync()
        {
            await _basePage.ClickElementAsync(SaveAndClose);
            _logger.LogInformation($"Clicked save&close button");
        }
        public async Task ClickDeactiveAsync()
        {
            await _basePage.ClickElementAsync(Deactivate);
            _logger.LogInformation($"Clicked deactive button");
        }
        public async Task ClickDeactiveConfirmAsync()
        {
            await _basePage.ClickElementAsync(ConfirmDeactivate);
            _logger.LogInformation($"Clicked confirm deactive button");
        }
        public async Task ClickConfirmDelete()
        {
            await _basePage.ClickElementAsync(ConfirmDelete);
            _logger.LogInformation($"Clicked confirm delete button");
        }
        public async Task EnterAgentAsync(string agent)
        {
            await _basePage.FillElementAsync(AgentField, agent);
            await _page.Locator("//span[text()='" + agent + "']").First.ClickAsync();
            _logger.LogInformation($"Entered agent : {agent}");
        }
        public async Task EnterPropertyOnlyAsync(string propertyOnly)
        {
            await _basePage.FillElementAsync(PropertyOnlyField, propertyOnly);
            _logger.LogInformation($"Entered property only : {propertyOnly}");
        }
        public async Task EnterMotorOnlyAsync(string motorOnly)
        {
            await _basePage.FillElementAsync(MotorOnly, motorOnly);
            _logger.LogInformation($"Entered motor only : {motorOnly}");
        }
        public async Task EnterMotorTotalAsync(string motorTotal)
        {
            await _basePage.FillElementAsync(MotorTotal, motorTotal);
            _logger.LogInformation($"Entered motor total : {motorTotal}");
        }
        public async Task ClickNewlyCreateUWAuthoritiesAsync(string agent)
        {
            await _page.Locator("(//span[text()='" + agent + "']//ancestor::div[@col-id='ntt_lookup_agent']//following-sibling::div[@col-id='ntt_decimal_propertyonly'])[1]").DblClickAsync();
        }
        public async Task ClickAgentAsync()
        {
            await _basePage.ClickElementAsync(AgentFilter);
            _logger.LogInformation($"Clicked agent filter button");
        }
        public async Task ClickFilterByAsync()
        {
            await _basePage.ClickElementAsync(FilterBy);
            _logger.LogInformation($"Clicked filter by button");
        }
        public async Task EnterAgentNameAsync(string agent)
        {
            await _basePage.FillElementAsync(FilterField, agent);
            _logger.LogInformation($"Entered agent : {agent}");
        }
        public async Task ClickApplyAsync()
        {
            await _basePage.ClickElementAsync(Apply);
            _logger.LogInformation($"Clicked apply button");
        }
        public async Task<string> GetAgentNameAsync()
        {
            return await AgentName.TextContentAsync();
        }
        public async Task<string> GetProprtyOnlyAsync()
        {
            return PropertyOnlyValue.GetAttributeAsync("label").ToString().Replace(",", "");
        }
        public async Task<string> GetMotorOnlyAsync()
        {
            return MotorOnlyValue.GetAttributeAsync("label").ToString().Replace(",", "");
        }
        public async Task<string> GetMotorTotalAsync()
        {
            return MotorTotalValue.GetAttributeAsync("label").ToString().Replace(",", "");
        }
        public async Task ClickClearFilterAsync()
        {
            await _basePage.ClickElementAsync(ClearFilter);
            _logger.LogInformation($"Clicked clear filter button");
        }
        public async Task SelectAgentAsync()
        {
            await _basePage.ClickElementAsync(SelectAgent);
            _logger.LogInformation($"Clicked select agent button");
        }
        public async Task ClickOnNewBookableResourceAsync()
        {
            await _basePage.ClickElementAsync(AgentField);
            await _basePage.ClickElementAsync(NewBookableResource);
        }
        public async Task CreateNewBookableResourceAsync(string ResourceType, string User, string Name, string TimeZone)
        {
            await _basePage.IsElementVisibleAsync(ResouceTypeField);
            await _basePage.FillElementAsync(UserField, User);
            await _page.Locator("//span[text()='" + User + "']").First.ClickAsync();
            await _basePage.FillElementAsync(NameField, Name);
            await _basePage.IsElementVisibleAsync(TimeZoneField);
            await _basePage.ClickElementAsync(BackBtn);
            await _basePage.ClickElementAsync(DiscardChanges);

        }
        public async Task ClickShareAsync()
        {
            await _basePage.ClickElementAsync(Share);
            _logger.LogInformation($"Clicked share button");
        }
        public async Task ClickManageAccessAsync()
        {
            await _basePage.ClickElementAsync(ManageAccess);
            _logger.LogInformation($"Clicked ManageAccess");
        }
        public async Task ClickAddUserOrTeamAsync(string userOrTeam)
        {
            await _basePage.ClickElementAsync(AddUserOrTeam);
            await _basePage.FillElementAsync(AddUserOrTeam, userOrTeam);
            await _page.Locator("//span[text()='" + userOrTeam + "']").First.ClickAsync();
            _logger.LogInformation($"Entered userOrTeam : {userOrTeam}");
        }
        public async Task ClickReadPermissionAsync()
        {
            await _basePage.ClickElementAsync(ReadPermission);
            _logger.LogInformation($"Clicked Read Permission checkbox");
        }
        public async Task ClickWritePermissionAsync()
        {
            await _basePage.ClickElementAsync(WritePermission);
            _logger.LogInformation($"Clicked Write Permission checkbox");
        }
        public async Task ClickDeletePermissionAsync()
        {
            await _basePage.ClickElementAsync(DeletePermission);
            _logger.LogInformation($"Clicked Delete Permission checkbox");
        }
        public async Task ClickAppendPermissionAsync()
        {
            await _basePage.ClickElementAsync(AppendPermission);
            _logger.LogInformation($"Clicked Append Permission checkbox");
        }
        public async Task ClickAppendToPermissionAsync()
        {
            await _basePage.ClickElementAsync(AppendToPermission);
            _logger.LogInformation($"Clicked Append to Permission checkbox");
        }
        public async Task ClickAssignPermissionAsync()
        {
            await _basePage.ClickElementAsync(AssignPermission);
            _logger.LogInformation($"Clicked Assign Permission checkbox");
        }
        public async Task ClickSharePermissionAsync()
        {
            await _basePage.ClickElementAsync(SharePermission);
            _logger.LogInformation($"Clicked Share Permission checkbox");
        }
        public async Task ClickShareBtnAsync()
        {
            await _basePage.ClickElementAsync(ShareBtn);
            _logger.LogInformation($"Clicked Share button");
        }
        public async Task SelectUserAsync()
        {
            await _basePage.ClickElementAsync(SelectUser);
            _logger.LogInformation($"User or team selected");
        }
        public async Task<string> GetMessageAsync()
        {
            return await _page.Locator(".ms-MessageBar-innerText").TextContentAsync();
        }
        public async Task ClickCloseAsync()
        {
            await _basePage.ClickElementAsync(Close);
            _logger.LogInformation($"Clicked close");
        }

        public async Task<ILocator> IsFieldVisible(string fieldname)
        {
            await _page.Locator("//label[text()='" + fieldname + "']").ScrollIntoViewIfNeededAsync();
            return _page.Locator("//label[text()='" + fieldname + "']");
        }
        public async Task ClickAssignAsync()
        {
            await _basePage.ClickElementAsync(Extra);
            await _basePage.ClickElementAsync(Assign);
            _logger.LogInformation($"Clicked assign");
        }
        public async Task SelectAssignToAsync(string userOrTeam)
        {
            await _basePage.ClickElementAsync(AssignTo);
            Thread.Sleep(3000);
            await _page.Locator("//*[text()='" + userOrTeam + "']").Last.ClickAsync();
            _logger.LogInformation($"Entered userOrTeam : {userOrTeam}");
        }
        public async Task ClickAssignBtnAsync()
        {
            await _basePage.ClickElementAsync(AssignBtn);
            _logger.LogInformation($"Clicked Assign button");
        }
        public async Task SelectUserOrTeamAsync(string userOrTeam)
        {
            await _basePage.ClickElementAsync(UserOrTeam);
            await _basePage.FillElementAsync(UserOrTeam, userOrTeam);
            await _page.Locator("//*[text()='" + userOrTeam + "']").First.ClickAsync();
            _logger.LogInformation($"Entered userOrTeam : {userOrTeam}");
        }
    }
}
