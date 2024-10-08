Feature: BulkRunTestCases

A short summary of the feature

@Work-146 @BulkCaseworker @smoke
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



	@Work-157 @BulkCaseworker
Scenario: Work-157: Phone call Entity - Data Mapping of Attributes
	Given User logged in to Dynamics application with 'Caseworker'
	When User 'Caseworker' creates new case 'TestCase157' 'I want information' 'Documents' 'Send Certificate' 'sarah marta' 'PL-HOM10003493441/00' '10/10/2024' 'Motor'
	And User clicks on details tab
	And User selects phone as origin
	Then User clicks on save button
	And User validates if phone "Phone" as origin is selected
	And User cancel the case "TestCase157"

	@work-89 @BulkCaseworker
Scenario: Work89 - Change in Primary Demand
	Given User logged in to Dynamics application with <userRole>
	When User <userRole> creates new case <CaseName> <PrimaryDemand> <Demand> <SubDemand> <Customer> <PolicyReference> <CaseDueDate> <Product>
	Then User clicks on save button
	And user validate the primary demand as "I want information"
	When user change the primary demand to "I want to change", demand to "Motor change" and subdemand to "Add Driver"
	Then user validate the primary demand as "I want to change"
	When user change the primary demand to "I want to renew", demand to "Renewal" and subdemand to "Review Renewal"
	Then user validate the primary demand as "I want to renew"
	When user change the primary demand to "I want to cancel", demand to "Cancellation" and subdemand to "Cancellation Request"
	Then user validate the primary demand as "I want to cancel"
	When user change the primary demand to "Error Management", demand to "Cancel & Replace" and subdemand to "NA"
	Then user validate the primary demand as "Error Management"
	And user cancel the case <CaseName>

Examples:
	| userRole     | CaseName    | PrimaryDemand        | Demand      | SubDemand          | Customer      | Product | PolicyReference        | CaseDueDate  |
	| 'Caseworker' | 'CWwork89B' | 'I want information' | 'Documents' | 'Send Certificate' | 'Sarah Jones' | 'Motor' | 'PL-HOM10003493441/00' | '10/10/2024' |


	@work-128 @BulkCaseworker
Scenario Outline: Work-128: Progression of Value-steps Stages
	Given User logged in to Dynamics application with <userRole>
	When User <userRole> creates new case <CaseName> <PrimaryDemand> <Demand> <SubDemand> <Customer> <PolicyReference> <CaseDueDate> <Product>
	Then User clicks on save button
	And user validate the status of the case as 'Active'
	When user click the 'Authentication' in progression stages
	Then user validate the popup along with 'Active for', <PrimaryDemand> and 'Next Stage' Button
	When user click on the 'Next Stage' Button in progression popup
	Then user validate the popup along with 'Active for', <PrimaryDemand>, 'Back' and 'Next Stage' Button
	When user click on the 'Previous Stage' Button in progression bar
	Then user validate the popup along with 'Completed', <PrimaryDemand> and 'Set Active' Button
	When user click on the 'Set Active' Button in progression popup
	Then user validate the popup along with 'Active for', <PrimaryDemand>, 'Back' and 'Next Stage' Button
	When user click on the 'Next Stage' Button in progression bar
	Then user validate the popup along with 'Inactive', <PrimaryDemand>, '' and '' Button
	And user cancel the case <CaseName>

Examples:
	| userRole     | CaseName    | PrimaryDemand        | Demand         | SubDemand          | Customer      | Product    | PolicyReference        | CaseDueDate  |
	| 'Caseworker' | 'CWwork128' | 'I want to change'   | 'Motor change' | 'Add Driver'       | 'Gary Adams' | 'Motor'    | 'PL-HOM10003493441/00' | '10/10/2024' |

	@work-56 @BulkCaseworker
Scenario Outline: Work56 - Case Progress Save
	Given User logged in to Dynamics application with <userRole>
	When User <userRole> creates new case <CaseName> <PrimaryDemand> <Demand> <SubDemand> <Customer> <PolicyReference> <CaseDueDate> <Product>
	Then User clicks on save button
	And user validate the status of the case as 'Active'
	And user cancel the case <CaseName>

Examples:
	| userRole     | CaseName    | PrimaryDemand        | Demand             | SubDemand              | Customer      | Product          | PolicyReference        | CaseDueDate  |
	| 'Caseworker' | 'CWwork56A' | 'I want information' | 'Documents'        | 'Send Certificate'     | 'Gary Adams'  | 'Motor'          | 'PL-HOM10003493441/00' | '10/10/2024' |
	| 'Caseworker' | 'CWwork56B' | 'I want to change'   | 'Motor change'     | 'Add Driver'           | 'Sarah Jones' | 'Property'       | 'PL-HOM10003493441/00' | '10/10/2024' |
	| 'Caseworker' | 'CWwork56C' | 'I want to cancel'   | 'Cancellation'     | 'Cancellation Request' | 'Gary Adams'  | 'Building works' | 'PL-HOM10003493441/00' | '10/10/2024' |
	
	@Work-130 @BulkCaseworker @smoke
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

@Work-130 @BulkCaseworker @smoke
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

	@Work-344 @BulkCaseworker
Scenario Outline: Work-344: Add a new contact and Validate as TDU, Service Delivery
	Given User logged in to Dynamics application with <team> and <role> for Contacts
	And User validates The sitemap menu
	And User Clicks on Contacts from Customers AreaGroup
	And User Clicks on New button
	Then User Enters <ContactID> <Firstname> <Surname> <Email> <Telephonenumber> <Broker> <Brokercorrespondenceaddress> <BrokerRegion> <BrokerArea> <FocusvsCore> <PostCode>
	And Validate Post Code is Present
	Then User Clicks on Save
	And User Navigates to My Active Contacts dashboard
	Then Validate the Contact <Firstname>

Examples:
	| team | role         | ContactID | Firstname | Surname | Email            | Telephonenumber | Broker | Brokercorrespondenceaddress | BrokerRegion | BrokerArea   | FocusvsCore | PostCode   |
	| ''   | 'Caseworker' | '2903456' | 'Raja'    | 'Dhoni' | 'raja@test.com ' | '8907654321'    | 'John' | ''                          | 'testrip'    | 'Roof match' | 'core'      | 'IV54 7QZ' |

	@Work-133 @BulkCaseworker @smoke
Scenario Outline: Work-133: Validate the Profile View of Contact
#case creation
	Given User logged in to Dynamics application with <team> and <role>
	When User creates new case <CaseName> <PrimaryDemand> <Demand> <SubDemand> <Customer> <PolicyReference>
	Then User clicks on save button
#Task creation
	When User clicks on activities tab
	And User clicks on task
	And User selects existing case under regarding search bar <CaseName>
	And User Enters <DemandTask>
	And User Enters Primary Demand <PrimaryDemand>
	Then User clicks the on save button
#Contact Validation
	Given User Clicks on Contacts from Customers AreaGroup
	And User Selects the Contact <contactName>
	Then User Selects Related
	And Selects Activities
	And User Validates the Task <DemandTask>
	Then User Selects Related
	And Selects Cases
	And User Validates the Case <CaseName>

Examples:
	| team | role         | CaseName   | PrimaryDemand        | Demand             | SubDemand               | PolicyReference        | Customer     | Owner        | DemandTask   | contactName  |
	| ''   | 'Caseworker' | 'Test133A' | 'I want information' | 'Documents'        | 'Send Certificate'      | 'PL-HOM10003493441/00' | 'Raja Dhoni' | 'Amitsharma' | 'Task-133'   | 'Raja Dhoni' |
	| ''   | 'Caseworker' | 'Test133B' | 'I want to change'   | 'Change of Broker' | 'Letter of Appointment' | 'PL-HOM10003493441/00' | 'RupKumar'   | 'Amitsharma' | 'Task-133-2' | 'RupKumar'   |

	@work-176 @regression @smoke @BulkCaseworker 
Scenario Outline: Work-176: Case Pending/Unpending SLA
	Given User logged in to Dynamics application with 'Caseworker'
	When User <userRole> creates new case <CaseName> <PrimaryDemand> <Demand> <SubDemand> <Customer> <PolicyReference> <CaseDueDate> <Product>
	Then User clicks on save button
	Then User validate the status of the case
	And User changes the Case status to 'On Hold'
	Then User clicks on <SaveType> button
	And User selects the Case <CaseName> and validates Case Status
	Then user validate the status of the case <CaseName> as 'On Hold'
	And User selects newly created case <CaseName>
	And User changes the Case status to 'In Progress'
	Then User clicks on <SaveType> button
	And User selects the Case <CaseName> and validates Case Status
	Then user validate the status of the case <CaseName> as 'In Progress'
	#And user cancel the case <CaseName>
Examples:
	| userRole      | CaseName    | PrimaryDemand        | Demand      | SubDemand          | Customer      | Product | PolicyReference        | CaseDueDate  | numberOfDays | SaveType         |
	| 'Case Worker' | 'TestCase1' | 'I want information' | 'Documents' | 'Send Certificate' | 'sarah marta' | 'Motor' | 'PL-HOM10003493441/00' | '10/10/2024' | 5            | 'Save'           |
	| 'Case Worker' | 'TestCase2' | 'I want information' | 'Documents' | 'Send Certificate' | 'sarah marta' | 'Motor' | 'PL-HOM10003493441/00' | '10/10/2024' | 5            | 'Save and Close' |
	| 'Case Worker' | 'TestCase3' | 'I want information' | 'Documents' | 'Send Certificate' | 'sarah marta' | 'Motor' | 'PL-HOM10003493441/00' | '10/10/2024' | 5            | 'Save and Route' |

	@Work523, @regression @BulkCaseworker
Scenario Outline: Work-523: Contact Screen changes
	Given User logged in to Dynamics application with 'Case Worker'
	And User Clicks on Contacts from Customers AreaGroup
	And User Clicks on New button
	Then details tab in contact screen should be hidden
	Then Summary page should be displayed for the contact
	Then User Enters Contact details as <Firstname> <Surname> <Email> <Street> <House Nr>
	Then User Clicks on Save
	Then Summary page should have Correspondence address as Concatenation of <Street> and <House Nr>
	And <Street> and <House Nr> should be removed from the form

Examples:
	| Firstname | Surname | Email             | Street  | House Nr |
	| 'Maheee'  | 'Dhoni' | 'maheee@test.com' | 'Camac' | '12'     |



