using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace wefa.Models
{
    public partial class FRMS_PRDContext : DbContext
    {
        public FRMS_PRDContext()
        {
        }

        public FRMS_PRDContext(DbContextOptions<FRMS_PRDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<RefCarrier> RefCarrier { get; set; }
        public virtual DbSet<RefCountry> RefCountry { get; set; }
        public virtual DbSet<RefDocumentType> RefDocumentType { get; set; }
        public virtual DbSet<RefFilingRequestStatus> RefFilingRequestStatus { get; set; }
        public virtual DbSet<RefFilingRequestType> RefFilingRequestType { get; set; }
        public virtual DbSet<RefFormClass> RefFormClass { get; set; }
        public virtual DbSet<RefFormGroup> RefFormGroup { get; set; }
        public virtual DbSet<RefPolicyClass> RefPolicyClass { get; set; }
        public virtual DbSet<RefPolicyType> RefPolicyType { get; set; }
        public virtual DbSet<RefPriority> RefPriority { get; set; }
        public virtual DbSet<RefState> RefState { get; set; }
        public virtual DbSet<RefStateFilingRequirementType> RefStateFilingRequirementType { get; set; }
        public virtual DbSet<RefStateFilingStatus> RefStateFilingStatus { get; set; }
        public virtual DbSet<RefSystem> RefSystem { get; set; }
        public virtual DbSet<TrnFilingRequest> TrnFilingRequest { get; set; }
        public virtual DbSet<TrnFilingRequestCarrierXref> TrnFilingRequestCarrierXref { get; set; }
        public virtual DbSet<TrnFilingRequestPolicyTypeXref> TrnFilingRequestPolicyTypeXref { get; set; }
        public virtual DbSet<TrnFilingRequestReplaceFormXref> TrnFilingRequestReplaceFormXref { get; set; }
        public virtual DbSet<TrnFormFilingRequest> TrnFormFilingRequest { get; set; }
        public virtual DbSet<TrnStateFiling> TrnStateFiling { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=ENIAC;Database=FRMS_PRD;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RefCarrier>(entity =>
            {
                entity.HasKey(e => e.CarrierId)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("ref_Carrier");

                entity.Property(e => e.CarrierId).ValueGeneratedNever();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.EnumValue)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RefCountry>(entity =>
            {
                entity.HasKey(e => e.CountryId)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("ref_Country");

                entity.Property(e => e.CountryId).ValueGeneratedNever();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RefDocumentType>(entity =>
            {
                entity.HasKey(e => e.DocumentTypeId);

                entity.ToTable("ref_DocumentType");

                entity.Property(e => e.DocumentTypeId).ValueGeneratedNever();

                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RefFilingRequestStatus>(entity =>
            {
                entity.HasKey(e => e.FilingRequestStatusId);

                entity.ToTable("ref_FilingRequestStatus", "frms");

                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Group)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.HasOne(d => d.FilingRequestType)
                    .WithMany(p => p.RefFilingRequestStatus)
                    .HasForeignKey(d => d.FilingRequestTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ref_FilingRequestStatus_ref_FilingRequestType");
            });

            modelBuilder.Entity<RefFilingRequestType>(entity =>
            {
                entity.HasKey(e => e.FilingRequestTypeId);

                entity.ToTable("ref_FilingRequestType", "frms");

                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RefFormClass>(entity =>
            {
                entity.HasKey(e => e.FormClassId)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("ref_FormClass");

                entity.Property(e => e.FormClassId).ValueGeneratedNever();

                entity.Property(e => e.ClassName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.PolicyClass)
                    .WithMany(p => p.RefFormClass)
                    .HasForeignKey(d => d.PolicyClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<RefFormGroup>(entity =>
            {
                entity.HasKey(e => e.FormGroupId)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("ref_FormGroup");

                entity.Property(e => e.FormGroupId).ValueGeneratedNever();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.PolicyClass)
                    .WithMany(p => p.RefFormGroup)
                    .HasForeignKey(d => d.PolicyClassId)
                    .HasConstraintName("R_191");
            });

            modelBuilder.Entity<RefPolicyClass>(entity =>
            {
                entity.HasKey(e => e.PolicyClassId)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("ref_PolicyClass");

                entity.Property(e => e.PolicyClassId).ValueGeneratedNever();

                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.Property(e => e.ClearanceProductCode)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FormRequestCcEmailAddress)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FormRequestToEmailAddress)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IndexOfEndorsementsPath)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.KytaxLineOfBusinessId).HasColumnName("KYTaxLineOfBusinessId");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NavigateClearancePolicyClassIds)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NavigateId).HasColumnName("NavigateID");

                entity.Property(e => e.NoiseCharacters)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NoiseWords)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ProductCode)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ReleaseNotificationEmailAddress)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RenewalHistoryLimitCoverageCodes)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.RequireAcknowledgementOfValidationAlertsAndNotifications)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.SystemTypeCode)
                    .HasColumnName("systemTypeCode")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UnapprovedBrokerEmailAddress)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.WebsiteUrl)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RefPolicyType>(entity =>
            {
                entity.HasKey(e => e.PolicyTypeId);

                entity.ToTable("ref_PolicyType");

                entity.Property(e => e.PolicyTypeId).ValueGeneratedNever();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IndexOfEndorsementsPath)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NavigatePolicyTypeId).HasColumnName("NavigatePolicyTypeID");

                entity.Property(e => e.PolicyReferenceCode)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.HasOne(d => d.PolicyClass)
                    .WithMany(p => p.RefPolicyType)
                    .HasForeignKey(d => d.PolicyClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ref_PolicyType_ref_PolicyClass");
            });

            modelBuilder.Entity<RefPriority>(entity =>
            {
                entity.HasKey(e => e.PriorityId);

                entity.ToTable("ref_Priority", "frms");

                entity.Property(e => e.AuditLastModified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.AuditLastModifiedBy)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RefState>(entity =>
            {
                entity.HasKey(e => e.StateId)
                    .ForSqlServerIsClustered(false);

                entity.ToTable("ref_State");

                entity.Property(e => e.StateId).ValueGeneratedNever();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.RefState)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ref_Country__ref_State__CountryId");
            });

            modelBuilder.Entity<RefStateFilingRequirementType>(entity =>
            {
                entity.HasKey(e => e.StateFilingRequirementTypeId);

                entity.ToTable("ref_StateFilingRequirementType", "frms");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.HasOne(d => d.FilingRequestType)
                    .WithMany(p => p.RefStateFilingRequirementType)
                    .HasForeignKey(d => d.FilingRequestTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ref_StateFilingRequirementType_ref_FilingRequestType");
            });

            modelBuilder.Entity<RefStateFilingStatus>(entity =>
            {
                entity.HasKey(e => e.StateFilingStatusId);

                entity.ToTable("ref_StateFilingStatus", "frms");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.HasOne(d => d.FilingRequestType)
                    .WithMany(p => p.RefStateFilingStatus)
                    .HasForeignKey(d => d.FilingRequestTypeId)
                    .HasConstraintName("FK_ref_StateFilingStatus_ref_FilingRequestType");
            });

            modelBuilder.Entity<RefSystem>(entity =>
            {
                entity.HasKey(e => e.SystemId);

                entity.ToTable("ref_System", "frms");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TrnFilingRequest>(entity =>
            {
                entity.HasKey(e => e.FilingRequestId);

                entity.ToTable("trn_FilingRequest", "frms");

                entity.Property(e => e.AuditLastModified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.AuditLastModifiedBy)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.BlockRelease).HasDefaultValueSql("((0))");

                entity.Property(e => e.BlockReleaseReason)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.ComplianceFilingNumber)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.HistoryListId)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LastActivityDate).HasColumnType("datetime");

                entity.Property(e => e.ListId)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ListItemId)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PriorityJustification)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.StatusComments)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.SubmittedBy)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.SubmittedDate).HasColumnType("datetime");

                entity.Property(e => e.TaskListId)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.WorkflowId)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.FilingRequestStatus)
                    .WithMany(p => p.TrnFilingRequest)
                    .HasForeignKey(d => d.FilingRequestStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_trn_FilingRequest_ref_FilingRequestStatus");

                entity.HasOne(d => d.FilingRequestType)
                    .WithMany(p => p.TrnFilingRequest)
                    .HasForeignKey(d => d.FilingRequestTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_trn_FilingRequest_ref_FilingRequestType");

                entity.HasOne(d => d.PolicyClass)
                    .WithMany(p => p.TrnFilingRequest)
                    .HasForeignKey(d => d.PolicyClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_trn_FilingRequest_ref_PolicyClass");

                entity.HasOne(d => d.RequestPriorityNavigation)
                    .WithMany(p => p.TrnFilingRequest)
                    .HasForeignKey(d => d.RequestPriority)
                    .HasConstraintName("FK_trn_FilingRequest_ref_Priority");

                entity.HasOne(d => d.SystemAffectedNavigation)
                    .WithMany(p => p.TrnFilingRequest)
                    .HasForeignKey(d => d.SystemAffected)
                    .HasConstraintName("FK_trn_filingRequest_ref_System_SystemAffected");
            });

            modelBuilder.Entity<TrnFilingRequestCarrierXref>(entity =>
            {
                entity.ToTable("trn_FilingRequestCarrierXref", "frms");

                entity.Property(e => e.AuditLastModified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.AuditLastModifiedBy)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(suser_sname())");

                entity.HasOne(d => d.Carrier)
                    .WithMany(p => p.TrnFilingRequestCarrierXref)
                    .HasForeignKey(d => d.CarrierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_trn_FilingRequestCarrierXref_ref_Carrier");

                entity.HasOne(d => d.FilingRequest)
                    .WithMany(p => p.TrnFilingRequestCarrierXref)
                    .HasForeignKey(d => d.FilingRequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_trn_FilingRequestCarrierXref_trn_FilingRequest");
            });

            modelBuilder.Entity<TrnFilingRequestPolicyTypeXref>(entity =>
            {
                entity.ToTable("trn_FilingRequestPolicyTypeXref", "frms");

                entity.HasIndex(e => e.FilingRequestId)
                    .HasName("IDX_trn_FilingRequestPolicyTypeXref_FilingRequestId");

                entity.Property(e => e.AuditLastModified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.AuditLastModifiedBy)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(suser_sname())");

                entity.HasOne(d => d.FilingRequest)
                    .WithMany(p => p.TrnFilingRequestPolicyTypeXref)
                    .HasForeignKey(d => d.FilingRequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_trn_FilingRequestPolicyTypeXref_trn_FilingRequest");

                entity.HasOne(d => d.PolicyType)
                    .WithMany(p => p.TrnFilingRequestPolicyTypeXref)
                    .HasForeignKey(d => d.PolicyTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_trn_FilingRequestPolicyTypeXref_ref_PolicyType");
            });

            modelBuilder.Entity<TrnFilingRequestReplaceFormXref>(entity =>
            {
                entity.ToTable("trn_FilingRequestReplaceFormXref", "frms");

                entity.Property(e => e.AuditLastModified).HasColumnType("datetime");

                entity.Property(e => e.AuditLastModifiedBy)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.BaseFormIdString)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EditionDate).HasColumnType("datetime");

                entity.Property(e => e.FormEditionId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.FilingRequest)
                    .WithMany(p => p.TrnFilingRequestReplaceFormXref)
                    .HasForeignKey(d => d.FilingRequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__trn_Filin__Filin__6BE40491");
            });

            modelBuilder.Entity<TrnFormFilingRequest>(entity =>
            {
                entity.HasKey(e => e.FormFilingRequestId);

                entity.ToTable("trn_FormFilingRequest", "frms");

                entity.Property(e => e.AdobeId)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.AuditLastModified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.AuditLastModifiedBy)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.BaseFormIdString)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BypassWorkFlow).HasDefaultValueSql("((0))");

                entity.Property(e => e.ChangeDetails).IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(2500)
                    .IsUnicode(false);

                entity.Property(e => e.EditionDate).HasColumnType("datetime");

                entity.Property(e => e.EffectiveDate).HasColumnType("datetime");

                entity.Property(e => e.ExistingFormsEditionId).HasColumnName("ExistingFormsEditionID");

                entity.Property(e => e.ExpiryDate).HasColumnType("datetime");

                entity.Property(e => e.FormDefaultComment).HasColumnType("text");

                entity.Property(e => e.FormIdString)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.FormType)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.IncludeTermsOnQb).HasColumnName("IncludeTermsOnQB");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.NavigateFormEditionId).HasColumnName("NavigateFormEditionID");

                entity.Property(e => e.PurposeOfForm).HasColumnType("text");

                entity.Property(e => e.ReplacesExisitingFormExpiryDate).HasColumnType("datetime");

                entity.Property(e => e.ReplacesExistingFormEditionDate).HasColumnType("datetime");

                entity.Property(e => e.ReplacesExistingFormName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ShortName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SpecialBehavior).HasColumnType("text");

                entity.Property(e => e.SubCategory)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.SubjectivityDefaultText).HasColumnType("text");

                entity.Property(e => e.Uatrejection).HasColumnName("UATRejection");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.TrnFormFilingRequest)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_trn_FormFilingRequest_ref_Country");

                entity.HasOne(d => d.DocumentType)
                    .WithMany(p => p.TrnFormFilingRequest)
                    .HasForeignKey(d => d.DocumentTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_trn_FormFilingRequest_ref_DocumentType");

                entity.HasOne(d => d.FilingRequest)
                    .WithMany(p => p.TrnFormFilingRequest)
                    .HasForeignKey(d => d.FilingRequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_trn_FormFilingRequest_trn_FilingRequest");

                entity.HasOne(d => d.FormClass)
                    .WithMany(p => p.TrnFormFilingRequest)
                    .HasForeignKey(d => d.FormClassId)
                    .HasConstraintName("FK_trn_FormFilingRequest_ref_FormClass");
            });

            modelBuilder.Entity<TrnStateFiling>(entity =>
            {
                entity.HasKey(e => e.StateFilingId);

                entity.ToTable("trn_StateFiling", "frms");

                entity.HasIndex(e => new { e.StateFilingStatusId, e.FilingRequestId, e.CarrierId })
                    .HasName("IDX_trn_StateFiling_FilingRequestId_CarrierID");

                entity.HasIndex(e => new { e.StateFilingId, e.FilingRequestId, e.FilingDate, e.ApprovalDate, e.NavigateFormEffectiveDate, e.StateId, e.CarrierId, e.ProductionReleaseDate, e.StateFilingStatusId })
                    .HasName("IDX_trn_StateFiling_StateFilingStatusId");

                entity.Property(e => e.ApprovalDate).HasColumnType("datetime");

                entity.Property(e => e.AuditLastModified)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.AuditLastModifiedBy)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.CarrierId).HasColumnName("CarrierID");

                entity.Property(e => e.Comment).IsUnicode(false);

                entity.Property(e => e.FilingDate).HasColumnType("datetime");

                entity.Property(e => e.NavigateFormEffectiveDate).HasColumnType("datetime");

                entity.Property(e => e.ProductionReleaseDate).HasColumnType("datetime");

                entity.HasOne(d => d.Carrier)
                    .WithMany(p => p.TrnStateFiling)
                    .HasForeignKey(d => d.CarrierId)
                    .HasConstraintName("FK_trn_StateFiling_ref_Carrier");

                entity.HasOne(d => d.FilingRequest)
                    .WithMany(p => p.TrnStateFiling)
                    .HasForeignKey(d => d.FilingRequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.StateFilingRequirementType)
                    .WithMany(p => p.TrnStateFiling)
                    .HasForeignKey(d => d.StateFilingRequirementTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_trn_StateFiling_ref_StateFilingRequirementType");

                entity.HasOne(d => d.StateFilingStatus)
                    .WithMany(p => p.TrnStateFiling)
                    .HasForeignKey(d => d.StateFilingStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_trn_StateFiling_ref_StateFilingStatus");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.TrnStateFiling)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_trn_StateFiling_ref_State");
            });
        }
    }
}
