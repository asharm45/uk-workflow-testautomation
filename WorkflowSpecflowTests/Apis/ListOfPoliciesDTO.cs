using Newtonsoft.Json;

namespace WorkflowSpecflowTests.Apis
{
    public partial class ListOfPoliciesDTO
    {
        public object ActiveCoversNetYearlyPremium { get; set; }
        public List<Broker365Datum> Broker365Data { get; set; }
        public List<object> ClaimInListHscxivOs { get; set; }
        public object ClauseIvOs { get; set; }
        public long CollectionMethodId { get; set; }
        public string ExternalPolicyNr { get; set; }
        public string MainRenewalDate { get; set; }
        public long PaymentTermId { get; set; }
        public object PolicyBankAccountExternalNumber { get; set; }
        public List<object> PolicyChangeHistoryIvo { get; set; }
        public List<PolicyContactIvo> PolicyContactIvOs { get; set; }
        public string PolicyEndDate { get; set; }
        public List<object> PolicyHeaderIrregularityRemarksList { get; set; }
        public List<PolicyHeaderRemarksList> PolicyHeaderRemarksList { get; set; }
        public List<object> PolicyItemUnderwritingAlertsIvOs { get; set; }
        public List<PolicyLobIvo> PolicyLobIvOs { get; set; }
        public List<object> PolicyRelatedInstallmentIvo { get; set; }
        public string PolicyStartDate { get; set; }
        public long PolicyVersionNr { get; set; }
        public double PolicyYearlyPremiumAmount { get; set; }
        public string ProductVoRefValue { get; set; }
        public List<QuestionnaireLineIvo> QuestionnaireLineIvOs { get; set; }
        public long RenewalNumber { get; set; }
        public object SiOnAllPreviousClaims { get; set; }
        public RefValue StatusCodeVoRefValue { get; set; }
        public string StatusDate { get; set; }
        public List<WordingIvo> WordingIvOs { get; set; }
    }

    public partial class Broker365Datum
    {
        public Guid AccountId { get; set; }
        public string Address1Composite { get; set; }
        public string Address1Postalcode { get; set; }
        public string MypAgencybrokernumber { get; set; }
        public string MypHiscoxbrokersegmentationcodeODataCommunityDisplayV1FormattedValue { get; set; }
        public string MypZhiscoxregion { get; set; }
        public string Name { get; set; }
        public string ParentAccountName { get; set; }
    }

    public partial class PolicyContactIvo
    {
        public string BrokerName { get; set; }
        public string BrokerSegmentation { get; set; }
        public object CompanyTypeVoRefValue { get; set; }
        public List<Dictionary<string, string>> ContactAddress { get; set; }
        public List<ContactBankAccount> ContactBankAccount { get; set; }
        public List<ContactEmail> ContactEmail { get; set; }
        public long ContactExtNum { get; set; }
        public List<ContactTelephone> ContactTelephone { get; set; }
        public long ContactUpdateVersion { get; set; }
        public string DateOfBirth { get; set; }
        public EntityTypeVoRefValue? EntityTypeVoRefValue { get; set; }
        public object FamilyStatusVoRefValue { get; set; }
        public List<object> Feedbacks { get; set; }
        public string FirstName { get; set; }
        public string GenderVoRefValue { get; set; }
        public string MasterBroker { get; set; }
        public string Name { get; set; }
        public PermissionHscxivo PermissionHscxivo { get; set; }
        public string PolicyContactRoleVoRefValue { get; set; }
        public string ProfessionVoRefValue { get; set; }
        public object SafeguardingConsiderations { get; set; }
        public string TitleVoRefValue { get; set; }
    }

    public partial class ContactBankAccount
    {
        public object BankAccountExternalNumber { get; set; }
        public object MandateStatusVoRefValue { get; set; }
    }

    public partial class ContactEmail
    {
        public string? DiscontinueDate { get; set; }
        public string Email { get; set; }
        public string EmailTypeVoRefValue { get; set; }
        public bool IncorrectEmail { get; set; }
    }

    public partial class ContactTelephone
    {
        public long CountryDialCodeReValue { get; set; }
        public string? DiscontinueDate { get; set; }
        public IncorrectPhone IncorrectPhone { get; set; }
        public object NumberPreferenceVoRefValue { get; set; }
        public string TelephoneNumber { get; set; }
        public string TelephonePrefix { get; set; }
        public string TelephoneTypeRefValue { get; set; }
    }

    public partial class PermissionHscxivo
    {
        public bool DontContactByEmail { get; set; }
        public bool DontContactByPhone { get; set; }
        public bool DontContactByPost { get; set; }
        public bool DontContactForFeedback { get; set; }
        public bool DontContactForServiceReview { get; set; }
        public bool DontPassInformation { get; set; }
    }

    public partial class PolicyHeaderRemarksList
    {
        public object Date { get; set; }
        public Remark Remark { get; set; }
    }

    public partial class PolicyLobIvo
    {
        public RefValue LobStatusRefValue { get; set; }
        public string LobVoRefValue { get; set; }
        public object NumberOfDrivers { get; set; }
        public object NumberOfVehicles { get; set; }
        public List<PolicyItemUnderwritingAlertsIvo> PolicyItemUnderwritingAlertsIvOs { get; set; }
        public List<PolicyLobAssetIvo> PolicyLobAssetIvOs { get; set; }
    }

    public partial class PolicyItemUnderwritingAlertsIvo
    {
        public string AuthorizationUserVoRefValue { get; set; }
        public string BusinessExceptionVoRefValue { get; set; }
    }

    public partial class PolicyLobAssetIvo
    {
        public object Abi250 { get; set; }
        public object AbiInterfaceFlag { get; set; }
        public object AdditionalSecurityHscxvoRefValue { get; set; }
        public string AdditionalStructureRebuildHscxvoRefValue { get; set; }
        public object AmountRate { get; set; }
        public object AnnualMileage { get; set; }
        public object AntiTheftExists { get; set; }
        public object AntivirusFirewall { get; set; }
        public string AssetDescription { get; set; }
        public string AssetEndDate { get; set; }
        public List<object> AssetIdentifierIvOs { get; set; }
        public string AssetStartDate { get; set; }
        public RefValue AssetStatusRefValue { get; set; }
        public string AssetTypeVoRefValue { get; set; }
        public object BodyStyleVoRefValue { get; set; }
        public object BuildingEstimatedCostAmount { get; set; }
        public string BuildingName { get; set; }
        public string BuildingWorks606VoRefValue { get; set; }
        public object BuildingWorksDescription { get; set; }
        public object BuildingWorksEndDate { get; set; }
        public object BuildingWorksStartDate { get; set; }
        public object BuildingWorksVoRefValue { get; set; }
        public string CityName { get; set; }
        public List<ClauseIvo> ClauseIvOs { get; set; }
        public string ConstructionFlatRoofPercentHscxvoRefValue { get; set; }
        public string ConstructionTypeVoRefValue { get; set; }
        public double? ContentSiManualAmount { get; set; }
        public object ConvertableFlag { get; set; }
        public string CountryVoRefValue { get; set; }
        public string CountyName { get; set; }
        public object CoveredLoss { get; set; }
        public List<CoverIvo> CoverIvOs { get; set; }
        public string CoverTypeHscxvoRefValue { get; set; }
        public string CurrencyVoRefValue { get; set; }
        public string DistrictName { get; set; }
        public object DrivingOtherCars { get; set; }
        public object ElectronicProtectionFlagVoRefValue { get; set; }
        public object EngineSize { get; set; }
        public object ExcludingVatFlag { get; set; }
        public object ExtMechanicalProtectionFlagVoRefValue { get; set; }
        public object FamilyFlag { get; set; }
        public object FuelTypeVoRefValue { get; set; }
        public string HasAdditionalPropertiesVoRefValue { get; set; }
        public object HasBuildingWorkVoRefValue { get; set; }
        public string HasBusinessFromHomeVoRefValue { get; set; }
        public string HasFloodingVoRefValue { get; set; }
        public string HasGrandDesignVoRefValue { get; set; }
        public string HasHabitableBasementHscxvoRefValue { get; set; }
        public string HasHighArtAndCollectionValueVoRefValue { get; set; }
        public long? HasHighItemsPairs606Value { get; set; }
        public string HasHighSingleItemValueVoRefValue { get; set; }
        public string HasMainHomeOccupancyVoRefValue { get; set; }
        public string HasMainHomeVoRefValue { get; set; }
        public string HasStructuralRepairVoRefValue { get; set; }
        public string HasSubsidenceVoRefValue { get; set; }
        public object HirerewardRefValue { get; set; }
        public object InsuredAmount { get; set; }
        public object InsuredAmountUplift { get; set; }
        public object IsArchPmmcAppointedVoRefValue { get; set; }
        public object IsCarCamera { get; set; }
        public object IsCededToFloodRe { get; set; }
        public object IsDiggingDoneVoRefValue { get; set; }
        public bool? IsEligibleForFloodRe { get; set; }
        public bool? IsHiscoxSurveyVo { get; set; }
        public object IsJctContractSignedVoRefValue { get; set; }
        public object IsJctSignedInJointNamesVoRefValue { get; set; }
        public object IsMachineryUsedVoRefValue { get; set; }
        public bool? IsMapflowAddressMatch { get; set; }
        public object IsNonNegligentLiabilityVoRefValue { get; set; }
        public object IsOccupancyDuringWorkVoRefValue { get; set; }
        public object IsOnSiteEveryDayVoRefValue { get; set; }
        public object IsPropertyWindAndWeatherTightVoRefValue { get; set; }
        public object IsSafeVoRefValue { get; set; }
        public object IsUnderpiningDoneVoRefValue { get; set; }
        public string IsWaterLeakDetectorVoRefValue { get; set; }
        public object IsWithinTenMetersOfWaterVoRefValue { get; set; }
        public object JeepFlag { get; set; }
        public string ListedBuildingHscxvoRefValue { get; set; }
        public string LodgerTypeVoRefValue { get; set; }
        public object MainDriverTypeVoRefValue { get; set; }
        public object ManufactureVoRefValue { get; set; }
        public object MarketValueAmount { get; set; }
        public string MarketValueHscxvoRefValue { get; set; }
        public object MechanicalProtectionFlagVoRefValue { get; set; }
        public object MinimalProtectionFlagVoRefValue { get; set; }
        public object ModelTrim { get; set; }
        public object ModelYear { get; set; }
        public object ModificationsRefValue { get; set; }
        public long? MortgageFlag { get; set; }
        public object MotorCoverTypeHscxvoRefValue { get; set; }
        public object MotorExcludeMidhscxvoRefValue { get; set; }
        public object MotorTypeHscxvoRefValue { get; set; }
        public long? NrOfAdultsHscxvoRefValue { get; set; }
        public object NrOfBathroomsHscxvoRefValue { get; set; }
        public string NrOfBedroomsHscxvoRefValue { get; set; }
        public long? NrOfChildrenHscxvoRefValue { get; set; }
        public long? NrOfFloorsHscxvoRefValue { get; set; }
        public object OperatingSysUpdates { get; set; }
        public long? OptionalAccidentalLossDiscount { get; set; }
        public object OvernightSecurityHscxvoRefValue { get; set; }
        public List<PolicyItemUnderwritingAlertsIvo> PolicyItemUnderwritingAlertsIvo { get; set; }
        public object PreExistingConditions { get; set; }
        public string PreviousClaimsFlagRefValue { get; set; }
        public string PropertyAlarmTypeVoRefValue { get; set; }
        public string PropertyFireAlarmTypeHscxvoRefValue { get; set; }
        public string PropertyOccupationTypeVoRefValue { get; set; }
        public object PropertyPostWorkTypeVoRefValue { get; set; }
        public long? PropertyPropositionHscxvoRefValue { get; set; }
        public object PropertySecuredNightVoRefValue { get; set; }
        public string PropertyTypeVoRefValue { get; set; }
        public object PurchaseValue { get; set; }
        public double? RebuildSiManualAmount { get; set; }
        public object RegisteredKeeperContactExtNum { get; set; }
        public object RegularDriverFlag { get; set; }
        public long? RenewalCategoryRefValue { get; set; }
        public object Restored { get; set; }
        public string RoofMaterialVoRefValue { get; set; }
        public object SafeDetails { get; set; }
        public object SafeRatingHscxvoRefValue { get; set; }
        public bool? SecondaryIsManualReferral { get; set; }
        public object SportsFlag { get; set; }
        public string StaffVoRefValue { get; set; }
        public string StreetName { get; set; }
        public object TotalAccessoriesValue { get; set; }
        public double? TotalSumInsured { get; set; }
        public object TravelClaims { get; set; }
        public object TravelDurationHscxvoRefValue { get; set; }
        public List<object> TravelFamilyMember { get; set; }
        public object TravelGeographicalHscxvoRefValue { get; set; }
        public object TravelTypeHscxvoRefValue { get; set; }
        public object Type { get; set; }
        public List<object> VehicleDriverVOs { get; set; }
        public object VehicleGearVoRefValue { get; set; }
        public object VehicleKm { get; set; }
        public object VehiclePrimaryIsManualReferal { get; set; }
        public object WintersportCover { get; set; }
        public string YearBuiltHscxvoRefValue { get; set; }
        public string ZipCode { get; set; }
    }

    public partial class ClauseIvo
    {
        public string ClauseVersionVoRefValue { get; set; }
        public object Text { get; set; }
    }

    public partial class CoverIvo
    {
        public List<object> ClauseIvOs { get; set; }
        public RefValue CoverStatusVoRefValue { get; set; }
        public string EndDate { get; set; }
        public string ExcessAmount { get; set; }
        public string InsuranceAmount { get; set; }
        public long? InsuranceAmountLevelId { get; set; }
        public string? InsuranceAmountLevelVoRefValue { get; set; }
        public long? ParentCoverExternalNumber { get; set; }
        public string ProductLineGroupVoRefValue { get; set; }
        public string StartDate { get; set; }
    }

    public partial class QuestionnaireLineIvo
    {
        public long? AnswerId { get; set; }
        public string QuestionnaireLineVoRefValue { get; set; }
    }

    public partial class WordingIvo
    {
        public string WordingCodeRefValue { get; set; }
        public string WordingModuleRefValue { get; set; }
    }

    public enum IncorrectPhone { False };

    public enum EntityTypeVoRefValue { Company, Individual, Other };

    public enum Remark { Remarks };

    public enum RefValue { Policy };

}
