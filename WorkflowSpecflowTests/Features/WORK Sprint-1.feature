Feature: WORK Sprint-1 feature


@work-36 @admin
Scenario Outline: Work-36: Case Resolve and Deletion
	Given User logged in to Dynamics application with <userRole>
	When User <userRole> creates new case <CaseName> <PrimaryDemand> <Demand> <SubDemand> <Customer> <PolicyReference> <CaseDueDate> <Product>
	Then User clicks on save button
	And user validate the status of the case as 'Active'
	When user select the "Resolve Case" option from the case actions
	And user selects the option <ResolutionType> and <Resolution> in resolved popup
	Then user click on 'Resolve' button in Resolve Case popup
	And user validate the status of the case as 'Resolved'
	When user navigates to Customer Service admin center
	And user navigates to the my resolved cases page
	Then user delete the cases <CaseName>
Examples:
	| userRole | CaseName      | PrimaryDemand        | Demand             | SubDemand              | Customer      | Product          | PolicyReference        | CaseDueDate  | ResolutionType                                | Resolution                     |
	| 'Admin'  | 'TestCase36A' | 'I want information' | 'Documents'        | 'Send Certificate'     | 'sarah marta' | 'Motor'          | 'PL-HOM10003493441/00' | '10/10/2024' | 'Request complete - first contact resolution' | 'Resolve Information request'  |
	| 'Admin'  | 'TestCase36B' | 'I want to change'   | 'Motor change'     | 'Add Driver'           | 'sarah marta' | 'Building works' | 'PL-HOM10003493441/00' | '10/10/2024' | 'Request complete - multi contact resolution' | 'Resolve Motor change request' |
	| 'Admin'  | 'TestCase36C' | 'I want to cancel'   | 'Cancellation'     | 'Cancellation Request' | 'sarah marta' | 'Property'       | 'PL-HOM10003493441/00' | '10/10/2024' | 'Request complete - error correction'         | 'Resolve cancel request'       |
	| 'Admin'  | 'TestCase36D' | 'I want to renew'    | 'Renewal'          | 'Review Renewal'       | 'sarah marta' | 'Motor'          | 'PL-HOM10003493441/00' | '10/10/2024' | 'Request complete - not taken up'             | 'Resolve renewal request'      |
	| 'Admin'  | 'TestCase36E' | 'Error Management'   | 'Cancel & Replace' | 'NA'                   | 'sarah marta' | 'Property'       | 'PL-HOM10003493441/00' | '10/10/2024' | 'Request complete - decline cover'            | 'Resolve error manage request' |
	| 'Admin'  | 'TestCase36F' | 'I want information' | 'Documents'        | 'Send Certificate'     | 'sarah marta' | 'Building works' | 'PL-HOM10003493441/00' | '10/10/2024' | 'Request incomplete - Unable to contact'      | 'Resolve incomplete request'   |
	| 'Admin'  | 'TestCase36G' | 'I want to cancel'   | 'Cancellation'     | 'Cancellation Request' | 'sarah marta' | 'Motor'          | 'PL-HOM10003493441/00' | '10/10/2024' | 'Duplicate closed '                           | 'Resolve duplicate request'    |


@Work-36
Scenario: Work-36: Check Whether able to delete a Case
	Given User logged in to Dynamics application with 'Admin'
	When User 'Admin' creates new case 'TestCase6' 'I want information' 'Documents' 'Send Certificate' 'sarah marta' 'PL-HOM10003493441/00' '10/10/2024' 'Motor'
	Then User clicks on save button
	And User checks newly created case "TestCase6"
	And User Clicks Delete button and deletes the Case

	
@work-89 @teamLead @caseworker
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
	| 'teamlead'   | 'TLwork89A' | 'I want information' | 'Documents' | 'Send Certificate' | 'Gary Adams'  | 'Motor' | 'PL-HOM10003493441/00' | '10/10/2024' |
	| 'caseworker' | 'CWwork89B' | 'I want information' | 'Documents' | 'Send Certificate' | 'Sarah Jones' | 'Motor' | 'PL-HOM10003493441/00' | '10/10/2024' |
