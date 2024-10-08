Feature: WORK Sprint-0 feature



@Work-115 @admin
Scenario Outline: Work-115: Create new Underwriter Authority and Create a new bookable resource validate the fields
	Given User logged in to Dynamics application
	When User selects customer admin hub from Dynamics Home page
	And User Clicks On Underwriter Authority
	Then User clicks on new button
	And User Click on New Bookable Resource
	And creates new bookable resource <ResourceType> <User> <Name> <TimeZone>
	And User creates New UA <Agent> <Property> <Vehicle> <Accumulation>
	And User clicks on save and close button
	And User selects the newly created UA with <Agent> and updated the <UpdatedProperty> <UpdatedVehicle> <UpdatedAccumulation>
	And User validates if UA is updated successfully with <Agent> <UpdatedProperty> <UpdatedVehicle> <UpdatedAccumulation>
	
	
Examples:
	| UserRoles              | Agent                  | Property      | Vehicle     | Accumulation | UpdatedProperty | UpdatedVehicle | UpdatedAccumulation | ResourceType | User    | Name          | TimeZone |
	| 'Trading Team leaders' | 'Jeevanathan Chandran' | '10000000.00' | '110000.00' | '2500000.00' | '2600000.00'    | '3600000.00'   | '4500000.00'        | ''           | '# CCA' | 'Sanjay Test' | ''       |
	
	

	
@Work-146 @Caseworker @smoke
Scenario Outline: Work-146: Create a New Broker Contact and Validate The fields
	Given User logged in to Dynamics application with <team> and <role> for Contacts
	And User validates The sitemap menu
	And User Clicks on Contacts from Customers AreaGroup
	And User Clicks on New button
	Then User Enters <ContactID> <Firstname> <Surname> <Email> <Telephonenumber> <Broker> <Brokercorrespondenceaddress> <BrokerRegion> <BrokerArea> <FocusvsCore> <PostCode>
	And Validate other fields are present for broker contact
	Then User Clicks on Save
	And User Navigates to My Active Contacts dashboard
	Then Validate the Contact By Clicking <Firstname>

Examples:
	| team | role         | ContactID | Firstname | Surname | Email            | Telephonenumber | Broker | Brokercorrespondenceaddress | BrokerRegion | BrokerArea   | FocusvsCore | PostCode   |
	| ''   | 'Caseworker' | '2903456' | 'Raja'    | 'Dhoni' | 'raja@test.com ' | '8907654321'    | 'John' | ''                          | 'testrip'    | 'Roof match' | 'Core'      | 'IV54 7QZ' |


 
@Work-148 @admin @smoke
Scenario Outline: Work-148
	Given User logged in to Dynamics application with 'Admin'
	Given User Clicks on Policy Holders from Service AreaGroup
	Given User Clicks on +New button
	Then User Validates new policy holder page
	Then User Enter the Policy <Policy>
	Then User selects the contact <Contact> and policy contact role <PolicyContactRole>
	Then User selects policy holder and primary policy holder
	Then User clicks on save and close button
	Then User Clicks On Created On and sorts by newer to older
	Then User selects the policy Holder and Validates


Examples:
	| Policy                 | Contact     | PolicyContactRole |
	| 'PL-HOM10002775299/18' | 'Anth Bear' | 'Test'            |

@Work-157 @caseworker
Scenario: Work-157: Phone call Entity - Data Mapping of Attributes
	Given User logged in to Dynamics application with 'Caseworker'
	When User 'Caseworker' creates new case 'TestCase157' 'I want information' 'Documents' 'Send Certificate' 'sarah marta' 'PL-HOM10003493441/00' '10/10/2024' 'Motor'
	And User clicks on details tab
	And User selects phone as origin
	Then User clicks on save button
	And User validates if phone "Phone" as origin is selected
	And User cancel the case "TestCase157"


@Work-156 @caseworker
Scenario: Work-156: Email Entity - Data Mapping of Attributes
	Given User logged in to Dynamics application with 'Caseworker'
	When User 'Caseworker' creates new case 'TestCase156' 'I want information' 'Documents' 'Send Certificate' 'sarah marta' 'PL-HOM10003493441/00' '10/10/2024' 'Property'
	And User clicks on details tab
	And User selects email as origin
	Then User clicks on save button
	And User validates if email "Email" as origin is selected
	And User cancel the case "TestCase156"

	
@Work-116 @admin
Scenario: Work-116: Task Entity - Data Mapping of Attributes
	Given User logged in to Dynamics application
	When User selects customer service hub from Dynamics Home page
	Then User clicks on Activities
	When User clicks on task
	Then User validates the Task fields
		| Fields             |
		| 'Regarding'        |
		| 'Demand Task'      |
		| 'Merlin ID'        |
		| 'Primary Demand'   |
		| 'Task Type'        |
		| 'Merlin Task Type' |
		| 'Value Step'       |
		| 'Urgent Flag'      |
		| 'Status Reason'    |
		| 'Task Description' |
		| 'Instructions'     |

@Work-114 @admin
Scenario: Work-114: Demand Entity - Data Mapping of Attributes
	Given User logged in to Dynamics application
	When User selects customer admin hub from Dynamics Home page
	Then User clicks on Demands
	And User clicks on New demand
	And User validates the Demands fields
		| Fields            |
		| 'Demand Type'     |
		| 'Primary Demand'  |
		| 'Demand'          |
		| 'Subdemand'       |
		| 'E2ETask'         |
		| 'Primary Product' |

@Work-113 @admin @teamlead
Scenario: Work-113: Case Entity - Data Mapping of Attributes
	Given User logged in to Dynamics application with 'Team Lead'
	When User 'Admin' creates new case 'TestCase113' 'I want information' 'Documents' 'Send Certificate' 'sarah marta' 'PL-HOM10003493441/00' '10/10/2024' 'Building works'
	And User clicks on details tab
	And User selects email as origin
	Then User clicks on save button
	And User cancel the case "TestCase113"

@Work-159 @Admin
Scenario: Work-159: SLA Stoppage Entity - Data Mapping of Attributes
	Given User logged in to Dynamics application with 'Admin'
	When User 'Admin' creates new case 'TestCase159' 'I want information' 'Documents' 'Send Certificate' 'sarah marta' 'PL-HOM10003493441/00' '10/10/2024' 'Motor'
	And User clicks on SLA Stoppages tab
	And User click the New button from SLA Home page
	Then User validate the fields are displayed 'Case' 'Pended Time' and 'Unpended Time'
	When User create new SLA for the caseName 'TestCase159', pended time as 'today' and unpended time as 'tomorrow'
	And User click on the Save button in new SLA stoppage page


@Work-161
Scenario Outline: WOrk-161: Vaidate the fields present while creating New Account
	Given User logged in to Dynamics application with ''
	When User selects customer service hub from Dynamics Home page
	Given User Clicks on Accounts Tab
	And User Clicks on New button
	And User Fills The Details <AccountName>
	Then User Clicks on Save
	Given User Clicks on Accounts Tab
	And User selects the account <AccountName> and Validates The Fields
	Given User Clicks on Accounts Tab
	Then User Selects The Account <AccountName>
	Then User Clicks Delete button and deletes the Case

Examples:
	| AccountName |
	| 'RupKumar'  |

	
@work-164
Scenario: Work-164
	Given User logged in to Dynamics application with <userRole>
	#Then User selects customer service hub from Dynamics Home page
	When The user clicks on Customer Assets dropdown and selects scheduling
	And The user clicks on Resources
	And The user creates a new Bookable Resource with Contact <ContactName>
	And The user verifies if new Bookable <ContactName> is created

Examples:
	| userRole     | ContactName     |
	| 'Caseworker' | 'Aut1 omation1' |
