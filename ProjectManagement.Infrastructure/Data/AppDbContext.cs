
using Microsoft.EntityFrameworkCore;
using ProjectManagementSystem.Domain.Entities;

namespace ProjectManagement.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    // Organization, identity and access
    public DbSet<User> Users => Set<User>();
    public DbSet<Organization> Organizations => Set<Organization>();
    public DbSet<OrganizationMember> OrganizationMembers => Set<OrganizationMember>();
    public DbSet<Team> Teams => Set<Team>();
    public DbSet<TeamMember> TeamMembers => Set<TeamMember>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<Permission> Permissions => Set<Permission>();
    public DbSet<RolePermission> RolePermissions => Set<RolePermission>();
    public DbSet<MemberRole> MemberRoles => Set<MemberRole>();
    public DbSet<ResourcePermission> ResourcePermissions => Set<ResourcePermission>();
    public DbSet<SsoConnection> SsoConnections => Set<SsoConnection>();
    public DbSet<ApiKey> ApiKeys => Set<ApiKey>();
    public DbSet<AuditLog> AuditLogs => Set<AuditLog>();

    // Project planning
    public DbSet<Project> Projects => Set<Project>();
    public DbSet<ProjectMember> ProjectMembers => Set<ProjectMember>();
    public DbSet<ProjectPhase> ProjectPhases => Set<ProjectPhase>();
    public DbSet<ProjectMilestone> ProjectMilestones => Set<ProjectMilestone>();
    public DbSet<ProjectDeliverable> ProjectDeliverables => Set<ProjectDeliverable>();
    public DbSet<ProjectGoal> ProjectGoals => Set<ProjectGoal>();

    // Tasks and workflows
    public DbSet<taskStatus> TaskStatuses => Set<taskStatus>();
    public DbSet<TaskPriority> TaskPriorities => Set<TaskPriority>();
    public DbSet<WorkflowTransition> WorkflowTransitions => Set<WorkflowTransition>();
    public DbSet<Tasks> Tasks => Set<Tasks>();
    public DbSet<TaskDependency> TaskDependencies => Set<TaskDependency>();
    public DbSet<Label> Labels => Set<Label>();
    public DbSet<TaskLabel> TaskLabels => Set<TaskLabel>();
    public DbSet<TaskWatcher> TaskWatchers => Set<TaskWatcher>();
    public DbSet<CustomFieldDefinition> CustomFieldDefinitions => Set<CustomFieldDefinition>();
    public DbSet<CustomFieldValue> CustomFieldValues => Set<CustomFieldValue>();
    public DbSet<Board> Boards => Set<Board>();
    public DbSet<BoardColumn> BoardColumns => Set<BoardColumn>();
    public DbSet<BoardTask> BoardTasks => Set<BoardTask>();
    public DbSet<Sprint> Sprints => Set<Sprint>();
    public DbSet<SprintTask> SprintTasks => Set<SprintTask>();
    public DbSet<SprintReport> SprintReports => Set<SprintReport>();
    public DbSet<ProjectRetrospective> ProjectRetrospectives => Set<ProjectRetrospective>();
    public DbSet<GoalTaskLink> GoalTaskLinks => Set<GoalTaskLink>();
    public DbSet<ProjectBaseline> ProjectBaselines => Set<ProjectBaseline>();
    public DbSet<BaselineItem> BaselineItems => Set<BaselineItem>();
    public DbSet<SavedView> SavedViews => Set<SavedView>();
    public DbSet<TaskAssignee> TaskAssignees => Set<TaskAssignee>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(
        typeof(AppDbContext).Assembly);

        // Match the table names in the ER diagram.
        modelBuilder.Entity<User>().ToTable("users");
        modelBuilder.Entity<Organization>().ToTable("organizations");
        modelBuilder.Entity<OrganizationMember>().ToTable("organization_members");
        modelBuilder.Entity<Team>().ToTable("teams");
        modelBuilder.Entity<TeamMember>().ToTable("team_members");
        modelBuilder.Entity<Role>().ToTable("roles");
        modelBuilder.Entity<Permission>().ToTable("permissions");
        modelBuilder.Entity<RolePermission>().ToTable("role_permissions");
        modelBuilder.Entity<MemberRole>().ToTable("member_roles");
        modelBuilder.Entity<ResourcePermission>().ToTable("resource_permissions");
        modelBuilder.Entity<SsoConnection>().ToTable("sso_connections");
        modelBuilder.Entity<ApiKey>().ToTable("api_keys");
        modelBuilder.Entity<AuditLog>().ToTable("audit_logs");

        modelBuilder.Entity<Project>().ToTable("projects");
        modelBuilder.Entity<ProjectMember>().ToTable("project_members");
        modelBuilder.Entity<ProjectPhase>().ToTable("project_phases");
        modelBuilder.Entity<ProjectMilestone>().ToTable("project_milestones");
        modelBuilder.Entity<ProjectDeliverable>().ToTable("project_deliverables");
        modelBuilder.Entity<ProjectGoal>().ToTable("project_goals");

        modelBuilder.Entity<taskStatus>().ToTable("task_statuses");
        modelBuilder.Entity<TaskPriority>().ToTable("task_priorities");
        modelBuilder.Entity<WorkflowTransition>().ToTable("workflow_transitions");
        modelBuilder.Entity<Tasks>().ToTable("tasks");
        modelBuilder.Entity<TaskDependency>().ToTable("task_dependencies");
        modelBuilder.Entity<Label>().ToTable("labels");
        modelBuilder.Entity<TaskLabel>().ToTable("task_labels");
        modelBuilder.Entity<TaskWatcher>().ToTable("task_watchers");
        modelBuilder.Entity<CustomFieldDefinition>().ToTable("custom_field_definitions");
        modelBuilder.Entity<CustomFieldValue>().ToTable("custom_field_values");
        modelBuilder.Entity<Board>().ToTable("boards");
        modelBuilder.Entity<BoardColumn>().ToTable("board_columns");
        modelBuilder.Entity<BoardTask>().ToTable("board_tasks");
        modelBuilder.Entity<Sprint>().ToTable("sprints");
        modelBuilder.Entity<SprintTask>().ToTable("sprint_tasks");
        modelBuilder.Entity<SprintReport>().ToTable("sprint_reports");
        modelBuilder.Entity<ProjectRetrospective>().ToTable("project_retrospectives");
        modelBuilder.Entity<GoalTaskLink>().ToTable("goal_task_links");
        modelBuilder.Entity<ProjectBaseline>().ToTable("project_baselines");
        modelBuilder.Entity<BaselineItem>().ToTable("baseline_items");
        modelBuilder.Entity<SavedView>().ToTable("saved_views");
        modelBuilder.Entity<TaskAssignee>().ToTable("task_assignees");

        // PostgreSQL JSONB columns from the ER diagram.
        modelBuilder.Entity<SsoConnection>()
            .Property(x => x.Config).HasColumnType("jsonb");

        modelBuilder.Entity<ApiKey>()
            .Property(x => x.Scopes).HasColumnType("jsonb");

        modelBuilder.Entity<AuditLog>()
            .Property(x => x.Metadata).HasColumnType("jsonb");

        modelBuilder.Entity<WorkflowTransition>()
            .Property(x => x.Conditions).HasColumnType("jsonb");

        modelBuilder.Entity<CustomFieldDefinition>()
            .Property(x => x.Options).HasColumnType("jsonb");

        modelBuilder.Entity<CustomFieldValue>()
            .Property(x => x.Value).HasColumnType("jsonb");

        modelBuilder.Entity<SavedView>()
            .Property(x => x.FilterJson).HasColumnType("jsonb");
    }
}

