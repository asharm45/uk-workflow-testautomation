using Microsoft.Extensions.Logging;
using Microsoft.Playwright;
using WorkflowSpecflowTests.Driver;

namespace WorkflowSpecflowTests.Pages
{
    public interface ICasesPage
    {
        Task AddNewCase();
        Task AsyncEnterNotes(string note);
        Task AsyncSelectTheFirstCase();
        Task CaseNoteCreatedAsync(string note);
        Task ChangeDemandAsync(string demand);
        Task ChangeOwnerForCase(string Owner);
        Task ChangePrimaryDemandAsync(string primaryDemand);
        Task ChangeSubDemandAsync(string primaryDemand, string subDemand);
        Task ClickAISuggestionAsync();
        Task ClickAllCases();
        Task ClickAuthenticationProgressionStageInCasePage();
        Task<string> GetPrimaryDemandFromAuthenticationPopupAsync();
        Task ClickBackButtonInStageProgressionPopup();
        Task ClickSetActiveButtonInProgressionPopup();
        Task ClickCloseButtonInStageProgressionPopup();
        Task ClickCancelButtonInResolveCasePopup();
        Task ClickPreviousStageButtonInProgressionBar();
        Task ClickNextStageButtonInProgressionBar();
        Task ClickCancelCase();
        Task ClickCollapse();
        Task ClickConfirmButton();
        Task ClickOnSaveContinue();
        Task ClickOnDiscardButton();
        Task ClickRefresh();
        ILocator GetSitemapMenu(string menu);
        Task<List<string>> GetValueSteps();
        ILocator GetValueStepsMessages();
        ILocator GetProcessedValueStep(string step);
        ILocator GetInProgressValueStep(string step);
        ILocator GetPendingValueStep(string step);
        Task<string> GetStatusReason();
        Task MoveValueStepsToManageReferral();
        Task ReloadPageAsync();
        Task ClickResolveCaseButton();
        Task ClickGoBackButton();
        Task ClickMyActiveCases();
        Task ClickMyResolvedCases();
        Task ClickNewlyCreatedCase(string newCase);
        Task ClickNextStageButtonInStageProgressionPopup();
        Task ClickOnCaseRelationshipsTab();
        Task ClickOnCases();
        Task ClickOnCustomerServiceAdmin();
        Task ClickOnCustomerServiceHub();
        Task ClickOnCustomerServicesIconOnTop();
        Task ClickOnDetailsTab();
        Task ClickOnNewInSLAstoppages();
        Task ClickOnSLATab();
        Task ClickOnSummaryTab();
        Task ClickOpenReportButtonInCasePage();
        Task ClickResolveButtonInResolveCasePopup();
        Task ClickSaveButton();
        Task ClickSaveAndCloseButton();
        Task ClickSaveAndRouteButton();
        Task CloseSignIn();
        Task CreateTaskUnderTime(string subject, string description);
        Task DeleteCase();
        Task EnterCaseDueDateAsync(string userRole, string caseDueDate);
        Task EnterCaseNameAsync(string caseName);
        Task EnterCustomerAsync(string customer);
        Task EnterDemandAsync(string demand);
        Task EnterPolicyReferenceAsync(string policyReference);
        Task EnterPolicyReferenceNumbereAsync(string policyReference);
        Task EnterPrimaryDemandAsync(string primaryDemand);
        Task EnterProductAsync(string product);
        Task EnterResolutionReason(string resolutionReason);
        Task EnterSubDemandAsync(string primaryDemand, string subDemand);
        Task FilterCase(string caseName);
        Task FilterCasesByOwnerName(string ownerName);
        Task GetActiveButtonFromStageProgressionPopup();
        Task GetBackButtonInStageProgressionPopup();
        Task<string> GetCaseDueDate();
        Task<string> GetCaseNameAsync();
        Task<string> GetCaseNumber(string caseName);
        Task<string> GetCaseStatus();
        Task<string> GetDemandAsync();
        ILocator GetReadOnlyLocator();
        Task ClickExpand();
        Task ClickChangeCaseStatus(String statusName);
        Task<string> GetDemandType();
        Task<int> GetLabelCount(string name);
        Task GetNextStageButtonInStageProgressionPopup();
        Task<string> GetPolicyReferenceNumberAsync();
        Task<string> GetPrimaryDemandAsync();
        ILocator GetPrimaryDemandFromCaseCreationPage();
        ILocator GetPriorityFromCasePage();
        ILocator GetReadonlyFields(string fieldName);
        Task<string> GetReInferLabelAsync();
        Task<string> GetRPAFlagAsync();
        ILocator GetSitemapMenu(string parentMenu, string childMenu);
        ILocator GetStatus();
        ILocator GetStatusCase(string statusName);
        Task<ILocator> IsFieldVisible(string name);
        Task<ILocator> IsFieldVisible(string name, int index);
        Task OverrideCasePriority(string casePriority);
        Task SearchGivenView(string searchView);
        Task SelectNewCaseValidateCaseNumber(string caseName);
        Task SelectNewlyCreatedCase(string newCase);
        Task SelectResolutionTypeFromResolveCasePopup(string optionToSelect);
        Task SelectTaskUnderTimeLineInCasePage();
        Task ValidateCaseDueDate(int numberOfDays);
        Task ValidateCaseNameNotPresent(string caseName);
        Task validateUsersDisplayedWithOwnerName(string caseName, string ownerName);
        Task ClickContinueAnywayAsync();
        Task ClearPolicyReferenceNumberAsync();
        Task CaseDueDateValidation();
        Task CaseStatusNewValidation();
        Task ClickSaveAsync();
        Task ClickSaveAndCountinueAsync();
        Task SwitchToInProgress();
        Task SwitchToOnHold();
        Task ValidateNoteNoteEditableAsync();
        Task SelectEmailUnderTimeLineInCasePage();
        Task<string> GetCaseNameErrorMessage();
        Task<string> GetPrimaryDemandErrorMessage();
        Task<string> GetCustomerErrorMessage();
        Task<string> GetPolicyReferenceNumberErrorMessage();
        Task RemoveOwnerAsync();
        Task SelectOwnerAsync(string owner);
        Task ClickOnQueueItemDetails();
        Task ValidateQueuePresentInItemDetails(string queue);
    }

    public class CasesPage : ICasesPage
    {
        private readonly IPage _page;
        private readonly IBrowserContext _browserContext;
        private readonly IBasePage _basePage;
        private readonly ILogger<CasesPage> _logger;

        public CasesPage(IPlaywrightDriver driver, IBasePage basePage, ILogger<CasesPage> logger)
        {
            _page = driver.Page.Result;
            _browserContext = driver.BrowserContext.Result;
            _basePage = basePage;
            _logger = logger;
        }
        private ILocator QueueItemDetailsOption => _page.Locator("//span[text()='Queue Item Details']");
        private ILocator Threedots => _page.Locator("//button[@aria-label='More commands for Case']");
        private ILocator CaseStatusNew => _page.Locator("//div[text()='Case Status']/preceding::div[text()='New']");
        private ILocator StatusNew => _page.Locator("//button[text()='New']");
        private ILocator StatusInProgress => _page.Locator("//button[text()='In Progress']");

        private ILocator ContinueAnyway => _page.Locator("//div[text()='Continue anyway']");
        private ILocator Route => _page.Locator("//div[text()='Route']");
        private ILocator OKbutton => _page.Locator("//div[text()='OK']");
        private ILocator SaveAndContinue => _page.Locator("//div[text()='Save and continue']");
        private ILocator DiscardChanges => _page.Locator("//button[@title='Discard changes']");
        private ILocator AddNote => _page.Locator("//span[text()='Add note and close']");
        private ILocator Timeline => _page.Locator("//h3[text()='Timeline']");
        private ILocator EnterText => _page.Locator("//p[@data-placeholder='Enter text...']");
        private ILocator FirstCase => _page.Locator("//div[text()='Case Name']//following::a[2]");

        private ILocator CustomerServiceIcon => _page.Locator("//*[@data-id='appBreadCrumb']");
        private ILocator CustomerServiceHub => _page.Locator("//div[@title='Customer Service Hub']");
        private ILocator CustomerServiceAdmin => _page.Locator("//div[@title='Customer Service admin center']");
        private ILocator CloseSignInPopup => _page.Locator("//button[@data-id='dialogCloseIconButton']");
        private ILocator Cases => _page.Locator("//div[@title='Cases']//span[1]");
        private ILocator NewCase => _page.Locator("//span[text()='New Case']");
        private ILocator AISuggestion => _page.Locator("//button[@aria-label='Accept all suggestions']");
        private ILocator SummaryTab => _page.Locator("//li[@aria-label='Summary']");
        private ILocator DetailsTab => _page.Locator("//li[@aria-label='Details']");
        private ILocator CaseRelationshipsTab => _page.Locator("//li[@aria-label='Case Relationships']");
        private ILocator SLATab => _page.Locator("//li[@aria-label='SLA Stoppages']");
        private ILocator CaseName => _page.Locator("(//input[@aria-label='Case Name'])[1]");
        private ILocator CaseNameErrorMessage => _page.Locator("//label[text()='Case Name']/parent::div/following::div//span[@data-id='title-error-message']");
        private ILocator PrimaryDemand => _page.Locator("(//div[contains(@title,'Primary Demand')]//following-sibling::div//input)[1]");
        private ILocator PrimaryDemandErrorMessage => _page.Locator("//label[text()='Primary Demand']/parent::div/following::div//span[@data-id='subjectid-error-message']");
        private ILocator DemandSearchIcon => _page.Locator("(//div[starts-with(@title,'Demand')]//following-sibling::div//input)[1]//following-sibling::button/span");
        private ILocator DemandSearch => _page.Locator("(//div[starts-with(@title,'Demand')]//following-sibling::div//input)[1]");
        private ILocator DueDateField => _page.Locator("//label[text()='Case Due Date']/following::input[1]");
        private ILocator DocumentRadio => _page.Locator("(//span[text()='Documents']//ancestor::div[@col-id='ntt_name']//preceding-sibling::div)[1]");
        private ILocator SubDemandSearch => _page.Locator("(//div[starts-with(@title,'Sub Demand')]//following-sibling::div//input)[1]");
        private ILocator CustomerSearch => _page.Locator("(//div[starts-with(@title,'Customer')]//following-sibling::div//input)[1]");
        private ILocator CustomerErrorMessage => _page.Locator("//label[text()='Customer']/parent::div/following::div//span[@data-id='customerid-error-message']");
        private ILocator PolicyReferenceNumberSearch => _page.Locator("(//div[starts-with(@title,'Policy Reference')]//following-sibling::div//input)[1]");
        private ILocator PolicyReferenceNumberErrorMessage => _page.Locator("//label[text()='Policy Reference Number']/parent::div/following::div//span[@data-id='ntt_policyreferencenumber-error-message']"); 
        private ILocator PolicyReferenceSearch => _page.Locator("(//div[starts-with(@title,'Policy Reference')]//following-sibling::div//input)[2]");
        private ILocator PrimaryProduct => _page.Locator("//button[@aria-label='Primary Product']");
        private ILocator ProductField => _page.Locator("//input[@aria-label='Product, Lookup' and @title='Select to enter data']");
        private ILocator SaveButton => _page.Locator("//span[text()='Save']");
        private ILocator SaveAndCloseBUtton => _page.Locator("//span[text()='Save & Close']");
        private ILocator SaveAndRoute => _page.Locator("//span[text()='Save & Route']");
        private ILocator Demand => _page.Locator("//input[starts-with(@aria-label,'Demand')]");
        private ILocator CancelCase => _page.Locator("//span[text()='Cancel Case']");
        private ILocator ConfirmButton => _page.Locator("//button[text()='Confirm']");
        private ILocator RefreshButton => _page.Locator("//span[text()='Refresh']");
        private ILocator PrimaryDemandRequried => _page.Locator("//span[text()='Primary Demand: Required fields must be filled in.']");
        private ILocator ClearPrimaryDemand => _page.Locator("//i[@data-icon-name='Clear']");
        private ILocator ValueSteps => _page.Locator("//*[starts-with(@id,'MscrmControls.Containers.ProcessBreadCrumb-processHeaderStageName_')]");
        private ILocator StatusReason => _page.Locator("//button[@aria-label='Status Reason']");
        private ILocator NextButton => _page.Locator("//label[text()='Next Stage']");
        private ILocator AuthenticationStep => _page.Locator("//div[text()='Authentication' and starts-with(@id,'MscrmControls.Containers.ProcessBreadCrumb-processHeaderStageName')]");
        private ILocator UnderstandRequestStep => _page.Locator("//div[text()='Understand My Request/Assess Information Provided' and starts-with(@id,'MscrmControls.Containers.ProcessBreadCrumb-processHeaderStageName')]");
        private ILocator PerformChangeStep => _page.Locator("//div[text()='Perform Change' and starts-with(@id,'MscrmControls.Containers.ProcessBreadCrumb-processHeaderStageName')]");
        private ILocator ManageReferralStep => _page.Locator("//div[text()='Manage Referral' and starts-with(@id,'MscrmControls.Containers.ProcessBreadCrumb-processHeaderStageName')]");
        private ILocator PresentIssueQuoteStep => _page.Locator("//div[text()='Present & Issue Quote' and starts-with(@id,'MscrmControls.Containers.ProcessBreadCrumb-processHeaderStageName')]");
        private ILocator ArrangePaymentStep => _page.Locator("//div[text()='Arrange Payment' and starts-with(@id,'MscrmControls.Containers.ProcessBreadCrumb-processHeaderStageName')]");
        private ILocator ConfirmPolicyStep => _page.Locator("//div[text()='Confirm Policy & Issue Documents' and starts-with(@id,'MscrmControls.Containers.ProcessBreadCrumb-processHeaderStageName')]");
        private ILocator ResolveCaseButton => _page.Locator("//*[@data-id='CommandBar']//button[@aria-label='Resolve Case']");
        private ILocator GoBackButton => _page.Locator("//button[@title='Go back']");
        private ILocator ResolveButtonInResolveCasePopup => _page.Locator("//*[@data-id='ResolveCase']//button[@title='Resolve']");
        private ILocator CancelButtonInResolveCasePopup => _page.Locator("//*[@data-id='ResolveCase']//button[@title='Cancel']");
        private ILocator ResolutionTypeDropdownButtonInResolveCasePopup => _page.Locator("//*[@data-id='ResolveCase']//button[@aria-label='Resolution Type']");
        private ILocator ResolutionReasonInResolveCasePopup => _page.Locator("//*[@data-id='ResolveCase']//input[@aria-label='Resolution']");
        private ILocator MyActiveCases => _page.Locator("//span[text()='My Active Cases']");
        private ILocator SearchView => _page.Locator("//input[@aria-label='Search views']");
        private ILocator MyResolvedCases => _page.Locator("//label[text()='My Resolved Cases']");
        private ILocator Filter => _page.Locator("//input[@placeholder='Filter by keyword']");
        private ILocator ReadOnly => _page.Locator("(//span[text()='Read-only  This record’s status: Resolved'])[2]");
        private ILocator ExpendIcon => _page.Locator("//span[@id='expandIcon']");
        private ILocator RemoveOwner => _page.Locator("//span[@data-id='header_ownerid.fieldControl-LookupResultsDropdown_ownerid_microsoftIcon_cancelButton']");
        private ILocator ChangeCaseStatus => _page.Locator("//button[@aria-label='Case Status']");
        private ILocator ClickSelectOnHold => _page.Locator("//*[text()='On Hold']");
        private ILocator ClickSelectInProgress => _page.Locator("//*[text()='In Progress']");
        private ILocator DemandType => _page.Locator("//input[@aria-label='Demand Type']");
        private ILocator CaseNumberField => _page.Locator("//label[text()='Case Number']/following::input[1]");
        private ILocator DeleteBtn => _page.Locator("//span[text()='Delete']");
        private ILocator DeletePrompt => _page.Locator("//div[text()='Delete']");
        private ILocator CaseStatus => _page.Locator("//div[text()='Status']//preceding-sibling::div/div");
        private ILocator ExpandIconInCasePage => _page.Locator("//span[@id='expandIcon']");
        private ILocator PriorityDropdownInCasePage => _page.Locator("//button[@aria-label='Priority']");
        private ILocator AddButtonInTimeLine => _page.Locator("//button[@title='Create a timeline record.']");
        private ILocator SubjectLocatorForTask => _page.Locator("//input[@aria-label='Subject']");
        private ILocator DescriptionLocatorForTask => _page.Locator("//textarea[@aria-label='Description']");
        private ILocator SaveAndCloseButtonLocatorForTask => _page.Locator("//button[@data-id='quickCreateSaveAndCloseBtn']");
        private ILocator OpenRecordInTaskUnderTimeline => _page.Locator("//a[@title='Open Record']");
        private ILocator OpenRecordInListPopupUnderTimeline => _page.Locator("//li//div[text()='Open Record']");
        private ILocator MainActionsLink => _page.Locator("//button[@title='Main actions']");
        private ILocator AuthenticationProgressionStageName => _page.Locator("//*[@title='Authentication']//*[text()='Authentication']");
        private ILocator AuthenticationProgressionStagePrimaryDemand => _page.Locator("(//div[contains(@title,'Primary Demand')]//following-sibling::div//input)[2]");
        private ILocator NextStageButtonInProgressionPopup => _page.Locator("//*[@title='Next Stage']");
        private ILocator BackButtonInProgressionPopup => _page.Locator("//*[@title='Back']");
        private ILocator CloseXButtonInProgressionPopup => _page.Locator("//*[@title='Close']");
        private ILocator NextStageButtonInProgressionBar => _page.Locator("//button[@title='Move to the next stage']");
        private ILocator PreviousButtonInProgressionBar => _page.Locator("//button[@title='Move to the previous stage']");
        private ILocator ActiveStageButtonInProgressionPopup => _page.Locator("//*[@title='Set Active']");
        private ILocator AcceptSuggestionsBtn => _page.Locator("//button[@aria-label='Accept all suggestions']");
        private ILocator MoreEditableFields => _page.Locator("//button[@title='More Header Editable Fields']");
        private ILocator CancelOwner => _page.Locator("//label[text()='Owner']/following::div//button[starts-with(@aria-label,'Delete')]");
        private ILocator ChangeOwner => _page.Locator("//label[text()='Owner']/following::input");
        private ILocator EnteraNote => _page.Locator("//span[text()='Enter a note...']");
        private ILocator AllCasesOPtions => _page.Locator("//label[text()='All Cases']");
        private ILocator OwnerByDropdown => _page.Locator("//*[@data-testid='ownerid']//i");
        private ILocator OwnerFilterByoption => _page.Locator("//*[text()='Filter by']");
        private ILocator FilterByValueUsername => _page.Locator("//*[text()='Filter by value']/parent::div//input");
        private ILocator ApplyButton => _page.Locator("//span[text()='Apply']");
        private ILocator NewButtonInSLAStoppage => _page.Locator("//*[@aria-label='New']");
        private ILocator DemandValue => _page.Locator("//div[@data-id='ntt_lookup_demand.fieldControl-LookupResultsDropdown_ntt_lookup_demand_selected_tag_text']");
        private ILocator ReInferValue => _page.Locator("//div[@data-id='ntt_lookup_reinferlabel.fieldControl-LookupResultsDropdown_ntt_lookup_reinferlabel_selected_tag_text']");
        private ILocator RPAFlag => _page.Locator("//button[@aria-label='RPA']");
        private ILocator ID => _page.Locator("//label[text()='ID']");
        private ILocator More => _page.Locator("//button[@data-id='OverflowButton']");
        private ILocator CloseBtn => _page.Locator("//h1/following::button[@title='Close']");
        private ILocator CaseDueDateField => _page.Locator("//label[text()='Case Due Date']/following::input[1]");
        private ILocator InProgress => _page.Locator("//div[text()='In Progress']");
        private ILocator OnHold => _page.Locator("//div[text()='On Hold']");
        private ILocator Owner => _page.Locator("//input[@aria-label='Owner, Lookup']");
        private ILocator QueueField => _page.Locator("//label[text()='Queue']//following::div[@role='link']/div[1]");

        public async Task RemoveOwnerAsync()
        {
            await _basePage.ClickElementAsync(RemoveOwner);
            _logger.LogInformation($"Removed owner");
        }
        public async Task SelectOwnerAsync(string owner)
        {
            await _basePage.FillElementAsync(Owner, owner);
            await _page.Keyboard.PressAsync("Enter");
            _logger.LogInformation($"Owner selected");
        }
        public async Task ClickOnCustomerServiceHub()
        {
            //await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
            try
            {
                await _page.WaitForSelectorAsync("//iframe[@id='AppLandingPage']");

                await _page.FrameLocator("//iframe[@id='AppLandingPage']").Locator("#refreshLbl").ClickAsync();
                await _page.FrameLocator("//iframe[@id='AppLandingPage']").Locator("//div[@title='Customer Service Hub']").ClickAsync();
                _logger.LogInformation("Clicked on Customer Service Hub");
            }
            catch (Exception ex)
            {
                await _page.WaitForSelectorAsync("//iframe[@id='AppLandingPage']");

                await _page.FrameLocator("//iframe[@id='AppLandingPage']").Locator("#refreshLbl").ClickAsync();
                await _page.FrameLocator("//iframe[@id='AppLandingPage']").Locator("//div[@title='Customer Service Hub']").ClickAsync();
                
                _logger.LogInformation("Clicked on Customer Service Hub");
            }
        }
        public async Task ClickOnCustomerServiceAdmin()
        {
            //await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
            try
            {
                await _page.WaitForSelectorAsync("//iframe[@id='AppLandingPage']");

                await _page.FrameLocator("//iframe[@id='AppLandingPage']").Locator("#refreshLbl").ClickAsync();
                await _page.FrameLocator("//iframe[@id='AppLandingPage']").Locator("//div[@title='A unified app for customer service administration.']").ClickAsync();

                _logger.LogInformation("Clicked on Customer Service admin center");
            }
            catch (Exception ex)
            {
                await _page.WaitForSelectorAsync("//iframe[@id='AppLandingPage']");

                await _page.FrameLocator("//iframe[@id='AppLandingPage']").Locator("#refreshLbl").ClickAsync();
                await _page.FrameLocator("//iframe[@id='AppLandingPage']").Locator("//div[@title='A unified app for customer service administration.']").ClickAsync();

                _logger.LogInformation("Clicked on Customer Service admin center");
            }
        }

        public async Task ClickOnCustomerServicesIconOnTop()
        {
            await _basePage.ClickElementAsync(CustomerServiceIcon);
            _logger.LogInformation("Clicked on Customer Service icon");
        }
        public async Task ClickOnCases()
        {
            //await _page.EvaluateAsync("document.body.style.zoom=0.75");
            if (await _page.Locator("//button[@aria-label='Copilot']//img").IsVisibleAsync())
            {
                await _page.Locator("//button[@aria-label='Copilot']//img").ClickAsync();
            }

            await _basePage.ClickElementAsync(Cases);
            _logger.LogInformation("Clicked on cases");

            if (await ContinueAnyway.IsVisibleAsync())
            {
                await _basePage.ClickElementAsync(ContinueAnyway);
                _logger.LogInformation("Clicked on continue anyway");
            }
        }

        public async Task AddNewCase()
        {
            await _page.WaitForLoadStateAsync();
            if (await _page.Locator("//h2[text()='Copilot']").IsVisibleAsync())
            {
                await _page.Locator("//button[@aria-label='Copilot']//img").ClickAsync();
            }
            await _basePage.ClickElementAsync(NewCase);
            _logger.LogInformation("Clicked on new case");
        }

        public async Task ClickAISuggestionAsync()
        {
            try
            {
                await _page.WaitForSelectorAsync("//button[@aria-label='Accept all suggestions']");
                await _basePage.ClickElementAsync(AISuggestion);
                _logger.LogInformation("Clicked on AI Suggestion button");
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message}");
            }
        }
        public async Task ClickOnSummaryTab()
        {
            await _basePage.ClickElementAsync(SummaryTab);
            _logger.LogInformation("Clicked on summary tab");
        }

        public async Task ClickOnDetailsTab()
        {
            await _basePage.ClickElementAsync(DetailsTab);
            _logger.LogInformation("Clicked on details tab");

        }

        public async Task ClickOnCaseRelationshipsTab()
        {
            await _basePage.ClickElementAsync(CaseRelationshipsTab);
            _logger.LogInformation("Clicked on case relationship tab");
        }
        public async Task ClickContinueAnywayAsync()
        {

            await _basePage.ClickElementAsync(ContinueAnyway);
            _logger.LogInformation("Clicked on continue anyway");

        }
        public async Task ClickOnSLATab()
        {
            await _basePage.ClickElementAsync(SLATab);
            _logger.LogInformation("Clicked on SLA tab");
        }

        public async Task CloseSignIn()
        {
            await _basePage.ClickElementAsync(CloseSignInPopup);
            _logger.LogInformation("Closed sign in popup");
        }

        public async Task<ILocator> IsFieldVisible(string name, int index)
        {
            await _page.Locator("(//label[text()='" + name + "'])[" + index + "]").ScrollIntoViewIfNeededAsync();
            return _page.Locator("(//label[text()='" + name + "'])[" + index + "]");
        }

        public async Task<ILocator> IsFieldVisible(string name)
        {
            await _page.Locator("//div[starts-with(@title,'" + name + "')]/label").ScrollIntoViewIfNeededAsync();
            return _page.Locator("//div[starts-with(@title,'" + name + "')]/label");
        }

        public async Task EnterCaseNameAsync(string caseName)
        {
            await _basePage.FillElementAsync(CaseName, caseName);
            _logger.LogInformation($"Entered case name {caseName}");
        }
        public async Task EnterPrimaryDemandAsync(string primaryDemand)
        {
            await _page.WaitForLoadStateAsync();
            Thread.Sleep(2000);
            if (await _page.Locator("//h2[text()='Copilot']").IsVisibleAsync())
            {
                await _page.Locator("//button[@aria-label='Copilot']//img").ClickAsync();
            }
            
            await _basePage.FillElementAsync(PrimaryDemand, primaryDemand);
            await _page.Locator("//div[@title='" + primaryDemand + "']/div/div").First.ScrollIntoViewIfNeededAsync();
            
            await _page.Locator("//div[@title='" + primaryDemand + "']/div/div").First.ClickAsync();
            Thread.Sleep(2000);
            _logger.LogInformation($"Entered primary demand {primaryDemand}");
        }
        public async Task EnterDemandAsync(string demand)
        {
            await _basePage.FillElementAsync(DemandSearch, demand);
            await _page.Locator("//span[text()='" + demand + "']").First.ClickAsync();
            _logger.LogInformation($"Entered demand {demand}");
        }
        public async Task EnterSubDemandAsync(string primaryDemand, string subDemand)
        {
            if (!primaryDemand.Equals("Error Management"))
            {
                await _basePage.FillElementAsync(SubDemandSearch, subDemand);
                await _page.Locator("//span[text()='" + subDemand + "']").First.ClickAsync();
                _logger.LogInformation($"Entered sub demand {subDemand}");
            }
        }
        public async Task EnterCustomerAsync(string customer)
        {
            await _basePage.FillElementAsync(CustomerSearch, customer);
            await _page.Locator("//span[text()='" + customer + "']").First.ClickAsync();
            _logger.LogInformation($"Entered customer {customer}");
        }
        public async Task EnterPolicyReferenceNumbereAsync(string policyReference)
        {
            Thread.Sleep(4000);
            await _basePage.FillElementAsync(PolicyReferenceNumberSearch, policyReference);
            _logger.LogInformation($"Entered primary reference number {policyReference}");
        }
        public async Task EnterPolicyReferenceAsync(string policyReference)
        {
            await _page.Mouse.WheelAsync(0, 500);

            await _basePage.FillElementAsync(PolicyReferenceSearch, policyReference);
            await _page.Locator("//span[text()='" + policyReference + "']").First.ClickAsync();
            _logger.LogInformation($"Entered primary reference {policyReference}");
        }
        public async Task ClearPolicyReferenceNumberAsync()
        {
            await _page.Mouse.WheelAsync(0, 500);

            await PolicyReferenceNumberSearch.ClearAsync();
            _logger.LogInformation($"Cleared primary reference number");
        }
        public async Task EnterProductAsync(string primaryProduct)
        {
            await _basePage.ClickElementAsync(PrimaryProduct);
            _logger.LogInformation($"Clicked on Primary Product dropdown");

            await _basePage.ClickElementAsync(_page.Locator("//*[@role='listbox']//div[text()='" + primaryProduct + "']"));
            _logger.LogInformation($"select the option : {primaryProduct}");
        }
        public async Task EnterCaseDueDateAsync(string userRole, string caseDueDate)
        {
            if (userRole.ToLower().Equals("admin"))
            {
                await _basePage.FillElementAsync(DueDateField, caseDueDate);
                _logger.LogInformation($"Entered case due date : {caseDueDate}");
            }
        }
        public async Task ClickSaveAndCountinueAsync()
        {
            Thread.Sleep(1000);

            if (await SaveAndContinue.IsVisibleAsync())
            {
                await _basePage.ClickElementAsync(SaveAndContinue);
                _logger.LogInformation($"Clicked save and continue button");
            }
        }
        public async Task ClickSaveButton()
        {
            if (await SaveButton.IsVisibleAsync())
            {
                await _basePage.ClickElementAsync(SaveButton);
                _logger.LogInformation($"Clicked save and continue button");
            }
            Thread.Sleep(1000);
            if (await SaveAndContinue.IsVisibleAsync())
            {
                await _basePage.ClickElementAsync(SaveAndContinue);
                _logger.LogInformation($"Clicked save and continue button");
            }
            Thread.Sleep(3000);
            if (await ContinueAnyway.IsVisibleAsync())
            {
                await _basePage.ClickElementAsync(ContinueAnyway);
                _logger.LogInformation($"Clicked continue anyway");
            }
        }

        public async Task ClickSaveAndCloseButton()
        {
            Thread.Sleep(1000);

            if (await SaveAndCloseBUtton.IsVisibleAsync())
            {
                await _basePage.ClickElementAsync(SaveAndCloseBUtton);
                _logger.LogInformation($"Clicked save and close button");
            }
            Thread.Sleep(3000);
            if (await ContinueAnyway.IsVisibleAsync())
            {
                await _basePage.ClickElementAsync(ContinueAnyway);
                _logger.LogInformation($"Clicked continue anyway");
            }
        }

        public async Task ClickSaveAndRouteButton()
        {
            Thread.Sleep(1000);

            if (await SaveAndRoute.IsVisibleAsync())
            {
                await _basePage.ClickElementAsync(SaveAndRoute);
                _logger.LogInformation($"Clicked save and Route button");
            }

            Thread.Sleep(7000);
            if (await Route.IsVisibleAsync())
            {
                await _basePage.ClickElementAsync(Route);
                _logger.LogInformation($"Clicked Route");
                Thread.Sleep(2000);
                if (await OKbutton.IsVisibleAsync())
                {
                    await _basePage.ClickElementAsync(OKbutton);
                }
            }

            Thread.Sleep(2000);
            if (await ContinueAnyway.IsVisibleAsync())
            {
                await _basePage.ClickElementAsync(ContinueAnyway);
                _logger.LogInformation($"Clicked continue anyway");
            }
        }
        public async Task ClickSaveAsync()
        {
            await _basePage.ClickElementAsync(SaveButton);
            _logger.LogInformation($"Clicked save button");
        }

        public ILocator GetStatus()
        {
            return _page.Locator("//div[text()='Status']//preceding-sibling::div/div");
        }

        public ILocator GetStatusCase(string caseName)
        {
            return _page.Locator("//span[text()='"+ caseName+"']//ancestor::div[@col-id='title']//following-sibling::div[@col-id='statuscode']//label/div");
        }
        public async Task ClickNewlyCreatedCase(string newCase)
        {
            await _page.Locator("//span[text()='" + newCase + "']").First.ClickAsync();
            _logger.LogInformation($"Clicked on newly created case : {newCase}");
        }
        public async Task ClickOnQueueItemDetails()
        {
            if (await QueueItemDetailsOption.IsVisibleAsync())
            {
                await _basePage.ClickElementAsync(QueueItemDetailsOption);
            }
            else
            {
                await _basePage.ClickElementAsync(Threedots);
                await _basePage.ClickElementAsync(QueueItemDetailsOption);
            }            
        }
        public async Task ValidateQueuePresentInItemDetails(string queue)
        {
            var q = await QueueField.InnerTextAsync();
            ILocatorAssertions.Equals(queue,q);
        }

        public async Task<string> GetCaseNumber(string caseName)
        {
            return await _page.Locator("//span[text()='" + caseName + "']//ancestor::div[@col-id='title']/following-sibling::div//label/div").TextContentAsync();
        }

        public async Task SelectNewlyCreatedCase(string newCase)
        {
            await _page.Locator("//span[text()='" + newCase + "']//ancestor::div[@col-id='title']/preceding-sibling::div//i").ClickAsync();
        }

        public async Task SelectNewCaseValidateCaseNumber(string caseName)
        {
            await _basePage.IsElementVisibleAsync(CaseNumberField);
            _logger.LogInformation($"Case number is visible : {caseName}");
        }
        public async Task ClickCancelCase()
        {
            await _basePage.ClickElementAsync(CancelCase);
            _logger.LogInformation($"Clicked more cancel case");
        }
        public async Task ClickConfirmButton()
        {
            await _basePage.ClickElementAsync(ConfirmButton);
            _logger.LogInformation($"Clicked confirm button");
        }
        public async Task ClickRefresh()
        {
            Thread.Sleep(2000);
            await _basePage.ClickElementAsync(RefreshButton);
            _logger.LogInformation($"Clicked more refresh button");
        }
        public async Task ClickOnSaveContinue()
        {
            if (await SaveAndContinue.IsVisibleAsync())
            {
                await _basePage.ClickElementAsync(SaveAndContinue);
                _logger.LogInformation($"Clicked Save and continue button");
            }
            if (await ContinueAnyway.IsVisibleAsync())
            {
                await _basePage.ClickElementAsync(ContinueAnyway);
                _logger.LogInformation($"Clicked continue anyway");
            }
        }

        public async Task ClickOnDiscardButton()
        {
            if (await DiscardChanges.IsVisibleAsync())
            {
                await _basePage.ClickElementAsync(DiscardChanges);
                _logger.LogInformation($"Clicked 'Discard Changes' button");
            }            
        }

        public async Task ChangePrimaryDemandAsync(string primaryDemand)
        {
            await _page.Mouse.WheelAsync(0, 500);
            await _basePage.ClickElementAsync(PrimaryDemand);
            _logger.LogInformation($"Clicked primary demand : {primaryDemand}");
            await _basePage.ClickElementAsync(ClearPrimaryDemand);
            Thread.Sleep(2000);
            await _basePage.FillElementAsync(PrimaryDemand, primaryDemand);
            await _page.Locator("//div[@title='" + primaryDemand + "']/div/div").First.ClickAsync();
            _logger.LogInformation($"Entered primary demand : {primaryDemand}");

            Thread.Sleep(2000);
        }
        public async Task ChangeDemandAsync(string demand)
        {
            await _basePage.ClickElementAsync(DemandSearch);

            await _basePage.FillElementAsync(DemandSearch, demand);
            await _page.Locator("//span[text()='" + demand + "']").First.ClickAsync();
            _logger.LogInformation($"Entered demand : {demand}");

        }
        public async Task ChangeSubDemandAsync(string primaryDemand, string subDemand)
        {
            if (!primaryDemand.Equals("Error Management"))
            {
                await _basePage.FillElementAsync(SubDemandSearch, subDemand);
                await _page.Locator("//span[text()='" + subDemand + "']").First.ClickAsync();
                _logger.LogInformation($"Entered sub demand : {subDemand}");
            }
        }

        public ILocator GetSitemapMenu(string menu)
        {
            _page.Locator("//div[@title='" + menu + "']//span[2]").ScrollIntoViewIfNeededAsync();
            return _page.Locator("//div[@title='" + menu + "']//span[2]");
        }

        public ILocator GetSitemapMenu(string parentMenu, string childMenu)
        {
            _page.Locator("//h3[text()='" + parentMenu + "']//following-sibling::ul//span[text()='" + childMenu + "']").ScrollIntoViewIfNeededAsync();
            return _page.Locator("//h3[text()='" + parentMenu + "']//following-sibling::ul//span[text()='" + childMenu + "']");
        }


        public ILocator GetProcessedValueStep(string step)
        {
            return _page.Locator("//div[@title='" + step + "']//following-sibling::div//div[contains(@id,'MscrmControls.Containers.ProcessBreadCrumb-processHeaderStageIndicator')]");
        }

        public ILocator GetInProgressValueStep(string step)
        {
            return _page.Locator("//div[@title='" + step + "']//following-sibling::div//div[contains(@id,'MscrmControls.Containers.ProcessBreadCrumb-stageIndicatorInnerHolder')]");
        }

        public ILocator GetPendingValueStep(string step)
        {
            return _page.Locator("//div[@title='" + step + "']//following-sibling::div//div[contains(@id,'MscrmControls.Containers.ProcessBreadCrumb-stageIndicatorHolder')]");
        }

        public async Task<string> GetStatusReason()
        {
            return await StatusReason.TextContentAsync();

        }

        public async Task ValidateCaseDueDate(int numberOfDays)
        {
            await _basePage.GetFutureDateExcludingWeekendsAsync(5);
            _logger.LogInformation($"Case due date should be : " + await _basePage.GetFutureDateExcludingWeekendsAsync(5));
        }
        public async Task<string> GetCaseDueDate()
        {
            await CaseName.DblClickAsync();
            _logger.LogInformation("Double clicked on case name");
            await _page.Mouse.WheelAsync(0, 650);
            return await DueDateField.GetAttributeAsync("value");
        }
        public async Task<List<string>> GetValueSteps()
        {
            int count = await ValueSteps.CountAsync();
            List<string> actualList = new List<string>();

            for (int i = 0; i < count; i++)
            {
                actualList.Add(await ValueSteps.Nth(i).TextContentAsync());
            }

            return actualList;

        }

        public ILocator GetValueStepsMessages()
        {
            return _page.Locator("//*[@aria-label='Check for']");
        }

        public async Task MoveValueStepsToManageReferral()
        {
            await _basePage.ClickElementAsync(AuthenticationStep);
            _logger.LogInformation($"Clicked on Authentication step");
            await _basePage.ClickElementAsync(NextButton);
            _logger.LogInformation($"Clicked on next button");
            Thread.Sleep(2000);
            await _basePage.ClickElementAsync(UnderstandRequestStep);
            _logger.LogInformation($"Clicked on understand request step");
            await _basePage.ClickElementAsync(NextButton);
            _logger.LogInformation($"Clicked on next button");
            Thread.Sleep(2000);
            await _basePage.ClickElementAsync(PerformChangeStep);
            _logger.LogInformation($"Clicked on perform change step");
            await _basePage.ClickElementAsync(NextButton);
            _logger.LogInformation($"Clicked on next button");
            Thread.Sleep(2000);
        }

        public async Task ClickResolveCaseButton()
        {
            
            await _basePage.ClickElementAsync(ResolveCaseButton);
            _logger.LogInformation($"Clicked on resolved case button");
        }
        public async Task ClickGoBackButton()
        {
            await _basePage.ClickElementAsync(GoBackButton);
            _logger.LogInformation($"Clicked on go back button");
        }

        public async Task ClickResolveButtonInResolveCasePopup()
        {
            await _basePage.ClickElementAsync(ResolveButtonInResolveCasePopup);
            _logger.LogInformation($"Clicked on resolve button");
        }

        public async Task ClickCancelButtonInResolveCasePopup()
        {
            await _basePage.ClickElementAsync(CancelButtonInResolveCasePopup);
            _logger.LogInformation($"Clicked on cancel button");
        }

        public async Task SelectResolutionTypeFromResolveCasePopup(string optionToSelect)
        {
            await _basePage.ClickElementAsync(ResolutionTypeDropdownButtonInResolveCasePopup);
            _logger.LogInformation($"Clicked on resolution type dropdown");

            await _page.Locator("//*[text()='" + optionToSelect + "']").ScrollIntoViewIfNeededAsync();
            await _page.Locator("//*[text()='" + optionToSelect + "']").ClickAsync();
            _logger.LogInformation($"Clicked on the option : {optionToSelect}");
        }

        public async Task EnterResolutionReason(string resolutionReason)
        {
            await _basePage.FillElementAsync(ResolutionReasonInResolveCasePopup, resolutionReason);
            _logger.LogInformation($"Entered resolution reason : {resolutionReason}");
        }

        public async Task<int> GetLabelCount(string name)
        {
            return await _page.Locator("//label[text()='" + name + "']").CountAsync();
        }

        public async Task ClickMyActiveCases()
        {
            await _basePage.ClickElementAsync(MyActiveCases);
            _logger.LogInformation($"Clicked on active case");
        }

        public async Task ClickAllCases()
        {
            await _basePage.ClickElementAsync(MyActiveCases);
            _logger.LogInformation($"Clicked on my active case");
            await _basePage.ClickElementAsync(AllCasesOPtions);
            _logger.LogInformation($"Clicked on all cases");
        }
        public async Task FilterCasesByOwnerName(string ownerName)
        {
            await _basePage.ClickElementAsync(OwnerByDropdown);
            _logger.LogInformation($"Clicked on owner by dropdown");
            await _basePage.ClickElementAsync(OwnerFilterByoption);
            _logger.LogInformation($"Clicked on owner filter by option");
            await _basePage.FillElementAsync(FilterByValueUsername, ownerName);
            await _page.Locator("//div[text()='" + ownerName + "']").First.ClickAsync();
            _logger.LogInformation($"Entered owner name : {ownerName}");
            await _basePage.ClickElementAsync(ApplyButton);
            _logger.LogInformation($"Clicked on apply button");
        }

        public async Task validateUsersDisplayedWithOwnerName(string caseName, string ownerName)
        {
            await _basePage.IsElementVisibleAsync(_page.Locator("//span[text()='" + caseName + "']//ancestor::div[@col-id='title']/preceding-sibling::div//i"));
        }

        public async Task SearchGivenView(string searchView)
        {
            await _basePage.FillElementAsync(SearchView, searchView);
            _logger.LogInformation($"Entered serach given view : {searchView}");
        }

        public async Task DeleteCase()
        {
            await _basePage.ClickElementAsync(DeleteBtn);
            _logger.LogInformation($"Clicked on delete button");
            await _basePage.ClickElementAsync(DeletePrompt);
            _logger.LogInformation($"Clicked on delete confirm button");
        }

        public async Task ClickMyResolvedCases()
        {
            await _basePage.ClickElementAsync(MyResolvedCases);
            _logger.LogInformation($"Clicked on my resolved cases");
        }

        public async Task FilterCase(string caseName)
        {
            await _basePage.FillElementAsync(Filter, caseName);
            await _page.Keyboard.PressAsync("Enter");
            _logger.LogInformation($"Entered case name : {caseName}");
        }

        public ILocator GetReadOnlyLocator()
        {
            return ReadOnly;
        }

        public async Task ClickExpand()
        {
            await _basePage.ClickElementAsync(ExpendIcon);
            _logger.LogInformation($"Clicked on Expend icon");
        }
        public async Task ClickChangeCaseStatus(String statusName)
        {
            await _basePage.ClickElementAsync(ChangeCaseStatus);
            _logger.LogInformation($"Clicked on change case status");
            if (statusName.Equals("On Hold"))
            {
                await _basePage.ClickElementAsync(ClickSelectOnHold);
                _logger.LogInformation($"Selected on-hold");
            }
            if (statusName.Equals("In Progress"))
            {
                await _basePage.ClickElementAsync(ClickSelectInProgress);
                _logger.LogInformation($"Selected in-progress");
            }

        }

        public async Task ClickCollapse()
        {
            await _basePage.ClickElementAsync(ExpendIcon);
            _logger.LogInformation($"Clicked on Expend Icon");
        }

        public async Task<string> GetDemandType()
        {
            return await DemandType.TextContentAsync();
        }

        public ILocator GetPrimaryDemandFromCaseCreationPage()
        {
            return _page.Locator("//label[text()='Primary Demand']//parent::div/following-sibling::div//input");
        }
        public ILocator GetPriorityFromCasePage()
        {
            return _page.Locator("//div[text()='Priority']//preceding-sibling::div/div");
        }

        public async Task OverrideCasePriority(string casePriority)
        {
            await _basePage.ClickElementAsync(ExpandIconInCasePage);
            _logger.LogInformation($"Clicked on expend icon");
            await _basePage.ClickElementAsync(PriorityDropdownInCasePage);
            _logger.LogInformation($"Clicked on priority drop down");

            await _page.Locator("//*[@role='listbox']//div[text()='" + casePriority + "']").ScrollIntoViewIfNeededAsync();
            await _page.Locator("//*[@role='listbox']//div[text()='" + casePriority + "']").ClickAsync();
            _logger.LogInformation($"Clicked on case priority : {casePriority}");
        }

        public async Task SelectTaskUnderTimeLineInCasePage()
        {
            await _basePage.ClickElementAsync(AddButtonInTimeLine);
            _logger.LogInformation($"Clicked on add button");

            await _page.Locator("//*[@role='menu']//div[text()='Task']").ScrollIntoViewIfNeededAsync();
            await _page.Locator("//*[@role='menu']//div[text()='Task']").ClickAsync();
            _logger.LogInformation($"Clicked on Task button");
        }

        public async Task CreateTaskUnderTime(string subject, string description)
        {
            await _basePage.FillElementAsync(SubjectLocatorForTask, subject);
            _logger.LogInformation($"Entered task subject : {subject}");
            //await _basePage.FillElementAsync(DescriptionLocatorForTask, description);
            //_logger.LogInformation($"Entered task description : {description}");

            await _basePage.ClickElementAsync(SaveAndCloseButtonLocatorForTask);
            _logger.LogInformation($"Clicked on save&close button");
        }

        public async Task ClickOpenReportButtonInCasePage()
        {
            if (await MainActionsLink.IsVisibleAsync())
            {
                await _basePage.ClickElementAsync(MainActionsLink);
                await _basePage.ClickElementAsync(OpenRecordInListPopupUnderTimeline);
                _logger.LogInformation($"Clicked Main Action button in Case timeline");
            }else
            {
                await _basePage.ClickElementAsync(OpenRecordInTaskUnderTimeline);
                _logger.LogInformation($"Clicked on open record in task under timeline");
            }
             
        }
        public async Task ClickAuthenticationProgressionStageInCasePage()
        {
            await _basePage.ClickElementAsync(AuthenticationProgressionStageName);
            _logger.LogInformation($"Clicked authentication stage");
        }
        public async Task<string> GetPrimaryDemandFromAuthenticationPopupAsync()
        {
            return await AuthenticationProgressionStagePrimaryDemand.GetAttributeAsync("value");
        }
        public async Task ClickNextStageButtonInStageProgressionPopup()
        {
            await _basePage.ClickElementAsync(NextStageButtonInProgressionPopup);
            _logger.LogInformation($"Clicked on next button");
        }
        public async Task ClickBackButtonInStageProgressionPopup()
        {
            await _basePage.ClickElementAsync(BackButtonInProgressionPopup);
            _logger.LogInformation($"Clicked on back button");
        }
        public async Task ClickSetActiveButtonInProgressionPopup()
        {
            await _basePage.ClickElementAsync(ActiveStageButtonInProgressionPopup);
            _logger.LogInformation($"Clicked on Set Active button in popup");
        }
        public async Task ClickCloseButtonInStageProgressionPopup()
        {
            await _basePage.ClickElementAsync(BackButtonInProgressionPopup);
            _logger.LogInformation($"Clicked on close 'X' button in popup");
        }
        public async Task ClickPreviousStageButtonInProgressionBar()
        {
            await _basePage.ClickElementAsync(PreviousButtonInProgressionBar);
            _logger.LogInformation($"Clicked on Previous Stage button in popup");
        }
        public async Task ClickNextStageButtonInProgressionBar()
        {
            await _basePage.ClickElementAsync(NextStageButtonInProgressionBar);
            _logger.LogInformation($"Clicked on Next Stage button in popup");
        }
        public async Task GetActiveButtonFromStageProgressionPopup()
        {
            await _basePage.IsElementVisibleAsync(ActiveStageButtonInProgressionPopup);
        }
        public async Task GetNextStageButtonInStageProgressionPopup()
        {
            await _basePage.IsElementVisibleAsync(NextStageButtonInProgressionPopup);
        }
        public async Task GetBackButtonInStageProgressionPopup()
        {
            await _basePage.IsElementVisibleAsync(BackButtonInProgressionPopup);
        }

        public async Task ChangeOwnerForCase(string owner)
        {
            await _basePage.ClickElementAsync(MoreEditableFields);
            _logger.LogInformation($"Clicked on moew editable fields");
            await _basePage.ClickElementAsync(CancelOwner);
            _logger.LogInformation($"Clicked on cancel button");
            await _basePage.FillElementAsync(ChangeOwner, owner);
            _logger.LogInformation($"Entered change owner : {owner}");
            Thread.Sleep(2000);
            await _basePage.PressKeyAsync(ChangeOwner, "Enter");
            Thread.Sleep(500);
            await _basePage.ClickElementAsync(SaveButton);
            _logger.LogInformation($"Clicked on save button");

        }
        public async Task ValidateCaseNameNotPresent(string caseName)
        {
            /*
            await _basePage.ClickElementAsync(Cases);         
            var count = await _page.Locator("//span[text()='" + caseName + "']").CountAsync();
            if (count > 0)
            {
                throw new Exception("Case Ownership not changed");
            }
            */
        }

        public async Task AsyncSelectTheFirstCase()
        {
            await _basePage.ClickElementAsync(FirstCase);
            _logger.LogInformation($"Clicked on first case");
        }

        public async Task AsyncEnterNotes(string note)
        {
            await _basePage.ClickElementAsync(EnteraNote);
            _logger.LogInformation($"Clicked on enter note");
            await _basePage.PressKeyAsync(Timeline, "PageDown");
            Thread.Sleep(500);
            await _basePage.FillElementAsync(EnterText, note);
            _logger.LogInformation($"Entered note : {note}");
            //try and add file

            //save
            await _basePage.ClickElementAsync(AddNote);
            _logger.LogInformation($"Clicked on add note");
        }
        public async Task CaseNoteCreatedAsync(string note)
        {
            await _page.Locator("//div[text()='" + note + "']").First.IsVisibleAsync();
        }
        public async Task<string> GetCaseStatus()
        {
            return await CaseStatus.TextContentAsync();
        }

        public ILocator GetReadonlyFields(string fieldName)
        {
            return _page.Locator("//div[starts-with(@title,'" + fieldName + "')]//following-sibling::div//input[@readonly]");
        }
        public async Task ClickOnNewInSLAstoppages()
        {
            await _basePage.ClickElementAsync(NewButtonInSLAStoppage);
            _logger.LogInformation($"Clicked on next button");
        }

        public async Task<string> GetCaseNameAsync()
        {
            return await CaseName.GetAttributeAsync("value");
        }
        public async Task<string> GetPrimaryDemandAsync()
        {
            return await PrimaryDemand.GetAttributeAsync("value");
        }
        public async Task<string> GetPolicyReferenceNumberAsync()
        {
            return await PolicyReferenceNumberSearch.GetAttributeAsync("value");
        }
        public async Task<string> GetDemandAsync()
        {
            return await DemandValue.TextContentAsync();
        }
        public async Task<string> GetReInferLabelAsync()
        {
            await ID.DblClickAsync();
            _logger.LogInformation($"Double clicked on ID");
            await _page.Mouse.WheelAsync(0, 600);
            return await ReInferValue.TextContentAsync();
        }
        public async Task<string> GetRPAFlagAsync()
        {
            return await RPAFlag.GetAttributeAsync("value");
        }
        public async Task CaseDueDateValidation()
        {
            var dateValue = await CaseDueDateField.InputValueAsync();
            DateTime fetchedDate = DateTime.Parse(dateValue);

            DateTime CurrentDate = DateTime.Now;

            if (CurrentDate != fetchedDate.AddDays(5))
            {
                throw new Exception("Date is not 5 days ahead");
            }
        }
        public async Task CaseStatusNewValidation()
        {
            await _basePage.IsElementVisibleAsync(CaseStatusNew);
        }

        public async Task ReloadPageAsync()
        {
            await _page.ReloadAsync();
        }
        public async Task SwitchToInProgress()
        {
            await _basePage.ClickElementAsync(ExpandIconInCasePage);
            await _basePage.ClickElementAsync(StatusNew);
            await _basePage.ClickElementAsync(InProgress);
            await _basePage.ClickElementAsync(SaveButton);
        }
        public async Task SwitchToOnHold()
        {
            await _basePage.ClickElementAsync(ExpandIconInCasePage);
            await _basePage.ClickElementAsync(StatusInProgress);
            await _basePage.ClickElementAsync(OnHold);
            await _basePage.ClickElementAsync(SaveButton);

        }
        public async Task ValidateNoteNoteEditableAsync()
        {
            await _page.Locator("//div[@contenteditable='false']").First.IsVisibleAsync();
        }

        public async Task SelectEmailUnderTimeLineInCasePage()
        {
            await _basePage.ClickElementAsync(AddButtonInTimeLine);
            _logger.LogInformation($"Clicked on add button");

            await _basePage.ClickElementAsync(_page.Locator("//*[@role='menu']//div[text()='Email']"));
            _logger.LogInformation($"Clicked on Email button");
        }

        public async Task<string> GetCaseNameErrorMessage()
        {
            _logger.LogInformation("Get Error Messages for 'Case Name'");
            return await CaseNameErrorMessage.TextContentAsync();
        }

        public async Task<string> GetPrimaryDemandErrorMessage()
        {
            _logger.LogInformation("Get Error Messages for 'Primary Demand'");
            return await PrimaryDemandErrorMessage.TextContentAsync();
        }

        public async Task<string> GetCustomerErrorMessage()
        {
            _logger.LogInformation("Get Error Messages for 'Customer'");
            return await CustomerErrorMessage.TextContentAsync();
        }

        public async Task<string> GetPolicyReferenceNumberErrorMessage()
        {
            _logger.LogInformation("Get Error Messages for 'Policy Reference Number'");
            return await PolicyReferenceNumberErrorMessage.TextContentAsync();
        }
    }
}

