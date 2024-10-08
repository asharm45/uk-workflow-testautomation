Feature: WORK Sprint-6 feature



@work-119
Scenario: Work-119: Create policy and link it to the case
	Given User logged in to Dynamics application with 'Admin'
	When User selects customer service hub from Dynamics Home page
	And User creates policy link it with case <CaseName> <PrimaryDemand> <Demand> <SubDemand> <Customer>  <Product> <PolicyReference> <CaseDueDate> sum insures <SumInsured> motor sum insured <MotorSumInsured> motor total sum insured <MotorTotalSumInsured> channel <Channel> policy start date <PolicyStartDate> policy end date <PolicyEndDate> policy inception date <PolicyInceptionDate> policy renweal date <PolicyRenewalDate> risk address <RiskAddress> excesses <Excesses> pas flag <PASFlag>
		| CaseName               | PrimaryDemand        | Demand                             | SubDemand                       | Customer      | Product    | PolicyReference        | CaseDueDate  | SumInsured | MotorSumInsured | MotorTotalSumInsured | Channel  | PolicyStartDate | PolicyEndDate | PolicyInceptionDate | PolicyRenewalDate | RiskAddress                       | Excesses | PASFlag  |
		| 'Testproperty1'        | 'I want to change'   | 'Property Change'                  | 'Change Flood Cover'            | 'sarah marta' | 'Property' | 'PL-HOM10003489119/00' | '10/10/2024' | '700000'   | ''              | ''                   | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' |
		| 'Testproperty2'        | 'I want to change'   | 'Property Change'                  | 'Change Public Liability'       | 'sarah marta' | 'Property' | 'PL-HOM10003489120/00' | '10/10/2024' | '1100000'  | ''              | ''                   | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' |
		| 'Testproperty3'        | 'I want to change'   | 'Property Change'                  | 'Change Excess'                 | 'sarah marta' | 'Property' | 'PL-HOM10003489121/00' | '10/10/2024' | '1500000'  | ''              | ''                   | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' |
		| 'Testproperty4'        | 'I want to change'   | 'Property Change'                  | 'Change Jewellery & Watches'    | 'sarah marta' | 'Property' | 'PL-HOM10003489122/00' | '10/10/2024' | '500000'   | ''              | ''                   | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' |
		| 'Testproperty5'        | 'I want to change'   | 'Property Change'                  | 'Change Safe'                   | 'sarah marta' | 'Property' | 'PL-HOM10003489123/00' | '10/10/2024' | '2100000'  | ''              | ''                   | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' |
		| 'Testproperty6'        | 'I want to change'   | 'Property Change'                  | 'Change Clause'                 | 'sarah marta' | 'Property' | 'PL-HOM10003489124/00' | '10/10/2024' | '2500000'  | ''              | ''                   | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' |
		| 'Testproperty7'        | 'I want to change'   | 'Change of broker account handler' | 'Change BAH'                    | 'sarah marta' | 'Property' | 'PL-HOM10003489125/00' | '10/10/2024' | '4200000'  | ''              | ''                   | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' |
		| 'Testproperty8'        | 'I want to change'   | 'Bereavement Notification'         | 'Bereavement Notification'      | 'sarah marta' | 'Property' | 'PL-HOM10003489126/00' | '10/10/2024' | '8700000'  | ''              | ''                   | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' |
		| 'Testproperty9'        | 'I want to change'   | 'Property Change'                  | 'Change Risk Address'           | 'sarah marta' | 'Property' | 'PL-HOM10003489127/00' | '10/10/2024' | '10000000' | ''              | ''                   | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' |
		| 'Testproperty10'       | 'I want to change'   | 'Property Change'                  | 'Change Risk Address'           | 'sarah marta' | 'Property' | 'PL-HOM10003489128/00' | '10/10/2024' | '11200000' | ''              | ''                   | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' |
		| 'Testmotoronly11'      | 'I want to change'   | 'Motor change'                     | 'Motor Change'                  | 'sarah marta' | 'Motor'    | 'PL-HOM10003489129/00' | '10/10/2024' | ''         | '70000'         | '70000'              | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' |
		| 'Testmotoronly12'      | 'I want to change'   | 'Motor change'                     | 'Add Driver'                    | 'sarah marta' | 'Motor'    | 'PL-HOM10003489130/00' | '10/10/2024' | ''         | '110000'        | '110000'             | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' |
		| 'Testmotoronly13'      | 'I want to change'   | 'Motor change'                     | 'Add Vehicle'                   | 'sarah marta' | 'Motor'    | 'PL-HOM10003489131/00' | '10/10/2024' | ''         | '150000'        | '150000'             | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' |
		| 'Testmotoronly14'      | 'I want to change'   | 'Motor change'                     | 'Add Driver'                    | 'sarah marta' | 'Motor'    | 'PL-HOM10003489132/00' | '10/10/2024' | ''         | '160000'        | ''                   | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' |
		| 'Testmotor totalacc15' | 'I want to change'   | 'Motor change'                     | 'Change Registration'           | 'sarah marta' | 'Motor'    | 'PL-HOM10003489133/00' | '10/10/2024' | ''         | '150000'        | '600000'             | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' |
		| 'Testmotor totalacc16' | 'I want to change'   | 'Motor change'                     | 'Change Sums Insured'           | 'sarah marta' | 'Motor'    | 'PL-HOM10003489134/00' | '10/10/2024' | ''         | '140000'        | '1900000'            | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' |
		| 'Testmotor totalacc17' | 'I want to change'   | 'Motor change'                     | 'Remove Driver'                 | 'sarah marta' | 'Motor'    | 'PL-HOM10003489135/00' | '10/10/2024' | ''         | '140000'        | '2500000'            | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' |
		| 'Testmotor totalacc18' | 'I want to change'   | 'Motor change'                     | 'Change Sums Insured'           | 'sarah marta' | 'Motor'    | 'PL-HOM10003489136/00' | '10/10/2024' | ''         | '140000'        | '2510000'            | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' |
		| 'Testotherowner19'     | 'I want to change'   | 'Motor change'                     | 'Change Sums Insured'           | 'sarah marta' | 'Motor'    | 'PL-HOM10003489137/00' | '10/10/2024' | ''         | '150000'        | '150000'             | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' |
		| 'Testcombin20'         | 'I want to change'   | 'Motor change'                     | 'Change Sums Insured'           | 'sarah marta' | 'Motor'    | 'PL-HOM10003489138/00' | '10/10/2024' | '10000000' | '170000'        | '2510000'            | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' |
		| 'Testcombin21'         | 'I want to change'   | 'Motor change'                     | 'Change Sums Insured'           | 'sarah marta' | 'Motor'    | 'PL-HOM10003489139/00' | '10/10/2024' | '10000000' | '150000'        | '2710000'            | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' |
		| 'Testcombin22'         | 'I want to change'   | 'Motor change'                     | 'Change Sums Insured'           | 'sarah marta' | 'Motor'    | 'PL-HOM10003489140/00' | '10/10/2024' | '13000000' | '210000'        | '2500000'            | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' |
		| 'Testcombin23'         | 'I want to change'   | 'Motor change'                     | 'Change Sums Insured'           | 'sarah marta' | 'Motor'    | 'PL-HOM10003489141/00' | '10/10/2024' | '13000000' | '150000'        | '2800000'            | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' |
		| 'Testcombin24'         | 'I want to change'   | 'Motor change'                     | 'Change Sums Insured'           | 'sarah marta' | 'Motor'    | 'PL-HOM10003489142/00' | '10/10/2024' | '10000000' | '150000'        | '2410000'            | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' |
		| 'SCN3property1'        | 'I want to cancel'   | 'Cancellation'                     | 'Cancellation'                  | 'sarah marta' | 'Property' | 'PL-HOM10003489143/00' | '10/10/2024' | '1301000'  | ''              | ''                   | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' |
		| 'SCN3property2'        | 'I want to cancel'   | 'Cancellation'                     | 'Cancellation Query'            | 'sarah marta' | 'Property' | 'PL-HOM10003489144/00' | '10/10/2024' | '1700000'  | ''              | ''                   | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' |
		| 'SCN3property3'        | 'I want to cancel'   | 'Cancellation'                     | 'Cancellation Request'          | 'sarah marta' | 'Property' | 'PL-HOM10003489145/00' | '10/10/2024' | '2300000'  | ''              | ''                   | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' |
		| 'SCN3property4'        | 'I want information' | 'Cover Query'                      | 'Cover Query'                   | 'sarah marta' | 'Property' | 'PL-HOM10003489146/00' | '10/10/2024' | '3000000'  | ''              | ''                   | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' |
		| 'SCN3property5'        | 'I want information' | 'Documents'                        | 'Documents'                     | 'sarah marta' | 'Property' | 'PL-HOM10003489147/00' | '10/10/2024' | '10000000' | ''              | ''                   | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' |
		| 'SCN3property6'        | 'I want information' | 'Documents'                        | 'Send Certificates'             | 'sarah marta' | 'Property' | 'PL-HOM10003489148/00' | '10/10/2024' | '25000000' | ''              | ''                   | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' |
		| 'SCN3property7'        | 'I want information' | 'Documents'                        | 'Send Wording'                  | 'sarah marta' | 'Property' | 'PL-HOM10003489149/00' | '10/10/2024' | '50000000' | ''              | ''                   | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' |
		| 'SCN3property8'        | 'I want information' | 'Documents'                        | 'Send Policy Documents'         | 'sarah marta' | 'Property' | 'PL-HOM10003489150/00' | '10/10/2024' | '75000000' | ''              | ''                   | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' |
		| 'SCN3property9'        | 'I want information' | 'Documents'                        | 'Send Wording'                  | 'sarah marta' | 'Property' | 'PL-HOM10003489151/00' | '10/10/2024' | '78000000' | ''              | ''                   | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' |
		| 'SCN3Motor10'          | 'I want to change'   | 'Bereavement Notification'         | 'Bereavement Notification'      | 'sarah marta' | 'Motor'    | 'PL-HOM10003489153/00' | '10/10/2024' | ''         | '80000'         | '80000'              | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' |
		| 'SCN3Motor11'          | 'I want to change'   | 'Contact change'                   | 'Change Correspondence Address' | 'sarah marta' | 'Motor'    | 'PL-HOM10003489154/00' | '10/10/2024' | ''         | '140000'        | '140000'             | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' |
		| 'SCN3Motor12'          | 'I want to change'   | 'Cyber change'                     | 'Remove Cyber'                  | 'sarah marta' | 'Motor'    | 'PL-HOM10003489155/00' | '10/10/2024' | ''         | '200000'        | '200000'             | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' |
		| 'SCN3Motor13'          | 'I want to change'   | 'Executor of estate'               | 'Amend Title'                   | 'sarah marta' | 'Motor'    | 'PL-HOM10003489156/00' | '10/10/2024' | ''         | '260000'        | '260000'             | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' |
		| 'SCN3Motor14'          | 'I want to change'   | 'Instruction to Bind'              | 'Instruction to Bind'           | 'sarah marta' | 'Motor'    | 'PL-HOM10003489157/00' | '10/10/2024' | ''         | '150000'        | '310000'             | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' |
		| 'SCN3Motor15'          | 'I want to change'   | 'Motor change'                     | 'Motor Change'                  | 'sarah marta' | 'Motor'    | 'PL-HOM10003489158/00' | '10/10/2024' | ''         | '110000'        | '350000'             | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' |
		| 'SCN3Motortot16'       | 'I want to change'   | 'Motor change'                     | 'Remove Vehicle'                | 'sarah marta' | 'Motor'    | 'PL-HOM10003489159/00' | '10/10/2024' | ''         | '90000'         | '1100000'            | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' |
		| 'SCN3Motortot17'       | 'I want to change'   | 'Payments'                         | 'Payments Query'                | 'sarah marta' | 'Motor'    | 'PL-HOM10003489160/00' | '10/10/2024' | ''         | '80000'         | '1700000'            | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' |
		| 'SCN3Motortot18'       | 'I want to change'   | 'Premium'                          | 'Providing Target Premium'      | 'sarah marta' | 'Motor'    | 'PL-HOM10003489161/00' | '10/10/2024' | ''         | '160000'        | '2200000'            | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' |
		| 'SCN3Motortot19'       | 'I want to change'   | 'Premium'                          | 'Quote Return Premium'          | 'sarah marta' | 'Motor'    | 'PL-HOM10003489162/00' | '10/10/2024' | ''         | '180000'        | '2500000'            | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' |
		| 'SCN3Motortot20'       | 'I want to change'   | 'Premium'                          | 'Reduce'                        | 'sarah marta' | 'Motor'    | 'PL-HOM10003489163/00' | '10/10/2024' | ''         | ''              | '4600000'            | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' |
		| 'SCN3Motor21'          | 'I want to change'   | 'Executor of estate'               | 'Amend Title'                   | 'sarah marta' | 'Motor'    | 'PL-HOM10003489164/00' | '10/10/2024' | ''         | '350000'        | '5000000'            | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' |
		| 'SCN3Motor16'          | 'I want to change'   | 'Motor change'                     | 'Change Registration'           | 'sarah marta' | 'Motor'    | 'PL-HOM10003489165/00' | '10/10/2024' | ''         | ''              | '6666000'            | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' |
		| 'SCN3Motor17'          | 'I want to change'   | 'Motor change'                     | 'Add Driver'                    | 'sarah marta' | 'Motor'    | 'PL-HOM10003489166/00' | '10/10/2024' | ''         | ''              | '12500000'           | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' |
		| 'SCN3Motor18'          | 'I want to change'   | 'Motor change'                     | 'Remove Driver'                 | 'sarah marta' | 'Motor'    | 'PL-HOM10003489167/00' | '10/10/2024' | ''         | ''              | '20000000'           | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' |
		| 'Testcombin25'         | 'I want to renew'    | 'Renewal'                          | 'Review Renewal'                | 'sarah marta' | 'Motor'    | 'PL-HOM10003489168/00' | '10/11/2024' | '10000000' | '370000'        | '2510000'            | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' |
		| 'Testcombin26'         | 'I want information' | 'Documents'                        | 'Send Certificate'              | 'sarah marta' | 'Motor'    | 'PL-HOM10003489160/00' | '10/11/2024' | '10000000' | '150000'        | '2710000'            | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' |
		| 'Testcombin27'         | 'I want to renew'    | 'Renewal'                          | 'Review Renewal'                | 'sarah marta' | 'Property' | 'PL-HOM10003489170/00' | '10/11/2024' | '13000000' | '360000'        | '2600000'            | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' |
		| 'Testcombin28'         | 'I want information' | 'Documents'                        | 'Send Certificate'              | 'sarah marta' | 'Property' | 'PL-HOM10003489171/00' | '10/11/2024' | '10000000' | '150000'        | '2500000'            | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' |
		| 'Testcombin29'         | 'I want to renew'    | 'Renewal'                          | 'Review Renewal'                | 'sarah marta' | 'Motor'    | 'PL-HOM10003489172/00' | '10/11/2024' | '75000000' | '150000'        | '2500000'            | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' |
		| 'Testcombin30'         | 'I want information' | 'Documents'                        | 'Send Certificate'              | 'sarah marta' | 'Motor'    | 'PL-HOM10003489173/00' | '10/11/2024' | '75000000' | '190000'        | '2200000'            | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' |
		| 'Testcombin31'         | 'I want to renew'    | 'Renewal'                          | 'Review Renewal'                | 'sarah marta' | 'Property' | 'PL-HOM10003489174/00' | '10/11/2024' | '10000000' | '22000000'      | '2100000'            | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' |
		| 'Testdata1'            | 'I want to change'   | 'Property Change'                  | 'Change Contents'               | 'sarah marta' | 'Property' | 'PL-HOM10003489175/00' | '10/10/2024' | '500000'   | ''              | ''                   | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' |
		| 'Testdata2'            | 'I want to change'   | 'Property Change'                  | 'Change Risk Address'           | 'sarah marta' | 'Property' | 'PL-HOM10003489176/00' | '10/11/2024' | '1700000'  | ''              | ''                   | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' |
		| 'Testdata3'            | 'I want to change'   | 'Property Change'                  | 'Change Alarm'                  | 'sarah marta' | 'Property' | 'PL-HOM10003489177/00' | '10/11/2024' | '2500000'  | ''              | ''                   | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' |
		| 'Testdata4'            | 'I want to change'   | 'Property Change'                  | 'Change Jewellery & Watches'    | 'sarah marta' | 'Property' | 'PL-HOM10003489178/00' | '10/11/2024' | '2500100'  | ''              | ''                   | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' |
		| 'Testdata5'            | 'I want to renew'    | 'Renewal'                          | 'Review Renewal'                | 'sarah marta' | 'Motor'    | 'PL-HOM10003489179/00' | '10/11/2024' | ''         | '1500000'       | '1500000'            | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' |
		| 'Testdata6'            | 'I want information' | 'Documents'                        | 'Send Certificate'              | 'sarah marta' | 'Motor'    | 'PL-HOM10003489180/00' | '10/11/2024' | ''         | '1500000'       | '2500000'            | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' |
		| 'Testdata7'            | 'I want to renew'    | 'Renewal'                          | 'Review Renewal'                | 'sarah marta' | 'Property' | 'PL-HOM10003489181/00' | '10/11/2024' | '1200000'  | ''              | ''                   | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' |
		| 'Testdata8'            | 'I want information' | 'Documents'                        | 'Send Certificate'              | 'sarah marta' | 'Property' | 'PL-HOM10003489182/00' | '10/11/2024' | '900000'   | '1500000'       | '2500000'            | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' |



@work-118
Scenario: Work-118: Create policy and link it to the case and task
	Given User logged in to Dynamics application with 'Admin'
	When User selects customer service hub from Dynamics Home page
	And User creates policy link it with case and task <CaseName> <PrimaryDemand> <Demand> <SubDemand> <Customer>  <Product> <PolicyReference> <CaseDueDate> sum insures <SumInsured> motor sum insured <MotorSumInsured> motor total sum insured <MotorTotalSumInsured> channel <Channel> policy start date <PolicyStartDate> policy end date <PolicyEndDate> policy inception date <PolicyInceptionDate> policy renweal date <PolicyRenewalDate> risk address <RiskAddress> excesses <Excesses> pas flag <PASFlag> and demand task <DemandTask> primary demand of task <TaskPrimaryDemand>
		| CaseName          | PrimaryDemand        | Demand                             | SubDemand                       | Customer      | Product    | PolicyReference        | CaseDueDate  | SumInsured | MotorSumInsured | MotorTotalSumInsured | Channel  | PolicyStartDate | PolicyEndDate | PolicyInceptionDate | PolicyRenewalDate | RiskAddress                       | Excesses | PASFlag  | DemandTask    | TaskPrimaryDemand    |
		| 'Casedata1'       | 'I want to change'   | 'Property Change'                  | 'Change Contents'               | 'sarah marta' | 'Property' | 'PL-HOM10003489175/00' | '10/10/2024' | '500000'   | ''              | ''                   | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' | 'Taskdata1'   | 'I want to change'   |
		| 'Casedata2'       | 'I want to change'   | 'Property Change'                  | 'Change Risk Address'           | 'sarah marta' | 'Property' | 'PL-HOM10003489176/00' | '10/11/2024' | '1700000'  | ''              | ''                   | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' | 'Taskdata2'   | 'I want to change'   |
		| 'Casedata3'       | 'I want to change'   | 'Property Change'                  | 'Change Alarm'                  | 'sarah marta' | 'Property' | 'PL-HOM10003489177/00' | '10/11/2024' | '2500000'  | ''              | ''                   | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' | 'Taskdata3'   | 'I want to change'   |
		| 'Casedata4'       | 'I want to change'   | 'Property Change'                  | 'Change Jewellery & Watches'    | 'sarah marta' | 'Property' | 'PL-HOM10003489178/00' | '10/11/2024' | '2500100'  | ''              | ''                   | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' | 'Taskdata4'   | 'I want to change'   |
		| 'Casedata5'       | 'I want to renew'    | 'Renewal'                          | 'Review Renewal'                | 'sarah marta' | 'Motor'    | 'PL-HOM10003489179/00' | '10/11/2024' | ''         | '1500000'       | '1500000'            | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' | 'Taskdata5'   | 'I want to cancel'   |
		| 'Casedata6'       | 'I want information' | 'Documents'                        | 'Send Certificate'              | 'sarah marta' | 'Motor'    | 'PL-HOM10003489180/00' | '10/11/2024' | ''         | '1500000'       | '2500000'            | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' | 'Taskdata6'   | 'I want information' |
		| 'Casedata7'       | 'I want to renew'    | 'Renewal'                          | 'Review Renewal'                | 'sarah marta' | 'Property' | 'PL-HOM10003489181/00' | '10/11/2024' | '1200000'  | ''              | ''                   | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' | 'Taskdata7'   | 'I want to change'   |
		| 'Casedata8'       | 'I want information' | 'Documents'                        | 'Send Certificate'              | 'sarah marta' | 'Property' | 'PL-HOM10003489182/00' | '10/11/2024' | '900000'   | '1500000'       | '2500000'            | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' | 'Taskdata8'   | 'I want to cancel'   |
		| 'Casetwop1'       | 'I want to change'   | 'Property Change'                  | 'Change Flood Cover'            | 'sarah marta' | 'Property' | 'PL-HOM10003489119/00' | '10/10/2024' | '700000'   | ''              | ''                   | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' | 'Tasktwo1'    | 'I want to change'   |
		| 'Casetwop2'       | 'I want to change'   | 'Property Change'                  | 'Change Public Liability'       | 'sarah marta' | 'Property' | 'PL-HOM10003489120/00' | '10/10/2024' | '1100000'  | ''              | ''                   | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' | 'Tasktwo2'    | 'I want to change'   |
		| 'Casetwop3'       | 'I want to change'   | 'Property Change'                  | 'Change Excess'                 | 'sarah marta' | 'Property' | 'PL-HOM10003489121/00' | '10/10/2024' | '1500000'  | ''              | ''                   | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' | 'Tasktwo3'    | 'I want to change'   |
		| 'Casetwop4'       | 'I want to change'   | 'Property Change'                  | 'Change Jewellery & Watches'    | 'sarah marta' | 'Property' | 'PL-HOM10003489122/00' | '10/10/2024' | '500000'   | ''              | ''                   | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' | 'Tasktwo4'    | 'I want to change'   |
		| 'Casetwop5'       | 'I want to change'   | 'Property Change'                  | 'Change Safe'                   | 'sarah marta' | 'Property' | 'PL-HOM10003489123/00' | '10/10/2024' | '2100000'  | ''              | ''                   | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' | 'Tasktwo5'    | 'I want to change'   |
		| 'Casetwop6'       | 'I want to change'   | 'Property Change'                  | 'Change Clause'                 | 'sarah marta' | 'Property' | 'PL-HOM10003489124/00' | '10/10/2024' | '2500000'  | ''              | ''                   | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' | 'Tasktwo6'    | 'I want to change'   |
		| 'Casetwop7'       | 'I want to change'   | 'Change of broker account handler' | 'Change BAH'                    | 'sarah marta' | 'Property' | 'PL-HOM10003489125/00' | '10/10/2024' | '4200000'  | ''              | ''                   | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' | 'Tasktwo7'    | 'I want to change'   |
		| 'Casetwop8'       | 'I want to change'   | 'Bereavement Notification'         | 'Bereavement Notification'      | 'sarah marta' | 'Property' | 'PL-HOM10003489126/00' | '10/10/2024' | '8700000'  | ''              | ''                   | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' | 'Tasktwo8'    | 'I want to change'   |
		| 'Casetwop9'       | 'I want to change'   | 'Property Change'                  | 'Change Risk Address'           | 'sarah marta' | 'Property' | 'PL-HOM10003489127/00' | '10/10/2024' | '10000000' | ''              | ''                   | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' | 'Tasktwo9'    | 'I want to change'   |
		| 'Casetwop10'      | 'I want to change'   | 'Property Change'                  | 'Change Risk Address'           | 'sarah marta' | 'Property' | 'PL-HOM10003489128/00' | '10/10/2024' | '11200000' | ''              | ''                   | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' | 'Tasktwo10'   | 'I want to change'   |
		| 'Casetwomo11'     | 'I want to change'   | 'Motor change'                     | 'Motor Change'                  | 'sarah marta' | 'Motor'    | 'PL-HOM10003489129/00' | '10/10/2024' | ''         | '70000'         | '70000'              | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' | 'Tasktwo11'   | 'I want to change'   |
		| 'Casetwomo12'     | 'I want to change'   | 'Motor change'                     | 'Add Driver'                    | 'sarah marta' | 'Motor'    | 'PL-HOM10003489130/00' | '10/10/2024' | ''         | '110000'        | '110000'             | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' | 'Tasktwo12'   | 'I want to change'   |
		| 'Casetwomo13'     | 'I want to change'   | 'Motor change'                     | 'Add Vehicle'                   | 'sarah marta' | 'Motor'    | 'PL-HOM10003489131/00' | '10/10/2024' | ''         | '150000'        | '150000'             | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' | 'Tasktwo13'   | 'I want to change'   |
		| 'Casetwomo14'     | 'I want to change'   | 'Motor change'                     | 'Add Driver'                    | 'sarah marta' | 'Motor'    | 'PL-HOM10003489132/00' | '10/10/2024' | ''         | '160000'        | ''                   | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' | 'Tasktwo14'   | 'I want to change'   |
		| 'Casetwomta15'    | 'I want to change'   | 'Motor change'                     | 'Change Registration'           | 'sarah marta' | 'Motor'    | 'PL-HOM10003489133/00' | '10/10/2024' | ''         | '150000'        | '600000'             | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' | 'Tasktwo15'   | 'I want to change'   |
		| 'Casetwomta16'    | 'I want to change'   | 'Motor change'                     | 'Change Sums Insured'           | 'sarah marta' | 'Motor'    | 'PL-HOM10003489134/00' | '10/10/2024' | ''         | '140000'        | '1900000'            | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' | 'Tasktwo16'   | 'I want to change'   |
		| 'Casetwomta17'    | 'I want to change'   | 'Motor change'                     | 'Remove Driver'                 | 'sarah marta' | 'Motor'    | 'PL-HOM10003489135/00' | '10/10/2024' | ''         | '140000'        | '2500000'            | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' | 'Tasktwo17'   | 'I want to change'   |
		| 'Casetwomta18'    | 'I want to change'   | 'Motor change'                     | 'Change Sums Insured'           | 'sarah marta' | 'Motor'    | 'PL-HOM10003489136/00' | '10/10/2024' | ''         | '140000'        | '2510000'            | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' | 'Tasktwo18'   | 'I want to change'   |
		| 'Casetwomta19'    | 'I want to change'   | 'Motor change'                     | 'Change Sums Insured'           | 'sarah marta' | 'Motor'    | 'PL-HOM10003489137/00' | '10/10/2024' | ''         | '150000'        | '150000'             | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' | 'Tasktwo19'   | 'I want to change'   |
		| 'Casetwocombin20' | 'I want to change'   | 'Motor change'                     | 'Change Sums Insured'           | 'sarah marta' | 'Motor'    | 'PL-HOM10003489138/00' | '10/10/2024' | '10000000' | '170000'        | '2510000'            | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' | 'Tasktwo20'   | 'I want to change'   |
		| 'Casetwocombin21' | 'I want to change'   | 'Motor change'                     | 'Change Sums Insured'           | 'sarah marta' | 'Motor'    | 'PL-HOM10003489139/00' | '10/10/2024' | '10000000' | '150000'        | '2710000'            | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' | 'Tasktwo21'   | 'I want to change'   |
		| 'Casetwocombin22' | 'I want to change'   | 'Motor change'                     | 'Change Sums Insured'           | 'sarah marta' | 'Motor'    | 'PL-HOM10003489140/00' | '10/10/2024' | '13000000' | '210000'        | '2500000'            | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' | 'Tasktwo22'   | 'I want to change'   |
		| 'Casetwocombin23' | 'I want to change'   | 'Motor change'                     | 'Change Sums Insured'           | 'sarah marta' | 'Motor'    | 'PL-HOM10003489141/00' | '10/10/2024' | '13000000' | '150000'        | '2800000'            | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' | 'Tasktwo23'   | 'I want to change'   |
		| 'Casetwocombin24' | 'I want to change'   | 'Motor change'                     | 'Change Sums Insured'           | 'sarah marta' | 'Motor'    | 'PL-HOM10003489142/00' | '10/10/2024' | '10000000' | '150000'        | '2410000'            | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' | 'Tasktwo24'   | 'I want to change'   |
		| 'Case3property1'  | 'I want to cancel'   | 'Cancellation'                     | 'Cancellation'                  | 'sarah marta' | 'Property' | 'PL-HOM10003489143/00' | '10/10/2024' | '1301000'  | ''              | ''                   | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' | 'TaskThree1'  |                      |
		| 'Case3property2'  | 'I want to cancel'   | 'Cancellation'                     | 'Cancellation Query'            | 'sarah marta' | 'Property' | 'PL-HOM10003489144/00' | '10/10/2024' | '1700000'  | ''              | ''                   | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' | 'TaskThree2'  |                      |
		| 'Case3property3'  | 'I want to cancel'   | 'Cancellation'                     | 'Cancellation Request'          | 'sarah marta' | 'Property' | 'PL-HOM10003489145/00' | '10/10/2024' | '2300000'  | ''              | ''                   | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' | 'TaskThree3'  |                      |
		| 'Case3property4'  | 'I want information' | 'Cover Query'                      | 'Cover Query'                   | 'sarah marta' | 'Property' | 'PL-HOM10003489146/00' | '10/10/2024' | '3000000'  | ''              | ''                   | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' | 'TaskThree4'  |                      |
		| 'Case3property5'  | 'I want information' | 'Documents'                        | 'Documents'                     | 'sarah marta' | 'Property' | 'PL-HOM10003489147/00' | '10/10/2024' | '10000000' | ''              | ''                   | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' | 'TaskThree5'  |                      |
		| 'Case3property6'  | 'I want information' | 'Documents'                        | 'Send Certificates'             | 'sarah marta' | 'Property' | 'PL-HOM10003489148/00' | '10/10/2024' | '25000000' | ''              | ''                   | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' | 'TaskThree6'  |                      |
		| 'Case3property7'  | 'I want information' | 'Documents'                        | 'Send Wording'                  | 'sarah marta' | 'Property' | 'PL-HOM10003489149/00' | '10/10/2024' | '50000000' | ''              | ''                   | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' | 'TaskThree7'  |                      |
		| 'Case3property8'  | 'I want information' | 'Documents'                        | 'Send Policy Documents'         | 'sarah marta' | 'Property' | 'PL-HOM10003489150/00' | '10/10/2024' | '75000000' | ''              | ''                   | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' | 'TaskThree8'  |                      |
		| 'Case3property9'  | 'I want information' | 'Documents'                        | 'Send Wording'                  | 'sarah marta' | 'Property' | 'PL-HOM10003489151/00' | '10/10/2024' | '78000000' | ''              | ''                   | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' | 'TaskThree9'  |                      |
		| 'Case3Motor10'    | 'I want to change'   | 'Bereavement Notification'         | 'Bereavement Notification'      | 'sarah marta' | 'Motor'    | 'PL-HOM10003489153/00' | '10/10/2024' | ''         | '80000'         | '80000'              | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' | 'TaskThree10' |                      |
		| 'Case3Motor11'    | 'I want to change'   | 'Contact change'                   | 'Change Correspondence Address' | 'sarah marta' | 'Motor'    | 'PL-HOM10003489154/00' | '10/10/2024' | ''         | '140000'        | '140000'             | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' | 'TaskThree11' |                      |
		| 'Case3Motor12'    | 'I want to change'   | 'Cyber change'                     | 'Remove Cyber'                  | 'sarah marta' | 'Motor'    | 'PL-HOM10003489155/00' | '10/10/2024' | ''         | '200000'        | '200000'             | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' | 'TaskThree12' |                      |
		| 'Case3Motor13'    | 'I want to change'   | 'Executor of estate'               | 'Amend Title'                   | 'sarah marta' | 'Motor'    | 'PL-HOM10003489156/00' | '10/10/2024' | ''         | '260000'        | '260000'             | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' | 'TaskThree13' |                      |
		| 'Case3Motor14'    | 'I want to change'   | 'Instruction to Bind'              | 'Instruction to Bind'           | 'sarah marta' | 'Motor'    | 'PL-HOM10003489157/00' | '10/10/2024' | ''         | '150000'        | '310000'             | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' | 'TaskThree14' |                      |
		| 'Case3Motor15'    | 'I want to change'   | 'Motor change'                     | 'Motor Change'                  | 'sarah marta' | 'Motor'    | 'PL-HOM10003489158/00' | '10/10/2024' | ''         | '110000'        | '350000'             | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' | 'TaskThree15' |                      |
		| 'Case3Motortot16' | 'I want to change'   | 'Motor change'                     | 'Remove Vehicle'                | 'sarah marta' | 'Motor'    | 'PL-HOM10003489159/00' | '10/10/2024' | ''         | '90000'         | '1100000'            | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' | 'TaskThree16' |                      |
		| 'Case3Motortot17' | 'I want to change'   | 'Payments'                         | 'Payments Query'                | 'sarah marta' | 'Motor'    | 'PL-HOM10003489160/00' | '10/10/2024' | ''         | '80000'         | '1700000'            | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' | 'TaskThree17' |                      |
		| 'Case3Motortot18' | 'I want to change'   | 'Premium'                          | 'Providing Target Premium'      | 'sarah marta' | 'Motor'    | 'PL-HOM10003489161/00' | '10/10/2024' | ''         | '160000'        | '2200000'            | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' | 'TaskThree18' |                      |
		| 'Case3Motortot19' | 'I want to change'   | 'Premium'                          | 'Quote Return Premium'          | 'sarah marta' | 'Motor'    | 'PL-HOM10003489162/00' | '10/10/2024' | ''         | '180000'        | '2500000'            | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' | 'TaskThree19' |                      |
		| 'Case3Motortot20' | 'I want to change'   | 'Premium'                          | 'Reduce'                        | 'sarah marta' | 'Motor'    | 'PL-HOM10003489163/00' | '10/10/2024' | ''         | ''              | '4600000'            | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' | 'TaskThree20' |                      |
		| 'Case3Motor21'    | 'I want to change'   | 'Executor of estate'               | 'Amend Title'                   | 'sarah marta' | 'Motor'    | 'PL-HOM10003489164/00' | '10/10/2024' | ''         | '350000'        | '5000000'            | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' | 'TaskThree21' |                      |
		| 'Case3Motor22'    | 'I want to change'   | 'Motor change'                     | 'Change Registration'           | 'sarah marta' | 'Motor'    | 'PL-HOM10003489165/00' | '10/10/2024' | ''         | ''              | '6666000'            | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' | 'TaskThree22' |                      |
		| 'Case3Motor23'    | 'I want to change'   | 'Motor change'                     | 'Add Driver'                    | 'sarah marta' | 'Motor'    | 'PL-HOM10003489166/00' | '10/10/2024' | ''         | ''              | '12500000'           | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' | 'TaskThree23' |                      |
		| 'Case3Motor24'    | 'I want to change'   | 'Motor change'                     | 'Remove Driver'                 | 'sarah marta' | 'Motor'    | 'PL-HOM10003489167/00' | '10/10/2024' | ''         | ''              | '20000000'           | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' | 'TaskThree24' |                      |
		| 'Casecombin25'    | 'I want to renew'    | 'Renewal'                          | 'Review Renewal'                | 'sarah marta' | 'Motor'    | 'PL-HOM10003489168/00' | '10/11/2024' | '10000000' | '370000'        | '2510000'            | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' | 'TaskThree25' |                      |
		| 'Casecombin26'    | 'I want information' | 'Documents'                        | 'Send Certificate'              | 'sarah marta' | 'Motor'    | 'PL-HOM10003489160/00' | '10/11/2024' | '10000000' | '150000'        | '2710000'            | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' | 'TaskThree26' |                      |
		| 'Casecombin27'    | 'I want to renew'    | 'Renewal'                          | 'Review Renewal'                | 'sarah marta' | 'Property' | 'PL-HOM10003489170/00' | '10/11/2024' | '13000000' | '360000'        | '2600000'            | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' | 'TaskThree27' |                      |
		| 'Casecombin28'    | 'I want information' | 'Documents'                        | 'Send Certificate'              | 'sarah marta' | 'Property' | 'PL-HOM10003489171/00' | '10/11/2024' | '10000000' | '150000'        | '2500000'            | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' | 'TaskThree28' |                      |
		| 'Casecombin29'    | 'I want to renew'    | 'Renewal'                          | 'Review Renewal'                | 'sarah marta' | 'Motor'    | 'PL-HOM10003489172/00' | '10/11/2024' | '75000000' | '150000'        | '2500000'            | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' | 'TaskThree29' |                      |
		| 'Casecombin30'    | 'I want information' | 'Documents'                        | 'Send Certificate'              | 'sarah marta' | 'Motor'    | 'PL-HOM10003489173/00' | '10/11/2024' | '75000000' | '190000'        | '2200000'            | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' | 'TaskThree30' |                      |
		| 'Casecombin31'    | 'I want to renew'    | 'Renewal'                          | 'Review Renewal'                | 'sarah marta' | 'Property' | 'PL-HOM10003489174/00' | '10/11/2024' | '10000000' | '22000000'      | '2100000'            | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' | 'TaskThree31' |                      |
		



Scenario: Create policy, contact and link it to policy holder
	Given User logged in to Dynamics application with 'Admin'
	When User selects customer service hub from Dynamics Home page
	And User creates policy and contact and link it with policy holder with policy reference <PolicyReference> sum insures <SumInsured> motor sum insured <MotorSumInsured> motor total sum insured <MotorTotalSumInsured> channel <Channel> policy start date <PolicyStartDate> policy end date <PolicyEndDate> policy inception date <PolicyInceptionDate> policy renweal date <PolicyRenewalDate> risk address <RiskAddress> excesses <Excesses> pas flag <PASFlag>
		| PolicyReference        | SumInsured | MotorSumInsured | MotorTotalSumInsured | Channel  | PolicyStartDate | PolicyEndDate | PolicyInceptionDate | PolicyRenewalDate | RiskAddress                       | Excesses | PASFlag  |
		| 'PL-HOM10003489175/00' | '500000'   | ''              | ''                   | 'Direct' | '8/8/2024'      | '8/7/2025'    | ''                  | ''                | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | 'Merlin' |
	And User creates contact and contact with first name <FirstName> sur name <SurName>
		| FirstName | SurName |
		| 'John'    | 'Smith' |
	Then User creates policy holder with policy <PolicyReference> contact first name <FirstName> sur name <SurName> and policy holder <PolicyHolder> primary policy holder <PrimaryPolicyHolder>
		| PolicyReference        | FirstName | SurName | PolicyHolder | PrimaryPolicyHolder |
		| 'PL-HOM10003489175/00' | 'John'    | 'Smith' | 'Yes'        | 'Yes'               |


		
@work-343 @admin
Scenario: Work-343: Verify whether the user is able to view the created buckets
	Given User logged in to Dynamics application
	When User selects customer admin hub from Dynamics Home page
	Then User clicks on queue
	And User validates all the queues visible on the screen
		| QueueName                    |
		| 'Archive'                    |
		| 'BFT- Manual Triage'         |
		| 'Broker Facing Team'         |
		| 'CEC- Manual Triage'         |
		| 'Customer Experience Centre' |
		| 'Hiscox Private Client'      |
		| 'HPC- Manual Triage'         |
		| 'SD- Manual Triage'          |
		| 'Service Delivery'           |
		| 'TEB- Manual Triage'         |
		| 'test_uksc_dynamics'         |
		| 'Trading Existing Business'  |
		| 'UK Service Centre'          |
		| 'UKSC- Manual Triage'        |
		| 'Unknown'                    |

@work-343 @admin
Scenario: Work-343: Verify whether the user is able to able to view the manual triage area, cases and tasks for each bucket
	Given User logged in to Dynamics application
	When User selects customer service hub from Dynamics Home page
	When User <userRole> creates new case <CaseName> <PrimaryDemand> <Demand> <SubDemand> <Customer> <PolicyReference> <CaseDueDate> <Product>
	Then User clicks on save button
	And User puts case in UKSC- Manual Triage queue
	Then User validates queue details popup for case
	When User clicks on activities tab
	And User clicks on task
	And User creates task with regarding <CaseName> demand task "task demand" and validates case due date <numberOfDays> and primary demand <PrimaryDemand>
	And User puts task in UKSC- Manual Triage queue
	And User validates queue details popup for task
Examples:
	| userRole | CaseName       | PrimaryDemand        | Demand      | SubDemand          | Customer      | Product | PolicyReference        | CaseDueDate  | numberOfDays |
	| 'Admin'  | 'TaskDueDate1' | 'I want information' | 'Documents' | 'Send Certificate' | 'sarah marta' | 'Motor' | 'PL-HOM10003493441/00' | '10/10/2024' | 5            |
	

	
@work-117 @admin
Scenario Outline: Work-117: Saving the emails to Merlin
	Given User logged in to Dynamics application
	When User selects customer service hub from Dynamics Home page
	And User <userRole> creates new case <CaseName> <PrimaryDemand> <Demand> <SubDemand> <Customer> <PolicyReference> <CaseDueDate> <Product>
	Then User clicks on save button
	When User clicks create a timeline button and select the Email from the option
	Then User clicks on send button
	And User validate the timeline history for sending the email
	And User cancels the case with tasks <CaseName>

Examples:
	| userRole | CaseName                    | PrimaryDemand        | Demand      | SubDemand          | Customer      | Product | PolicyReference        | CaseDueDate  | Priority |
	| 'Admin'  | 'WF117SavingEmailsToMerlin' | 'I want information' | 'Documents' | 'Send Certificate' | 'sarah marta' | 'Motor' | 'PL-HOM10003493441/00' | '10/10/2024' | "High"   |
	

	
@Work-261
Scenario Outline: Work-261: Validate the motor total sum insured field can be enter manually by admin in policy entity
	Given User logged in to Dynamics application
	When User selects customer admin hub from Dynamics Home page
	Then User validates sitemap menu
	Given User Clicks on Policies from Service AreaGroup
	And User Clicks on +New button
	Then User Enters  <Policy Reference> <Channel> <Policy Start Date> <Policy End Date> <Annual Premium> <Covers Held> <Risk Address> <Excesses> <Motor sum insured>
	And Enter the total motor sum Insured Manually
	Then User clicks on save button

Examples:
	| Policy Reference       | Channel  | Policy Start Date | Policy End Date | Annual Premium | Covers Held | Risk Address                      | Excesses | Motor sum insured |
	| 'PL-HOM10003512777/00' | 'Direct' | '25/07/2024'      | '24/07/2025'    | '3,797.23'     | 'Motor'     | '2 Avenue Road ST. ALBANS AL13QQ' | '500'    | '12,000,000'      |



@work-342 @admin
Scenario: Work-342: Existing Case : Fields Removal from Workflow
	Given User logged in to Dynamics application with 'Admin'
	When User 'Admin' creates new case 'TestCase6' 'I want information' 'Documents' 'Send Certificate' 'sarah marta' 'PL-HOM10003493441/00' '10/10/2024' 'Building works'
	Then User clicks on save button
	Then User selects newly created case 'TestCase6'
	And User clicks on summary tab
	And User validates if fields Days OOS "Days OOS" Effective Date of Change "Effective Date of Change" Urgent flag "Urgent flag" are not displayed
	And User cancel the case "TestCase6"
	And User clicks on sign out

@work-342 @admin
Scenario: Work-342: Contact : Fields Removal from Workflow
	Given User logged in to Dynamics application with 'Admin'
	When User navigates to Customer Service hub
	And User clicks on contact and clicks on new
	Then User validates sub agent "Sub Agent" field is not displayed

@work-342 @admin
Scenario: Work-342: UW Authority : Fields Removal from Workflow
	Given User logged in to Dynamics application with 'Admin'
	When User navigates to Customer Service admin center
	Then User clicks on Underwriter Authorities
	And User validates Underwriter Authority "Underwriter Authority" field is not displayed
	And User clicks on sign out

@work-342 @admin
Scenario: Work-342: Existing Contact : Exisitng contact fields Removal from Workflow
	Given User logged in to Dynamics application with 'Admin'
	When User navigates to Customer Service hub
	And User clicks on contact
	Then User selects the existing contact with firstName 'Workflow' and lastName 'Contact'
	Then User validates sub agent "Sub Agent" field is not displayed

@work-342 @admin
Scenario: Work-342: UW Authority : Existing UW Authority fields Removal from Workflow
	Given User logged in to Dynamics application with 'Admin'
	When User navigates to Customer Service admin center
	Then User clicks on Underwriter Authorities
	And User creates new Underwriter Authorities with agent 'WorkflowBookableResource' Property only '100000.00' Motor only single vehicle '20000.00' Motor total accumulation '30000.00'
	Then User selects new Underwriter Authorities with agent 'WorkflowBookableResource'
	And User validates Underwriter Authority "Underwriter Authority" field is not displayed
	And User deactivates the Underwriter Authority
	And User clicks on sign out


	
@Work-344 @Caseworker
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


 
@Work-78 @admin @teamlead @paralleltest
Scenario Outline: Work-78: Pick Assignment Rules' Data Management for Underwriter Authority
	Given User logged in to Dynamics application
	When User selects customer admin hub from Dynamics Home page
	And User Clicks On Underwriter Authority
	Then User clicks on new button
	And User creates New UA <Agent> <Property> <Vehicle> <Accumulation>
	And User clicks on save and close button
	And User selects the newly created UA with <Agent> and updated the <UpdatedProperty> <UpdatedVehicle> <UpdatedAccumulation>
	And User validates if UA is updated successfully with <Agent> <UpdatedProperty> <UpdatedVehicle> <UpdatedAccumulation>
	And User deletes the UA <Agent>
	
Examples:
	| UserRoles                      | Agent                           | Property      | Vehicle     | Accumulation | UpdatedProperty | UpdatedVehicle | UpdatedAccumulation |
	| 'Trading Team leaders'         | 'Jeevanathan Chandran'          | '10000000.00' | '110000.00' | '2500000.00' | '2600000.00'    | '3600000.00'   | '4500000.00'        |
	| 'service delivery team leader' | 'JyothiPriyadarshini Periasamy' | '20000000.00' | '120000.00' | '2600000.00' | '2700000.00'    | '3700000.00'   | '4600000.00'        |
	| 'broker facing caseworker'     | 'Meena Shankaran'               | '30000000.00' | '130000.00' | '2700000.00' | '2800000.00'    | '3800000.00'   | '4700000.00'        |
	| 'service delivery caseworker'  | 'Sanjay Jayakumar'              | '40000000.00' | '140000.00' | '2800000.00' | '2900000.00'    | '3900000.00'   | '4800000.00'        |
	| 'Trading caseworker'           | 'Aravind Dakarapu'              | '50000000.00' | '150000.00' | '2900000.00' | '3000000.00'    | '4000000.00'   | '4900000.00'        |
	

	
@work-26 @teamleader
Scenario Outline: Work26 - Case or task Priority Override
	Given User logged in to Dynamics application with <userRole>
	When User <userRole> creates new case <CaseName> <PrimaryDemand> <Demand> <SubDemand> <Customer> <PolicyReference> <CaseDueDate> <Product>
	Then User clicks on save button
	And user validate the priority of the case as "Normal"
	When user override the priority from "Normal" to <Priority>
	Then User clicks on save button
	Then user validate the priority of the case as <Priority>
	When user creates a new task under timeline <Subject> <Description>
	And user click on the "open report" button on the Task under timeline
	Then user validate the priority of the task should be <Priority>
	When user select the "Go back" option from the case actions
	And create the new task <CaseName> <Demand> <PrimaryDemand>
	Then User clicks on save button
	And user validate the priority of the task should be <Priority>
	And User cancels the case with tasks <CaseName>

Examples:
	| userRole   | CaseName                   | PrimaryDemand        | Demand      | SubDemand          | Customer      | Product    | PolicyReference        | Subject              | Description | CaseDueDate  | Priority |
	| 'teamlead' | 'WF26PriortiyNormalToHigh' | 'I want information' | 'Documents' | 'Send Certificate' | 'sarah marta' | 'Motor'    | 'PL-HOM10003493441/00' | 'quick-TaskWF26High' | 'endorse'   | '10/10/2024' | "High"   |
	| 'teamlead' | 'WF26PriortiyNormalToLow'  | 'I want information' | 'Documents' | 'Send Certificate' | 'sarah marta' | 'Property' | 'PL-HOM10003493441/00' | 'quick-TaskWF26Low'  | 'endorse'   | '10/10/2024' | "Low"    |


@Work-17
Scenario: Work-17: Duplicate Email Removals
	Given User sends an email to UKSC mailbox
		| sender                      | to                   | subject                   | body                       | attachment |
		| 'Svc_HiscoxUKWorkflowAuto4' | 'Test_UKSC_Dynamics' | 'Agent pipelinetest test' | 'Kindly change my address' | 'No'       |
		| 'Svc_HiscoxUKWorkflowAuto4' | 'Test_UKSC_Dynamics' | 'Agent pipelinetest test' | 'Kindly change my address' | 'No'       |
	And User logged in to Dynamics application
	When User selects customer service hub from Dynamics Home page
	Then User clicks on Activities
	And User searches the email by subject 'Agent pipelinetest test'
	And User filter the mail with current date
	And User validates the mail count of 'Agent pipelinetest test'

	