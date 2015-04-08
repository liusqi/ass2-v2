namespace a2.Models
{
    using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

    public class LookupModel : DbContext
    {
        // Your context has been configured to use a 'LookupModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'a2.Models.LookupModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'LookupModel' 
        // connection string in the application configuration file.
        public LookupModel()
            : base("name=LookupTables")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        /* Client and Smart Entity */
        public DbSet<Client> Clients { get; set; }
        public DbSet<Smart> Smarts { get; set; }


        /* Client Entity Lookup Tables */
        public DbSet<FiscalYear> FiscalYears { get; set; }
        public DbSet<RiskLevel> RiskLevels { get; set; }
        public DbSet<Crisis> Crises { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Program> Programs { get; set; }
        public DbSet<RiskStatus> RiskStatuses { get; set; }
        public DbSet<AssignedWorker> AssignedWorkers { get; set; }
        public DbSet<ReferralSource> ReferralSources { get; set; }
        public DbSet<ReferralContact> ReferralContacts { get; set; }
        public DbSet<Incident> Incidents { get; set; }
        public DbSet<AbuserRelationship> AbuserRelationships { get; set; }
        public DbSet<VictimOfIncident> VictimOfIncidents { get; set; }
        public DbSet<FamilyViolenceFile> FamilyViolenceFiles { get; set; }
        public DbSet<Ethnicity> Ethnicities { get; set; }
        public DbSet<Age> Ages { get; set; }
        public DbSet<RepeatClient> RepeatClients { get; set; }
        public DbSet<DuplicateFile> DuplicateFiles { get; set; }
        public DbSet<StatusOfFile> StatusOfFiles { get; set; }

        /* Smart Entity Lookup Tables */
        public DbSet<SexWorkExploitation> SexWorkExploitation { get; set; }
        public DbSet<MultiplePerpetrators> MultiplePerpetrators { get; set; }
        public DbSet<DrugFacilitatedAssault> DrugFacilitatedAssault { get; set; }
        public DbSet<CityOfAssault> CityOfAssault { get; set; }
        public DbSet<CityOfResidence> CityOfResidence { get; set; }
        public DbSet<ReferringHospital> ReferringHospital { get; set; }
        public DbSet<HospitalAttended> HospitalAttended { get; set; }
        public DbSet<SocialWorkAttendance> SocialWorkAttendance { get; set; }
        public DbSet<PoliceAttendance> PoliceAttendance { get; set; }
        public DbSet<VictimServicesAttendance> VictimServicesAttendance { get; set; }
        public DbSet<MedicalOnly> MedicalOnly { get; set; }
        public DbSet<EvidenceStored> EvidenceStored { get; set; }
        public DbSet<HIVMeds> HIVMeds { get; set; }
        public DbSet<ReferredToCBVS> ReferredToCBVS { get; set; }
        public DbSet<PoliceReported> PoliceReported { get; set; }
        public DbSet<ThirdPartyReport> ThirdPartyReport { get; set; }
        public DbSet<BadDateReport> BadDateReport { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}

    public class Client
    {
        [Key]
        [Column(Order = 0)]
        public int id { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public string Surname { get; set; }
        public string FirstName { get; set; }
        public string PoliceFileNum { get; set; }
        public int CourtFileNum { get; set; }
        public int SWCFileNum { get; set; }
        public string RiskAssessmentAssigned { get; set; }
        public string AbuserName { get; set; }
        public char Gender { get; set; }
        public int NumOfChildUnderSix { get; set; }
        public int NumOfChildUnderTwelve { get; set; }
        public int NumOfChildUnderEighteen { get; set; }
        public string DateLastTransferred { get; set; }
        public string DateClosed { get; set; }
        public string DateReopened { get; set; }


        public FiscalYear FiscalYear { get; set; }
        public RiskLevel RiskLevel { get; set; }
        public Crisis Crisis { get; set; }
        public Service Service { get; set; }
        public Program Program { get; set; }
        public RiskStatus RiskStatus { get; set; }
        public AssignedWorker AssignedWorker { get; set; }
        public ReferralSource ReferralSource { get; set; }
        public ReferralContact ReferralContact { get; set; }
        public Incident Incident { get; set; }
        public AbuserRelationship AbuserRelationship { get; set; }
        public VictimOfIncident VictimOfIncident { get; set; }
        public FamilyViolenceFile FamilyViolenceFile { get; set; }
        public Ethnicity Ethnicity { get; set; }
        public Age Age { get; set; }
        public RepeatClient RepeatClient { get; set; }
        public DuplicateFile DuplicateFile { get; set; }
        [ForeignKey("id")]
        public Smart SmartData { get; set; }
    }

    /* Smart Entity */
    public class Smart
    {
        [Key]
        public int id { get; set; }
        public int AccompanimentMinutes { get; set; }
        public int NumberTransportsProvided { get; set; }
        public bool ReferredToNursePractitioner { get; set; }
        public SexWorkExploitation SexWorkExploitation { get; set; }
        public MultiplePerpetrators MultiplePerpertrators { get; set; }
        public DrugFacilitatedAssault DrugFacilitatedAssaults { get; set; }
        public CityOfAssault CityOfAssault { get; set; }
        public CityOfResidence CityOfResidence { get; set; }
        public ReferringHospital ReferringHospital { get; set; }
        public HospitalAttended HospitalAttended { get; set; }
        public SocialWorkAttendance SocialWorkAttendance { get; set; }
        public PoliceAttendance PoliceAttendance { get; set; }
        public VictimServicesAttendance VictimServicesAttendance { get; set; }
        public MedicalOnly MedicalOnly { get; set; }
        public EvidenceStored EvidenceStored { get; set; }
        public HIVMeds HIVMeds { get; set; }
        public ReferredToCBVS ReferredToCBVS { get; set; }
        public PoliceReported PoliceReported { get; set; }
        public ThirdPartyReport ThirdPartyReport { get; set; }
        public BadDateReport BadDateReport { get; set; }
    }

    public class RiskLevel
    {
        [Key]
        public int id { get; set; }
        public string value { get; set; }
        public virtual List<Client> Clients { get; set; }
    }
    public class Crisis
    {
        [Key]
        public int id { get; set; }
        public string value { get; set; }
    }
    public class Service
    {
        [Key]
        public int id { get; set; }
        public string value { get; set; }
    }
    public class Program
    {
        [Key]
        public int id { get; set; }
        public string value { get; set; }
    }
    public class RiskStatus
    {
        [Key]
        public int id { get; set; }
        public string value { get; set; }
    }
    public class AssignedWorker
    {
        [Key]
        public int id { get; set; }
        public string value { get; set; }
    }
    public class ReferralSource
    {
        [Key]
        public int id { get; set; }
        public string value { get; set; }
    }
    public class ReferralContact
    {
        [Key]
        public int id { get; set; }
        public string value { get; set; }
    }
    public class Incident
    {
        [Key]
        public int id { get; set; }
        public string value { get; set; }
    }
    public class AbuserRelationship
    {
        [Key]
        public int id { get; set; }
        public string value { get; set; }
    }
    public class VictimOfIncident
    {
        [Key]
        public int id { get; set; }
        public string value { get; set; }
    }
    public class FamilyViolenceFile
    {
        [Key]
        public int id { get; set; }
        public string value { get; set; }
    }
    public class Ethnicity
    {
        [Key]
        public int id { get; set; }
        public string value { get; set; }
    }
    public class Age
    {
        [Key]
        public int id { get; set; }
        public string value { get; set; }
    }
    public class RepeatClient
    {
        [Key]
        public int id { get; set; }
        public string value { get; set; }
    }
    public class DuplicateFile
    {
        [Key]
        public int id { get; set; }
        public string value { get; set; }
    }
    public class StatusOfFile
    {
        [Key]
        public int id { get; set; }
        public string value { get; set; }
    }

    public class FiscalYear
    {
        [Key]
        public int id { get; set; }
        public string value { get; set; }
    }
    public class SexWorkExploitation
    {
        [Key]
        public int id { get; set; }
        public string value { get; set; }
    }
    public class MultiplePerpetrators
    {
        [Key]
        public int id { get; set; }
        public string value { get; set; }
    }
    public class DrugFacilitatedAssault
    {
        [Key]
        public int id { get; set; }
        public string value { get; set; }
    }
    public class CityOfAssault
    {
        [Key]
        public int id { get; set; }
        public string value { get; set; }
    }
    public class CityOfResidence
    {
        [Key]
        public int id { get; set; }
        public string value { get; set; }
    }
    public class ReferringHospital
    {
        [Key]
        public int id { get; set; }
        public string value { get; set; }
    }
    public class HospitalAttended
    {
        [Key]
        public int id { get; set; }
        public string value { get; set; }
    }
    public class SocialWorkAttendance
    {
        [Key]
        public int id { get; set; }
        public string value { get; set; }
    }
    public class PoliceAttendance
    {
        [Key]
        public int id { get; set; }
        public string value { get; set; }
    }
    public class VictimServicesAttendance
    {
        [Key]
        public int id { get; set; }
        public string value { get; set; }
    }
    public class MedicalOnly
    {
        [Key]
        public int id { get; set; }
        public string value { get; set; }
    }
    public class EvidenceStored
    {
        [Key]
        public int id { get; set; }
        public string value { get; set; }
    }
    public class HIVMeds
    {
        [Key]
        public int id { get; set; }
        public string value { get; set; }
    }
    public class ReferredToCBVS
    {
        [Key]
        public int id { get; set; }
        public string value { get; set; }
    }
    public class PoliceReported
    {
        [Key]
        public int id { get; set; }
        public string value { get; set; }
    }
    public class ThirdPartyReport
    {
        [Key]
        public int id { get; set; }
        public string value { get; set; }
    }
    public class BadDateReport
    {
        [Key]
        public int id { get; set; }
        public string value { get; set; }
    }
}