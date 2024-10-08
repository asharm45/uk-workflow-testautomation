Feature: WORK Sprint-5 feature


@Work-130 @Caseworker @smoke
Scenario Outline: Work-130: Validate Case Owner can be switched
	Given User logged in to Dynamics application with <team> and <role>
	When User creates new case <CaseName> <PrimaryDemand> <Demand> <SubDemand> <Customer> <PolicyReference>
	Then User clicks on save button
	Then User Changes the <Owner>
	And Validates Owner is Changed <CaseName>
#casename should be changed to avoid Conflicts
Examples:
	| team | role         | CaseName       | PrimaryDemand        | Demand      | SubDemand          | PolicyReference        | Customer      | Owner        |
	| ''   | 'Caseworker' | 'TestWhatever' | 'I want information' | 'Documents' | 'Send Certificate' | 'PL-HOM10003493441/00' | 'sarah marta' | 'Amitsharma' |

@Work-130 @Caseworker @smoke
Scenario Outline: Work-130: Validate Task Owners can be switched
	Given User logged in to Dynamics application with <team> and <role>
	When User clicks on activities tab
	And User clicks on task
	And User Enters <DemandTask>
	Then User Changes the <Owner>
	Then User clicks on save button

Examples:
 
	| team | role         | DemandTask | Owner        |
	| ''   | 'Caseworker' | 'TestCase' | 'Amitsharma' |
 

 
@work-141 @regression @work-143 @admin
Scenario: Work-141: Validate case SLA
	Given User logged in to Dynamics application
	#When User selects customer service hub from Dynamics Home page
	When User validates the mandatory fields error messages
		| FieldName         |
		| 'CaseName'        |
		| 'PrimaryDemand'   |
		| 'Customer'        |
		| 'PolicyReference' |
	Then User creates new case and validates case status, case due date, case number and sitemap
		| userRole | CaseName    | PrimaryDemand        | Demand             | SubDemand              | Customer      | Product          | PolicyReference        | CaseDueDate  | numberOfDays |
		| 'Admin'  | 'TestCase1' | 'I want information' | 'Documents'        | 'Send Certificate'     | 'sarah marta' | 'Motor'          | 'PL-HOM10003493441/00' | '10/10/2024' | 5            |
		| 'Admin'  | 'TestCase2' | 'I want to change'   | 'Motor change'     | 'Add Driver'           | 'sarah marta' | 'Motor'          | 'PL-HOM10003493441/00' | '10/11/2024' | 5            |
		| 'Admin'  | 'TestCase3' | 'I want to cancel'   | 'Cancellation'     | 'Cancellation Request' | 'sarah marta' | 'Property'       | 'PL-HOM10003493441/00' | '10/11/2024' | 5            |
		| 'Admin'  | 'TestCase4' | 'I want to renew'    | 'Renewal'          | 'Review Renewal'       | 'sarah marta' | 'Building works' | 'PL-HOM10003493441/00' | '10/11/2024' | 30           |
		| 'Admin'  | 'TestCase5' | 'Error Management'   | 'Cancel & Replace' | 'NA'                   | 'sarah marta' | 'Motor'          | 'PL-HOM10003493441/00' | '10/11/2024' | 1            |
	And User cancel the case
		| CaseName    |
		| 'TestCase1' |
		| 'TestCase2' |
		| 'TestCase3' |
		| 'TestCase4' |
		| 'TestCase5' |
	And User clicks on sign out

@work-141
Scenario: Work-141: Validate case SLA - update SLA time
	Given User logged in to Dynamics application
	When User selects customer admin hub from Dynamics Home page
	Then User clicsUser clicks on SLA timer
	Then User updates the sla for primaryDemand:
		| SLA | PrimaryDemand        |
		| 7   | 'I want information' |
		| 7   | 'I want to change'   |
		| 7   | 'I want to cancel'   |
		| 35  | 'I want to renew''   |
		| 2   | 'Error Management'   |
	When User navigates to Customer Service Hub
	And User creates the case and validates the sla:
		| userRole | CaseName    | PrimaryDemand        | Demand             | SubDemand              | Customer      | Product          | PolicyReference        | CaseDueDate  | numberOfDays |
		| 'Admin'  | 'TestCase1' | 'I want information' | 'Documents'        | 'Send Certificate'     | 'sarah marta' | 'Motor'          | 'PL-HOM10003493441/00' | '10/10/2024' | 7            |
		| 'Admin'  | 'TestCase2' | 'I want to change'   | 'Motor change'     | 'Add Driver'           | 'sarah marta' | 'Property'       | 'PL-HOM10003493441/00' | '10/11/2024' | 7            |
		| 'Admin'  | 'TestCase3' | 'I want to cancel'   | 'Cancellation'     | 'Cancellation Request' | 'sarah marta' | 'Property'       | 'PL-HOM10003493441/00' | '10/11/2024' | 7            |
		| 'Admin'  | 'TestCase4' | 'I want to renew'    | 'Renewal'          | 'Review Renewal'       | 'sarah marta' | 'Building works' | 'PL-HOM10003493441/00' | '10/11/2024' | 35           |
		| 'Admin'  | 'TestCase5' | 'Error Management'   | 'Cancel & Replace' | 'NA'                   | 'sarah marta' | 'Motor'          | 'PL-HOM10003493441/00' | '10/11/2024' | 2            |
	When user navigates to Customer Service admin center
	Then User updates original sla for primaryDemand:
		| SLA | PrimaryDemand        |
		| 5   | 'I want information' |
		| 5   | 'I want to change'   |
		| 5   | 'I want to cancel'   |
		| 30  | 'I want to renew''   |
		| 1   | 'Error Management'   |
	And User clicks on sign out

Scenario Outline: Validate case SLA - Validate the Case SLA is updated if Primary demand is updated
	Given User logged in to Dynamics application with <userRole>
	When User 'Admin' creates new case 'TestCase6' 'I want information' 'Documents' 'Send Certificate' 'sarah marta' 'PL-HOM10003493441/00' '10/10/2024' 'Motor'
	Then User clicks on save button
	And User validates the valueSteps "Authentication,Understand My Request/Assess Information Provided,Perform Change,Confirm Policy & Issue Documents" for primaryDemand "I want information"
	Then User selects newly created case 'TestCase6'
	Then User changes the primaryDemand <PrimaryDemand> demand <Demand> and subDemand <SubDemand>
	And User validates the <valueSteps> for primaryDemand <PrimaryDemand>
	Then User validate the status of the case
	And User validates the case due date <numberOfDays> for primary demand <PrimaryDemand>
	And User validate the updated SLA
	And User cancel the case "TestCase6"

Examples:
	| userRole | PrimaryDemand      | Demand             | SubDemand              | valueSteps                                                                                                                                                               |
	| 'Admin'  | 'I want to change' | 'Motor change'     | 'Add Driver'           | 'Authentication,Understand My Request/Assess Information Provided,Perform Change,Manage Referral,Present & Issue Quote,Arrange Payment,Confirm Policy & Issue Documents' |
	| 'Admin'  | 'I want to cancel' | 'Cancellation'     | 'Cancellation Request' | 'Authentication,Understand My Request/Assess Information Provided,Perform Change,Arrange Payment,Confirm Policy & Issue Documents'                                       |
	| 'Admin'  | 'I want to renew'  | 'Renewal'          | 'Review Renewal'       | 'Authentication,Understand My Request/Assess Information Provided,Perform Change,Manage referral,Present & Issue Quote,Arrange Payment,Confirm Policy & Issue Documents' |
	| 'Admin'  | 'Error Management' | 'Cancel & Replace' | 'NA'                   | 'Authentication,Understand My Request/Assess Information Provided,Perform Change,Confirm Policy & Issue Documents'                                                       |

	
@work-77 @admin
Scenario: Work-77: Correspondence - Case Management
	Given User sends email to UKSC mailbox with sender <sender> to <to> subject <subject> body <body> and attachment <attachment>
	And User logged in to Dynamics application
	When User selects customer service hub from Dynamics Home page
	Then User clicks on Activities
	And User searches the email by subject <subject> and clicks on the email
	Then User validates the email content like subject <subject> body <body>
	Then User validates if regarding field is updated with case name <CaseName> and click on the case link
	And User validates if email appears in the timeline subject <subject> body <body>
Examples:
	| sender          | to                   | subject                                                | body                                                                                                                | attachment | CaseName                                               |
	| 'Tonysmithtest' | 'Test_UKSC_Dynamics' | '(EXT) RE: Mr Guinevere Forbes - PL-HOM05006213708/06' | 'Apologies, Lionel. Client has also confirmed that the tracker subscription has been renewed for a further 3 years' | 'No'       | '(EXT) RE: Mr Guinevere Forbes - PL-HOM05006213708/06' |
	

	
@work-46 @admin
Scenario Outline: Work-46: Validate the user can able to search attributes in whole search/search results bar which makes user to find out information easily.
	Given User logged in to Dynamics application
	When User selects customer service hub from Dynamics Home page
	Then User searches by postCode <postCode> and validates the results
	Then User searches by phoneNumber <phoneNumber> and validates the results
	Then User searches by emailAddress <emailAddress> and validates the results
	Then User searches by contactName <contactName> and validates the results
	Then User searches by policyRef <policyRef> and validates the results
	Then User searches by brokerName <brokerName> and validates the results
	#Then User searches by caseNumber <caseNumber> and validates the results
	Then User searches by resolvedStatus <resolvedStatus> and validates the results
	Then User searches by openStatus <openStatus> and validates the results
	Then User searches by activeStatus <activeStatus> and validates the results
	Then User searches by primaryDemand <primaryDemand> and validates the results
Examples:
	| postCode | phoneNumber   | emailAddress                       | contactName        | policyRef              | brokerName      | caseNumber         | resolvedStatus | openStatus | activeStatus | primaryDemand        |
	| '1000'   | '09992105411' | 'amitsharma.jaiprakash@hiscox.com' | 'Workflow Contact' | 'PL-HOM10003493441/00' | 'Walter Disney' | 'CAS-01429-Y2F6P7' | 'Resolved'     | 'Open'     | 'Active'     | 'I want information' |


@Work-47 @teamlead @paralleltest
Scenario Outline: Work-47: Team Leader - Bulk Case Management
	Given User logged in to Dynamics application with 'Team Lead'
	When User <userRole> creates new case <CaseName1> <PrimaryDemand> <Demand> <SubDemand> <Customer> <PolicyReference> <CaseDueDate> <Product>
	Then User clicks on save button
	When User 'caseWorker' creates new case <CaseName2> <PrimaryDemand> <Demand> <SubDemand> <Customer> <PolicyReference> <CaseDueDate> <Product>
	Then User clicks on save button
	When User 'caseworker' creates new case <CaseName3> <PrimaryDemand> <Demand> <SubDemand> <Customer> <PolicyReference> <CaseDueDate> <Product>
	Then User clicks on save button
	When User select the cases <CaseName1> <CaseName2> <CaseName3>
	Then User Assigns the Task and selects <UserOrTeam>
	And User validates the cases <CaseName1> <CaseName2> <CaseName3> ownername is changed to <UserOrTeam>
	And user cancel the case <CaseName1><CaseName2><CaseName3>

Examples:
	| userRole    | CaseName1        | CaseName2        | CaseName3        | PrimaryDemand        | Demand      | SubDemand          | Customer      | Product | PolicyReference        | CaseDueDate  | UserOrTeam         |
	| 'Team Lead' | 'WF47Bulkcases1' | 'WF47Bulkcases2' | 'WF47Bulkcases3' | 'I want information' | 'Documents' | 'Send Certificate' | 'sarah marta' | 'Motor' | 'PL-HOM10003493441/00' | '10/10/2024' | 'Sanjay Jayakumar' |


	
@Work-245
Scenario Outline: Work-245: Mark a demand as Failure from case creation
	Given User logged in to Dynamics application with 'Admin'
	When User 'Admin' creates new case 'TestCase6' 'I want information' 'Documents' 'Send Certificate' 'sarah marta' 'PL-HOM10003493441/00' '10/10/2024' 'Motor'
	Then User clicks on save button
	And User checks newly created case "TestCase6"
	Then User resolve the case with Resolution Type <ResolutionType> Resolution <Resolution>
	And User validates resolved case "TestCase6" is read only
	And User validates the demand type <demandType>


Examples:
	| ResolutionType                                | Resolution      | demandType |
	| "Request complete - first contact resolution" | "Case Resolved" | "Value"    |
	| "Request complete - multi contact resolution" | "Case Resolved" | "Value"    |
	| "Request complete - error correction"         | "Case Resolved" | "Failure"  |
	| "Request complete - not taken up"             | "Case Resolved" | "Value"    |
	| "Request complete - decline cover"            | "Case Resolved" | "Value"    |
	| "Request incomplete - unable to contact"      | "Case Resolved" | "Value"    |
	| "Duplicate closed "                           | "Case Resolved" | "Failure"  |
	
	