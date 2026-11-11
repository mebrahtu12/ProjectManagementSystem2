
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManagementSystem.Domain.Entities;

namespace ProjectManagement.Infrastructure.Configurations;

// =====================================================
// PART 1: PROJECT PLANNING RELATIONSHIPS
// =====================================================

// Project -> Organization and Owner
public class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne<Organization>()
            .WithMany()
            .HasForeignKey(x => x.OrganizationId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.OwnerId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

// ProjectMember -> Project and User
public class ProjectMemberConfiguration
    : IEntityTypeConfiguration<ProjectMember>
{
    public void Configure(EntityTypeBuilder<ProjectMember> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne<Project>()
            .WithMany()
            .HasForeignKey(x => x.ProjectId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

// ProjectPhase -> Project
public class ProjectPhaseConfiguration
    : IEntityTypeConfiguration<ProjectPhase>
{
    public void Configure(EntityTypeBuilder<ProjectPhase> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne<Project>()
            .WithMany()
            .HasForeignKey(x => x.ProjectId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

// ProjectMilestone -> Project and ProjectPhase
public class ProjectMilestoneConfiguration
    : IEntityTypeConfiguration<ProjectMilestone>
{
    public void Configure(EntityTypeBuilder<ProjectMilestone> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne<Project>()
            .WithMany()
            .HasForeignKey(x => x.ProjectId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<ProjectPhase>()
            .WithMany()
            .HasForeignKey(x => x.PhaseId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

// ProjectDeliverable -> Project and ProjectMilestone
public class ProjectDeliverableConfiguration
    : IEntityTypeConfiguration<ProjectDeliverable>
{
    public void Configure(EntityTypeBuilder<ProjectDeliverable> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne<Project>()
            .WithMany()
            .HasForeignKey(x => x.ProjectId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<ProjectMilestone>()
            .WithMany()
            .HasForeignKey(x => x.MilestoneId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

// ProjectGoal -> Project and parent ProjectGoal
public class ProjectGoalConfiguration
    : IEntityTypeConfiguration<ProjectGoal>
{
    public void Configure(EntityTypeBuilder<ProjectGoal> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne<Project>()
            .WithMany()
            .HasForeignKey(x => x.ProjectId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<ProjectGoal>()
            .WithMany()
            .HasForeignKey(x => x.ParentId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}


// =====================================================
// PART 2: TASK STATUS, PRIORITY AND WORKFLOW
// =====================================================

// TaskStatus -> Project
public class taskStatusConfiguration
    : IEntityTypeConfiguration<taskStatus>
{
    public void Configure(EntityTypeBuilder<taskStatus> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne<Project>()
            .WithMany()
            .HasForeignKey(x => x.ProjectId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

// TaskPriority -> Project
public class TaskPriorityConfiguration
    : IEntityTypeConfiguration<TaskPriority>
{
    public void Configure(EntityTypeBuilder<TaskPriority> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne<Project>()
            .WithMany()
            .HasForeignKey(x => x.ProjectId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

// WorkflowTransition -> Project and two TaskStatus records
public class WorkflowTransitionConfiguration
    : IEntityTypeConfiguration<WorkflowTransition>
{
    public void Configure(EntityTypeBuilder<WorkflowTransition> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne<Project>()
            .WithMany()
            .HasForeignKey(x => x.ProjectId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<taskStatus>()
            .WithMany()
            .HasForeignKey(x => x.FromStatusId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<taskStatus>()
            .WithMany()
            .HasForeignKey(x => x.ToStatusId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}


// =====================================================
// PART 3: TASKS AND DEPENDENCIES
// =====================================================

// Tasks -> Project, Phase, Milestone, Parent Task,
// Status, Priority and Reporter
public class TasksConfiguration : IEntityTypeConfiguration<Tasks>
{
    public void Configure(EntityTypeBuilder<Tasks> builder)
    {
        builder.HasKey(x => x.Id);

        builder.ToTable("tasks");

        builder.HasOne<Project>()
            .WithMany()
            .HasForeignKey(x => x.ProjectId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<ProjectPhase>()
            .WithMany()
            .HasForeignKey(x => x.PhaseId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<ProjectMilestone>()
            .WithMany()
            .HasForeignKey(x => x.MilestoneId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Tasks>()
            .WithMany()
            .HasForeignKey(x => x.ParentTaskId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<taskStatus>()
            .WithMany()
            .HasForeignKey(x => x.StatusId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<TaskPriority>()
            .WithMany()
            .HasForeignKey(x => x.PriorityId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.ReporterId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

// TaskDependency -> Predecessor Task and Successor Task
public class TaskDependencyConfiguration
    : IEntityTypeConfiguration<TaskDependency>
{
    public void Configure(EntityTypeBuilder<TaskDependency> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne<Tasks>()
            .WithMany()
            .HasForeignKey(x => x.PredecessorTaskId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Tasks>()
            .WithMany()
            .HasForeignKey(x => x.SuccessorTaskId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}


// =====================================================
// PART 4: LABELS AND CUSTOM FIELDS
// =====================================================

// Label -> Project
public class LabelConfiguration : IEntityTypeConfiguration<Label>
{
    public void Configure(EntityTypeBuilder<Label> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne<Project>()
            .WithMany()
            .HasForeignKey(x => x.ProjectId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

// TaskLabel -> Task and Label
public class TaskLabelConfiguration : IEntityTypeConfiguration<TaskLabel>
{
    public void Configure(EntityTypeBuilder<TaskLabel> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne<Tasks>()
            .WithMany()
            .HasForeignKey(x => x.TaskId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Label>()
            .WithMany()
            .HasForeignKey(x => x.LabelId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

// TaskWatcher -> Task and User
public class TaskWatcherConfiguration
    : IEntityTypeConfiguration<TaskWatcher>
{
    public void Configure(EntityTypeBuilder<TaskWatcher> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne<Tasks>()
            .WithMany()
            .HasForeignKey(x => x.TaskId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

// CustomFieldDefinition -> Project
public class CustomFieldDefinitionConfiguration
    : IEntityTypeConfiguration<CustomFieldDefinition>
{
    public void Configure(EntityTypeBuilder<CustomFieldDefinition> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne<Project>()
            .WithMany()
            .HasForeignKey(x => x.ProjectId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

// CustomFieldValue -> Task and CustomFieldDefinition
public class CustomFieldValueConfiguration
    : IEntityTypeConfiguration<CustomFieldValue>
{
    public void Configure(EntityTypeBuilder<CustomFieldValue> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne<Tasks>()
            .WithMany()
            .HasForeignKey(x => x.TaskId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<CustomFieldDefinition>()
            .WithMany()
            .HasForeignKey(x => x.FieldDefinitionId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}


// =====================================================
// PART 5: BOARDS AND BOARD TASKS
// =====================================================

// Board -> Project
public class BoardConfiguration : IEntityTypeConfiguration<Board>
{
    public void Configure(EntityTypeBuilder<Board> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne<Project>()
            .WithMany()
            .HasForeignKey(x => x.ProjectId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

// BoardColumn -> Board and TaskStatus
public class BoardColumnConfiguration
    : IEntityTypeConfiguration<BoardColumn>
{
    public void Configure(EntityTypeBuilder<BoardColumn> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne<Board>()
            .WithMany()
            .HasForeignKey(x => x.BoardId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<taskStatus>()
            .WithMany()
            .HasForeignKey(x => x.StatusId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

// BoardTask -> Board, BoardColumn and Task
public class BoardTaskConfiguration : IEntityTypeConfiguration<BoardTask>
{
    public void Configure(EntityTypeBuilder<BoardTask> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne<Board>()
            .WithMany()
            .HasForeignKey(x => x.BoardId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<BoardColumn>()
            .WithMany()
            .HasForeignKey(x => x.ColumnId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Tasks>()
            .WithMany()
            .HasForeignKey(x => x.TaskId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}


// =====================================================
// PART 6: SPRINTS AND REPORTS
// =====================================================

// Sprint -> Project
public class SprintConfiguration : IEntityTypeConfiguration<Sprint>
{
    public void Configure(EntityTypeBuilder<Sprint> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne<Project>()
            .WithMany()
            .HasForeignKey(x => x.ProjectId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

// SprintTask -> Sprint and Task
public class SprintTaskConfiguration : IEntityTypeConfiguration<SprintTask>
{
    public void Configure(EntityTypeBuilder<SprintTask> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne<Sprint>()
            .WithMany()
            .HasForeignKey(x => x.SprintId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Tasks>()
            .WithMany()
            .HasForeignKey(x => x.TaskId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

// SprintReport -> Sprint
public class SprintReportConfiguration
    : IEntityTypeConfiguration<SprintReport>
{
    public void Configure(EntityTypeBuilder<SprintReport> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne<Sprint>()
            .WithMany()
            .HasForeignKey(x => x.SprintId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

// ProjectRetrospective -> Project and Sprint
public class ProjectRetrospectiveConfiguration
    : IEntityTypeConfiguration<ProjectRetrospective>
{
    public void Configure(EntityTypeBuilder<ProjectRetrospective> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne<Project>()
            .WithMany()
            .HasForeignKey(x => x.ProjectId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Sprint>()
            .WithMany()
            .HasForeignKey(x => x.SprintId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}


// =====================================================
// PART 7: GOALS, BASELINES AND SAVED VIEWS
// =====================================================

// GoalTaskLink -> ProjectGoal and Task
public class GoalTaskLinkConfiguration
    : IEntityTypeConfiguration<GoalTaskLink>
{
    public void Configure(EntityTypeBuilder<GoalTaskLink> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne<ProjectGoal>()
            .WithMany()
            .HasForeignKey(x => x.GoalId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Tasks>()
            .WithMany()
            .HasForeignKey(x => x.TaskId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

// ProjectBaseline -> Project and User who created it
public class ProjectBaselineConfiguration
    : IEntityTypeConfiguration<ProjectBaseline>
{
    public void Configure(EntityTypeBuilder<ProjectBaseline> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne<Project>()
            .WithMany()
            .HasForeignKey(x => x.ProjectId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.CreatedById)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

// BaselineItem -> ProjectBaseline and Task
public class BaselineItemConfiguration
    : IEntityTypeConfiguration<BaselineItem>
{
    public void Configure(EntityTypeBuilder<BaselineItem> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne<ProjectBaseline>()
            .WithMany()
            .HasForeignKey(x => x.BaselineId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Tasks>()
            .WithMany()
            .HasForeignKey(x => x.TaskId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

// SavedView -> Project and Owner
public class SavedViewConfiguration : IEntityTypeConfiguration<SavedView>
{
    public void Configure(EntityTypeBuilder<SavedView> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne<Project>()
            .WithMany()
            .HasForeignKey(x => x.ProjectId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(x => x.OwnerId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

// TaskAssignee -> Task and ProjectMember
public class TaskAssigneeConfiguration
    : IEntityTypeConfiguration<TaskAssignee>
{
    public void Configure(EntityTypeBuilder<TaskAssignee> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne<Tasks>()
            .WithMany()
            .HasForeignKey(x => x.TaskId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<ProjectMember>()
            .WithMany()
            .HasForeignKey(x => x.ProjectMemberId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
