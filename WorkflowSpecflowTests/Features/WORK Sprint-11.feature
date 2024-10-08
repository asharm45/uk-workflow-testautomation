Feature: WORK Sprint-11 feature


@Work-710 @admin @teamlead
Scenario: Work-710: Removal of Standard Dashboards
	Given User logged in to Dynamics application
	When User selects customer service hub from Dynamics Home page
	And User clicks on Dashboard
	Then User validates dynamics dashboards are NOT visible
		| Dashboards                              |
		| 'Customer Service Operations Dashboard' |
		| 'Connected Customer Service Dashboard'  |
		| 'Knowledge Manager'                     |
		| 'My Knowledge Dashboard'                |


		
#You should have two existing case with different Case Due Date, e.g.AutomationCase1 and AutomationCase2
@Work-799 @wip
Scenario: Work-799: (ReParented) Task SLA
	Given User logged in to Dynamics application with 'admin'
	When User clicks on activities tab
	And User clicks on task
	Then User creates task with regarding 'AutomationCase1' demand task 'ReParentedTask' and validates case due date '10/10/2024'
	And User changes regarding 'AutomationCase2' and validates case due date '23/08/2025'
	
	
@Work-171 @admin @teamlead
Scenario Outline: Work-171: Validate task is assigned to the person who has created it
	Given User logged in to Dynamics application
	When User selects customer service hub from Dynamics Home page
	And User <userRole> creates new case <CaseName> <PrimaryDemand> <Demand> <SubDemand> <Customer> <PolicyReference> <CaseDueDate> <Product>
	Then User clicks on save button
	When User clicks on activities tab
	And User clicks on task
	And User creates task with regarding <CaseName> demand task "task demand" and validates case due date <numberOfDays> and primary demand <PrimaryDemand>
	Then User validates task is assigned to the person who has created it 'Amitsharma Jaiprakash'
	#Change the assignee name if needed
Examples:
	| userRole     | CaseName       | PrimaryDemand        | Demand      | SubDemand          | Customer      | Product    | PolicyReference        | CaseDueDate  | numberOfDays |
	| 'Caseworker' | 'TaskDueDate1' | 'I want information' | 'Documents' | 'Send Certificate' | 'sarah marta' | 'Property' | 'PL-HOM10003493441/00' | '10/10/2024' | 5            |


@Work-171 @wip
Scenario Outline: Work-171: Validate Task could be assigned to a specific queue manually selected by users by clicking on “Add to Queue”
	Given User logged in to Dynamics application
	When User selects customer service hub from Dynamics Home page
	And User <userRole> creates new case <CaseName> <PrimaryDemand> <Demand> <SubDemand> <Customer> <PolicyReference> <CaseDueDate> <Product>
	Then User clicks on save button
	When User clicks on activities tab
	And User clicks on task
	And User creates task with regarding <CaseName> demand task "task demand" and validates case due date <numberOfDays> and primary demand <PrimaryDemand>
	Then User click on Add to Queue
	And User assign the task to different queue 'UK Service Centre'
	And User validates if it is assiged to same queue
Examples:
	| userRole     | CaseName       | PrimaryDemand        | Demand      | SubDemand          | Customer      | Product    | PolicyReference        | CaseDueDate  | numberOfDays |
	| 'Caseworker' | 'TaskDueDate1' | 'I want information' | 'Documents' | 'Send Certificate' | 'sarah marta' | 'Property' | 'PL-HOM10003493441/00' | '10/10/2024' | 5            |



@Work-171 @admin @teamlead
Scenario Outline: Work-171: Validate Task should be assigned to the queue where the associated case is sitting
	Given User logged in to Dynamics application
	When User selects customer service hub from Dynamics Home page
	And User <userRole> creates new case <CaseName> <PrimaryDemand> <Demand> <SubDemand> <Customer> <PolicyReference> <CaseDueDate> <Product>
	Then User clicks on save button
	And User click on Add to Queue
	And User assign the case to a queue 'UK Service Centre'
	When User clicks on activities tab
	And User clicks on task
	And User creates task with regarding <CaseName> demand task "task demand" and validates case due date <numberOfDays> and primary demand <PrimaryDemand>
	Then User clicks on Save & Route
	And User validates task is also assigned to 'UK Service Centre' queue
Examples:
	| userRole     | CaseName       | PrimaryDemand        | Demand      | SubDemand          | Customer      | Product    | PolicyReference        | CaseDueDate  | numberOfDays |
	| 'Caseworker' | 'TaskDueDate1' | 'I want information' | 'Documents' | 'Send Certificate' | 'sarah marta' | 'Property' | 'PL-HOM10003493441/00' | '10/10/2024' | 5            |


@Work-171 @admin @teamlead
Scenario Outline: Work-171: Validate Task should be assigned to the queue 'Manual Triage'
	Given User logged in to Dynamics application
	When User selects customer service hub from Dynamics Home page
	And User <userRole> creates new case <CaseName> <PrimaryDemand> <Demand> <SubDemand> <Customer> <PolicyReference> <CaseDueDate> <Product>
	Then User clicks on save button
	And User makes sure case is not added to any queue
	When User clicks on activities tab
	And User clicks on task
	And User creates task with regarding <CaseName> demand task "task demand" and validates case due date <numberOfDays> and primary demand <PrimaryDemand>
	Then User validates task is in manual triage
	#Manual triage could be UKSC - Manual Triage or BFT - Manual traige or SD - Maunal Triage etc. it depends on the logged in user's team
Examples:
	| userRole     | CaseName       | PrimaryDemand        | Demand      | SubDemand          | Customer      | Product    | PolicyReference        | CaseDueDate  | numberOfDays |
	| 'Caseworker' | 'TaskDueDate1' | 'I want information' | 'Documents' | 'Send Certificate' | 'sarah marta' | 'Property' | 'PL-HOM10003493441/00' | '10/10/2024' | 5            |


@Work-171 @admin @teamlead
Scenario Outline: Work-171: Validate Manual Task should be assigned to the person who has created it
	Given User logged in to Dynamics application
	When User selects customer service hub from Dynamics Home page
	When User clicks on activities tab
	And User clicks on task
	Then User enters demand task
	And User Selects primary demand 'I want to change' and saves the task
	Then User validates task is assigned to the person who has created it 'Amitsharma Jaiprakash'
	#Change the assignee name if needed


@Work-92 @admin @teamlead
Scenario Outline: Work-92: Task Categorization - to get Merlin task Inbound Correspondence - Canx Request
	Given User has valid policy reference from Merlin <PolicyReference>
	And User creates a case <CaseName> in Dynamincs using Merlin policy refererce with primary demand 'I want information'
	When User logged into Merlin and updates policy details to get MerlinTask Inbound Correspondence - Canx Request
	Then User gets taskId and make api call
	And User logged into Dynamics and navigates to activities screen
	When User filters the cases or regarding <CaseName> and checks if new task is created
	And User clicks on new task link and validates the primary demand <PrimaryDemand> and task type <DynamicsTaskType>
	Then 
Examples:
	| PolicyReference        | CaseName              | MerlinTask                              | DynamicsTaskType         | PrimaryDemand      |
	| 'PolicyNumber-1212324' | 'TestCaseMerlinTask1' | 'Inbound Correspondence - Canx Request' | 'Inbound Correspondence' | 'I want to cancel' |

@Work-92 @admin @teamlead
Scenario Outline: Work-92: Task Categorization - to get Merlin task Inbound Correspondence - MTA Request
	Given User has valid policy reference from Merlin <PolicyReference>
	And User creates a case <CaseName> in Dynamincs using Merlin policy refererce with primary demand 'I want information'
	When User logged into Merlin and updates policy details to get MerlinTask Inbound Correspondence - MTA Request
	Then User gets taskId and make api call
	And User logged into Dynamics and navigates to activities screen
	When User filters the cases or regarding <CaseName> and checks if new task is created
	And User clicks on new task link and validates the primary demand <PrimaryDemand> and task type <DynamicsTaskType>
	Then 
Examples:
	| PolicyReference        | CaseName              | MerlinTask                             | DynamicsTaskType         | PrimaryDemand      |
	| 'PolicyNumber-1212324' | 'TestCaseMerlinTask2' | 'Inbound Correspondence - MTA Request' | 'Inbound Correspondence' | 'I want to change' |
@Work-92 @admin @teamlead
Scenario Outline: Work-92: Task Categorization - to get Merlin task Endorsement construction referral
	Given User has valid policy reference from Merlin <PolicyReference>
	And User creates a case <CaseName> in Dynamincs using Merlin policy refererce with primary demand 'I want information'
	When User logged into Merlin and updates policy details to get MerlinTask Endorsement construction referral
	Then User gets taskId and make api call
	And User logged into Dynamics and navigates to activities screen
	When User filters the cases or regarding <CaseName> and checks if new task is created
	And User clicks on new task link and validates the primary demand <PrimaryDemand> and task type <DynamicsTaskType>
	Then 
Examples:
	| PolicyReference        | CaseName              | MerlinTask                          | DynamicsTaskType       | PrimaryDemand      |
	| 'PolicyNumber-1212324' | 'TestCaseMerlinTask3' | 'Endorsement construction referral' | 'Endorsement Referral' | 'I want to change' |
	
@Work-92 @admin @teamlead
Scenario Outline: Work-92: Task Categorization - to get Merlin task Update Policy at Renewal
	Given User has valid policy reference from Merlin <PolicyReference>
	And User creates a case <CaseName> in Dynamincs using Merlin policy refererce with primary demand 'I want information'
	When User logged into Merlin and updates policy details to get MerlinTask Update Policy at Renewal
	Then User gets taskId and make api call
	And User logged into Dynamics and navigates to activities screen
	When User filters the cases or regarding <CaseName> and checks if new task is created
	And User clicks on new task link and validates the primary demand <PrimaryDemand> and task type <DynamicsTaskType>
	Then 
Examples:
	| PolicyReference        | CaseName              | MerlinTask                 | DynamicsTaskType           | PrimaryDemand     |
	| 'PolicyNumber-1212324' | 'TestCaseMerlinTask4' | 'Update Policy at Renewal' | 'Review policy at renewal' | 'I want to renew' |
@Work-92 @admin @teamlead
Scenario Outline: Work-92: Task Categorization - to get Merlin task Renewal reminder chaser email
	Given User has valid policy reference from Merlin <PolicyReference>
	And User creates a case <CaseName> in Dynamincs using Merlin policy refererce with primary demand 'I want information'
	When User logged into Merlin and updates policy details to get MerlinTask Renewal reminder chaser email
	Then User gets taskId and make api call
	And User logged into Dynamics and navigates to activities screen
	When User filters the cases or regarding <CaseName> and checks if new task is created
	And User clicks on new task link and validates the primary demand <PrimaryDemand> and task type <DynamicsTaskType>
	Then 
Examples:
	| PolicyReference        | CaseName              | MerlinTask                      | DynamicsTaskType | PrimaryDemand     |
	| 'PolicyNumber-1212324' | 'TestCaseMerlinTask5' | 'Renewal reminder chaser email' | 'Renewal'        | 'I want to renew' |
	
@Work-92 @admin @teamlead
Scenario Outline: Work-92: Task Categorization - to get Merlin task Broker - Inbound Renewal Correspondence (PU)
	Given User has valid policy reference from Merlin <PolicyReference>
	And User creates a case <CaseName> in Dynamincs using Merlin policy refererce with primary demand 'I want information'
	When User logged into Merlin and updates policy details to get MerlinTask Broker - Inbound Renewal Correspondence (PU)
	Then User gets taskId and make api call
	And User logged into Dynamics and navigates to activities screen
	When User filters the cases or regarding <CaseName> and checks if new task is created
	And User clicks on new task link and validates the primary demand <PrimaryDemand> and task type <DynamicsTaskType>
	Then 
Examples:
	| PolicyReference        | CaseName              | MerlinTask                                     | DynamicsTaskType                 | PrimaryDemand     |
	| 'PolicyNumber-1212324' | 'TestCaseMerlinTask6' | 'Broker - Inbound Renewal Correspondence (PU)' | 'Inbound Renewal Correspondence' | 'I want to renew' |