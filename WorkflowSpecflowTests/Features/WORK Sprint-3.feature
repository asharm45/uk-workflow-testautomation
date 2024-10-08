Feature: WORK Sprint-3 feature

@work-134
Scenario Outline: Work-134: Validate the Merlin Task ID field
	Given User logged in to Dynamics application with <userRole>
	When User <userRole> creates new case <CaseName> <PrimaryDemand> <Demand> <SubDemand> <Customer> <PolicyReference> <CaseDueDate> <Product>
	When User clicks on activities tab
	And User clicks on task
	And User selects existing case under regarding search bar <CaseName>
	Then User validates all the fields under details section
	And User enter demand task details "Cancellation"
	And User validates Merlin task id field is disabled & read only
	And User enters task details primary demand "I want to cancel" task type "Cancellation"
	And User validates merlinTaskType "Broker - Cancellation Request" and valueStep "Understand My Request/Assess Information Provided"
	And User enters  task description "Creating task for testing" and instruction field "Testing purpose"
	Then User clicks on save button
	And User cancels the case with tasks <CaseName>
Examples:
	| userRole | CaseName       | PrimaryDemand      | Demand         | SubDemand              | Customer      | Product | PolicyReference        | CaseDueDate  | ResolutionType                        | Resolution               |
	| 'Admin'  | 'TestCase126C' | 'I want to cancel' | 'Cancellation' | 'Cancellation Request' | 'sarah marta' | 'Motor' | 'PL-HOM10003493441/00' | '10/10/2024' | 'Request complete - error correction' | 'Resolve cancel request' |
	

@tag1
Scenario: Work-134: Validate the Merlin Task Unique Identifier - After task API Integration.
	When User creates new case with CaseName "TestCase7" PrimaryDemand "I want to cancel" Demand "Cancellation" SubDemand "Cancellation" Customer "Anth Bear" PolicyReference "Hom-1290009253" CaseDueDate "10/10/2024" "Home"
	When User clicks on activities tab

	
@work-86 @admin
Scenario Outline: Work-86: Send an Email from Dynamics 365 without attachment
	Given User logged in to Dynamics application with 'Admin'
	When User selects customer service hub from Dynamics Home page
	Then User clicks on Activities
	And User clicks on Emails
	Then User enters from <From> to <To> subject <Subject> body <Body> and attach files <Attachment> with file path <AttachmentPath>
	And User clicks on send button
	And User validates if email <Subject> has sent successfully
Examples:
	| From                 | To                      | Subject                                    | Body                             | Attachment | AttachmentPath |
	| 'test_uksc_dynamics' | 'Amitsharma Jaiprakash' | 'Email from Dynamics - without attachment' | 'This emailis from Dynamics 365' | 'No'       | 'Not requried' |

@work-86 @admin
Scenario Outline: Work-86: Send an Email from Dynamics 365 with attachment
	Given User logged in to Dynamics application with 'Admin'
	When User selects customer service hub from Dynamics Home page
	Then User clicks on Activities
	And User clicks on Emails
	Then User enters from <From> to <To> subject <Subject> body <Body> and attach files <Attachment> with file path <AttachmentPath>
	And User clicks on send button
	And User validates if email <Subject> has sent successfully
Examples:
	| From                 | To                      | Subject                                 | Body                             | Attachment | AttachmentPath |
	| 'test_uksc_dynamics' | 'Amitsharma Jaiprakash' | 'Email from Dynamics - with attachment' | 'This emailis from Dynamics 365' | 'Yes'      | ''             |


	
@work-53 @admin
Scenario Outline: Work-53: Create a case and assoicate a task with it.
	Given User logged in to Dynamics application
	When User selects customer service hub from Dynamics Home page
	Then User creates new case and validates case status, case due date, case number and sitemap
		| userRole | CaseName | PrimaryDemand      | Demand             | SubDemand               | Customer           | Product    | PolicyReference       | CaseDueDate  | numberOfDays |
		| 'Admin'  | 'Sep 17' | 'I want to change' | 'Change of Broker' | 'Letter of Appointment' | 'Rad test Account' | 'Property' | 'PL-HOM0000010003/01' | '10/10/2024' | 5            |
	When User clicks on activities tab
	And User clicks on task
	And User selects existing case under regarding search bar <CaseName>
	And User Enters <DemandTask>
	And User Enters Primary Demand <PrimaryDemand>
	#Add some step to validate fields in task type
	And User Clicks on Task Type <TaskType>
	Then User clicks the on save button

	#SN.2 User is able to update the created case	
Examples:
	| CaseName | PrimaryDemand        | Demand      | SubDemand          | PolicyReference        | Customer     | Owner        | DemandTask  | contactName  | TaskType    |
	| 'Sep 17' | 'I want information' | 'Documents' | 'Send Certificate' | 'PL-HOM10003493441/00' | 'Raja Dhoni' | 'Amitsharma' | 'My demand' | 'Raja Dhoni' | 'Follow up' |

@work-53 @admin
Scenario Outline: Work-53: SN.2 User is able to update the created case
	Given User logged in to Dynamics application with <team> and <role>
	When User clicks on activities tab
	And User switches to All activities
	When User searches the the demand task <DemandTask>
	And User clicks on the task <DemandTask>
	And User Enters Primary Demand <PrimaryDemand>
	When User Clicks on Task Type <TaskType>
	Then User clicks the on save button


Examples:

	| team | role         | CaseName  | PrimaryDemand      | Demand      | SubDemand          | PolicyReference        | Customer     | Owner        | DemandTask  | contactName  | TaskType          |
	| ''   | 'Caseworker' | 'Test133' | 'I want to cancel' | 'Documents' | 'Send Certificate' | 'PL-HOM10003493441/00' | 'Raja Dhoni' | 'Amitsharma' | 'My demand' | 'Raja Dhoni' | 'Action Required' |
	
@work-53 @admin
Scenario Outline: Work-53: User is able to delete the case
	Given User logged in to Dynamics application
	When User selects customer service hub from Dynamics Home page
	When User clicks on activities tab
	And User clicks on task
	When User searches the the demand task <DemandTask>
	And User Selects the task <DemandTask> and deletes it
	# Validated whether task is present after deletion in the previous step

Examples:

	| team | role         | CaseName  | PrimaryDemand      | Demand      | SubDemand          | PolicyReference        | Customer     | Owner        | DemandTask  | contactName  | TaskType          |
	| ''   | 'Caseworker' | 'Test133' | 'I want to cancel' | 'Documents' | 'Send Certificate' | 'PL-HOM10003493441/00' | 'Raja Dhoni' | 'Amitsharma' | 'My demand' | 'Raja Dhoni' | 'Action Required' |


 
@work-124 @teamleader
Scenario Outline: Work-124: Value steps for each Primary Demand type
	Given User logged in to Dynamics application with 'Team Lead'
	When User 'Team Lead' creates new case <CaseName> 'I want information' 'Documents' 'Send Certificate' 'sarah marta' 'PL-HOM10003493441/00' '10/10/2024' 'Motor'
	Then User changes the primaryDemand <PrimaryDemand> demand <Demand> and subDemand <SubDemand>
	And User validates the <valueSteps> for primaryDemand <PrimaryDemand>
	And User validates the <valueStepsMessage> in the case page

Examples:
	| CaseName       | PrimaryDemand        | Demand             | SubDemand              | valueSteps                                                                                                                                                               | valueStepsMessage                                                            |
	| 'TestCase124A' | 'I want information' | 'Documents'        | 'Send Certificate'     | 'Authentication,Understand My Request/Assess Information Provided,Perform Change,Manage Referral,Present & Issue Quote,Arrange Payment,Confirm Policy & Issue Documents' | 'Check For: Vulnerable Customer; Fraud Warnings; Complaints(different Text)' |
	| 'TestCase124B' | 'I want to change'   | 'Motor change'     | 'Add Driver'           | 'Authentication,Understand My Request/Assess Information Provided,Perform Change,Manage Referral,Present & Issue Quote,Arrange Payment,Confirm Policy & Issue Documents' | 'Check For: Vulnerable Customer; Fraud Warnings; Complaints'                 |
	| 'TestCase124C' | 'I want to cancel'   | 'Cancellation'     | 'Cancellation Request' | 'Authentication,Understand My Request/Assess Information Provided,Perform Change,Arrange Payment,Confirm Policy & Issue Documents'                                       | 'Check For: Vulnerable Customer; Fraud Warnings; Complaints(different Text)' |
	| 'TestCase124D' | 'I want to renew'    | 'Renewal'          | 'Review Renewal'       | 'Authentication,Understand My Request/Assess Information Provided,Perform Change,Manage referral,Present & Issue Quote,Arrange Payment,Confirm Policy & Issue Documents' | 'Check For: Vulnerable Customer; Fraud Warnings; Complaints(different Text)' |
	| 'TestCase124E' | 'Error Management'   | 'Cancel & Replace' | 'NA'                   | 'Authentication,Understand My Request/Assess Information Provided,Perform Change,Confirm Policy & Issue Documents'                                                       | 'Check For: Vulnerable Customer; Fraud Warnings; Complaints'                 |

	
@work-128 @teamleader @caseworker @admin
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
	| 'teamlead'   | 'TLwork128' | 'I want information' | 'Documents'    | 'Send Certificate' | 'Sarah Jones' | 'Property' | 'PL-HOM10003493441/00' | '10/10/2024' |
	| 'caseworker' | 'CWwork128' | 'I want to change'   | 'Motor change' | 'Add Driver'       | 'Gary Adams' | 'Motor'    | 'PL-HOM10003493441/00' | '10/10/2024' |

@work-106
Scenario Outline: Work-106 From Task
	Given User logged in to Dynamics application with <userRole>
	When User clicks on activities tab
	And User clicks on task
	Then User enter demand task details "demand 002"
	And User enters new task details primary demand "I want information" task type "Follow up"
	And User clicks on save button
	And User validates the task status reason

	Examples:
	| userRole			|
	| 'Caseworker'		|
	| 'Team Lead'		|
	| 'System Admin'	|

	@work-106
	Scenario Outline: Work-106 From My Activities
	Given User logged in to Dynamics application with <userRole>
	When User clicks on activities tab
	And User Filters the Task "demand 002"
	And User clicks on the task 'demand 002'
	Then User enters task details primary demand "I want to cancel" task type "Chaser"
	And User clicks on save button
	And User validates the task status reason
	

	Examples:
	| userRole			|
	| 'Caseworker'		|
	| 'Team Lead'		|
	| 'System Admin'	|


