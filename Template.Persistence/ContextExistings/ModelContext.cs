using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Template.Persistence.ContextExistings;

public partial class ModelContext : DbContext
{
    public ModelContext()
    {
    }

    public ModelContext(DbContextOptions<ModelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<MsPickupPickupRel> MsPickupPickupRels { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseOracle("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=BTU-DEV-SCAN.braspress.com.br)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=BTUD.braspress.com.br)));User Id = BTUCOLETA; Password = ownbtucoleta");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasDefaultSchema("BTUCOLETA")
            .UseCollation("USING_NLS_COMP");

        modelBuilder.Entity<MsPickupPickupRel>(entity =>
        {
            entity.HasKey(e => e.PickupRelId).HasName("PICKUP_REL_PK");

            entity.ToTable("MS_PICKUP_PICKUP_REL");

            entity.Property(e => e.PickupRelId)
                .HasDefaultValueSql("BTUCOLETA.SEQ_PICKUP_REL_ID.NEXTVAL ")
                .HasColumnType("NUMBER")
                .HasColumnName("PICKUP_REL_ID");
            entity.Property(e => e.PickupId)
                .HasColumnType("NUMBER")
                .HasColumnName("PICKUP_ID");
            entity.Property(e => e.PickupWorkflowIdApproved)
                .HasColumnType("NUMBER")
                .HasColumnName("PICKUP_WORKFLOW_ID_APPROVED");
            entity.Property(e => e.PickupWorkflowIdDisapproved)
                .HasColumnType("NUMBER")
                .HasColumnName("PICKUP_WORKFLOW_ID_DISAPPROVED");
            entity.Property(e => e.TaxInvoiceIdLast)
                .HasColumnType("NUMBER")
                .HasColumnName("TAX_INVOICE_ID_LAST");
        });
        modelBuilder.HasSequence("SEQ_ADDRESS_ID");
        modelBuilder.HasSequence("SEQ_APPROVER_GROUP_ID");
        modelBuilder.HasSequence("SEQ_BRANCH_ACCESS_ID");
        modelBuilder.HasSequence("SEQ_BRANCH_CANCEL_CONFIGURATION_ID");
        modelBuilder.HasSequence("SEQ_BRANCH_CANCEL_ID");
        modelBuilder.HasSequence("SEQ_BRANCH_CHECKLIST_ID");
        modelBuilder.HasSequence("SEQ_BRANCH_CONFIGURATION_ID");
        modelBuilder.HasSequence("SEQ_BRANCH_DOCUMENTATION_ID");
        modelBuilder.HasSequence("SEQ_BRANCH_EXTENSION_CONFIGURATION_ID");
        modelBuilder.HasSequence("SEQ_BRANCH_EXTENSION_ID");
        modelBuilder.HasSequence("SEQ_BRANCH_FILTER_ID");
        modelBuilder.HasSequence("SEQ_BRANCH_ID");
        modelBuilder.HasSequence("SEQ_BRANCH_IMPORT_OCCURRENCE_ID");
        modelBuilder.HasSequence("SEQ_BRANCH_INCOMPATIBLE_GOODS_ID");
        modelBuilder.HasSequence("SEQ_BRANCH_MATERIAL_ID");
        modelBuilder.HasSequence("SEQ_BRANCH_NOTIFICATION_ID");
        modelBuilder.HasSequence("SEQ_BRANCH_PARAMETERIZATION_ID");
        modelBuilder.HasSequence("SEQ_BRANCH_PARAMETERIZATION_INACTIVATE_ID");
        modelBuilder.HasSequence("SEQ_BRANCH_PARAMETERIZATION_SUSPEND_ID");
        modelBuilder.HasSequence("SEQ_BRANCH_RESPONSIBLE_ID");
        modelBuilder.HasSequence("SEQ_BRANCH_SCHEDULE_ID");
        modelBuilder.HasSequence("SEQ_BRANCH_VALIDATION_ID");
        modelBuilder.HasSequence("SEQ_BRANCH_WORKFLOW_APPROVAL_ESCALATION_ID");
        modelBuilder.HasSequence("SEQ_BRANCH_WORKFLOW_APPROVAL_STRUCTURE_CONTROLLER_DATA_ID");
        modelBuilder.HasSequence("SEQ_BRANCH_WORKFLOW_APPROVAL_STRUCTURE_ID");
        modelBuilder.HasSequence("SEQ_BRANCH_WORKFLOW_APPROVAL_STRUCTURE_REQUIREMENT_PARAMETERS_ID");
        modelBuilder.HasSequence("SEQ_BRANCH_WORKFLOW_COLLECTION_ID");
        modelBuilder.HasSequence("SEQ_BRANCH_WORKFLOW_COLLECTION_RETURN_ID");
        modelBuilder.HasSequence("SEQ_BRANCH_WORKFLOW_FREQUENCY_ID");
        modelBuilder.HasSequence("SEQ_BRANCH_WORKFLOW_PARAMETERIZATION_ID");
        modelBuilder.HasSequence("SEQ_BRANCH_WORKFLOW_PARAMETERIZATION_INACTIVATE_ID");
        modelBuilder.HasSequence("SEQ_BRANCH_WORKFLOW_PARAMETERS_ID");
        modelBuilder.HasSequence("SEQ_BRANCH_WORKFLOW_SCHEDULE_ID");
        modelBuilder.HasSequence("SEQ_BRANCH_WORKFLOW_SCHEDULING_DEADLINE_ID");
        modelBuilder.HasSequence("SEQ_BRANCH_WORKFLOW_TYPE_ID");
        modelBuilder.HasSequence("SEQ_BRANCH_WORKFLOW_USER_GROUP_ID");
        modelBuilder.HasSequence("SEQ_BRANCH_WORKFLOW_VALIDATION_BUSINESS_HOURS_ID");
        modelBuilder.HasSequence("SEQ_BRANCH_WORKFLOW_VALIDATION_PARAMETERS_ID");
        modelBuilder.HasSequence("SEQ_CANCEL_REASON_ID");
        modelBuilder.HasSequence("SEQ_CONTACT_ID");
        modelBuilder.HasSequence("SEQ_CORPORATION_ID");
        modelBuilder.HasSequence("SEQ_ESCALATION_EMAIL_ID");
        modelBuilder.HasSequence("SEQ_EXTENSION_REASON_ID");
        modelBuilder.HasSequence("SEQ_IMPORT_FILE_ID");
        modelBuilder.HasSequence("SEQ_INCOMPATIBLE_GOODS_ID");
        modelBuilder.HasSequence("SEQ_LOG_ID");
        modelBuilder.HasSequence("SEQ_MS_PICKUP_PICKUP_SCHEDULES_CANCEL_ID");
        modelBuilder.HasSequence("SEQ_MS_PICKUP_PICKUP_SCHEDULES_ID");
        modelBuilder.HasSequence("SEQ_OCCURRENCES_ID");
        modelBuilder.HasSequence("SEQ_PICKUP_ADDITIONAL_INFORMATION_ID");
        modelBuilder.HasSequence("SEQ_PICKUP_ID");
        modelBuilder.HasSequence("SEQ_PICKUP_NOTIFICATION_ID");
        modelBuilder.HasSequence("SEQ_PICKUP_OCCURENCE_ID");
        modelBuilder.HasSequence("SEQ_PICKUP_PROTOCOL");
        modelBuilder.HasSequence("SEQ_PICKUP_REL_ID");
        modelBuilder.HasSequence("SEQ_PICKUP_STATUS_EVOLUTION_ID");
        modelBuilder.HasSequence("SEQ_PICKUP_TAX_EXTENSION_ID");
        modelBuilder.HasSequence("SEQ_PICKUP_UPDATE_HISTORY_ID");
        modelBuilder.HasSequence("SEQ_PICKUP_WORKFLOW_ID");
        modelBuilder.HasSequence("SEQ_PICKUP_WORKFLOWS_TRANSFER_RETURN_ID");
        modelBuilder.HasSequence("SEQ_PRE_COLLECT_REGISTER_ID");
        modelBuilder.HasSequence("SEQ_PRE_COLLECT_SHIPMENT_AVAILABILITY_ID");
        modelBuilder.HasSequence("SEQ_REPORT_CUSTOM_ID");
        modelBuilder.HasSequence("SEQ_REPORT_FILTERS_ID");
        modelBuilder.HasSequence("SEQ_REPORT_ID");
        modelBuilder.HasSequence("SEQ_REPORT_SCHEDULING_DAYS_OF_WEEK_ID");
        modelBuilder.HasSequence("SEQ_REPORT_SCHEDULING_EMAILS_ID");
        modelBuilder.HasSequence("SEQ_REPORT_SCHEDULING_ID");
        modelBuilder.HasSequence("SEQ_REPORT_STORAGE_ID");
        modelBuilder.HasSequence("SEQ_SHIPMENT_AVAILABILITY_ID");
        modelBuilder.HasSequence("SEQ_SHIPMENT_ID");
        modelBuilder.HasSequence("SEQ_SHIPMENT_PACKAGE_ID");
        modelBuilder.HasSequence("SEQ_STANDARD_COLLECTION_REQUEST_ID");
        modelBuilder.HasSequence("SEQ_TAX_DOCUMENT_ID");
        modelBuilder.HasSequence("SEQ_TAX_INFORMATION_ID");
        modelBuilder.HasSequence("SEQ_TAX_INVOICE_ID");
        modelBuilder.HasSequence("SEQ_TEMPLATE_ID");
        modelBuilder.HasSequence("SEQ_TEMPLATE_IMAGE_ID");
        modelBuilder.HasSequence("SEQ_USER_GROUP_ID");
        modelBuilder.HasSequence("SEQ_USER_LOGIN_ID");
        modelBuilder.HasSequence("SEQ_USER_MANAGER_ID");
        modelBuilder.HasSequence("SEQ_WORKFLOW_SCHEDULE_RETURN_ID");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
