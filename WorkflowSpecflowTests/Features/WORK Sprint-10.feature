Feature: WORK Sprint-10 feature

@work-178 @regression @smoke @caseWorker
Scenario: Work-178 Unpending Case Due to Activity
	Given User logged in to Dynamics application with 'Caseworker'
	When User <userRole> creates new case <CaseName> <PrimaryDemand> <Demand> <SubDemand> <Customer> <PolicyReference> <CaseDueDate> <Product>
	Then User clicks on save button
	Then User validate the status of the case
	And User changes the Case status to 'On Hold'
	Then User clicks on <SaveType> button
	When User clicks on activities tab
	And User clicks on task
	And User creates task with regarding <CaseName> demand task "task demand" and validates case due date <numberOfDays> and primary demand <PrimaryDemand>
	#Then User goes to Cases tab
	#And user validate the status of the case <CaseName> as 'In Progress'
	


	#And User selects the Case <CaseName> and validates Case Status
	#Then user validate the status of the case as 'On Hold'
	#And User changes the Case status to 'In Progress'
	#Then User clicks on <SaveType> button
	#And User selects the Case <CaseName> and validates Case Status
	#Then user validate the status of the case as 'In Progress'
	#And user cancel the case <CaseName>

Examples:
	| userRole      | CaseName    | PrimaryDemand        | Demand      | SubDemand          | Customer      | Product | PolicyReference        | CaseDueDate  | numberOfDays | SaveType         |
	| 'Case Worker' | 'TestCase1' | 'I want information' | 'Documents' | 'Send Certificate' | 'sarah marta' | 'Motor' | 'PL-HOM10003493441/00' | '10/10/2024' | 5            | 'Save'           |
