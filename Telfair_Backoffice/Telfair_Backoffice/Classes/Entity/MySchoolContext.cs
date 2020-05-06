using System;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Telfair_Backend.Classes.Entity
{
    public partial class MySchoolContext : DbContext
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        public MySchoolContext()
        {
        }

        public MySchoolContext(DbContextOptions<MySchoolContext> options)
            : base(options)
        {
        }

        public MySchoolContext(string conn)
        {
            ConnectionString = conn;
            if (!string.IsNullOrEmpty(ConnectionString))
            {
                var words = ConnectionString.Split('=');
                DatabaseName = words[words.Length - 1].Replace(";", string.Empty);
            }

        }

        //Dummy table for store procedure
        public virtual DbSet<PlanSummary> PlanSummary { get; set; }
        public virtual DbSet<BatchQualityControl> BatchQualityControl { get; set; }
        public virtual DbSet<CurriculumCount> CurriculumCount { get; set; }
        public virtual DbSet<CurriculumDetailCount> CurriculumDetailCount { get; set; }

        //End

        public virtual DbSet<Blog> Blog { get; set; }
        public virtual DbSet<Curriculum> Curriculum { get; set; }
        public virtual DbSet<CurriculumDetail> CurriculumDetail { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<EmployeePlan> EmployeePlan { get; set; }
        public virtual DbSet<EmployeeSubject> EmployeeSubject { get; set; }
        public virtual DbSet<EmployeeType> EmployeeType { get; set; }
        public virtual DbSet<HomeWork> HomeWork { get; set; }
        public virtual DbSet<HomeWork_Action> HomeWork_Action { get; set; }
        public virtual DbSet<Lesson> Lesson { get; set; }
        public virtual DbSet<Node> Node { get; set; }
        public virtual DbSet<NodeHierarchy> NodeHierarchy { get; set; }
        public virtual DbSet<NodeType> NodeType { get; set; }
        public virtual DbSet<Plan> Plan { get; set; }
        public virtual DbSet<PlanDetail> PlanDetail { get; set; }
        public virtual DbSet<PlanNursery> PlanNursery { get; set; }
        public virtual DbSet<PlanType> PlanType { get; set; }
        public virtual DbSet<Subject> Subject { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<Link> Link { get; set; }
        public virtual DbSet<RoleLink> RoleLink { get; set; }
        public virtual DbSet<ParentChildrenNode> ParentChildrenNode { get; set; }
        public virtual DbSet<Attachments> Attachments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                if (string.IsNullOrEmpty(ConnectionString))
                {
                    var environment = ConfigurationManager.AppSettings["Environment"].ToString();
                    var connString = ConfigurationManager.ConnectionStrings[environment].ConnectionString;
                    optionsBuilder.UseMySQL(connString);
                }
                else
                    optionsBuilder.UseMySQL(ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Blog>(entity =>
            {
                entity.ToTable("Blog", "MySchool");

                entity.HasIndex(e => e.MyId)
                    .HasName("MyId");

                entity.Property(e => e.Id)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MyId).HasColumnType("bigint(19)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.Status).HasColumnType("int(2)");
            });

            modelBuilder.Entity<Curriculum>(entity =>
            {
                entity.ToTable("Curriculum", "MySchool");

                entity.HasIndex(e => e.LevelNodeId)
                    .HasName("FK_Curriculum_Node");

                entity.HasIndex(e => e.MyId)
                    .HasName("MyId");

                entity.Property(e => e.Id)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LevelNodeId)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.MyId).HasColumnType("bigint(20)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Status).HasColumnType("int(2)");

                entity.HasOne(d => d.LevelNode)
                    .WithMany(p => p.Curriculum)
                    .HasForeignKey(d => d.LevelNodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Curriculum_Node");
            });

            modelBuilder.Entity<CurriculumDetail>(entity =>
            {
                entity.ToTable("CurriculumDetail", "MySchool");

                entity.HasIndex(e => e.CurriculumId)
                    .HasName("FK_CurriculumDetail_Curriculum");

                entity.HasIndex(e => e.LessonId)
                    .HasName("FK_CurriculumDetail_Lesson");

                entity.HasIndex(e => e.MyId)
                    .HasName("MyId");

                entity.Property(e => e.Id)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CurriculumId)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.Day)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.LessonId)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.MyId).HasColumnType("bigint(20)");

                entity.Property(e => e.Objectives)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.Status)
                    .HasColumnType("int(2)")
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.Term)
                    .HasColumnType("int(3)")
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.Week)
                    .HasColumnType("int(3)")
                    .HasDefaultValueSql("NULL");

                entity.HasOne(d => d.Curriculum)
                    .WithMany(p => p.CurriculumDetail)
                    .HasForeignKey(d => d.CurriculumId)
                    .HasConstraintName("FK_CurriculumDetail_Curriculum");

                entity.HasOne(d => d.Lesson)
                    .WithMany(p => p.CurriculumDetail)
                    .HasForeignKey(d => d.LessonId)
                    .HasConstraintName("FK_CurriculumDetail_Lesson");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee", "MySchool");

                entity.HasIndex(e => e.EmployeeTypeId)
                    .HasName("FK_Employee_EmployeeType");

                entity.HasIndex(e => e.MyId)
                    .HasName("MyId");

                entity.Property(e => e.Id)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Age).HasColumnType("int(3)");

                entity.Property(e => e.EmployeeTypeId)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.MyId).HasColumnType("bigint(20)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Status).HasColumnType("int(2)");

                entity.HasOne(d => d.EmployeeType)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.EmployeeTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_EmployeeType");
            });

            modelBuilder.Entity<EmployeePlan>(entity =>
            {
                entity.ToTable("EmployeePlan", "MySchool");

                entity.HasIndex(e => e.EmployeeId)
                    .HasName("FK_EmployeePlan_Employee");

                entity.HasIndex(e => e.MyId)
                    .HasName("MyId");

                entity.HasIndex(e => e.PlanId)
                    .HasName("FK_EmployeePlan_Plan");

                entity.Property(e => e.Id)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.EmployeeId)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.MyId).HasColumnType("bigint(20)");

                entity.Property(e => e.PlanId)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.Status).HasColumnType("int(2)");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeePlan)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeePlan_Employee");
            });

            modelBuilder.Entity<EmployeeSubject>(entity =>
            {
                entity.ToTable("EmployeeSubject", "MySchool");

                entity.HasIndex(e => e.EmployeeId)
                    .HasName("FK_EmployeeSubject_Employee");

                entity.HasIndex(e => e.MyId)
                    .HasName("MyId");

                entity.HasIndex(e => e.SubjectId)
                    .HasName("FK_EmployeeSubject_Subject");

                entity.Property(e => e.Id)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.EmployeeId)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.MyId).HasColumnType("bigint(20)");

                entity.Property(e => e.Status).HasColumnType("int(2)");

                entity.Property(e => e.SubjectId)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeSubject)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeeSubject_Employee");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.EmployeeSubject)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeeSubject_Subject");
            });

            modelBuilder.Entity<EmployeeType>(entity =>
            {
                entity.ToTable("EmployeeType", "MySchool");

                entity.HasIndex(e => e.MyId)
                    .HasName("MyId");

                entity.Property(e => e.Id)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MyId).HasColumnType("bigint(20)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Status).HasColumnType("int(2)");
            });

            modelBuilder.Entity<HomeWork>(entity =>
            {
                entity.ToTable("HomeWork", "MySchool");

                entity.Property(e => e.Id)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.DateCreate).HasDefaultValueSql("NULL");

                entity.Property(e => e.DateLimit).HasDefaultValueSql("NULL");

                entity.Property(e => e.Description)
                    .HasColumnType("longtext")
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.Status)
                    .HasColumnType("int(2)")
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.SubjectId)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("NULL");
            });

            modelBuilder.Entity<HomeWork_Action>(entity =>
            {
                entity.ToTable("HomeWork_Action", "MySchool");

                entity.Property(e => e.Id)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Name).HasDefaultValueSql("NULL");

                entity.Property(e => e.Description).HasDefaultValueSql("NULL");
            });

            modelBuilder.Entity<Lesson>(entity =>
            {
                entity.ToTable("Lesson", "MySchool");

                entity.HasIndex(e => e.MyId)
                    .HasName("MyId");

                entity.HasIndex(e => e.SubjectId)
                    .HasName("FK_Lesson_Subject");

                entity.Property(e => e.Id)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MyId).HasColumnType("bigint(20)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Status).HasColumnType("int(2)");

                entity.Property(e => e.SubjectId)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Lesson)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Lesson_Subject");
            });

            modelBuilder.Entity<Node>(entity =>
            {
                entity.ToTable("Node", "MySchool");

                entity.HasIndex(e => e.MyId)
                    .HasName("MyId")
                    .IsUnique();

                entity.HasIndex(e => e.NodeTypeId)
                    .HasName("FK_NodeType");

                entity.Property(e => e.Id)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.MyId).HasColumnType("bigint(20)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NodeTypeId)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.Status).HasColumnType("int(2)");

                entity.HasOne(d => d.NodeType)
                    .WithMany(p => p.Node)
                    .HasForeignKey(d => d.NodeTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NodeType");
            });

            modelBuilder.Entity<NodeHierarchy>(entity =>
            {
                entity.ToTable("NodeHierarchy", "MySchool");

                entity.HasIndex(e => e.MyId)
                    .HasName("MyId");

                entity.HasIndex(e => e.NodeId)
                    .HasName("FK_NodeHierarchy_Node");

                entity.HasIndex(e => e.ParentNodeId)
                    .HasName("FK_NodeHierarchy_ParentNode");

                entity.Property(e => e.Id)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.MyId).HasColumnType("bigint(20)");

                entity.Property(e => e.NodeId)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.ParentNodeId)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.Status).HasColumnType("int(2)");

                entity.HasOne(d => d.Node)
                    .WithMany(p => p.NodeHierarchy)
                    .HasForeignKey(d => d.NodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NodeHierarchy_Node");

                entity.HasOne(d => d.ParentNode)
                    .WithMany(p => p.NodeHierarchyParent)
                    .HasForeignKey(d => d.ParentNodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NodeHierarchy_ParentNode");
            });

            modelBuilder.Entity<NodeType>(entity =>
            {
                entity.ToTable("NodeType", "MySchool");

                entity.HasIndex(e => e.MyId)
                    .HasName("MyId");

                entity.Property(e => e.Id)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MyId).HasColumnType("bigint(20)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Status).HasColumnType("int(2)");
            });

            modelBuilder.Entity<Plan>(entity =>
            {
                entity.ToTable("Plan", "MySchool");

                entity.HasIndex(e => e.EmployeeId)
                    .HasName("FK_Plan_Employee");

                entity.HasIndex(e => e.LessonId)
                    .HasName("FK_Plan_Lesson");

                entity.HasIndex(e => e.MyId)
                    .HasName("MyId");

                entity.HasIndex(e => e.NodeLevelId)
                    .HasName("FK_Plan_NodeLevel");

                entity.HasIndex(e => e.PlanTypeId)
                    .HasName("FK_PlanPlanType");

                entity.Property(e => e.Id)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Activities)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Aims)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Days)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.Duration)
                    .HasColumnType("int(3)")
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.EmployeeId)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.Evaluation)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.LessonId)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.Materials)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Method)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MyId).HasColumnType("bigint(20)");

                entity.Property(e => e.NoOfChildren)
                    .HasColumnType("int(3)")
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.NodeLevelId)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.Note)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.OutcomesNotes)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PlanTypeId)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.Status).HasColumnType("int(2)");

                entity.Property(e => e.Term).HasColumnType("int(2)");

                entity.Property(e => e.Week).HasColumnType("int(2)");

                entity.HasOne(d => d.Lesson)
                    .WithMany(p => p.Plan)
                    .HasForeignKey(d => d.LessonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Plan_Lesson");

                entity.HasOne(d => d.NodeLevel)
                    .WithMany(p => p.Plan)
                    .HasForeignKey(d => d.NodeLevelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Plan_NodeLevel");

                entity.HasOne(d => d.PlanType)
                    .WithMany(p => p.Plan)
                    .HasForeignKey(d => d.PlanTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PlanPlanType");
            });

            modelBuilder.Entity<PlanDetail>(entity =>
            {
                entity.ToTable("PlanDetail", "MySchool");

                entity.HasIndex(e => e.MyId)
                    .HasName("MyId");

                entity.HasIndex(e => e.PlanId)
                    .HasName("FK_PlanDetail_Plan");

                entity.Property(e => e.Id)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.MyId).HasColumnType("bigint(20)");

                entity.Property(e => e.PlanId)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.Status).HasColumnType("int(2)");

                entity.HasOne(d => d.Plan)
                    .WithMany(p => p.PlanDetail)
                    .HasForeignKey(d => d.PlanId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PlanDetail_Plan");
            });

            modelBuilder.Entity<PlanNursery>(entity =>
            {
                entity.ToTable("PlanNursery", "MySchool");

                entity.HasIndex(e => e.EmployeeId)
                    .HasName("FK_Plan_Employee");

                entity.HasIndex(e => e.LessonId)
                    .HasName("FK_Plan_Lesson");

                entity.HasIndex(e => e.MyId)
                    .HasName("MyId");

                entity.HasIndex(e => e.NodeLevelId)
                    .HasName("FK_Plan_NodeLevel");

                entity.HasIndex(e => e.PlanTypeId)
                    .HasName("FK_PlanPlanType");

                entity.Property(e => e.Id)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Activities)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Aims)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Days)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeId)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.Evaluation)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LessonId)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.Materials)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Method)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MyId).HasColumnType("bigint(20)");

                entity.Property(e => e.NoOfChildren).HasColumnType("int(3)");

                entity.Property(e => e.NodeLevelId)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.Note)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.OutcomesNotes)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PlanTypeId)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.Status).HasColumnType("int(2)");

                entity.Property(e => e.Term).HasColumnType("int(2)");

                entity.Property(e => e.Week).HasColumnType("int(2)");
            });

            modelBuilder.Entity<PlanType>(entity =>
            {
                entity.ToTable("PlanType", "MySchool");

                entity.HasIndex(e => e.MyId)
                    .HasName("MyId")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MyId).HasColumnType("int(19)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Status).HasColumnType("int(2)");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.ToTable("Subject", "MySchool");

                entity.HasIndex(e => e.LevelNodeId)
                    .HasName("FK_Subject_NodeLevel");

                entity.HasIndex(e => e.MyId)
                    .HasName("MyId")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LevelNodeId)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.MyId).HasColumnType("bigint(20)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Status).HasColumnType("int(2)");

                entity.HasOne(d => d.LevelNode)
                    .WithMany(p => p.Subject)
                    .HasForeignKey(d => d.LevelNodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Subject_NodeLevel");
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.ToTable("Menu", "MySchool");

                entity.Property(e => e.Id)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Link>(entity =>
            {
                entity.ToTable("Link", "MySchool");

                entity.Property(e => e.Id)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RoleLink>(entity =>
            {
                entity.ToTable("RoleLink", "MySchool");

                entity.Property(e => e.Id)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .ValueGeneratedNever();
            });
            modelBuilder.Entity<ParentChildrenNode>(entity =>
            {
                entity.ToTable("ParentChildrenNode", "MySchool");

                entity.Property(e => e.Id)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .ValueGeneratedNever();
            });
            modelBuilder.Entity<Attachments>(entity =>
            {
                entity.ToTable("Attachments", "MySchool");

                entity.Property(e => e.Id)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .ValueGeneratedNever();
            });
        }
    }
}
