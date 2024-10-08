using Microsoft.Extensions.Logging;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkflowSpecflowTests.Apis;
using WorkflowSpecflowTests.Pages;

namespace WorkflowSpecflowTests.StepDefinitions
{
    [Binding]
    public class PolicyCreation
    {
        private readonly ITaskApi _taskApi;
        private readonly ILogger<PolicyCreation> _logger;
        private readonly IPolicyApi _policyApi;

        public PolicyCreation(ITaskApi taskApi, ILogger<PolicyCreation> logger, IPolicyApi policyApi)
        {
            _taskApi = taskApi;
            _logger = logger;
            _policyApi = policyApi;
        }

        [Given(@"User calls task api with lastTaskId '([^']*)'")]
        public async Task GivenUserCallsTaskApiWithLastTaskId(string lastTaskId)
        {
            var apiResponse = await _policyApi.CallPolicyApiAsync(lastTaskId);
            _logger.LogInformation(apiResponse.MainRenewalDate);
        }

    }
}
