Feature: WORK Sprint-2 feature
	
@Work-105 @admin @teamlead
Scenario Outline: Work-105: Validate admin or teamlead can add new Underwriter Authority
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

@Work-105 @admin @teamlead
Scenario Outline: Work-105: Validate admin or teamlead can share Underwriter Authority
	Given User logged in to Dynamics application
	When User selects customer admin hub from Dynamics Home page
	And User Clicks On Underwriter Authority
	Then User clicks on new button
	And User creates New UA <Agent> <Property> <Vehicle> <Accumulation>
	And User clicks on save
	Then User clicks on share and manage access
	And User share it with <ShareWith> and grants the permission and click on share button
	And User deletes the UA
	
Examples:
	| Agent                   | Property     | Vehicle      | Accumulation | ShareWith          |
	| 'Amitsharma Jaiprakash' | '2500000.00' | '3500000.00' | '4500000.00' | 'Sanjay Jayakumar' |

@Work-105 @admin @teamlead
Scenario Outline: Work-105: Validate admin or teamlead can assign Underwriter Authority
	Given User logged in to Dynamics application
	When User selects customer admin hub from Dynamics Home page
	And User Clicks On Underwriter Authority
	Then User clicks on new button
	And User creates New UA <Agent> <Property> <Vehicle> <Accumulation>
	And User clicks on save
	Then User clicks on assign button
	And User assign it to <AssignTo> and clicks on assign button
	And User deletes the UA
	
Examples:
	| Agent                   | Property     | Vehicle      | Accumulation | AssignTo  |
	| 'Amitsharma Jaiprakash' | '2500000.00' | '3500000.00' | '4500000.00' | 'Trading' |

@Work-105 @admin @teamlead
Scenario Outline: Work-105: Validate admin or teamlead can update existing Underwriter Authority
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

@Work-105 @admin @teamlead
Scenario Outline: Work-105: Validate admin or teamlead can delete existing Underwriter Authority
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
