Feature: WORK Sprint-4 feature


@work-125
Scenario Outline: Work-125: Validate value steps stage for a Parent Case moves forward automatically when child task mapped with upcoming value step is manually linked to an Open case
	Given User logged in to Dynamics application with <userRole>
	When User <userRole> creates new case <CaseName> <PrimaryDemand> <Demand> <SubDemand> <Customer> <PolicyReference> <CaseDueDate> <Product>
	When User clicks on activities tab
	And User clicks on task
	And User selects existing case under regarding search bar <CaseName>
	Then User validates all the fields under details section
	And User enter demand task details "Chaser"
	And User validates Merlin task id field is disabled & read only
	And User enters task details primary demand "I want to cancel" task type "chaser"
	And User validates merlinTaskType "chaser" and valueStep "Understand My Request/Assess Information Provided"
	And User enters  task description "Creating task for testing" and instruction field "Testing purpose"
	Then User clicks on save button
	And User validates the task status reason
	When User navigates to cases <CaseName> and validates newly created task under Highlights panel <Demand>
	Then User also validates the case value step moved to "Understand My Request/Assess Information Provided"
Examples:
	| userRole | CaseName    | PrimaryDemand      | Demand         | SubDemand              | Customer      | Product | PolicyReference        | CaseDueDate  | numberOfDays |
	| 'Admin'  | 'TestCase3' | 'I want to cancel' | 'Cancellation' | 'Cancellation Request' | 'sarah marta' | 'Motor' | 'PL-HOM10003493441/00' | '10/11/2024' | 5            |


@work-125
Scenario Outline: Work-125: Validate value steps stage for a Parent Case Stays as-is in current value step when child task mapped with bygone value step is manually linked to an Open case
	Given User logged in to Dynamics application with <userRole>
	When User <userRole> creates new case <CaseName> <PrimaryDemand> <Demand> <SubDemand> <Customer> <PolicyReference> <CaseDueDate> <Product>
	And User moves value steps to Manage Referral
	When User clicks on activities tab
	And User clicks on task
	And User selects existing case under regarding search bar <CaseName>
	Then User validates all the fields under details section
	And User enter demand task details "Contents Changes"
	And User validates Merlin task id field is disabled & read only
	And User enters task details primary demand "I want to change" task type "General Administration"
	And User validates merlinTaskType "General Administration" and valueStep "Understand My Request/Assess Information Provided"
	And User enters  task description "Creating task for testing" and instruction field "Testing purpose"
	Then User clicks on save button
	And User validates the task status reason
	When User navigates to cases <CaseName> and validates newly created task under Highlights panel <Demand>
	Then User also validates the case value step moved to "Manage Referral"
Examples:
	| userRole | CaseName    | PrimaryDemand      | Demand         | SubDemand    | Customer      | Product | PolicyReference        | CaseDueDate  | numberOfDays |
	| 'Admin'  | 'TestCase2' | 'I want to change' | 'Motor change' | 'Add Driver' | 'sarah marta' | 'Motor' | 'PL-HOM10003493441/00' | '10/11/2024' | 5            |
	

@work-125
Scenario Outline: Work-125: Validate value steps stage for a Parent Case moves forward automatically when  two child task with different value step stages(one in future step and one in Past step) is manually linked to an Open case
	Given User logged in to Dynamics application with <userRole>
	When User <userRole> creates new case <CaseName> <PrimaryDemand> <Demand> <SubDemand> <Customer> <PolicyReference> <CaseDueDate> <Product>
	When User clicks on activities tab
	And User clicks on task
	And User selects existing case under regarding search bar <CaseName>
	Then User validates all the fields under details section
	And User enter demand task details "Motor change"
	And User validates Merlin task id field is disabled & read only
	And User enters task details primary demand "I want to change" task type "chaser"
	And User validates merlinTaskType "Motor Referral" and valueStep "Manage Referral"
	And User enters  task description "Creating task for testing" and instruction field "Testing purpose"
	Then User clicks on save button
	And User validates the task status reason
	When User navigates to cases <CaseName> and validates newly created task under Highlights panel <Demand>
	Then User also validates the case value step moved to "Manage Referral"
	When User clicks on activities tab
	And User clicks on task
	And User selects existing case under regarding search bar <CaseName>
	Then User validates all the fields under details section
	And User enter demand task details "Motor change"
	And User validates Merlin task id field is disabled & read only
	And User enters task details primary demand "I want to change" task type "General Endorsement"
	And User validates merlinTaskType "General Endorsement" and valueStep "Understand My Request/Assess Information Provided"
	And User enters  task description "Creating task for testing" and instruction field "Testing purpose"
	Then User clicks on save button
	When User navigates to cases <CaseName> and validates newly created task under Highlights panel <Demand>
	Then User also validates the case value step remains at "Manage Referral"
Examples:
	| userRole | CaseName    | PrimaryDemand      | Demand         | SubDemand    | Customer      | Product | PolicyReference        | CaseDueDate  | numberOfDays |
	| 'Admin'  | 'TestCase2' | 'I want to change' | 'Motor change' | 'Add Driver' | 'sarah marta' | 'Motor' | 'PL-HOM10003493441/00' | '10/11/2024' | 5            |
	

	
@work-126 @teamlead @caseworker @admin
Scenario Outline: Work-126: Value-steps stage - Resolve - At starting stage
	Given User logged in to Dynamics application with <userRole>
	When User <userRole> creates new case <CaseName> <PrimaryDemand> <Demand> <SubDemand> <Customer> <PolicyReference> <CaseDueDate> <Product>
	Then User clicks on save button
	And user validate the status of the case as 'Active'
	When user select the "Resolve Case" option from the case actions
	Then user validates the resolve case popup is 'Enabled'
	And user click on 'Cancel' button in Resolve Case popup
	Then user validates the resolve case popup is 'Disabled'
	When user select the "Resolve Case" option from the case actions
	And user selects the option <ResolutionType> and <Resolution> in resolved popup
	Then user click on 'Resolve' button in Resolve Case popup
	And user validate the status of the case as 'Resolved'
Examples:
	| userRole    | CaseName       | PrimaryDemand        | Demand             | SubDemand              | Customer      | Product          | PolicyReference        | CaseDueDate  | ResolutionType                                | Resolution                     |
	| 'Team Lead' | 'TestCase126A' | 'I want information' | 'Documents'        | 'Send Certificate'     | 'sarah marta' | 'Motor'          | 'PL-HOM10003493441/00' | '10/10/2024' | 'Request complete - first contact resolution' | 'Resolve Information request'  |
	| 'Team Lead' | 'TestCase126B' | 'I want to change'   | 'Motor change'     | 'Add Driver'           | 'sarah marta' | 'Property'       | 'PL-HOM10003493441/00' | '10/10/2024' | 'Request complete - multi contact resolution' | 'Resolve Motor change request' |
	| 'Team Lead' | 'TestCase126C' | 'I want to cancel'   | 'Cancellation'     | 'Cancellation Request' | 'sarah marta' | 'Building works' | 'PL-HOM10003493441/00' | '10/10/2024' | 'Request complete - error correction'         | 'Resolve cancel request'       |
	| 'Team Lead' | 'TestCase126D' | 'I want to renew'    | 'Renewal'          | 'Review Renewal'       | 'sarah marta' | 'Motor'          | 'PL-HOM10003493441/00' | '10/10/2024' | 'Request complete - not taken up'             | 'Resolve renewal request'      |
	| 'Team Lead' | 'TestCase126E' | 'Error Management'   | 'Cancel & Replace' | 'NA'                   | 'sarah marta' | 'Property'       | 'PL-HOM10003493441/00' | '10/10/2024' | 'Request complete - decline cover'            | 'Resolve error manage request' |
	| 'Team Lead' | 'TestCase126F' | 'I want information' | 'Documents'        | 'Send Certificate'     | 'sarah marta' | 'Property'       | 'PL-HOM10003493441/00' | '10/10/2024' | 'Request incomplete - Unable to contact'      | 'Resolve incomplete request'   |
	| 'Team Lead' | 'TestCase126G' | 'I want to cancel'   | 'Cancellation'     | 'Cancellation Request' | 'sarah marta' | 'Motor'          | 'PL-HOM10003493441/00' | '10/10/2024' | 'Duplicate closed '                           | 'Resolve duplicate request'    |

	
@Work-28 @admin
Scenario: Work-28: Validate case SLA
	Given User logged in to Dynamics application
	When User selects customer service hub from Dynamics Home page
	And User validates the mandatory fields error messages
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



	
@smoke1
Scenario: 1.Send an Email to UKSC mailbox & Validate the mail in D365 multi senders
	Given User sends an email to UKSC mailbox
		| sender          | to                   | subject                        | body                       | attachment |
		| 'Tonysmithtest' | 'Test_UKSC_Dynamics' | 'Agent pipelinetest test 2024' | 'Kindly change my address' | 'No'       |
	And User logged in to Dynamics application
	Then User clicks on Activities
	And User searches the email by subject 'Agent pipelinetest test 2024' and clicks on the email
	Then User validates the email content like subject 'Agent pipelinetest test 2024' body 'Kindly change my address'
	And User clicks on sign out



@work-145 @admin
Scenario Outline: Work-145: Send an Email to UKSC mailbox & Validate the mail in D365
	Given User sends email to UKSC mailbox with sender <sender> to <to> subject <subject> body <body> and attachment <attachment>
	And User logged in to Dynamics application with 'Admin'
	Then User clicks on Activities
	And User searches the email by subject <subject> and clicks on the email
	Then User validates the email content like subject <subject> body <body>
	And User clicks on sign out
Examples:
	| sender          | to                   | subject                          | body                                                   | attachment |
	| 'Tonysmithtest' | 'Test_UKSC_Dynamics' | 'PH-HOM123456789 Change address' | 'Kindly change my address'                             | 'No'       |
	| 'Tonysmithtest' | 'Test_UKSC_Dynamics' | 'PH-HOM123456789 Change address' | 'Kindly change my address, please find the attachment' | 'Yes'      |

	
@work-33 @admin
Scenario: Work-33: Send Email to dynamics with Attachment Ingestion
	Given User sends an email to UKSC mailbox
		| sender          | to                   | subject                           | body                        | attachment | FileName                   |
		| 'Tonysmithtest' | 'Test_UKSC_Dynamics' | 'Agent attachment for Doc'        | 'Attachment For Doc'        | 'Yes'      | Work-33-DocxFile.docx      |
		| 'Tonysmithtest' | 'Test_UKSC_Dynamics' | 'Agent attachment for Json'       | 'Attachment For Json'       | 'Yes'      | Work-33-JsonFile.json      |
		| 'Tonysmithtest' | 'Test_UKSC_Dynamics' | 'Agent attachment for PDF'        | 'Attachment For PDF'        | 'Yes'      | Work-33-PDFFile.pdf        |
		| 'Tonysmithtest' | 'Test_UKSC_Dynamics' | 'Agent attachment for Screenshot' | 'Attachment For Screenshot' | 'Yes'      | Work-33-ScreenshotFile.MHT |
		| 'Tonysmithtest' | 'Test_UKSC_Dynamics' | 'Agent attachment for Text File'  | 'Attachment For Text File'  | 'Yes'      | Work-33-TextFile.txt       |
		| 'Tonysmithtest' | 'Test_UKSC_Dynamics' | 'Agent attachment for Video'      | 'Attachment For Video'      | 'Yes'      | Work-33-VideoFile.mp4      |
		| 'Tonysmithtest' | 'Test_UKSC_Dynamics' | 'Agent attachment for XLS'        | 'Attachment For XLS File'   | 'Yes'      | Work-33-XLSFile.xls        |
		| 'Tonysmithtest' | 'Test_UKSC_Dynamics' | 'Agent attachment for XLSX'       | 'Attachment For XLSX File'  | 'Yes'      | Work-33-XLSXFile.xlsx      |
		| 'Tonysmithtest' | 'Test_UKSC_Dynamics' | 'Agent attachment for XML'        | 'Attachment For XML File'   | 'Yes'      | Work-33-XMLFile.xml        |
	And User logged in to Dynamics application
	When User selects customer service hub from Dynamics Home page
	Then User clicks on Activities
	And User clicks on Emails
	And User search and validates the email content with the below
		| sender          | to                   | subject                           | body                        | FileName                   |
		| 'Tonysmithtest' | 'Test_UKSC_Dynamics' | 'Agent attachment for Doc'        | 'Attachment For Doc'        | Work-33-DocxFile.docx      |
		| 'Tonysmithtest' | 'Test_UKSC_Dynamics' | 'Agent attachment for Json'       | 'Attachment For Json'       | Work-33-JsonFile.json      |
		| 'Tonysmithtest' | 'Test_UKSC_Dynamics' | 'Agent attachment for PDF'        | 'Attachment For PDF'        | Work-33-PDFFile.pdf        |
		| 'Tonysmithtest' | 'Test_UKSC_Dynamics' | 'Agent attachment for Screenshot' | 'Attachment For Screenshot' | Work-33-ScreenshotFile.MHT |
		| 'Tonysmithtest' | 'Test_UKSC_Dynamics' | 'Agent attachment for Text File'  | 'Attachment For Text File'  | Work-33-TextFile.txt       |
		| 'Tonysmithtest' | 'Test_UKSC_Dynamics' | 'Agent attachment for Video'      | 'Attachment For Video'      | Work-33-VideoFile.mp4      |
		| 'Tonysmithtest' | 'Test_UKSC_Dynamics' | 'Agent attachment for XLS'        | 'Attachment For XLS File'   | Work-33-XLSFile.xls        |
		| 'Tonysmithtest' | 'Test_UKSC_Dynamics' | 'Agent attachment for XLSX'       | 'Attachment For XLSX File'  | Work-33-XLSXFile.xlsx      |
		| 'Tonysmithtest' | 'Test_UKSC_Dynamics' | 'Agent attachment for XML'        | 'Attachment For XML File'   | Work-33-XMLFile.xml        |
			
@Work-208 @admin
Scenario: Work-208: Validate the characters in UI Fields while creating Task type  with Admin role
	Given User logged in to Dynamics application
	When User selects customer admin hub from Dynamics Home page
	Then User clicks task type
	And User clicks on New
	And User validates Task type & merlin task type fields having 200 characters as per data catalogue
		| PrimaryDemand      | TaskType                                                                                                                                                                                                   | MerlinType                                                                                                                                                                                                      | AvailableForManualSelection | ValueStep        |
		| 'I want to change' | 'Task Type Contains Two Hundreds Letters Task Type Contains Two Hundreds Letters Task Type Contains Two Hundreds Letters Task Type Contains Two Hundreds Letters Task Type Contains Two Hundreds Letters ' | 'Merlin Type Contains Two Hundred Letters Merlin Type Contains Two Hundred Letters Merlin Type Contains Two Hundred Letters Merlin Type Contains Two Hundred Letters Merlin Type Contains Two Hundred Letters ' | 'No'                        | 'Perform Change' |

@Work-208 @admin
Scenario: Work-208: Validate all the UI Fields while creating Task type  with Admin role
	Given User logged in to Dynamics application
	When User selects customer admin hub from Dynamics Home page
	Then User clicks task type
	And User clicks on New
	And User validates all fields & save the task type
		| PrimaryDemand      | TaskType         | MerlinType         | AvailableForManualSelection | ValueStep        |
		| 'I want to change' | 'Task Type Demo' | 'Merlin Type Demo' | 'No'                        | 'Perform Change' |
		
@work-277 @admin
Scenario Outline: Work-277: Manual Selection for Task field type change
	Given User logged in to Dynamics application
	When User selects customer admin hub from Dynamics Home page
	And User selects task type from Sitemap menu
	Then User clicks on new button and validates all fields
	And User validates error messages
	Then User fills all the details in the page primary demand <PrimaryDemand> task type <TaskType> merlin task type <MerlinTaskType> manual selection <AvailableForManualSelection> value step <ValueStep>
	And User finishes task type creation & validate all fields in view mode
	And User deletes the task type <TaskType>

Examples:
	| PrimaryDemand        | TaskType    | MerlinTaskType    | AvailableForManualSelection | ValueStep         |
	| 'I want information' | 'TaskType1' | 'MerlinTaskType1' | 'Yes'                       | 'Manage Referral' |
	| 'I want to cancel'   | 'TaskType1' | 'MerlinTaskType1' | 'No'                        | 'Manage Referral' |

@Work-50 @admin @caseworker @teamlead
Scenario Outline: Work-50: Validate Duplicate case can be Resolved with resolution type as Duplicate closed
	Given User logged in to Dynamics application with 'Admin'
	When User 'Admin' creates new case 'TestCase6' 'I want information' 'Documents' 'Send Certificate' 'sarah marta' 'PL-HOM10003493441/00' '10/10/2024' 'Property'
	Then User clicks on save button
	And User checks newly created case "TestCase6"
	Then User resolve the case with Resolution Type <ResolutionType> Resolution <Resolution>
	And User validates resolved case "TestCase6" is read only
	And User validate the case status as resolved
	And User validates the demand type <demandType>
	And User validates fields are non editable

Examples:
	| ResolutionType      | Resolution      | demandType |
	| "Duplicate closed " | "Case Resolved" | "Failure"  |

@work-56 @teamleader @caseworker
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
	| 'Teamlead'   | 'TLwork56D' | 'I want to renew'    | 'Renewal'          | 'Review Renewal'       | 'Gary Adams'  | 'Motor'          | 'PL-HOM10003493441/00' | '10/10/2024' |
	| 'Teamlead'   | 'TLwork56E' | 'Error Management'   | 'Cancel & Replace' | 'NA'                   | 'Sarah Jones' | 'Property'       | 'PL-HOM10003493441/00' | '10/10/2024' |