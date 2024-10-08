Feature: WORK Sprint-8 feature



@Work-505 @Work-163 @admin @teamlead
Scenario Outline: Work-163 Work-505: Validate admin can add new Underwriter Authority
	Given User logged in to Dynamics application
	When User selects customer admin hub from Dynamics Home page
	And User Clicks On Underwriter Authority
	Then User clicks on new button
	And User validates all the fields visible 'Agent' 'Property only' 'Motor only single vehicle' and 'Motor total accumulation'
	Then User validates error messages on UA screen
	And User creates New UA <Agent> <Property> <Vehicle> <Accumulation>
	And User clicks on save and close button
	And User validate UA is saved and created successfully with <Agent> <Property> <Vehicle> <Accumulation>
	And User deletes the UA <Agent>
	
Examples:
	| Agent                   | Property     | Vehicle      | Accumulation |
	| 'Amitsharma Jaiprakash' | '2500000.00' | '3500000.00' | '4500000.00' |

@Work-505 @Work-163 @admin @teamlead
Scenario Outline: Work-163 Work-505: Validate admin can update existing Underwriter Authority
	Given User logged in to Dynamics application
	When User selects customer admin hub from Dynamics Home page
	And User Clicks On Underwriter Authority
	Then User clicks on new button
	And User validates all the fields visible 'Agent' 'Property only' 'Motor only single vehicle' and 'Motor total accumulation'
	And User creates New UA <Agent> <Property> <Vehicle> <Accumulation>
	And User clicks on save and close button
	And User selects the newly created UA with <Agent> and updated the <NewProperty> <NewVehicle> <NewAccumulation>
	Then User validates if UA is updated successfully with <Agent> <NewProperty> <NewVehicle> <NewAccumulation>
	And User deletes the UA <Agent>
	
Examples:
	| Agent                   | Property     | Vehicle      | Accumulation | NewProperty  | NewVehicle   | NewAccumulation |
	| 'Amitsharma Jaiprakash' | '2500000.00' | '3500000.00' | '4500000.00' | '2600000.00' | '3600000.00' | '4600000.00'    |

@Work-505 @Work-163 @admin @teamlead
Scenario Outline: Work-163 Work-505: Validate admin can update existing Underwriter Authority with Agent
	Given User logged in to Dynamics application
	When User selects customer admin hub from Dynamics Home page
	And User Clicks On Underwriter Authority
	Then User clicks on new button
	And User validates all the fields visible 'Agent' 'Property only' 'Motor only single vehicle' and 'Motor total accumulation'
	And User creates New UA <Agent> <Property> <Vehicle> <Accumulation>
	And User clicks on save and close button
	And User selects the newly created UA with <Agent> and updated the <NewAgent> <NewProperty> <NewVehicle> <NewAccumulation>
	Then User validates if UA is updated successfully with <NewAgent> <NewProperty> <NewVehicle> <NewAccumulation>
	And User deletes the UA <NewAgent>
	
Examples:
	| Agent                   | Property     | Vehicle      | Accumulation | NewAgent           | NewProperty  | NewVehicle   | NewAccumulation |
	| 'Amitsharma Jaiprakash' | '2500000.00' | '3500000.00' | '4500000.00' | 'Aravind Dakarapu' | '2600000.00' | '3600000.00' | '4600000.00'    |

@Work-505 @Work-163 @admin @teamlead @paralleltest
Scenario Outline: Work-163 Work-505: Validate admin can delete existing Underwriter Authority
	Given User logged in to Dynamics application
	When User selects customer admin hub from Dynamics Home page
	And User Clicks On Underwriter Authority
	Then User clicks on new button
	And User validates all the fields visible 'Agent' 'Property only' 'Motor only single vehicle' and 'Motor total accumulation'
	And User creates New UA <Agent> <Property> <Vehicle> <Accumulation>
	And User clicks on save and close button
	And User deletes the UA <Agent>
	
Examples:
	| Agent                   | Property     | Vehicle      | Accumulation |
	| 'Amitsharma Jaiprakash' | '2500000.00' | '3500000.00' | '4500000.00' |


	
@Work-140 @smoke
Scenario Outline: Work-140
	Given User logged in to Dynamics application with <userRole>
	When User <userRole> creates new case <CaseName> <PrimaryDemand> <Demand> <SubDemand> <Customer> <PolicyReference> <CaseDueDate> <Product>
	Then User clicks on save button
	When User clicks on activities tab
	And User clicks on task
	And User creates task with regarding <CaseName> demand task "task demand" and validates case due date <numberOfDays> and primary demand <PrimaryDemand>
	Then User cancels the case with tasks <CaseName>
Examples:
	| userRole     | CaseName       | PrimaryDemand        | Demand             | SubDemand              | Customer      | Product    | PolicyReference        | CaseDueDate  | numberOfDays |
	| 'Caseworker' | 'TaskDueDate1' | 'I want information' | 'Documents'        | 'Send Certificate'     | 'sarah marta' | 'Property' | 'PL-HOM10003493441/00' | '10/10/2024' | 5            |
	| 'Caseworker' | 'TaskDueDate2' | 'I want to change'   | 'Motor change'     | 'Add Driver'           | 'sarah marta' | 'Property' | 'PL-HOM10003493441/00' | '10/10/2024' | 5            |
	| 'Caseworker' | 'TaskDueDate3' | 'I want to cancel'   | 'Cancellation'     | 'Cancellation Request' | 'sarah marta' | 'Property' | 'PL-HOM10003493441/00' | '10/10/2024' | 5            |
	| 'Caseworker' | 'TaskDueDate4' | 'I want to renew'    | 'Renewal'          | 'Renewal'              | 'sarah marta' | 'Property' | 'PL-HOM10003493441/00' | '10/10/2024' | 30           |
	| 'Caseworker' | 'TaskDueDate5' | 'Error Management'   | 'Cancel & Replace' | 'NA'                   | 'sarah marta' | 'Property' | 'PL-HOM10003493441/00' | '10/10/2024' | 1            |


	
@work-502 @admin
Scenario Outline: Work-502: Pick exclusion Criteria
	Given User sends email to UKSC mailbox with subject <subject> body <body> and attachment if any <attachment>
	And User logged in to Dynamics application
	When User selects customer service hub from Dynamics Home page
	Then User clicks on Activities
	And User searches the email by subject <subject> and clicks on the email
	Then User validates the email content like subject <subject> body <body>
	Then User validates if regarding field is updated with case name <CaseName> and click on the case link
	And User validates case name <CaseName> primary demand <PrimaryDemand> demand <Demand> policy reference <PolicyReference> case due date <CaseDueDate> reinfer label <ReInferLabel> and RPA flag <RPAFlag>
	And User checks case status is set to new
	Then User clicks on queue
	And user selects all items and clicks test_uksc
	And User searches the email by subject <subject> and validate present in TEST_UKSC queue
	And User clicks on Dashboards
	And Validates case is not present after clicking on pick work button <subject>
	
	
Examples:
	| subject                                                                                 | body                                                                                                                                                                                                                                   | attachment | CaseName                                                                                | PrimaryDemand        | Demand         | PolicyReference        | CaseDueDate | ReInferLabel                        | RPAFlag |
	| '(EXT) FW: Hiscox Insurance - policy number PL-HOM05006213708/06'                       | 'Hi, Please note the above has renewed from 31sy July.'                                                                                                                                                                                | 'No'       | '(EXT) FW: Hiscox Insurance - policy number PL-HOM05006213708/06'                       | 'I want information' | 'Documents'    | 'PL-HOM10003493441/00' | 5           | 'Documentation'                     | 'No'    |
	| 'FW: (EXT) RE: Hiscox Insurance for Mr Guinevere Forbes PL-HOM05006213708/06'           | 'Hi, Please cancel this off from inception.'                                                                                                                                                                                           | 'No'       | 'FW: (EXT) RE: Hiscox Insurance for Mr Guinevere Forbes PL-HOM05006213708/06'           | 'I want to cancel'   | 'Cancellation' | 'PL-HOM10003493441/00' | 5           | 'Cancellation - Lapse'              | 'Yes'   |
	| '(EXT) RE: Hiscox Insurance for Mr Guinevere Forbes- quote number PL-HOM05006213708/06' | 'Hi Louise, The above client has decided to go elsewhere for their insurance. Can you please lapse?'                                                                                                                                   | 'No'       | '(EXT) RE: Hiscox Insurance for Mr Guinevere Forbes- quote number PL-HOM05006213708/06' | 'I want to cancel'   | 'Cancellation' | 'PL-HOM10003493441/00' | 5           | 'Cancellation - Broker lost client' | 'Yes'   |
	| '(EXT) Please cancel-PL-HOM05006213708/06'                                              | 'Good afternoon, With effect 31.05.2024, please can you cancel this policy, I believe client is moving in with a relative and insurance no longer required by him. Please advise refund and forward cancellation docs when available.' | 'No'       | '(EXT) Please cancel-PL-HOM05006213708/06'                                              | 'I want to cancel'   | 'Cancellation' | 'PL-HOM10003493441/00' | 5           | 'Cancellation - No longer required' | 'Yes'   |


	
@work-520 @admin
Scenario Outline: Work-520: Send an Email to UKSC mailbox & Validate the mail in D365
	Given User sends email to UKSC mailbox with subject <subject> body <body> and attachment if any <attachment>
	And User logged in to Dynamics application
	When User selects customer service hub from Dynamics Home page
	Then User clicks on Activities
	And User searches the email by subject <subject> and clicks on the email
	Then User validates the email content like subject <subject> body <body>
	Then User validates if regarding field is updated with case name <CaseName> and click on the case link
	And User validates case name <CaseName> primary demand <PrimaryDemand> demand <Demand> policy reference <PolicyReference> case due date <CaseDueDate> reinfer label <ReInferLabel> and RPA flag <RPAFlag>
	
	
Examples:
	| subject                                                                                     | body                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           | attachment | CaseName                                                                                    | PrimaryDemand        | Demand             | PolicyReference        | CaseDueDate | ReInferLabel                        | RPAFlag |
	| 'RE: Cancel & Replace request - Hiscox Insurance - policy number PL-HOM05006213708/06'      | 'Hi Tim, Option 2 please!! New policy inception date starting 02/04/2020. Thank you very much!'                                                                                                                                                                                                                                                                                                                                                                                                                | 'No'       | 'RE: Cancel & Replace request - Hiscox Insurance - policy number PL-HOM05006213708/06'      | 'Error Management'   | 'Cancel & Replace' | 'PL-HOM10003493441/00' | 1           | 'Cancel and replace'                | 'No'    |
	| '(EXT) Mr Guinevere Forbes Renewal - PL-HOM05006213708/06'                                  | 'Morning all, I have been informed Mildmay is under offer and will likely be sold by the end of the month. Can you please inform me what difference this will make to the renewal terms/premium if Mildmay is not included?'                                                                                                                                                                                                                                                                                   | 'No'       | '(EXT) Mr Guinevere Forbes Renewal - PL-HOM05006213708/06'                                  | 'I want information' | 'Cover Query'      | 'PL-HOM10003493441/00' | 5           | 'Underwriting policy queries'       | 'No'    |
	| '(EXT) RE: Mr Guinevere Forbes - PL-HOM05006213708/06'                                      | 'Apologies, Lionel. Client has also confirmed that the tracker subscription has been renewed for a further 3 years'                                                                                                                                                                                                                                                                                                                                                                                            | 'No'       | '(EXT) RE: Mr Guinevere Forbes - PL-HOM05006213708/06'                                      | 'I want to change'   | 'Motor change'     | 'PL-HOM10003493441/00' | 5           | 'Changes to motor cover'            | 'No'    |
	| '(EXT) RE: Quote Required Mr Guinevere Forbes PL-HOM05006213708/06'                         | 'Good ,Morning, Property has a cellar, not habitable though, used for storage. Let me know if you need anything further.'                                                                                                                                                                                                                                                                                                                                                                                      | 'No'       | '(EXT) RE: Quote Required Mr Guinevere Forbes PL-HOM05006213708/06'                         | 'I want to change'   | 'Property Changes' | 'PL-HOM10003493441/00' | 5           | 'Property Changes'                  | 'No'    |
	| '(EXT) RE: Hiscox Insurance - policy number PL-HOM05006213708/06'                           | 'Hi Terry, Please could you give me a call when you get this message. The client is not at all happy with the business exclusion clause that has been put onto the policy and we don’t have enough time prior to renewal date to get this sorted. The exclusion was added onto the renewal on Thursday at 2pm renewal date is tomorrow. The client has been with Hiscox for many years and his circumstances hasn’t changed from the exchange student’s perspective. I look forward to hearing from you ASAP.' | 'No'       | '(EXT) RE: Hiscox Insurance - policy number PL-HOM05006213708/06'                           | 'I want to renew'    | 'Renewal'          | 'PL-HOM10003493441/00' | 30          | 'Underwriting Revised renewals'     | 'No'    |
	| '(EXT) FW: Hiscox Insurance - policy number PL-HOM05006213708/06'                           | 'Hi, Please note the above has renewed from 31sy July.'                                                                                                                                                                                                                                                                                                                                                                                                                                                        | 'No'       | '(EXT) FW: Hiscox Insurance - policy number PL-HOM05006213708/06'                           | 'I want information' | 'Documents'        | 'PL-HOM10003493441/00' | 5           | 'Documentation'                     | 'No'    |
	| '(EXT) RE: Hiscox Insurance for Mr Guinevere Forbes – policy number PL-HOM05006213708/06'   | 'Hi Norbert, Please could you provide a copy of the clients No claims bonus, the client requires this for her new insurer'                                                                                                                                                                                                                                                                                                                                                                                     | 'No'       | '(EXT) RE: Hiscox Insurance for Mr Guinevere Forbes – policy number PL-HOM05006213708/06'   | 'I want information' | 'Cover Query'      | 'PL-HOM10003493441/00' | 5           | 'Underwriting policy queries'       | 'No'    |
	| '(EXT) RE:  Hiscox Insurance for Mr Guinevere Forbes – policy number  PL-HOM05006213708/06' | 'Hey guys, The client has sent us this: Chris, when should the direct debits to Hiscox for the Edwardes Square insurance stop? There was a direct debit of £1,192 paid on 1st July. Is that correct? I believe you have taken a DD when this policy cancelled. Can you please confirm if this is correct and that the payment will be refunded ASAP.'                                                                                                                                                          | 'No'       | '(EXT) RE:  Hiscox Insurance for Mr Guinevere Forbes – policy number  PL-HOM05006213708/06' | 'I want to change'   | 'Payments'         | 'PL-HOM10003493441/00' | 5           | 'Payments query'                    | 'No'    |
	| 'Address change - Mr Guinevere Forbes PL-HOM05006213708/06'                                 | 'Hi, Good morning! Could you please update my address? Existing address: Test Building 38 Innes Street Woodford Green NW1 6HU New address: Test Building 38 Innes Street Woodford Green NW2 6HU. Thanks'                                                                                                                                                                                                                                                                                                       | 'No'       | 'Address change - Maisie Villarreal PL-HOM05006213708/06'                                   | 'I want to change'   | 'Contact change'   | 'PL-HOM10003493441/00' | 5           | 'Change of address'                 | 'No'    |
	| 'FW: (EXT) RE: Hiscox Insurance for Mr Guinevere Forbes PL-HOM05006213708/06'               | 'Hi, Please cancel this off from inception.'                                                                                                                                                                                                                                                                                                                                                                                                                                                                   | 'No'       | 'FW: (EXT) RE: Hiscox Insurance for Mr Guinevere Forbes PL-HOM05006213708/06'               | 'I want to cancel'   | 'Cancellation'     | 'PL-HOM10003493441/00' | 5           | 'Cancellation - Lapse'              | 'Yes'   |
	| '(EXT) RE: Hiscox Insurance for Mr Guinevere Forbes- quote number PL-HOM05006213708/06'     | 'Hi Louise, The above client has decided to go elsewhere for their insurance. Can you please lapse?'                                                                                                                                                                                                                                                                                                                                                                                                           | 'No'       | '(EXT) RE: Hiscox Insurance for Mr Guinevere Forbes- quote number PL-HOM05006213708/06'     | 'I want to cancel'   | 'Cancellation'     | 'PL-HOM10003493441/00' | 5           | 'Cancellation - Broker lost client' | 'Yes'   |
	| 'RE: (EXT) RE: Hiscox Insurance - policy number PL-HOM05006213708/06'                       | 'Jack, I don’t know as cover lapsed from first renewal/works. Not received any payment. Would be great to NTU this case.'                                                                                                                                                                                                                                                                                                                                                                                      | 'No'       | 'RE: (EXT) RE: Hiscox Insurance - policy number PL-HOM05006213708/06'                       | 'I want to cancel'   | 'Cancellation'     | 'PL-HOM10003493441/00' | 5           | 'Cancellation - Lapse'              | 'Yes'   |
	| '(EXT) Please cancel-PL-HOM05006213708/06'                                                  | 'Good afternoon, With effect 31.05.2024, please can you cancel this policy, I believe client is moving in with a relative and insurance no longer required by him. Please advise refund and forward cancellation docs when available.'                                                                                                                                                                                                                                                                         | 'No'       | '(EXT) Please cancel-PL-HOM05006213708/06'                                                  | 'I want to cancel'   | 'Cancellation'     | 'PL-HOM10003493441/00' | 5           | 'Cancellation - No longer required' | 'Yes'   |


@work-520 @admin
Scenario Outline: Work-520: Validate case SLA
	Given User logged in to Dynamics application
	When User selects customer service hub from Dynamics Home page
	And User <userRole> creates new case <CaseName> <PrimaryDemand> <Demand> <SubDemand> <Customer> <PolicyReference> <CaseDueDate> <Product>
	Then User saves the case <CaseName> with <PrimaryDemand>
	Then User validate the status of the case
	And User validates the case due date <numberOfDays> for primary demand <PrimaryDemand>
	#And user cancel the case <CaseName>
	

Examples:
	| userRole | CaseName    | PrimaryDemand        | Demand      | SubDemand          | Customer      | Product | PolicyReference        | CaseDueDate  | numberOfDays |
	| 'Admin'  | 'TestCase1' | 'I want information' | 'Documents' | 'Send Certificate' | 'sarah marta' | 'Motor' | 'PL-HOM10003493441/00' | '10/10/2024' | 5            |
	
	
@work-143 @admin
Scenario: Work-143: Validate case SLA
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

@work-127 @admin
Scenario Outline: work-127 User validates fields required in Quick Create
	Given User logged in to Dynamics application
	When User selects customer service hub from Dynamics Home page
	Then User creates new case and validates case status, case due date, case number and sitemap
		| userRole | CaseName       | PrimaryDemand        | Demand      | SubDemand          | Customer      | Product | PolicyReference        | CaseDueDate  | numberOfDays |
		| 'Admin'  | 'TestCase127A' | 'I want information' | 'Documents' | 'Send Certificate' | 'sarah marta' | 'Motor' | 'PL-HOM10003493441/00' | '10/10/2024' | 5            |
	
	Then User clicks on Case Relationships tab and clicks on new case button to add a quick case
	And User validates the fields displayed for quick case 'Parent Case' 'Case Name' 'Owner' 'Customer' 'Policy Reference Number' 'Policy Reference' 'Primary Demand' 'Demand' 'Sub-demand' 'Product'
	Then User validates the pre populated Parent Case <CaseName> Case Name as Demand <Demand> Owner <Customer> Customer <Customer> Policy Reference Number <PolicyReference> and Product <Product>

Examples:
	| userRole | CaseName       | PrimaryDemand        | Demand      | SubDemand          | Customer      | Product    | Owner                   | PolicyReference        | CaseDueDate  | numberOfDays |
	| 'Admin'  | 'TestCase127A1' | 'I want information' | 'Documents' | 'Send Certificate' | 'sarah marta' | 'Property' | 'Amitsharma Jaiprakash' | 'PL-HOM10003493441/00' | '10/10/2024' | 5            |

@work-127 @admin
Scenario Outline: work-127 User creates the Quick Create and validate child case due date also validate if it is linked in case timeline
	Given User logged in to Dynamics application with <userRole>
	When User <userRole> creates new case <CaseName> <PrimaryDemand> <Demand> <SubDemand> <Customer> <PolicyReference> <CaseDueDate> <Product>
	Then User clicks on save button
	Then User selects newly created case <CaseName>
	Then User enters the mandatory fields primary demand <ChildPrimaryDemand> demand <ChildDemand> sub demand <ChildSubDemand> and validates SLA start date of child case <numberOfDays> also child case is shown in timeline.
		| ChildPrimaryDemand | ChildDemand    | ChildSubDemand | numberOfDays |
		| 'I want to change' | 'Motor change' | 'Add Driver'   | 5            |
		#| 'I want information' | 'Documents'        | 'Send Certificate'     | 5            |
		#| 'I want to cancel'   | 'Cancellation'     | 'Cancellation Request' | 5            |
		#| 'Error Management'   | 'Cancel & Replace' | 'NA'                   | 1            |
Examples:
	| userRole | CaseName       | PrimaryDemand     | Demand    | SubDemand        | Customer      | Product    | Owner                   | PolicyReference        | CaseDueDate  | numberOfDays |
	| 'Admin'  | 'TestCase127B1' | 'I want to renew' | 'Renewal' | 'Review Renewal' | 'sarah marta' | 'Property' | 'Amitsharma Jaiprakash' | 'PL-HOM10003493441/00' | '10/10/2024' | 5            |

@work-127 @admin
Scenario: work-127 User creates the Quick Create and validate child case due date is calcuated from email receive date also validate if it is linked in case timeline
	Given User sends email to UKSC mailbox
		| subject                | body                                                                                               | attachment |
		| 'PL-HOM10003101233/01' | 'Hi Sarah The above client has decided to go elsewhere for their insurance. Can you please lapse?' | 'No'       |
		#| '(EXT) Mr Guinevere Forbes Renewal - PL-HOM05006213708/06'                    | 'Morning all, I’ve been informed Mildmay is under offer and will likely be sold by the end of the month. Can you please inform me what difference this will make to the renewal terms/premium if Mildmay is not included?'                                                                                                                                                                                                                                                                                     | 'No'       |
		#| '(EXT) RE: Hiscox Insurance - policy number PL-HOM05006213708/06'             | 'Hi Terry, Please could you give me a call when you get this message. The client is not at all happy with the business exclusion clause that has been put onto the policy and we don’t have enough time prior to renewal date to get this sorted. The exclusion was added onto the renewal on Thursday at 2pm renewal date is tomorrow. The client has been with Hiscox for many years and his circumstances hasn’t changed from the exchange student’s perspective. I look forward to hearing from you ASAP.' | 'No'       |
		#| 'FW: (EXT) RE: Hiscox Insurance for Mr Guinevere Forbes PL-HOM05006213708/06' | 'Hi, Please cancel this off from inception.'                                                                                                                                                                                                                                                                                                                                                                                                                                                                   | 'No'       |
	And User logged in to Dynamics application
	When User selects customer service hub from Dynamics Home page
	And User creates child case and validates SLA
		| ChildPrimaryDemand | ChildDemand    | ChildSubDemand         | numberOfDays |
		| 'I want to cancel' | 'Cancellation' | 'Cancellation Request' | 5            |
		#| 'I want to change'   | 'Motor change'     | 'Add Driver'           | 5            |
		#| 'I want information' | 'Documents'        | 'Send Certificate'     | 5            |
		#| 'Error Management'   | 'Cancel & Replace' | 'NA'                   | 1            |

@work-127 @admin
Scenario Outline: work-127 User creates the Quick Create and SLA Start Date for the child case will be as applied for “I want to renew”
	Given User logged in to Dynamics application with 'Admin'
	When User <userRole> creates new case <CaseName> <PrimaryDemand> <Demand> <SubDemand> <Customer> <PolicyReference> <CaseDueDate> <Product>
	Then User clicks on save button
	Then User selects newly created case <CaseName>
	Then User enters the mandatory fields primary demand <ChildPrimaryDemand> demand <ChildDemand> sub demand <ChildSubDemand> and validates SLA start date of child case <numberOfDays> also child case is shown in timeline.
		| ChildPrimaryDemand | ChildDemand | ChildSubDemand   | numberOfDays |
		| 'I want to renew'  | 'Renewal'   | 'Review Renewal' | 30           |
Examples:
	| userRole | CaseName       | PrimaryDemand        | Demand      | SubDemand          | Customer      | Product    | Owner                   | PolicyReference        | CaseDueDate  | numberOfDays |
	| 'Admin'  | 'TestCase127C1' | 'I want information' | 'Documents' | 'Send Certificate' | 'sarah marta' | 'Property' | 'Amitsharma Jaiprakash' | 'PL-HOM10003493441/00' | '10/10/2024' | 5            |



	
@work-176 @regression @smoke @caseWorker @smoke3
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


	
@Work-44 @Admin
Scenario Outline: Work-44: SLA Stoppage Entity - Manual Pending Case with Dependency
	Given User logged in to Dynamics application with <userRole>
	When User <userRole> creates new case <CaseName> <PrimaryDemand> <Demand> <SubDemand> <Customer> <PolicyReference> <CaseDueDate> <Product>
	Then User clicks on save button
	When User clicks on SLA Stoppages tab
	And User click the New button from SLA Home page
	Then User validate the fields are displayed 'Case' 'Pended Time' and 'Unpended Time'
	When User create new SLA for the caseName <CaseName>, pended time as 'today' and unpended time as 'tomorrow'
	And User click on the Save button in new SLA stoppage page
	Then User validate the status as 'On Hold' for the case <CaseName>
	When User clicks on SLA Stoppages tab
	And User select the SLA Stoppage for the case <CaseName>
	And User clicks the 'Deactivate' button on the SLA home page
	And User select the 'Deactivate' button on the confim popup
	Then User validate the status as 'In Progress' for the case <CaseName>
	And user cancel the case <CaseName>

Examples:
	| userRole | CaseName     | PrimaryDemand        | Demand             | SubDemand              | Customer      | Product          | PolicyReference        | CaseDueDate  |
	| 'Admin'  | 'TestSLA44A' | 'I want information' | 'Documents'        | 'Send Certificate'     | 'sarah marta' | 'Motor'          | 'PL-HOM10003493441/00' | '10/10/2024' |
	| 'Admin'  | 'TestSLA44B' | 'I want to change'   | 'Motor change'     | 'Add Driver'           | 'sarah marta' | 'Property'       | 'PL-HOM10003493441/00' | '10/10/2024' |
	| 'Admin'  | 'TestSLA44C' | 'I want to cancel'   | 'Cancellation'     | 'Cancellation Request' | 'sarah marta' | 'Building works' | 'PL-HOM10003493441/00' | '10/10/2024' |
	| 'Admin'  | 'TestSLA44D' | 'I want to renew'    | 'Renewal'          | 'Review Renewal'       | 'sarah marta' | 'Motor'          | 'PL-HOM10003493441/00' | '10/10/2024' |
	| 'Admin'  | 'TestSLA44E' | 'Error Management'   | 'Cancel & Replace' | 'NA'                   | 'sarah marta' | 'Property'       | 'PL-HOM10003493441/00' | '10/10/2024' |
	| 'Admin'  | 'TestSLA44F' | 'I want information' | 'Documents'        | 'Send Certificate'     | 'sarah marta' | 'Property'       | 'PL-HOM10003493441/00' | '10/10/2024' |
	| 'Admin'  | 'TestSLA44G' | 'I want to cancel'   | 'Cancellation'     | 'Cancellation Request' | 'sarah marta' | 'Motor'          | 'PL-HOM10003493441/00' | '10/10/2024' |



@Work523, @regression @Caseworker @smoke3
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

 