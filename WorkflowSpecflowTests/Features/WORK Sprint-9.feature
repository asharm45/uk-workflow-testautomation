Feature: WORK Sprint-9 feature



@Work64 @regression
Scenario Outline: Work-64: View Policy data - Case Management - admin
	Given User logged in Dynamics application with <Profile>
	And User Clicks on Contacts from Customers AreaGroup
	And User Clicks on New button
	Then User Enters Contact details as <Firstname> <Surname> <Email> <Street> <House Nr>
	And User Clicks on Save
	When User open the contact <>
	And User can be edit the fields <FirstName><Surname><Email>
	Then User Clicks on Save
	When User select the contact <>
	And User click on the delete button for the contact

Examples:
	| Profile | Firstname | Surname | Email             | Street  | House Nr |
	| 'admin' | 'Jadeja'  | 'Dhoni' | 'Jadduu@test.com' | 'Camac' | '12'     |

@Work64 @regression
Scenario Outline: Work-64: View Policy data - Case Management - TeamLead
	Given User logged in Dynamics application with 'Admin'
	And User Clicks on Contacts from Customers AreaGroup
	And User Clicks on New button
	Then User Enters Contact details as <Firstname> <Surname> <Email> <Street> <House Nr>
	And User Clicks on Save
	Given User logged in Dynamics application with <Profile>
	When User open the contact <>
	And User unable to edit the fields <FirstName><Surname><Email>
	When User select the contact <>
	And User unable to view the delete button on top menu

Examples:
	| Profile    | Firstname | Surname | Email               | Street  | House Nr |
	| 'TeamLead' | 'Mahen'   | 'Dhoni' | 'TeamLead@test.com' | 'Camac' | '12'     |


@Work-75 @smoke
Scenario Outline: Work-75: View Renewal details of Policy - Case Management
	Given User logged in to Dynamics application with <userRole>
	Then User Clicks on Policies <Policy>
	And User Validates the user policy renewal date
	And Check Whether it's read-only

	
Examples:
	| userRole     | Policy                 |
	| 'Caseworker' |'PL-HOM10003500586/00'  |
	| 'Caseworker' |'PL-HOM10003500486/01'  |
	| 'Caseworker' |'PL-EAH10003500886/01'  |
	| 'Caseworker' |'PL-HOM10001802378/19'  |
	| 'Caseworker' |'PL-HOM10003285995/02'  |
	| 'Caseworker' |'PL-HOM10003364501/07'  |
	| 'Caseworker' |'PL-HOM10005679870/02'  |



#Work-74 can be integrated with work-75 its checking whether POLICY RENEWAL DATE should be read only 
@work-74 @Caseworker @teamlead @admin
Scenario: Work-74: View Renewal details APC - Case Management
	Given User logged in to Dynamics application with 'Admin'
	#And User creates a APC policy in Merlin with renewal date
	When User makes policy summary api call and loads policy 'PL-HOM123456789' and validates Policy Renewal Date
	Then User validates the Policy Renewal Date field is ready only
	

@work-74 @Caseworker @teamlead @admin
Scenario: Work-74: View Renewal details eTrading - Case Management
	Given User logged in to Dynamics application with 'Admin'
	#And User creates an eTrading policy in Merlin with renewal date
	When User makes policy summary api call and loads policy 'E-PL-HOM123456789' and validates Policy Renewal Date
	Then User validates the Policy Renewal Date field is ready only

@work-74 @Caseworker @teamlead @admin
Scenario: Work-74: View Renewal details PSC - Case Management
	Given User logged in to Dynamics application with 'Admin'
	#And User creates a PSC policy in Merlin with renewal date
	When User makes policy summary api call and loads policy 'PL-HOM123456789'
	Then User validates the policy is not loaded into Dynamics



	
@work-94 @admin
Scenario: Work-94: Primary Product Identification - Automatic
	Given User fetch policy number from Merlin where policy has product Motor
	And User sends an email to UKSC mailbox
		| sender                      | to                   | subject                                                | body                                                                                                                | attachment |
		| 'Svc_HiscoxUKWorkflowAuto3' | 'Test_UKSC_Dynamics' | '(EXT) RE: Mr Guinevere Forbes - PL-HOM05006213708/06' | 'Apologies, Lionel. Client has also confirmed that the tracker subscription has been renewed for a further 3 years' | 'No'       |
	And User logged in to Dynamics application with 'Admin'
	When User selects customer service hub from Dynamics Home page
	Then User clicks on Activities
	And User searches the email by subject and clicks on the email
	Then User validates the email content
	And User clicks on regarding
	And User validates the product name

@work-94 @admin
Scenario Outline: Work-94: Primary Product Identification - Manual
	Given User fetch policy number from Merlin where policy has product Motor and Building works
	And User logged in to Dynamics application with 'Admin'
	When User selects customer service hub from Dynamics Home page
	And User <userRole> creates new case <CaseName> <PrimaryDemand> <Demand> <SubDemand> <Customer> <PolicyReference> <CaseDueDate> <Product>
	Then User calls GetInfo API and validates product updates to Motor
Examples:
	| userRole     | CaseName       | PrimaryDemand      | Demand         | SubDemand    | Customer      | Product    | PolicyReference        | CaseDueDate  | numberOfDays |
	| 'Caseworker' | 'TaskDueDate2' | 'I want to change' | 'Motor change' | 'Add Driver' | 'sarah marta' | 'Property' | 'PL-HOM10003493441/00' | '10/10/2024' | 5            |

@work-94 @admin
Scenario Outline: Work-94: Primary Product Identification - Override Product
	Given User fetch policy number from Merlin where policy has product Motor and Building works
	And User logged in to Dynamics application with 'Admin'
	When User selects customer service hub from Dynamics Home page
	And User <userRole> creates new case <CaseName> <PrimaryDemand> <Demand> <SubDemand> <Customer> <PolicyReference> <CaseDueDate> <Product>
	Then User calls GetInfo API and validates product updates to Motor
	And User overriddes the product and validates the changes

Examples:
	| userRole     | CaseName       | PrimaryDemand      | Demand         | SubDemand    | Customer      | Product    | PolicyReference        | CaseDueDate  | numberOfDays |
	| 'Caseworker' | 'TaskDueDate2' | 'I want to change' | 'Motor change' | 'Add Driver' | 'sarah marta' | 'Property' | 'PL-HOM10003493441/00' | '10/10/2024' | 5            |
		
@work-94 @admin
Scenario Outline: Work-94: Primary Product Identification - Prodcut does not change after refresh
	Given User fetch policy number from Merlin where policy has product Motor and Building works
	And User logged in to Dynamics application with 'Admin'
	When User selects customer service hub from Dynamics Home page
	And User <userRole> creates new case <CaseName> <PrimaryDemand> <Demand> <SubDemand> <Customer> <PolicyReference> <CaseDueDate> <Product>
	Then User calls GetInfo API and validates product updates to Motor
	And User overriddes the product and validates the changes
	And User calls the GetInfo API and validates product not changed

Examples:
	| userRole     | CaseName       | PrimaryDemand      | Demand         | SubDemand    | Customer      | Product    | PolicyReference        | CaseDueDate  | numberOfDays |
	| 'Caseworker' | 'TaskDueDate2' | 'I want to change' | 'Motor change' | 'Add Driver' | 'sarah marta' | 'Property' | 'PL-HOM10003493441/00' | '10/10/2024' | 5            |
	
@work-94 @admin
Scenario Outline: Work-94: Primary Product Identification - Prodcut label changed to Primary Product
	Given User logged in to Dynamics application with 'Admin'
	When User selects customer service hub from Dynamics Home page
	And User clicks on Cases and new case
	Then User valdates the label Primary Product is visiable on summary screen

@work-20 @admin
Scenario: Work20 - Automatic Email Triage (Routing)
	Given User sends an email to UKSC mailbox
		| sender          | to                | subject                       | body                          | attachment |
		| 'Tonysmithtest' | 'Test_WF_BFT_EB'  | 'BFT manual triage queue'     | 'BFT manual triage queue'     | 'No'       |
		| 'Tonysmithtest' | 'Test_WF_CEC_EB'  | 'CEC manual triage queue'     | 'CEC manual triage queue'     | 'No'       |
		| 'Tonysmithtest' | 'Test_WF_HPC_EB'  | 'HPC manual triage queue'     | 'HPC manual triage queue'     | 'No'       |
		| 'Tonysmithtest' | 'Test_WF_SD_EB'   | 'SD manual triage queue'      | 'SD manual triage queue'      | 'No'       |
		| 'Tonysmithtest' | 'Test_WF_TRAD_EB' | 'Trading manual triage queue' | 'Trading manual triage queue' | 'No'       |
	And User logged in to Dynamics application
	When User selects customer service hub from Dynamics Home page
	Then User search and validates the email content with the below
		| subject                       | body                          |
		| 'BFT manual triage queue'     | 'BFT manual triage queue'     |
		| 'CEC manual triage queue'     | 'CEC manual triage queue'     |
		| 'HPC manual triage queue'     | 'HPC manual triage queue'     |
		| 'SD manual triage queue'      | 'SD manual triage queue'      |
		| 'Trading manual triage queue' | 'Trading manual triage queue' |

@work-23 @admin
Scenario Outline: Work23 - Automatic Routing of Cases to Queues
	Given User logged in to Dynamics application with <userRole>
	When User navigates to Customer Service hub
	When User <userRole> creates new case <CaseName> <PrimaryDemand> <Demand> <SubDemand> <Customer> <PolicyReference> <CaseDueDate> <Product>
	Then User clicks on save&route button
	Then User selects newly created case <CaseName>
	When User click on Queue Items Details 
	Then User Validate the case is assigned automatically assigned to respective <Queue> 
	# Need to update the queue name depends on reality

Examples:
	| Queue                             | userRole     | CaseName    | PrimaryDemand        | Demand         | SubDemand          | Customer      | Product          | PolicyReference        | CaseDueDate  |
	| 'UK Service Centre Case'          | 'Caseworker' | 'CWwork56A' | 'I want information' | 'Documents'    | 'Send Certificate' | 'sarah marta' | 'Motor'          | 'PL-HOM10003488945/00' | '10/10/2024' |
	| 'Customer Experience Centre Case' | 'Caseworker' | 'CWwork56B' | 'I want to change'   | 'Motor change' | 'Add Driver'       | 'sarah marta' | 'Property'       | 'PL-HOM10003512888/00' | '10/10/2024' |
	| 'Hiscox Private Client Case'      | 'Caseworker' | 'CWwork56C' | 'I want to renew'    | 'Renewal'      | 'Review Renewal'   | 'sarah marta' | 'Building works' | 'PL-HOM05006561234/04' | '10/10/2024' |


@work-94 
Scenario Outline: Work-94

@work-64 @caseworker 
Scenario Outline: Work-64 caseworker
	Given User logged in to Dynamics application with <userRole>
	And User Clicks on Policies from Service AreaGroup
	When User searches the policy from search bar and clicks on it <Policy>
	And Check whether fields are displaying for policy screen
	Then Check Whether it's read-only
	#Contact Page
	When User clicks on contact
	Then User selects the existing contact with firstName <FirstName> and lastName <LastName>
	And User checks whether fields are displaying for contact screen
	Then Check Whether it's read-only


Examples:
	| userRole     | Policy                 | FirstName | LastName |
	| 'Caseworker' | 'PL-HOM10002898598/05' | 'Raja'    | 'Dhoni'  |


@work-64 @admin 
Scenario Outline: Work-64 admin
	Given User logged in to Dynamics application
	When User selects customer service hub from Dynamics Home page
	Given User Clicks on Policies from Service AreaGroup
	#User creates a policy and fills necesaary details and then saves it
	Given User Clicks on Policies from Service AreaGroup
	When User searches the policy from search bar and clicks on it <Policy>	
	Then User deletes the policy
	
	#Contact Page
	When User clicks on contact
	Then User clicks on New
	#User creates a contact and fills necessary details and then saves it
	Then User selects the existing contact with firstName <FirstName> and lastName <LastName>
    Then User deletes the contact

Examples:
	| userRole     | Policy                 | FirstName | LastName |
	| 'Caseworker' | 'PL-HOM10002898598/05' | 'Raja'    | 'Dhoni'  |
