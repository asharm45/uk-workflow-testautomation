﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace WorkflowSpecflowTests.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class WORKSprint_7FeatureFeature : object, Xunit.IClassFixture<WORKSprint_7FeatureFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private static string[] featureTags = ((string[])(null));
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "WORK Sprint-7.feature"
#line hidden
        
        public WORKSprint_7FeatureFeature(WORKSprint_7FeatureFeature.FixtureData fixtureData, WorkflowSpecflowTests_XUnitAssemblyFixture assemblyFixture, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en"), "Features", "WORK Sprint-7 feature", null, ProgrammingLanguage.CSharp, featureTags);
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public void TestInitialize()
        {
        }
        
        public void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        void System.IDisposable.Dispose()
        {
            this.TestTearDown();
        }
        
        [Xunit.SkippableTheoryAttribute(DisplayName="Work-133: Validate the Profile View of Contact")]
        [Xunit.TraitAttribute("FeatureTitle", "WORK Sprint-7 feature")]
        [Xunit.TraitAttribute("Description", "Work-133: Validate the Profile View of Contact")]
        [Xunit.TraitAttribute("Category", "Work-133")]
        [Xunit.TraitAttribute("Category", "Caseworker")]
        [Xunit.TraitAttribute("Category", "smoke")]
        [Xunit.InlineDataAttribute("\'\'", "\'teamlead\'", "\'Test133C\'", "\'I want information\'", "\'Documents\'", "\'Send Certificate\'", "\'PL-HOM10003493441/00\'", "\'Raja Dhoni\'", "\'Amitsharma\'", "\'Task-133\'", "\'Raja Dhoni\'", "\'Property\'", "\'9/9/2024\'", new string[0])]
        [Xunit.InlineDataAttribute("\'\'", "\'teamlead\'", "\'Test133D\'", "\'I want to change\'", "\'Change of Broker\'", "\'Letter of Appointment\'", "\'PL-HOM10003493441/00\'", "\'RupKumar\'", "\'Amitsharma\'", "\'Task-133-2\'", "\'RupKumar\'", "\'Motor\'", "\'9/9/2024\'", new string[0])]
        public void Work_133ValidateTheProfileViewOfContact(string team, string userRole, string caseName, string primaryDemand, string demand, string subDemand, string policyReference, string customer, string owner, string demandTask, string contactName, string product, string caseDueDate, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "Work-133",
                    "Caseworker",
                    "smoke"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("team", team);
            argumentsOfScenario.Add("userRole", userRole);
            argumentsOfScenario.Add("CaseName", caseName);
            argumentsOfScenario.Add("PrimaryDemand", primaryDemand);
            argumentsOfScenario.Add("Demand", demand);
            argumentsOfScenario.Add("SubDemand", subDemand);
            argumentsOfScenario.Add("PolicyReference", policyReference);
            argumentsOfScenario.Add("Customer", customer);
            argumentsOfScenario.Add("Owner", owner);
            argumentsOfScenario.Add("DemandTask", demandTask);
            argumentsOfScenario.Add("contactName", contactName);
            argumentsOfScenario.Add("Product", product);
            argumentsOfScenario.Add("CaseDueDate", caseDueDate);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Work-133: Validate the Profile View of Contact", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 5
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 7
 testRunner.Given(string.Format("User logged in to Dynamics application with {0}", userRole), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 8
 testRunner.When(string.Format("User {0} creates new case {1} {2} {3} {4} {5} {6} {7} {8}", userRole, caseName, primaryDemand, demand, subDemand, customer, policyReference, caseDueDate, product), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 9
 testRunner.Then("User clicks on save button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 11
 testRunner.When("User clicks on activities tab", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 12
 testRunner.And("User clicks on task", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 13
 testRunner.Then(string.Format("User creates task with regarding {0} demand task {1} and primary demand {2}", caseName, demandTask, primaryDemand), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 15
 testRunner.Given("User Clicks on Contacts from Customers AreaGroup", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 16
 testRunner.And(string.Format("User filters contacts {0}", contactName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 17
 testRunner.And(string.Format("User Selects the Contact {0}", contactName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 18
 testRunner.Then("User Selects Related", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 19
 testRunner.And("Selects Activities", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 20
 testRunner.And(string.Format("User Validates the Task {0}", demandTask), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 21
 testRunner.Then("User Selects Related", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 22
 testRunner.And("Selects Cases", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 23
 testRunner.And(string.Format("User Validates the Case {0}", caseName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableTheoryAttribute(DisplayName="Work-31: Manual Triage Process")]
        [Xunit.TraitAttribute("FeatureTitle", "WORK Sprint-7 feature")]
        [Xunit.TraitAttribute("Description", "Work-31: Manual Triage Process")]
        [Xunit.TraitAttribute("Category", "Work-31")]
        [Xunit.InlineDataAttribute("\'(EXT) Validate Manual Triage Incoming2\'", "\'Testing Manual Triage\'", "\'No\'", "\'Caseworker\'", new string[0])]
        [Xunit.InlineDataAttribute("\'Address change-PL-HOM05006213708/06,PL-HOM05006213709/06\'", "\'Testing Manual Triage\'", "\'No\'", "\'Caseworker\'", new string[0])]
        public void Work_31ManualTriageProcess(string subject, string body, string attachment, string userRole, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "Work-31"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("subject", subject);
            argumentsOfScenario.Add("body", body);
            argumentsOfScenario.Add("attachment", attachment);
            argumentsOfScenario.Add("userRole", userRole);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Work-31: Manual Triage Process", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 36
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 37
 testRunner.Given(string.Format("User sends email to UKSC mailbox with subject {0} body {1} and attachment if any " +
                            "{2}", subject, body, attachment), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 38
 testRunner.And(string.Format("User logged in to Dynamics application with {0}", userRole), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 40
 testRunner.Then("User clicks on Activities", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 41
 testRunner.And(string.Format("User searches the email by subject {0} and clicks on the email", subject), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 42
 testRunner.Then(string.Format("User validates the email content like subject {0} body {1}", subject, body), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 43
 testRunner.Then("Validate that case number is not created", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 44
 testRunner.Then(string.Format("Validate the request {0} is in UKSC Manual Triage Bucket", subject), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableTheoryAttribute(DisplayName="Work-138")]
        [Xunit.TraitAttribute("FeatureTitle", "WORK Sprint-7 feature")]
        [Xunit.TraitAttribute("Description", "Work-138")]
        [Xunit.TraitAttribute("Category", "Work-138")]
        [Xunit.TraitAttribute("Category", "smoke")]
        [Xunit.InlineDataAttribute("\'\'", "\'Caseworker\'", "\'TestWhatever\'", "\'I want information\'", "\'Documents\'", "\'Send Certificate\'", "\'PL-HOM10003493441/00\'", "\'sarah marta\'", "\'Amitsharma\'", "\'hello world\'", "\'Resolving\'", new string[0])]
        public void Work_138(string team, string role, string caseName, string primaryDemand, string demand, string subDemand, string policyReference, string customer, string owner, string note, string resolutionReason, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "Work-138",
                    "smoke"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("team", team);
            argumentsOfScenario.Add("role", role);
            argumentsOfScenario.Add("CaseName", caseName);
            argumentsOfScenario.Add("PrimaryDemand", primaryDemand);
            argumentsOfScenario.Add("Demand", demand);
            argumentsOfScenario.Add("SubDemand", subDemand);
            argumentsOfScenario.Add("PolicyReference", policyReference);
            argumentsOfScenario.Add("Customer", customer);
            argumentsOfScenario.Add("Owner", owner);
            argumentsOfScenario.Add("Note", note);
            argumentsOfScenario.Add("resolutionReason", resolutionReason);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Work-138", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 55
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 56
 testRunner.Given(string.Format("User logged in to Dynamics application with {0} and {1}", team, role), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 57
 testRunner.When(string.Format("User creates new case {0} {1} {2} {3} {4} {5}", caseName, primaryDemand, demand, subDemand, customer, policyReference), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 58
 testRunner.Then("User clicks on save button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 59
 testRunner.When(string.Format("User Enter a {0}", note), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 60
 testRunner.Then(string.Format("User validates {0} is added", note), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 61
 testRunner.And("User Validates note is not editable", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 62
 testRunner.When("User Switches case status to In-Progress", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 63
 testRunner.When(string.Format("User Enter a {0}", note), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 64
 testRunner.Then("User Validates note is not editable", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 65
 testRunner.Then(string.Format("User validates {0} is added", note), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 66
 testRunner.When("User Switches case status to On-Hold", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 67
 testRunner.When(string.Format("User Enter a {0}", note), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 68
 testRunner.Then(string.Format("User validates {0} is added", note), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 69
 testRunner.And("User Validates note is not editable", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 70
 testRunner.Then(string.Format("User clicks on resolve case {0}", resolutionReason), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 71
 testRunner.When(string.Format("User Enter a {0}", note), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 72
 testRunner.Then(string.Format("User validates {0} is added", note), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableTheoryAttribute(DisplayName="Work-51: Update Case and Task SLA")]
        [Xunit.TraitAttribute("FeatureTitle", "WORK Sprint-7 feature")]
        [Xunit.TraitAttribute("Description", "Work-51: Update Case and Task SLA")]
        [Xunit.TraitAttribute("Category", "Work-51")]
        [Xunit.TraitAttribute("Category", "Admin")]
        [Xunit.InlineDataAttribute("\'2\'", "\'1\'", "\'Admin\'", "\'TestSLA51A\'", "\'I want information\'", "\'Documents\'", "\'Send Certificate\'", "\'sarah marta\'", "\'Motor\'", "\'PL-HOM10003493441/00\'", "\'10/10/2024\'", "\'I want to cancel\'", new string[0])]
        public void Work_51UpdateCaseAndTaskSLA(string sLADays, string defaultSLA, string userRole, string caseName, string primaryDemand, string demand, string subDemand, string customer, string product, string policyReference, string caseDueDate, string sLAprimaryDemand, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "Work-51",
                    "Admin"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("SLADays", sLADays);
            argumentsOfScenario.Add("DefaultSLA", defaultSLA);
            argumentsOfScenario.Add("userRole", userRole);
            argumentsOfScenario.Add("CaseName", caseName);
            argumentsOfScenario.Add("PrimaryDemand", primaryDemand);
            argumentsOfScenario.Add("Demand", demand);
            argumentsOfScenario.Add("SubDemand", subDemand);
            argumentsOfScenario.Add("Customer", customer);
            argumentsOfScenario.Add("Product", product);
            argumentsOfScenario.Add("PolicyReference", policyReference);
            argumentsOfScenario.Add("CaseDueDate", caseDueDate);
            argumentsOfScenario.Add("SLAprimaryDemand", sLAprimaryDemand);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Work-51: Update Case and Task SLA", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 82
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 83
 testRunner.Given(string.Format("User logged in to Dynamics application with {0}", userRole), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 84
 testRunner.When(string.Format("User \'Team Lead\' creates new case {0} {1} {2} {3} {4} {5} {6} {7}", caseName, primaryDemand, demand, subDemand, customer, policyReference, caseDueDate, product), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 85
 testRunner.Then(string.Format("User saves the case {0} with {1}", caseName, primaryDemand), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 86
 testRunner.When("user navigates to Customer Service admin center", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 87
 testRunner.And(string.Format("User update the SLA days {0} for the primary demand {1}", sLADays, sLAprimaryDemand), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 88
 testRunner.And("User click the Save button on the SLA time page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 89
 testRunner.And("User navigates to Customer Service Hub", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 90
 testRunner.Then(string.Format("User selects newly created case {0}", caseName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 91
 testRunner.And(string.Format("User changes the primaryDemand {0} demand \'Cancellation\' and subDemand \'Cancellat" +
                            "ion Request\'", sLAprimaryDemand), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 92
 testRunner.And("User clicks on save button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 93
 testRunner.And(string.Format("User validate the duedate {0} for the case {1}", sLADays, caseName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 94
 testRunner.And(string.Format("user cancel the case {0}", caseName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 95
 testRunner.When("user navigates to Customer Service admin center", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 96
 testRunner.And(string.Format("User update the SLA days {0} for the primary demand {1}", defaultSLA, primaryDemand), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 97
 testRunner.And("User click the Save button on the SLA time page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableTheoryAttribute(DisplayName="Work-39: Manual Allocation of Case")]
        [Xunit.TraitAttribute("FeatureTitle", "WORK Sprint-7 feature")]
        [Xunit.TraitAttribute("Description", "Work-39: Manual Allocation of Case")]
        [Xunit.TraitAttribute("Category", "Work-39")]
        [Xunit.TraitAttribute("Category", "teamlead")]
        [Xunit.InlineDataAttribute("\'Team Lead\'", "\'WF39ManualCaseAllocation\'", "\'I want information\'", "\'Documents\'", "\'Send Certificate\'", "\'sarah marta\'", "\'Property\'", "\'PL-HOM10003493441/00\'", "\'10/10/2024\'", "\'Sanjay Jayakumar\'", new string[0])]
        [Xunit.InlineDataAttribute("\'Team Lead\'", "\'WF39ManualCaseAllocation\'", "\'I want information\'", "\'Documents\'", "\'Send Certificate\'", "\'sarah marta\'", "\'Motor\'", "\'PL-HOM10003493441/00\'", "\'10/10/2024\'", "\'\'", new string[0])]
        public void Work_39ManualAllocationOfCase(string userRole, string caseName, string primaryDemand, string demand, string subDemand, string customer, string product, string policyReference, string caseDueDate, string userOrTeam, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "Work-39",
                    "teamlead"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("userRole", userRole);
            argumentsOfScenario.Add("CaseName", caseName);
            argumentsOfScenario.Add("PrimaryDemand", primaryDemand);
            argumentsOfScenario.Add("Demand", demand);
            argumentsOfScenario.Add("SubDemand", subDemand);
            argumentsOfScenario.Add("Customer", customer);
            argumentsOfScenario.Add("Product", product);
            argumentsOfScenario.Add("PolicyReference", policyReference);
            argumentsOfScenario.Add("CaseDueDate", caseDueDate);
            argumentsOfScenario.Add("UserOrTeam", userOrTeam);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Work-39: Manual Allocation of Case", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 106
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 107
 testRunner.Given(string.Format("User logged in to Dynamics application with {0}", userRole), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 108
 testRunner.When(string.Format("User {0} creates new case {1} {2} {3} {4} {5} {6} {7} {8}", userRole, caseName, primaryDemand, demand, subDemand, customer, policyReference, caseDueDate, product), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 109
 testRunner.Then("User clicks on save button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 110
 testRunner.When(string.Format("User select the case {0} from case home page", caseName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 111
 testRunner.Then(string.Format("User Assigns the Task and selects {0}", userOrTeam), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 112
 testRunner.And(string.Format("User validates the cases {0} ownername is changed to {1}", caseName, userOrTeam), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 113
 testRunner.And(string.Format("user cancel the case {0}", caseName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableTheoryAttribute(DisplayName="Work-39: Manual Allocation of Task")]
        [Xunit.TraitAttribute("FeatureTitle", "WORK Sprint-7 feature")]
        [Xunit.TraitAttribute("Description", "Work-39: Manual Allocation of Task")]
        [Xunit.TraitAttribute("Category", "Work-39")]
        [Xunit.TraitAttribute("Category", "teamlead")]
        [Xunit.InlineDataAttribute("\'Team Lead\'", "\'WF39ManualTaskAllocation\'", "\'I want information\'", "\'Documents\'", "\'Sanjay Jayakumar\'", new string[0])]
        [Xunit.InlineDataAttribute("\'Team Lead\'", "\'WF39ManualTaskAllocation\'", "\'I want information\'", "\'Documents\'", "\'Sanjay Jayakumar\'", new string[0])]
        public void Work_39ManualAllocationOfTask(string userRole, string taskName, string primaryDemand, string demand, string userOrTeam, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "Work-39",
                    "teamlead"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("userRole", userRole);
            argumentsOfScenario.Add("TaskName", taskName);
            argumentsOfScenario.Add("PrimaryDemand", primaryDemand);
            argumentsOfScenario.Add("Demand", demand);
            argumentsOfScenario.Add("UserOrTeam", userOrTeam);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Work-39: Manual Allocation of Task", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 121
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 122
 testRunner.Given(string.Format("User logged in to Dynamics application with {0}", userRole), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 123
 testRunner.When(string.Format("create the new task {0} {1} {2}", taskName, demand, primaryDemand), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 124
 testRunner.Then("User clicks on save button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 125
 testRunner.When(string.Format("User select the task {0} from task page", taskName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 126
 testRunner.Then(string.Format("User Assigns the Task and selects {0}", userOrTeam), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 127
 testRunner.And(string.Format("User validates the task {0} ownernName is changed to {1}", taskName, userOrTeam), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 128
 testRunner.Then(string.Format("User cancels the tasks {0}", taskName), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableTheoryAttribute(DisplayName="Work-82: Send an Email to UKSC mailbox & Validate the mandatory details")]
        [Xunit.TraitAttribute("FeatureTitle", "WORK Sprint-7 feature")]
        [Xunit.TraitAttribute("Description", "Work-82: Send an Email to UKSC mailbox & Validate the mandatory details")]
        [Xunit.TraitAttribute("Category", "work-82")]
        [Xunit.TraitAttribute("Category", "wip")]
        [Xunit.InlineDataAttribute("\'Caseworker\'", "\'Preston floyd  – policy number PL-HOM10003285995/02\'", @"'Can you please note that the policyholder, Preston floyd has recently passed away and we would be grateful if you could change the policy into the name of Mrs Alice floyd (joint insured). I trust you find this to be in order and look forward to receiving amended policy documentation Regards Gary Adams'", "\'No\'", "PL-HOM10003285995/02", "Change of policyholder", "UKSC", "Contact", new string[0])]
        public void Work_82SendAnEmailToUKSCMailboxValidateTheMandatoryDetails(string userRole, string subject, string body, string attachment, string policyNumber, string demand, string queue, string customer, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "work-82",
                    "wip"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("userRole", userRole);
            argumentsOfScenario.Add("subject", subject);
            argumentsOfScenario.Add("body", body);
            argumentsOfScenario.Add("attachment", attachment);
            argumentsOfScenario.Add("Policy number", policyNumber);
            argumentsOfScenario.Add("Demand", demand);
            argumentsOfScenario.Add("Queue", queue);
            argumentsOfScenario.Add("Customer", customer);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Work-82: Send an Email to UKSC mailbox & Validate the mandatory details", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 139
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 140
 testRunner.Given(string.Format("User sends email to UKSC mailbox with subject {0} body {1} and attachment if any " +
                            "{2}", subject, body, attachment), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 141
 testRunner.Given(string.Format("User logged in to Dynamics application with {0}", userRole), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 142
 testRunner.Then("User clicks on Activities", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 143
 testRunner.And("User Selects All Emails", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 144
 testRunner.And(string.Format("User searches the email by subject {0} and clicks on the email", subject), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 145
 testRunner.Then(string.Format("User validates the email content like subject {0} body {1}", subject, body), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 146
 testRunner.And("User Validates The Regarding has Casename", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 147
 testRunner.And("User Validates Case due date is 5 days further from creation date", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 148
 testRunner.And("Case Status Should be new", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 149
 testRunner.And("Email should be displayed under timeline", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 150
 testRunner.And("New Page will display queue details", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 151
 testRunner.And("Validate Case is Under bucket", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 152
 testRunner.And("User Clicks on Dashboard and Clicks Pick Work", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 153
 testRunner.And("Should Display new RPA Cases", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 154
 testRunner.And("User Deletes the email", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 155
 testRunner.And("User clicks on sign out", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                WORKSprint_7FeatureFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                WORKSprint_7FeatureFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
