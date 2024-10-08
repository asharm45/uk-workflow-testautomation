Feature: WORK Sprint-7 feature


@Work-133 @Caseworker @smoke
Scenario Outline: Work-133: Validate the Profile View of Contact
#case creation
	Given User logged in to Dynamics application with <userRole>
	When User <userRole> creates new case <CaseName> <PrimaryDemand> <Demand> <SubDemand> <Customer> <PolicyReference> <CaseDueDate> <Product>
	Then User clicks on save button
#Task creation
	When User clicks on activities tab
	And User clicks on task
	Then User creates task with regarding <CaseName> demand task <DemandTask> and primary demand <PrimaryDemand>
#Contact Validation
	Given User Clicks on Contacts from Customers AreaGroup
	And User filters contacts <contactName>
	And User Selects the Contact <contactName>
	Then User Selects Related
	And Selects Activities
	And User Validates the Task <DemandTask>
	Then User Selects Related
	And Selects Cases
	And User Validates the Case <CaseName>
#After Validating delete the case
#Then User cancels the case with tasks <CaseName>
#All views , Add more test data

Examples:

	| team | userRole   | CaseName   | PrimaryDemand        | Demand             | SubDemand               | PolicyReference        | Customer     | Owner        | DemandTask   | contactName  | Product    | CaseDueDate |
	| ''   | 'teamlead' | 'Test133C' | 'I want information' | 'Documents'        | 'Send Certificate'      | 'PL-HOM10003493441/00' | 'Raja Dhoni' | 'Amitsharma' | 'Task-133'   | 'Raja Dhoni' | 'Property' | '9/9/2024'  |
	| ''   | 'teamlead' | 'Test133D' | 'I want to change'   | 'Change of Broker' | 'Letter of Appointment' | 'PL-HOM10003493441/00' | 'RupKumar'   | 'Amitsharma' | 'Task-133-2' | 'RupKumar'   | 'Motor'    | '9/9/2024'  |


@Work-31
Scenario Outline: Work-31: Manual Triage Process
	Given User sends email to UKSC mailbox with subject <subject> body <body> and attachment if any <attachment>
	And User logged in to Dynamics application with <userRole>
	#When User selects customer service hub from Dynamics Home page
	Then User clicks on Activities
	And User searches the email by subject <subject> and clicks on the email
	Then User validates the email content like subject <subject> body <body>
	Then Validate that case number is not created
	Then Validate the request <subject> is in UKSC Manual Triage Bucket
	
	
Examples:
	| subject                                                    | body                    | attachment | userRole     |
	| '(EXT) Validate Manual Triage Incoming2'                   | 'Testing Manual Triage' | 'No'       | 'Caseworker' |
	| 'Address change-PL-HOM05006213708/06,PL-HOM05006213709/06' | 'Testing Manual Triage' | 'No'       | 'Caseworker' |

		
		
@Work-138 @smoke
Scenario Outline: Work-138
	Given User logged in to Dynamics application with <team> and <role>
	When User creates new case <CaseName> <PrimaryDemand> <Demand> <SubDemand> <Customer> <PolicyReference>
	Then User clicks on save button
	When User Enter a <Note>
	Then User validates <Note> is added
	And User Validates note is not editable
	When User Switches case status to In-Progress
	When User Enter a <Note>
	Then User Validates note is not editable
	Then User validates <Note> is added
	When User Switches case status to On-Hold
	When User Enter a <Note>
	Then User validates <Note> is added
	And User Validates note is not editable
	Then User clicks on resolve case <resolutionReason>
	When User Enter a <Note>
	Then User validates <Note> is added
	
Examples:

	| team | role         | CaseName       | PrimaryDemand        | Demand      | SubDemand          | PolicyReference        | Customer      | Owner        | Note          | resolutionReason |
	| ''   | 'Caseworker' | 'TestWhatever' | 'I want information' | 'Documents' | 'Send Certificate' | 'PL-HOM10003493441/00' | 'sarah marta' | 'Amitsharma' | 'hello world' | 'Resolving'      |


 
@Work-51 @Admin
Scenario Outline: Work-51: Update Case and Task SLA
	Given User logged in to Dynamics application with <userRole>
	When User 'Team Lead' creates new case <CaseName> <PrimaryDemand> <Demand> <SubDemand> <Customer> <PolicyReference> <CaseDueDate> <Product>
	Then User saves the case <CaseName> with <PrimaryDemand>
	When user navigates to Customer Service admin center
	And User update the SLA days <SLADays> for the primary demand <SLAprimaryDemand>
	And User click the Save button on the SLA time page
	And User navigates to Customer Service Hub
	Then User selects newly created case <CaseName>
	And User changes the primaryDemand <SLAprimaryDemand> demand 'Cancellation' and subDemand 'Cancellation Request'
	And User clicks on save button
	And User validate the duedate <SLADays> for the case <CaseName>
	And user cancel the case <CaseName>
	When user navigates to Customer Service admin center
	And User update the SLA days <DefaultSLA> for the primary demand <PrimaryDemand>
	And User click the Save button on the SLA time page

Examples:
	| SLADays | DefaultSLA | userRole | CaseName     | PrimaryDemand        | Demand      | SubDemand          | Customer      | Product | PolicyReference        | CaseDueDate  | SLAprimaryDemand   |
	| '2'     | '1'        | 'Admin'  | 'TestSLA51A' | 'I want information' | 'Documents' | 'Send Certificate' | 'sarah marta' | 'Motor' | 'PL-HOM10003493441/00' | '10/10/2024' | 'I want to cancel' |


	
@Work-39 @teamlead
Scenario Outline: Work-39: Manual Allocation of Case
	Given User logged in to Dynamics application with <userRole>
	When User <userRole> creates new case <CaseName> <PrimaryDemand> <Demand> <SubDemand> <Customer> <PolicyReference> <CaseDueDate> <Product>
	Then User clicks on save button
	When User select the case <CaseName> from case home page
	Then User Assigns the Task and selects <UserOrTeam>
	And User validates the cases <CaseName> ownername is changed to <UserOrTeam>
	And user cancel the case <CaseName>

Examples:
	| userRole    | CaseName                   | PrimaryDemand        | Demand      | SubDemand          | Customer      | Product    | PolicyReference        | CaseDueDate  | UserOrTeam         |
	| 'Team Lead' | 'WF39ManualCaseAllocation' | 'I want information' | 'Documents' | 'Send Certificate' | 'sarah marta' | 'Property' | 'PL-HOM10003493441/00' | '10/10/2024' | 'Sanjay Jayakumar' |
	| 'Team Lead' | 'WF39ManualCaseAllocation' | 'I want information' | 'Documents' | 'Send Certificate' | 'sarah marta' | 'Motor'    | 'PL-HOM10003493441/00' | '10/10/2024' | ''                 |

@Work-39 @teamlead
Scenario Outline: Work-39: Manual Allocation of Task
	Given User logged in to Dynamics application with <userRole>
	When create the new task <TaskName> <Demand> <PrimaryDemand>
	Then User clicks on save button
	When User select the task <TaskName> from task page
	Then User Assigns the Task and selects <UserOrTeam>
	And User validates the task <TaskName> ownernName is changed to <UserOrTeam>
	Then User cancels the tasks <TaskName>

Examples:
	| userRole    | TaskName                   | PrimaryDemand        | Demand      | UserOrTeam         |
	| 'Team Lead' | 'WF39ManualTaskAllocation' | 'I want information' | 'Documents' | 'Sanjay Jayakumar' |
	| 'Team Lead' | 'WF39ManualTaskAllocation' | 'I want information' | 'Documents' | 'Sanjay Jayakumar' |



	
@work-82 @wip
Scenario Outline: Work-82: Send an Email to UKSC mailbox & Validate the mandatory details
	Given User sends email to UKSC mailbox with subject <subject> body <body> and attachment if any <attachment>
	Given User logged in to Dynamics application with <userRole>
	Then User clicks on Activities
	And User Selects All Emails
	And User searches the email by subject <subject> and clicks on the email
	Then User validates the email content like subject <subject> body <body>
	And User Validates The Regarding has Casename
	And User Validates Case due date is 5 days further from creation date
	And Case Status Should be new
	And Email should be displayed under timeline
	And New Page will display queue details
	And Validate Case is Under bucket
	And User Clicks on Dashboard and Clicks Pick Work
	And Should Display new RPA Cases
	And User Deletes the email
	And User clicks on sign out
Examples:
	| userRole     | subject                                               | body                                                                                                                                                                                                                                                                                                             | attachment | Policy number        | Demand                 | Queue | Customer |
	| 'Caseworker' | 'Preston floyd  – policy number PL-HOM10003285995/02' | 'Can you please note that the policyholder, Preston floyd has recently passed away and we would be grateful if you could change the policy into the name of Mrs Alice floyd (joint insured). I trust you find this to be in order and look forward to receiving amended policy documentation Regards Gary Adams' | 'No'       | PL-HOM10003285995/02 | Change of policyholder | UKSC  | Contact  |
	
	