using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SAIM.Core.BusinessObjects.BusinessLogic;
using SAIM.Core.BusinessObjects.Model;
using SAIM.Core.BusinessObjects.RequestAndResponse;
using SAIM.Core.Data;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using Telfair_Backend.Classes.Entity;
using Telfair_Backend.Classes.Models;

namespace Telfair_Backend.Classes.Services
{
    public class PlanService
    {
        MySchoolContext dbcontext;
        private static string ConnectionString { get; set; }
        private static string CoreConnectionString { get; set; }

        public PlanService()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            ConnectionString = configuration.GetConnectionString("TEST");
            CoreConnectionString = configuration.GetConnectionString("TEST_Core");
            dbcontext = new MySchoolContext(ConnectionString);



        }

        public Person GetPersonByEmployeeId(string employeeId)
        {
            try
            {
                using(MyCoreContext coreContext = new MyCoreContext(CoreConnectionString))
                {
                    return coreContext.Person.Where(p => p.EmployeeId.Equals(employeeId)).First();
                }
            }
            catch (Exception)
            {
                return new Person();
            }
        }

        public List<DepartmentModel> GetDepartmentModel(List<NodeModel> departments)
        {
            List<DepartmentModel> results = new List<DepartmentModel>();
            try
            {
                foreach(NodeModel nodeModel in departments)
                {
                    List<NodeModel> grades = ViewNodeByParent(nodeModel.Id);
                    List<GradeModel> gradeModels = new List<GradeModel>();
                    foreach (NodeModel grade in grades)
                    {
                        gradeModels.Add(new GradeModel()
                        {
                            GradeId = grade.Id,
                            GradeName = grade.Name
                        });
                    }
                    results.Add(new DepartmentModel()
                    {
                        DepartmentId = nodeModel.Id,
                        DepartmentName = nodeModel.Name,
                        Grades = gradeModels
                    });
                }
            }
            catch (Exception)
            {
                throw;
            }
            return results;
        }

        #region Menu
        public List<MenuModel> GetMenuByRoleId(string roleId)
        {
            List<MenuModel> result = new List<MenuModel>();
            try
            {
                if(!string.IsNullOrEmpty(roleId)) roleId = ""; 
                List<Menu> menus = dbcontext.Menu.Where(m => m.Status.Equals(1)).OrderBy(m => m.MyId).ToList();
                foreach (Menu menu in menus)
                {
                    List<LinkModel> linkModels = new List<LinkModel>();
                    string sql = "SELECT l.Id , l.Name, l.Href, l.Status, COALESCE(r.`Status`, 0) FROM Link l LEFT JOIN RoleLink r ON r.LinkId = l.Id JOIN Menu m ON m.Id = l.MenuId WHERE m.Id LIKE '%" + menu.Id + "%'";
                    using (var command = dbcontext.Database.GetDbConnection().CreateCommand())
                    {
                        command.CommandText = sql;
                        dbcontext.Database.OpenConnection();
                        using (var res = command.ExecuteReader())
                        {
                            while (res.Read())
                            {
                                linkModels.Add(new LinkModel()
                                {
                                    Id = res.GetString(0),
                                    Name = res.GetString(1),
                                    Href = res.GetString(2),
                                    Status = res.GetInt32(3),
                                    Cheked = res.GetInt32(4).Equals(1)
                                });
                            }
                        }

                    }
                    result.Add(new MenuModel()
                    {
                        MenuId = menu.Id,
                        MenuFa_Fa = menu.Fa_fa,
                        MenuName = menu.Name,
                        LinkModels = linkModels
                    });
                }
            }
            catch (Exception)
            {

            }
            return result;
        }
        #endregion

        #region Plan
        public int SavePlan(PlanModel plan)
        {
            try
            {
                Plan plandata = new Plan()
                {
                    Id = string.IsNullOrEmpty(plan.Id) ? Guid.NewGuid().ToString() : plan.Id,
                    MyId = plan.MyId,
                    LessonId = plan.LessonId,
                    Aims = plan.Aims,
                    Activities = plan.Activities,
                    Materials = plan.Materials,
                    Method = plan.Method,
                    OutcomesNotes = plan.OutcomesNotes,
                    EmployeeId = plan.EmployeeIds.Contains(",") ? plan.EmployeeIds.Split(",")[0] : plan.EmployeeIds,
                    DateFrom = plan.DateFrom,
                    DateTo = plan.DateTo,
                    NodeLevelId = plan.NodeLevelId,
                    Note = plan.Note,
                    Days = plan.Days,
                    Evaluation = plan.Evaluation,
                    Duration = plan.Duration,
                    NoOfChildren = plan.NoOfChildren,
                    Week = plan.Week,
                    Term = plan.Term,
                    DateOfIssue = plan.DateOfIssue,
                    PlanTypeId = plan.PlanTypeId,
                    Status = 1

                };

                if (!string.IsNullOrEmpty(plan.Id))
                {
                    dbcontext.Plan.Attach(plandata);
                    dbcontext.Entry(plandata).State = EntityState.Modified;
                }
                else
                {
                    dbcontext.Plan.Add(plandata);

                }

                string[] employeeIds = new string[20];

                if (plan.EmployeeIds.Contains(","))
                {
                    employeeIds = plan.EmployeeIds.Split(",");
                }
                else
                {
                    employeeIds[0] = plan.EmployeeIds;
                }

                var employeeplans = dbcontext.EmployeePlan.Where(x => x.PlanId == plan.Id);

                var list = employeeIds.ToList();


                //remove employeeplan no more valid
                foreach (var employeeplan in employeeplans)
                {
                    bool found = false;
                    for (int i = 0; i < list.Count(); i++)
                    {
                        found = false;
                        if (!string.IsNullOrEmpty(list[i]))
                        {
                            if (employeeplan.EmployeeId == list[i])
                            {
                                found = true;
                                list.RemoveAt(i);
                                break;
                            }
                        }
                    }

                    if (!found)
                    {
                        dbcontext.EmployeePlan.Attach(employeeplan);
                        dbcontext.Entry(employeeplan).State = EntityState.Deleted;
                    }
                }

                // add employeeplan not yet added
                for (int i = 0; i < list.Count; i++)
                {
                    if (string.IsNullOrEmpty(list.ElementAt(i))) break;

                    var data = new EmployeePlan()
                    {
                        Id = Guid.NewGuid().ToString(),
                        EmployeeId = list.ElementAt(i),
                        PlanId = plandata.Id,
                        Status = 1
                    };

                    dbcontext.EmployeePlan.Add(data);
                    dbcontext.SaveChanges();
                }
                dbcontext.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public List<PlanModel> ViewPlan(int affichage, int page)
        {
            List<PlanModel> plans = new List<PlanModel>();

            try
            {
                int offset = (page - 1) * page, limit = affichage;
                var query = dbcontext.Plan.Where(x => x.Status == 1).OrderByDescending(p => p.MyId).Skip(offset).Take(limit);

                foreach (var plan in query)
                {
                    string employeeNames = string.Empty;
                    if (plan.EmployeeId.Contains(","))
                    {
                        string[] items = plan.EmployeeId.Split(",");
                        for (int i = 0; i < items.Length; i++)
                        {
                            if (!string.IsNullOrEmpty(items[i]))
                                employeeNames += dbcontext.Employee.Where(x => x.Id == items[i]).FirstOrDefault().Name;
                        }
                    }
                    else
                        employeeNames = dbcontext.Employee.Where(x => x.Id == plan.EmployeeId).FirstOrDefault().Name;

                    plans.Add(new PlanModel()
                    {
                        Id = plan.Id,
                        MyId = plan.MyId,
                        LessonId = plan.LessonId,
                        LessonName = dbcontext.Lesson.Where(x => x.Id == plan.LessonId).FirstOrDefault().Name,
                        Aims = plan.Aims,
                        Activities = plan.Activities,
                        Materials = plan.Materials,
                        Method = plan.Method,
                        OutcomesNotes = plan.OutcomesNotes,
                        EmployeeIds = plan.EmployeeId,
                        EmployeeNames = employeeNames,
                        DateFrom = plan.DateFrom,
                        DateTo = plan.DateTo,
                        NodeLevelId = plan.NodeLevelId,
                        NodeLevelName = dbcontext.Node.Where(x => x.Id == plan.NodeLevelId).FirstOrDefault().Name,
                        Note = plan.Note,
                        Days = plan.Days,
                        Duration = plan.Duration,
                        Evaluation = plan.Evaluation,
                        NoOfChildren = plan.NoOfChildren,
                        Week = plan.Week,
                        Term = plan.Term,
                        DateOfIssue = plan.DateOfIssue,
                        PlanTypeId = plan.PlanTypeId,
                        PlanTypeName = dbcontext.PlanType.Where(x => x.Id == plan.PlanTypeId).FirstOrDefault().Name,
                        Status = plan.Status
                    });
                }


                return plans;

            }
            catch (Exception ex)
            {
                return new List<PlanModel>();
            }
        }

        public int CountPlan()
        {
            try
            {
                return dbcontext.Plan.Where(x => x.Status == 1).Count();
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public PlanModel GetPlanById(string Id)
        {
            try
            {
                PlanModel model = new PlanModel();

                if (!string.IsNullOrEmpty(Id))
                {

                    Plan plan = dbcontext.Set<Plan>().SingleOrDefault(p => p.Id == Id);

                    string employeeNames = string.Empty;
                    if (plan != null && !string.IsNullOrEmpty(plan.EmployeeId) && plan.EmployeeId.Contains(","))
                    {
                        string[] items = plan.EmployeeId.Split(",");
                        for (int i = 0; i < items.Length; i++)
                        {
                            if (!string.IsNullOrEmpty(items[i]))
                                employeeNames += dbcontext.Employee.Where(x => x.Id == items[i]).FirstOrDefault().Name;
                        }
                    }
                    else
                        employeeNames = dbcontext.Employee.Where(x => x.Id == plan.EmployeeId).FirstOrDefault().Name;
                        //employeeNames = dbcontext.Employee.Where(x => x.Id == plan.EmployeeId && x.Status == 1).FirstOrDefault().Name;

                    if (plan != null)
                    {
                        var lesson = dbcontext.Lesson.Where(x => x.Id == plan.LessonId).FirstOrDefault();
                        //var lesson = dbcontext.Lesson.Where(x => x.Id == plan.LessonId && x.Status == 1).FirstOrDefault();

                        model.Id = plan.Id;
                        model.MyId = plan.MyId;
                        model.LessonId = plan.LessonId;
                        model.LessonName = dbcontext.Lesson.Where(x => x.Id == plan.LessonId && x.Status == 1).FirstOrDefault().Name;
                        model.Aims = plan.Aims;
                        model.Activities = plan.Activities;
                        model.Materials = plan.Materials;
                        model.Method = plan.Method;
                        model.OutcomesNotes = plan.OutcomesNotes;
                        model.EmployeeIds = plan.EmployeeId;
                        //model.EmployeeNames = context.Employee.Where(x => x.Id == plan.EmployeeId).FirstOrDefault().Name;
                        model.EmployeeNames = employeeNames;
                        model.DateFrom = plan.DateFrom;
                        model.DateTo = plan.DateTo;
                        model.NodeLevelId = plan.NodeLevelId;
                        model.NodeLevelName = dbcontext.Node.Where(x => x.Id == plan.NodeLevelId && x.Status == 1).FirstOrDefault().Name;
                        model.NodeDepartmentId = dbcontext.NodeHierarchy.Where(x => x.NodeId == plan.NodeLevelId && x.Status == 1).FirstOrDefault().ParentNodeId;
                        model.Note = plan.Note;
                        model.Days = plan.Days;
                        model.Duration = plan.Duration;
                        model.Evaluation = plan.Evaluation;
                        model.NoOfChildren = plan.NoOfChildren;
                        model.Week = plan.Week;
                        model.Term = plan.Term;
                        model.DateOfIssue = plan.DateOfIssue;
                        model.PlanTypeId = plan.PlanTypeId;
                        model.SubjectId = lesson != null ? lesson.SubjectId : "";
                        //model.SubjectName = !string.IsNullOrEmpty(model.SubjectId) ? dbcontext.su
                        model.PlanTypeName = dbcontext.PlanType.Where(x => x.Id == plan.PlanTypeId && x.Status == 1).FirstOrDefault().Name;
                        model.Status = plan.Status;
                    }

                }

                return model;
            }
            catch (Exception)
            {
                return new PlanModel();
            }

        }

        public List<PlanModel> GetPlanByEmployeeId(string employeeId)
        {
            List<PlanModel> models = new List<PlanModel>();

            if (!string.IsNullOrEmpty(employeeId))
            {

                var plansData = dbcontext.Plan.Where(p => p.EmployeeId.Contains(employeeId));

                string employeeNames = string.Empty;


                foreach (var plan in plansData)
                {
                    if (plan != null)
                    {
                        if (plan.EmployeeId.Contains(","))
                        {
                            string[] items = plan.EmployeeId.Split(",");
                            for (int i = 0; i < items.Length; i++)
                            {
                                if (!string.IsNullOrEmpty(items[i]))
                                    employeeNames += dbcontext.Employee.Where(x => x.Id == items[i]).FirstOrDefault().Name;
                            }
                        }
                        else
                            employeeNames = dbcontext.Employee.Where(x => x.Id == plan.EmployeeId).FirstOrDefault().Name;

                        models.Add(new PlanModel()
                        {
                            Id = plan.Id,
                            MyId = plan.MyId,
                            LessonId = plan.LessonId,
                            LessonName = dbcontext.Lesson.Where(x => x.Id == plan.LessonId).FirstOrDefault().Name,
                            Aims = plan.Aims,
                            Activities = plan.Activities,
                            Materials = plan.Materials,
                            Method = plan.Method,
                            OutcomesNotes = plan.OutcomesNotes,
                            EmployeeIds = plan.EmployeeId,
                            EmployeeNames = employeeNames,
                            DateFrom = plan.DateFrom,
                            DateTo = plan.DateTo,
                            NodeLevelId = plan.NodeLevelId,
                            NodeLevelName = dbcontext.Node.Where(x => x.Id == plan.NodeLevelId).FirstOrDefault().Name,
                            Note = plan.Note,
                            Week = plan.Week,
                            Term = plan.Term,
                            DateOfIssue = plan.DateOfIssue,
                            PlanTypeId = plan.PlanTypeId,
                            PlanTypeName = dbcontext.PlanType.Where(x => x.Id == plan.PlanTypeId).FirstOrDefault().Name,
                            Status = plan.Status
                        });
                    }
                }



            }


            return models;

        }

        public List<PlanModel> GetWeeklyPlanBySubjectAndEmployee(string subjectId, string employeeId, int term, int week, int duration)
        {
            try
            {
                List<PlanModel> models = new List<PlanModel>();

                if (!string.IsNullOrEmpty(subjectId))
                {
                    string sql = "CALL GetWeeklyPlanBySubjectAndEmployee('" + subjectId + "','" + employeeId + "'," + term + "," + week + ");";
                    var plansData = dbcontext.Plan.FromSql(sql);

                    foreach (var plan in plansData)
                    {
                        if (plan != null)
                        {
                            models.Add(new PlanModel()
                            {
                                Id = plan.Id,
                                MyId = plan.MyId,
                                LessonId = plan.LessonId,
                                LessonName = dbcontext.Lesson.Where(x => x.Id == plan.LessonId).FirstOrDefault().Name,
                                Aims = plan.Aims,
                                Activities = plan.Activities,
                                Materials = plan.Materials,
                                Method = plan.Method,
                                OutcomesNotes = plan.OutcomesNotes,
                                EmployeeIds = plan.EmployeeId,
                                EmployeeNames = dbcontext.Employee.Where(x => x.Id == plan.EmployeeId).FirstOrDefault().Name,
                                DateFrom = plan.DateFrom,
                                DateTo = plan.DateTo,
                                NodeLevelId = plan.NodeLevelId,
                                NodeLevelName = dbcontext.Node.Where(x => x.Id == plan.NodeLevelId).FirstOrDefault().Name,
                                NodeLevelDescription = dbcontext.Node.Where(x => x.Id == plan.NodeLevelId).FirstOrDefault().Description,
                                SubjectName = dbcontext.Subject.Where(x => x.Id == subjectId).FirstOrDefault().Name,
                                Note = plan.Note,
                                Week = plan.Week,
                                Term = plan.Term,
                                DateOfIssue = plan.DateOfIssue,
                                PlanTypeId = plan.PlanTypeId,
                                PlanTypeName = dbcontext.PlanType.Where(x => x.Id == plan.PlanTypeId).FirstOrDefault().Name,
                                Days = plan.Days,
                                Duration = plan.Duration,
                                Evaluation = plan.Evaluation,
                                NoOfChildren = plan.NoOfChildren,
                                Status = plan.Status
                            });
                        }
                    }
                }

                return models;
            }
            catch (Exception ex)
            {
                return new List<PlanModel>();
            }

        }

        public List<PlanModel> GetPlanBySubjectId(string subjectId)
        {
            List<PlanModel> models = new List<PlanModel>();

            if (!string.IsNullOrEmpty(subjectId))
            {

                //var plansData = context.Set<Plan>().Where(p => p.EmployeeId == subjectId);
                var plansData = dbcontext.Plan.FromSql("CALL GetPlanBySubject('" + subjectId + "');");

                foreach (var plan in plansData)
                {
                    if (plan != null)
                    {
                        models.Add(new PlanModel()
                        {
                            Id = plan.Id,
                            MyId = plan.MyId,
                            LessonId = plan.LessonId,
                            LessonName = dbcontext.Lesson.Where(x => x.Id == plan.LessonId).FirstOrDefault().Name,
                            Aims = plan.Aims,
                            Activities = plan.Activities,
                            Materials = plan.Materials,
                            Method = plan.Method,
                            OutcomesNotes = plan.OutcomesNotes,
                            EmployeeIds = plan.EmployeeId,
                            EmployeeNames = dbcontext.Employee.Where(x => x.Id == plan.EmployeeId).FirstOrDefault().Name,
                            DateFrom = plan.DateFrom,
                            DateTo = plan.DateTo,
                            NodeLevelId = plan.NodeLevelId,
                            NodeLevelName = dbcontext.Node.Where(x => x.Id == plan.NodeLevelId).FirstOrDefault().Name,
                            NodeLevelDescription = dbcontext.Node.Where(x => x.Id == plan.NodeLevelId).FirstOrDefault().Description,
                            SubjectName = dbcontext.Subject.Where(x => x.Id == subjectId).FirstOrDefault().Name,
                            Note = plan.Note,
                            Week = plan.Week,
                            Term = plan.Term,
                            DateOfIssue = plan.DateOfIssue,
                            PlanTypeId = plan.PlanTypeId,
                            PlanTypeName = dbcontext.PlanType.Where(x => x.Id == plan.PlanTypeId).FirstOrDefault().Name,
                            Days = plan.Days,
                            Duration = plan.Duration,
                            Evaluation = plan.Evaluation,
                            NoOfChildren = plan.NoOfChildren,
                            Status = plan.Status
                        });
                    }
                }
            }

            return models;

        }

        public List<PlanSummaryModel> GetPlanSummaryByEmployeeId(string employeeId, int affichage, int page, int duration)
        {
            List<PlanSummaryModel> models = new List<PlanSummaryModel>();
            int offset = (page - 1) * affichage, limit = affichage;
            if (!string.IsNullOrEmpty(employeeId))
            {

                //string param = login.ToLower().Contains("charon")  ? "1" : employeeId;

                try
                {
                    string sql = "CALL GetPlanSummary('" + employeeId + "');".ToString();
                    var planSummary = dbcontext.PlanSummary.FromSql(sql).Skip(offset).Take(limit);

                    foreach (var summary in planSummary)
                    {
                        if (summary != null)
                        {
                            models.Add(new PlanSummaryModel()
                            {
                                Id = summary.Id,
                                SubjectId = summary.SubjectId,
                                Term = summary.Term,
                                SubjectName = summary.SubjectName,
                                Level = summary.Level,
                                EmployeeName = summary.EmployeeName,
                                EmployeeId = summary.EmployeeId,
                                Duration = summary.Duration,
                                Week = summary.Week
                            });

                        }
                    }
                }
                catch (Exception ex)
                {

                }
            }

            return models;
        }

        public int CountPlanSummaryByEmployeeId(string employeeId)
        {
            try
            {
                return dbcontext.PlanSummary.FromSql("CALL GetPlanSummary('" + employeeId + "');".ToString()).Count();
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public List<PlanTypeModel> GetPlanTypes()
        {
            List<PlanTypeModel> planTypes = new List<PlanTypeModel>();

            try
            {

                var query = dbcontext.PlanType.Where(x => x.Status == 1);

                foreach (var planType in query)
                {
                    planTypes.Add(new PlanTypeModel()
                    {
                        Id = planType.Id,
                        MyId = planType.MyId,
                        Description = planType.Description,
                        Name = planType.Name,
                        Status = planType.Status
                    });
                }

                return planTypes;

            }
            catch (Exception ex)
            {
                return new List<PlanTypeModel>();
            }
        }

        #endregion 

        #region Node
        public List<NodeTypeModel> GetNodeType()
        {
            List<NodeTypeModel> nodeTypes = new List<NodeTypeModel>();

            try
            {

                var query = dbcontext.NodeType;
                foreach (var nodeType in dbcontext.NodeType)
                {
                    nodeTypes.Add(new NodeTypeModel()
                    {
                        Id = nodeType.Id,
                        Name = nodeType.Name
                    }
                    );
                }

                return nodeTypes;

            }
            catch (Exception ex)
            {
                return new List<NodeTypeModel>();
            }
        }
        public int SaveNode(NodeModel node)
        {
            try
            {
                Node nodedata = new Node()
                {
                    Id = string.IsNullOrEmpty(node.Id) ? Guid.NewGuid().ToString() : node.Id,
                    Description = node.Description,
                    Name = node.Name,
                    NodeTypeId = node.NodeTypeId,
                    MyId = node.MyId,
                    Status = 1
                };
                if (!string.IsNullOrEmpty(node.Id))
                {
                    dbcontext.Node.Attach(nodedata);
                    dbcontext.Entry(nodedata).State = EntityState.Modified;
                }
                else
                {
                    dbcontext.Node.Add(nodedata);
                }
                if (!string.IsNullOrEmpty(node.ParentNodeId))
                {
                    var hierarchydata = dbcontext.NodeHierarchy.Where(x => x.NodeId == nodedata.Id).FirstOrDefault();

                    if (hierarchydata != null)
                    {
                        hierarchydata.ParentNodeId = node.ParentNodeId;
                        return dbcontext.SaveChanges();
                    }
                    else
                    {
                        NodeHierarchy hierarchy = new NodeHierarchy()
                        {
                            Id = Guid.NewGuid().ToString(),
                            NodeId = nodedata.Id,
                            ParentNodeId = node.ParentNodeId,
                            Status = 1
                        };
                        dbcontext.NodeHierarchy.Add(hierarchy);
                    }
                }
                dbcontext.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int DeleteNode(string id)
        {
            try
            {
                Node node = dbcontext.Node.Find(id);
                node.Status = 0;
                dbcontext.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public List<HomeWork_Action> GetAllHomeWorkAction()
        {
            try
            {
                return dbcontext.HomeWork_Action.ToList();
            }
            catch (Exception)
            {
                return new List<HomeWork_Action>();
            }
        }

        public List<NodeModel> ViewNodeByNodeType(string nodeTypeId, int affichage, int page)
        {
            List<NodeModel> nodes = new List<NodeModel>();

            try
            {
                int limit = affichage, offset = (page - 1) * affichage;
                var query = dbcontext.Node.Include(node => node.NodeHierarchy)
                                                .Where(node => node.NodeTypeId == nodeTypeId && node.Status == 1).OrderByDescending(node => node.MyId).Skip(offset).Take(limit);

                foreach (var node in query)
                {
                    var parentNodeId = node.NodeHierarchy.FirstOrDefault() != null ? node.NodeHierarchy.FirstOrDefault().ParentNodeId : string.Empty;

                    var parentNode = string.IsNullOrEmpty(parentNodeId) ? new Node() : dbcontext.Node.Where(x => x.Id == parentNodeId).FirstOrDefault();

                    nodes.Add(new NodeModel()
                    {
                        Id = node.Id,
                        Description = node.Description,
                        Name = node.Name,
                        MyId = node.MyId,
                        Status = node.Status,
                        ParentNodeId = parentNode.Id,
                        ParentNodeName = parentNode.Name
                    });
                }

                return nodes;

            }
            catch (Exception ex)
            {
                return new List<NodeModel>();
            }
        }

        public int CountLevel(string nodeTypeId)
        {
            try
            {
                return dbcontext.Node.Include(node => node.NodeHierarchy)
                                                .Where(node => node.NodeTypeId == nodeTypeId && node.Status == 1).Count();
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public List<NodeModel> ViewNodeByNodeType(string nodeTypeId, string trick)
        {
            List<NodeModel> nodes = new List<NodeModel>();

            try
            {


                var query = dbcontext.Node.Include(node => node.NodeHierarchy)
                                              .Where(node => node.NodeTypeId == nodeTypeId && node.Status == 1 && (node.Id == "565e3a1e-1a71-4094-81c1-88c3d6a19456" || node.Id == "e7c69cf5-4b79-4942-a5e2-da8046fe077d")).OrderBy(node => node.Name);




                //var query = context.Node.Where(x => x.NodeTypeId == nodeType4Id && x.Status == 1);

                foreach (var node in query)
                {
                    var parentNodeId = node.NodeHierarchy.FirstOrDefault() != null ? node.NodeHierarchy.FirstOrDefault().ParentNodeId : string.Empty;

                    var parentNode = string.IsNullOrEmpty(parentNodeId) ? new Node() : dbcontext.Node.Where(x => x.Id == parentNodeId).FirstOrDefault();

                    nodes.Add(new NodeModel()
                    {
                        Id = node.Id,
                        Description = node.Description,
                        Name = node.Name,
                        MyId = node.MyId,
                        Status = node.Status,
                        ParentNodeId = parentNode.Id,
                        ParentNodeName = parentNode.Name

                        //ParentNodeId = parentnode.FirstOrDefault().ParentNodeId,
                        //ParentNodeName = parentnode.FirstOrDefault().


                    });


                }


                return nodes;

            }
            catch (Exception ex)
            {
                return new List<NodeModel>();
            }
        }

        public NodeModel GetNodeById(string id)
        {
            NodeModel model = new NodeModel();

            if (!string.IsNullOrEmpty(id))
            {
                var node = dbcontext.Node.Include(x => x.NodeHierarchy)
                                                .Where(x => x.Id == id && x.Status == 1).FirstOrDefault();



                var parentNodeId = node.NodeHierarchy.FirstOrDefault() != null ? node.NodeHierarchy.FirstOrDefault().ParentNodeId : string.Empty;

                var parentNode = string.IsNullOrEmpty(parentNodeId) ? new Node() : dbcontext.Node.Where(x => x.Id == parentNodeId).FirstOrDefault();


                if (node != null)
                {
                    model.Id = node.Id;
                    model.Name = node.Name;
                    model.Description = node.Description;
                    model.NodeTypeId = node.NodeTypeId;
                    model.MyId = node.MyId;
                    model.Status = node.Status;
                    model.ParentNodeId = parentNode.Id;
                    model.ParentNodeName = parentNode.Name;
                }


            }

            return model;

        }
        public int DeleteHomeWork(string Id)
        {

            try
            {
                var homework = dbcontext.HomeWork.Where(x => x.Id == Id).FirstOrDefault();
                homework.Status = 0;
                dbcontext.HomeWork.Attach(homework);
                dbcontext.Entry(homework).State = EntityState.Modified;
                dbcontext.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }

        }
        public bool SaveNodeHierarchy(NodeHierarchyModel model, NodeHierarchy data)
        {
            try
            {
                //MySchoolContext context = new MySchoolContext();

                NodeHierarchy hierarchy = new NodeHierarchy()
                {
                    Id = string.IsNullOrEmpty(model.Id) ? Guid.NewGuid().ToString() : model.Id,
                    NodeId = model.NodeId,
                    ParentNodeId = model.ParentNodeId,
                    MyId = model.MyId,
                    Status = 1
                };

                if (!string.IsNullOrEmpty(model.Id))
                {
                    dbcontext.NodeHierarchy.Attach(hierarchy);
                    dbcontext.Entry(hierarchy).State = EntityState.Modified;
                }
                else
                {
                    dbcontext.NodeHierarchy.Add(hierarchy);
                }

                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<NodeModel> ViewNodeByParent(string parentNodeId)
        {
            List<NodeModel> nodes = new List<NodeModel>();

            try
            {


                var query = dbcontext.Node.Include(node => node.NodeHierarchy)
                                                .Where(node => node.NodeHierarchy.Count() > 0 & node.NodeHierarchy.All(x => x.ParentNodeId == parentNodeId && node.Status == 1)).OrderBy(node => node.Name);

                foreach (var node in query)
                {

                    nodes.Add(new NodeModel()
                    {
                        Id = node.Id,
                        Description = node.Description,
                        Name = node.Name,
                        MyId = node.MyId,
                        Status = node.Status
                    });
                }

                return nodes;
            }
            catch (Exception ex)
            {
                return new List<NodeModel>();
            }
        }
        public List<NodeModel> ViewNodeBySubject(string nodeTypeId, string employeeId)
        {
            List<NodeModel> nodes = new List<NodeModel>();

            try
            {
                var query = from es in dbcontext.EmployeeSubject
                            join s in dbcontext.Subject
                            on es.SubjectId equals s.Id
                            join n in dbcontext.Node
                            on s.LevelNodeId equals n.Id
                            where es.EmployeeId == employeeId && es.Status == 1 && s.Status == 1 && n.Status == 1
                            select new { n.Id, n.Name };

                foreach (var node in query)
                {
                    nodes.Add(new NodeModel()
                    {
                        Id = node.Id,
                        Name = node.Name
                    });
                }

                return nodes;
            }
            catch (Exception ex)
            {
                return new List<NodeModel>();
            }
        }

        #endregion

        #region Curriculum

        public string IsCurriculumExist(string departmentId, string gradeId, string subjectId)
        {
            string result = "";
            try
            {
                string sql = "";
                sql += "SELECT c.Id ";
                sql += "FROM curriculum c ";
                sql += "JOIN curriculumdetail cd ON cd.CurriculumId = c.Id ";
                sql += "JOIN lesson l ON l.Id = cd.LessonId ";
                sql += "WHERE c.LevelNodeId = '" + gradeId + "' ";
                sql += "AND l.SubjectId = '" + subjectId + "' ";
                sql += "AND c.`Status` = 1 ";
                sql += "AND cd.`Status` = 1 ";
                sql += "GROUP BY c.Id, l.SubjectId ";
                sql += "LIMIT 1 ";
                using (var command = dbcontext.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = sql;
                    dbcontext.Database.OpenConnection();
                    using (var res = command.ExecuteReader())
                    {
                        while (res.Read())
                        {
                            result = res.GetString(0);
                            break;
                        }
                    }

                }
            }
            catch (Exception)
            {
                return "";
            }
            return result;
        }

        public int SaveCurriculum(CurriculumModel curriculumModel)
        {
            try
            {
                Curriculum curriculumdata = new Curriculum()
                {
                    Id = string.IsNullOrEmpty(curriculumModel.Id) ? Guid.NewGuid().ToString() : curriculumModel.Id,
                    Description = curriculumModel.Description,
                    Name = curriculumModel.Name,
                    LevelNodeId = curriculumModel.LevelNodeId,
                    MyId = curriculumModel.MyId,
                    Status = 1
                };

                if (!string.IsNullOrEmpty(curriculumModel.Id))
                {
                    dbcontext.Curriculum.Attach(curriculumdata);
                    dbcontext.Entry(curriculumdata).State = EntityState.Modified;
                }
                else
                {
                    dbcontext.Curriculum.Add(curriculumdata);
                }

                if (curriculumModel.Id != null && curriculumModel.Lessons != null)
                {
                    foreach (var curriculumDetailData in dbcontext.CurriculumDetail.Where(x => x.CurriculumId == curriculumModel.Id && x.Status == 1))
                    {
                        curriculumDetailData.Status = 0;
                        dbcontext.CurriculumDetail.Attach(curriculumDetailData);
                        dbcontext.Entry(curriculumDetailData).State = EntityState.Modified;
                    }
                }

                var lessons = string.IsNullOrEmpty(curriculumModel.Lessons) ? new string[0] : curriculumModel.Lessons.Split(',');
                var objectives = string.IsNullOrEmpty(curriculumModel.Objectives) ? new string[0] : curriculumModel.Objectives.Split(',');
                var weeks = string.IsNullOrEmpty(curriculumModel.Weeks) ? new string[0] : curriculumModel.Weeks.Split(',');
                var terms = string.IsNullOrEmpty(curriculumModel.Terms) ? new string[0] : curriculumModel.Terms.Split(',');
                var days = string.IsNullOrEmpty(curriculumModel.Days) ? new string[0] : curriculumModel.Days.Split(',');

                for (int i = 0; i < lessons.Length; i++)
                {
                    if (String.IsNullOrEmpty(lessons[i])) continue;

                    var curriculumDetailData = new CurriculumDetail();
                    {
                        curriculumDetailData.Id = Guid.NewGuid().ToString();
                        curriculumDetailData.CurriculumId = curriculumdata.Id;
                        curriculumDetailData.LessonId = lessons[i];
                        curriculumDetailData.Objectives = "";
                        curriculumDetailData.Week = weeks.Length > 0 ? int.Parse(string.IsNullOrEmpty(weeks[i]) ? "0" : weeks[i]) : 0;
                        curriculumDetailData.Term = terms.Length > 0 ? int.Parse(string.IsNullOrEmpty(terms[i]) ? "0" : terms[i]) : 0;
                        curriculumDetailData.Day = days.Length > 0 ? string.IsNullOrEmpty(days[i]) ? "N/A" : days[i] : "N/A";
                        curriculumDetailData.Status = 1;
                    };

                    dbcontext.CurriculumDetail.Add(curriculumDetailData);
                    dbcontext.SaveChanges();
                }
                dbcontext.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public int SaveCurriculumDetail(CurriculumDetailModel curriculumDetail)
        {
            try
            {


                CurriculumDetail data = new CurriculumDetail()

                {
                    Id = string.IsNullOrEmpty(curriculumDetail.Id) ? Guid.NewGuid().ToString() : curriculumDetail.Id,
                    CurriculumId = curriculumDetail.CurriculumId,
                    LessonId = curriculumDetail.LessonId,
                    Objectives = curriculumDetail.Objectives,
                    MyId = curriculumDetail.MyId,
                    Status = 1
                };

                if (!string.IsNullOrEmpty(curriculumDetail.Id))
                {
                    dbcontext.CurriculumDetail.Attach(data);
                    dbcontext.Entry(data).State = EntityState.Modified;
                }
                else
                {
                    dbcontext.CurriculumDetail.Add(data);
                }

                return dbcontext.SaveChanges();
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public List<CurriculumModel> GetCurriculumModels()
        {
            List<CurriculumModel> models = new List<CurriculumModel>();


            var query = dbcontext.Curriculum.Where(x => x.Status == 1);

            foreach (var curriculum in query)
            {


                models.Add(new CurriculumModel()
                {
                    Id = curriculum.Id,
                    Description = curriculum.Description,
                    Name = curriculum.Name,
                    MyId = curriculum.MyId,
                    Status = curriculum.Status
                });
            }

            return models;
        }
        public IEnumerable<CurriculumModel> ViewCurriculum(string employeeId)
        {
            List<CurriculumModel> curriculums = new List<CurriculumModel>();

            try
            {
                var curriculumsData = !string.IsNullOrEmpty(employeeId)
                           ? from cur in dbcontext.Curriculum
                             join sub in dbcontext.Subject on cur.LevelNodeId equals sub.LevelNodeId
                             join esub in dbcontext.EmployeeSubject on sub.Id equals esub.SubjectId
                             where esub.EmployeeId == employeeId && cur.Status == 1 && sub.Status == 1 && esub.Status == 1
                             select new { cur.Id, cur.MyId, cur.Name, cur.Description, cur.LevelNodeId, cur.Status }
                           : from cur in dbcontext.Curriculum
                             where cur.Status == 1
                             select new { cur.Id, cur.MyId, cur.Name, cur.Description, cur.LevelNodeId, cur.Status };

                foreach (var curriculum in curriculumsData)
                {

                    CurriculumModel curriculumModel = new CurriculumModel();

                    curriculumModel.LevelNodeId = curriculum.LevelNodeId;
                    curriculumModel.LevelNodeName = dbcontext.Node.Where(y => y.Id == curriculum.LevelNodeId).FirstOrDefault().Name;
                    curriculumModel.Name = curriculum.Name;
                    curriculumModel.Description = curriculum.Description;
                    curriculumModel.Id = curriculum.Id;
                    curriculumModel.MyId = curriculum.MyId;
                    curriculumModel.Status = curriculum.Status;

                    List<CurriculumDetailModel> curriculumDetailModels = new List<CurriculumDetailModel>();

                    var curriculumDetailsData = dbcontext.CurriculumDetail.Where(x => x.CurriculumId == curriculumModel.Id && x.Status == 1);

                    foreach (var curriculumDetail in curriculumDetailsData)
                    {

                        CurriculumDetailModel curriculumDetailModel = new CurriculumDetailModel();

                        var lesson = dbcontext.Lesson.Where(x => x.Id == curriculumDetail.LessonId).FirstOrDefault();
                        var subject = dbcontext.Subject.Where(y => y.Id == lesson.SubjectId).FirstOrDefault();
                        curriculumDetailModel.Id = curriculumDetail.Id;
                        curriculumDetailModel.MyId = curriculumDetail.MyId;
                        curriculumDetailModel.CurriculumId = curriculumDetail.CurriculumId;
                        curriculumDetailModel.CurriculumName = curriculum.Name;
                        curriculumDetailModel.LessonId = curriculumDetail.LessonId;
                        curriculumDetailModel.LessonName = lesson.Name;
                        curriculumDetailModel.Objectives = curriculumDetail.Objectives;
                        curriculumDetailModel.Day = string.IsNullOrEmpty(curriculumDetail.Day) ? "N/A" : curriculumDetail.Day;
                        curriculumDetailModel.Week = curriculumDetail.Week.Value;
                        curriculumDetailModel.SubjectName = subject.Name;

                        curriculumDetailModels.Add(curriculumDetailModel);
                    }

                    curriculumModel.Curriculumdetails = curriculumDetailModels;
                    curriculums.Add(curriculumModel);
                }

                return curriculums;
            }
            catch (Exception ex)
            {
                return new List<CurriculumModel>();
            }
        }

        public CurriculumPagedModel ViewCurriculumPaged(string employeeId, string nameSearch, string descriptionSearch, string levelnodeid, int page = 1, int pageSize = 1)
        {
            CurriculumPagedModel pagedModel = new CurriculumPagedModel();
            List<CurriculumModel> curriculums = new List<CurriculumModel>();
            string filterCriteria = string.Empty;

            try
            {
                filterCriteria += string.IsNullOrEmpty(nameSearch) ? "''" : "'" + nameSearch + "'";
                filterCriteria += string.IsNullOrEmpty(descriptionSearch) ? ",''" : ",'" + descriptionSearch + "'";
                filterCriteria += string.IsNullOrEmpty(levelnodeid) ? ",''" : ",'" + levelnodeid + "'";
                filterCriteria += string.IsNullOrEmpty(employeeId) ? ",''" : ",'" + employeeId + "'";


                var curriculumDatas = dbcontext.Curriculum.FromSql("CALL GetPagedCurriculum(" + page + "," + pageSize + "," + filterCriteria + ")");
                var curriculumsCount = dbcontext.CurriculumCount.FromSql("CALL GetPagedCurriculumCount(" + page + "," + pageSize + "," + filterCriteria + ")");

                pagedModel.CurrentPage = page;
                pagedModel.PageCount = Int32.Parse(Math.Ceiling((double)(curriculumsCount.FirstOrDefault().Count) / ((double)(pageSize))).ToString());
                pagedModel.PageSize = curriculumDatas.Count();
                pagedModel.Total = curriculumsCount.FirstOrDefault().Count;

                foreach (var curriculumdata in curriculumDatas)
                {
                    var model = new CurriculumModel()
                    {
                        Id = curriculumdata.Id,
                        MyId = curriculumdata.MyId,
                        Name = curriculumdata.Name,
                        Description = curriculumdata.Description,
                        LevelNodeId = curriculumdata.LevelNodeId,
                        LevelNodeName = dbcontext.Node.Where(y => y.Id == curriculumdata.LevelNodeId).FirstOrDefault().Name,
                        Status = curriculumdata.Status
                    };
                    curriculums.Add(model);
                }

                pagedModel.CurriculumModels = curriculums;

                return pagedModel;
            }
            catch (Exception ex)
            {
                return new CurriculumPagedModel();
            }
        }

        public CurriculumDetailsPagedModel ViewCurriculumDetailsPaged(string curriculumId, int page = 1, int pageSize = 1)
        {
            CurriculumDetailsPagedModel pagedModel = new CurriculumDetailsPagedModel();
            List<CurriculumDetailModel> curriculumDetails = new List<CurriculumDetailModel>();
            string filterCriteria = string.Empty;

            try
            {



                var curriculumDetailsData = dbcontext.CurriculumDetail.FromSql("CALL GetPagedCurriculumDetails(" + page + "," + pageSize + "," + "'" + curriculumId + "'" + ")");
                var curriculumDetailsDataCount = dbcontext.CurriculumDetailCount.FromSql("CALL GetPagedCurriculumDetailsCount(" + page + "," + pageSize + "," + "'" + curriculumId + "'" + ")");

                pagedModel.CurrentPage = page;
                pagedModel.PageCount = Int32.Parse(Math.Ceiling((double)(curriculumDetailsDataCount.FirstOrDefault().Count) / ((double)(pageSize))).ToString());
                pagedModel.PageSize = curriculumDetailsData.Count();
                pagedModel.Total = curriculumDetailsDataCount.FirstOrDefault().Count;

                foreach (var curriculumDetail in curriculumDetailsData)
                {

                    CurriculumDetailModel curriculumDetailModel = new CurriculumDetailModel();

                    var lesson = dbcontext.Lesson.Where(x => x.Id == curriculumDetail.LessonId).FirstOrDefault();
                    var subject = dbcontext.Subject.Where(y => y.Id == lesson.SubjectId).FirstOrDefault();
                    curriculumDetailModel.Id = curriculumDetail.Id;
                    curriculumDetailModel.MyId = curriculumDetail.MyId;
                    curriculumDetailModel.CurriculumId = curriculumDetail.CurriculumId;
                    curriculumDetailModel.CurriculumName = dbcontext.Curriculum.Where(x => x.Id == curriculumDetail.CurriculumId).FirstOrDefault().Name;
                    curriculumDetailModel.LessonId = curriculumDetail.LessonId;
                    curriculumDetailModel.LessonName = lesson.Name;
                    curriculumDetailModel.Objectives = curriculumDetail.Objectives;
                    curriculumDetailModel.Day = string.IsNullOrEmpty(curriculumDetail.Day) ? "N/A" : curriculumDetail.Day;
                    curriculumDetailModel.Week = curriculumDetail.Week.Value;
                    curriculumDetailModel.SubjectName = subject.Name;

                    curriculumDetails.Add(curriculumDetailModel);
                }

                pagedModel.CurriculumDetailsModels = curriculumDetails;

                return pagedModel;
            }
            catch (Exception ex)
            {
                return new CurriculumDetailsPagedModel();
            }
        }

        public CurriculumModel ViewCurriculumById(string id)
        {
            CurriculumModel curriculumModel = new CurriculumModel();

            try
            {
                var query = dbcontext.Curriculum.Where(curriculum => curriculum.Status == 1 &&
                                              curriculum.Id == id);

                foreach (var curriculum in query)
                {
                    var parentNode = dbcontext.NodeHierarchy.Where(x => x.NodeId == curriculum.LevelNodeId && x.Status == 1).FirstOrDefault();

                    curriculumModel.DepartmentNodeId = parentNode != null ? parentNode.ParentNodeId : "";
                    curriculumModel.LevelNodeId = curriculum.LevelNodeId;
                    curriculumModel.LevelNodeName = dbcontext.Node.Where(y => y.Id == curriculum.LevelNodeId).FirstOrDefault().Name;
                    curriculumModel.Name = curriculum.Name;
                    curriculumModel.Description = curriculum.Description;
                    curriculumModel.Id = curriculum.Id;
                    curriculumModel.MyId = curriculum.MyId;
                    curriculumModel.Status = curriculum.Status;
                    List<CurriculumDetail> curriculumDetails = dbcontext.CurriculumDetail.Where(c => c.CurriculumId.Equals(curriculum.Id)).ToList();
                    List<CurriculumDetailModel> curriculumDetailModels = new List<CurriculumDetailModel>();

                    foreach (var curriculumDetail in curriculumDetails)
                    {
                        if (curriculumDetail.Status != 1) continue;

                        CurriculumDetailModel curriculumDetailModel = new CurriculumDetailModel();


                        var lesson = dbcontext.Lesson.Where(x => x.Id == curriculumDetail.LessonId).FirstOrDefault();
                        var subject = dbcontext.Subject.Where(y => y.Id == lesson.SubjectId).FirstOrDefault();
                        curriculumDetailModel.Id = curriculumDetail.Id;
                        curriculumDetailModel.MyId = curriculumDetail.MyId;
                        curriculumDetailModel.CurriculumId = curriculumDetail.CurriculumId;
                        curriculumDetailModel.CurriculumName = curriculum.Name;
                        curriculumDetailModel.LessonId = curriculumDetail.LessonId;
                        curriculumDetailModel.LessonName = lesson.Name;
                        curriculumDetailModel.Objectives = curriculumDetail.Objectives;
                        curriculumDetailModel.Day = string.IsNullOrEmpty(curriculumDetail.Day) ? "N/A" : curriculumDetail.Day;
                        curriculumDetailModel.Week = curriculumDetail.Week.Value;
                        curriculumDetailModel.SubjectName = subject.Name;

                        //set subjectid 
                        curriculumModel.SubjectId = subject.Id;


                        curriculumDetailModels.Add(curriculumDetailModel);
                    }

                    curriculumModel.Curriculumdetails = curriculumDetailModels;

                    //curriculums.Add(curriculumModel);
                }

                return curriculumModel;
            }
            catch (Exception ex)
            {
                return new CurriculumModel();
            }
        }

        public IEnumerable<CurriculumModel> ViewCurriculum()
        {
            List<CurriculumModel> curriculums = new List<CurriculumModel>();

            try
            {
                var query = dbcontext.Curriculum.Include(curriculum => curriculum.CurriculumDetail)
                                                   .Where(curriculum => curriculum.Status == 1);

                foreach (var curriculum in query)
                {

                    CurriculumModel curriculumModel = new CurriculumModel();


                    curriculumModel.LevelNodeId = curriculum.LevelNodeId;
                    curriculumModel.LevelNodeName = dbcontext.Node.Where(y => y.Id == curriculum.LevelNodeId).FirstOrDefault().Name;
                    curriculumModel.Name = curriculum.Name;
                    curriculumModel.Description = curriculum.Description;
                    curriculumModel.Id = curriculum.Id;
                    curriculumModel.MyId = curriculum.MyId;
                    curriculumModel.Status = curriculum.Status;

                    List<CurriculumDetailModel> curriculumDetailModels = new List<CurriculumDetailModel>();

                    foreach (var curriculumDetail in curriculum.CurriculumDetail)
                    {
                        if (curriculumDetail.Status != 1) continue;

                        CurriculumDetailModel curriculumDetailModel = new CurriculumDetailModel();


                        var lesson = dbcontext.Lesson.Where(x => x.Id == curriculumDetail.LessonId).FirstOrDefault();
                        var subject = dbcontext.Subject.Where(y => y.Id == lesson.SubjectId).FirstOrDefault();
                        curriculumDetailModel.Id = curriculumDetail.Id;
                        curriculumDetailModel.MyId = curriculumDetail.MyId;
                        curriculumDetailModel.CurriculumId = curriculumDetail.CurriculumId;
                        curriculumDetailModel.CurriculumName = curriculum.Name;
                        curriculumDetailModel.LessonId = curriculumDetail.LessonId;
                        curriculumDetailModel.LessonName = lesson.Name;
                        curriculumDetailModel.Objectives = curriculumDetail.Objectives;
                        curriculumDetailModel.Day = string.IsNullOrEmpty(curriculumDetail.Day) ? "N/A" : curriculumDetail.Day;
                        curriculumDetailModel.Week = curriculumDetail.Week.Value;
                        curriculumDetailModel.SubjectName = subject.Name;


                        curriculumDetailModels.Add(curriculumDetailModel);
                    }

                    curriculumModel.Curriculumdetails = curriculumDetailModels;

                    curriculums.Add(curriculumModel);
                }

                return curriculums;
            }
            catch (Exception ex)
            {
                return new List<CurriculumModel>();
            }
        }
        public List<CurriculumDetailModel> ViewCurriculumDetail()
        {
            List<CurriculumDetailModel> curriculumDetails = new List<CurriculumDetailModel>();

            try
            {

                var query = dbcontext.CurriculumDetail.Where(x => x.Status == 1);

                foreach (var curriculumDetail in query)
                {
                    curriculumDetails.Add(new CurriculumDetailModel()
                    {
                        Id = curriculumDetail.Id,
                        CurriculumId = curriculumDetail.CurriculumId,
                        CurriculumName = dbcontext.Curriculum.Where(x => x.Id == curriculumDetail.CurriculumId).FirstOrDefault().Name,
                        LessonId = curriculumDetail.LessonId,
                        LessonName = dbcontext.Lesson.Where(x => x.Id == curriculumDetail.LessonId).FirstOrDefault().Name,
                        Objectives = curriculumDetail.Objectives,
                        MyId = curriculumDetail.MyId,
                        Week = curriculumDetail.Week.Value,
                        Term = curriculumDetail.Term.Value,
                        Day = curriculumDetail.Day,
                        Status = curriculumDetail.Status.Value

                    });
                }

                return curriculumDetails;
            }
            catch (Exception ex)
            {
                return new List<CurriculumDetailModel>();
            }
        }
        public CurriculumModel GetCurriculumById(string Id)
        {
            CurriculumModel model = new CurriculumModel();

            if (!string.IsNullOrEmpty(Id))
            {

                Curriculum curriculum = dbcontext.Set<Curriculum>().SingleOrDefault(p => p.Id == Id && p.Status == 1);

                if (curriculum != null)
                {
                    var parentNode = dbcontext.NodeHierarchy.Where(x => x.NodeId == curriculum.LevelNodeId && x.Status == 1).FirstOrDefault();
                    var lessonid = dbcontext.CurriculumDetail.Where(x => x.CurriculumId == curriculum.Id && x.Status == 1).FirstOrDefault();

                    model.Id = curriculum.Id;
                    model.LevelNodeId = curriculum.LevelNodeId;
                    model.DepartmentNodeId = parentNode != null ? parentNode.ParentNodeId : "";
                    model.SubjectId = "";
                    model.Name = curriculum.Name;
                    model.Description = curriculum.Description;
                    model.MyId = curriculum.MyId;
                    model.Status = curriculum.Status;
                }


            }

            return model;

        }
        public CurriculumDetailModel GetCurriculumDetailById(string Id)
        {
            CurriculumDetailModel model = new CurriculumDetailModel();

            if (!string.IsNullOrEmpty(Id))
            {

                CurriculumDetail curriculumDetail = dbcontext.Set<CurriculumDetail>().SingleOrDefault(p => p.Id == Id);

                if (curriculumDetail != null)
                {
                    model.Id = curriculumDetail.Id;
                    model.CurriculumId = curriculumDetail.CurriculumId;
                    model.LessonId = curriculumDetail.LessonId;
                    model.Objectives = curriculumDetail.Objectives;
                    model.MyId = curriculumDetail.MyId;
                    model.Week = curriculumDetail.Week.Value;
                    model.Term = curriculumDetail.Term.Value;
                    model.Day = curriculumDetail.Day;
                    model.Status = curriculumDetail.Status.Value;
                }


            }
            return model;
        }
        public int DeleteCurriculum(string Id)
        {
            try
            {
                var curriculumdata = dbcontext.Curriculum.Where(x => x.Id == Id).FirstOrDefault();
                curriculumdata.Status = 0;
                dbcontext.Curriculum.Attach(curriculumdata);
                dbcontext.Entry(curriculumdata).State = EntityState.Modified;
                dbcontext.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }

        }
        public int DeleteCurriculumDetail(string Id)
        {

            var curriculumDetaildata = dbcontext.CurriculumDetail.Where(x => x.Id == Id).FirstOrDefault();
            curriculumDetaildata.Status = 0;
            dbcontext.CurriculumDetail.Attach(curriculumDetaildata);
            dbcontext.Entry(curriculumDetaildata).State = EntityState.Modified;
            return dbcontext.SaveChanges();

        }

        public List<CurriculumDetailModel> ViewAllCurriculumDetailsByCurriculum(string subjectId, string curriculumId)
        {
            List<CurriculumDetailModel> models = new List<CurriculumDetailModel>();


            var query = dbcontext.Lesson.Where(x => x.SubjectId == subjectId && x.Status == 1).OrderByDescending(x => x.MyId);
            var curriculumDetails = dbcontext.CurriculumDetail.Where(x => x.CurriculumId == curriculumId && x.Status == 1).OrderBy(x => x.Term).OrderBy(x => x.Week);

            foreach (var lesson in query)
            {
                CurriculumDetailModel model = new CurriculumDetailModel();
                var curriculumDetailData = curriculumDetails != null ? curriculumDetails.Where(x => x.LessonId == lesson.Id).FirstOrDefault() : null;
                model.Id = curriculumDetailData != null ? curriculumDetailData.Id : string.Empty;
                model.LessonId = curriculumDetailData != null ? curriculumDetailData.LessonId : lesson.Id;
                model.LessonName = lesson.Name;
                model.Objectives = curriculumDetailData != null ? curriculumDetailData.Objectives : string.Empty;
                model.Week = curriculumDetailData != null ? curriculumDetailData.Week.Value : 0;
                model.Term = curriculumDetailData != null ? curriculumDetailData.Term.Value : 0;
                model.Day = curriculumDetailData != null ? curriculumDetailData.Day = string.IsNullOrEmpty(curriculumDetailData.Day) ? "N/A" : curriculumDetailData.Day : string.Empty;
                model.Selected = curriculumDetailData != null ? true : false;
                models.Add(model);
            }


            return models;
        }

        #endregion

        #region Subject
        public int SaveSubject(SubjectModel subject)
        {
            try
            {


                Subject subjectdata = new Subject()
                {
                    Id = string.IsNullOrEmpty(subject.Id) ? Guid.NewGuid().ToString() : subject.Id,
                    Description = subject.Description,
                    Name = subject.Name,
                    LevelNodeId = subject.LevelNodeId,
                    MyId = subject.MyId,
                    Status = 1
                };

                if (!string.IsNullOrEmpty(subject.Id))
                {
                    dbcontext.Subject.Attach(subjectdata);
                    dbcontext.Entry(subjectdata).State = EntityState.Modified;
                }
                else
                {
                    dbcontext.Subject.Add(subjectdata);
                }
                dbcontext.SaveChanges();
                return 1;

            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public List<SubjectModel> ViewSubject(int affichage, int page)
        {
            List<SubjectModel> subjects = new List<SubjectModel>();

            try
            {
                int limit = affichage, offset = (page - 1) * affichage;
                var query = dbcontext.Subject.Where(x => x.Status == 1).OrderByDescending(x => x.MyId).Skip(offset).Take(limit);

                foreach (var subject in query)
                {


                    subjects.Add(new SubjectModel()
                    {
                        Id = subject.Id,
                        Name = subject.Name,
                        Description = subject.Description,
                        LevelNodeId = subject.LevelNodeId,
                        LevelNodeName = dbcontext.Node.Where(x => x.Id == subject.LevelNodeId && x.Status == 1).FirstOrDefault().Name,
                        MyId = subject.MyId
                    });


                }


                return subjects;

            }
            catch (Exception)
            {
                return new List<SubjectModel>();
            }
        }

        public int CountSubject()
        {
            try
            {
                return dbcontext.Subject.Where(x => x.Status == 1).Count();
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public List<SubjectModel> ViewSubjectByLevel(string levelId)
        {
            List<SubjectModel> subjects = new List<SubjectModel>();

            try
            {

                var query = dbcontext.Subject.Where(x => x.LevelNodeId == levelId && x.Status == 1);

                foreach (var subject in query)
                {
                    subjects.Add(new SubjectModel()
                    {
                        Id = subject.Id,
                        Name = subject.Name,
                        Description = subject.Description,
                        MyId = subject.MyId,
                        LevelNodeId = subject.LevelNodeId,
                        LevelNodeName = dbcontext.Node.Where(x => x.Id == levelId && x.Status == 1).FirstOrDefault().Name
                    });
                }

                return subjects;

            }
            catch (Exception ex)
            {
                return new List<SubjectModel>();
            }
        }
        public SubjectModel GetSubjectById(string Id)
        {
            SubjectModel model = new SubjectModel();

            if (!string.IsNullOrEmpty(Id))
            {

                Subject subject = dbcontext.Subject.SingleOrDefault(p => p.Id == Id);

                var node = (from nl in dbcontext.Node
                            join s in dbcontext.Subject on nl.Id equals s.LevelNodeId
                            join nh in dbcontext.NodeHierarchy on nl.Id equals nh.NodeId
                            where s.Id == subject.Id && nl.Status == 1 && s.Status == 1 && nh.Status == 1
                            select new { NodeLevelId = nl.Id, NodeDepartmentId = nh.ParentNodeId });

                if (subject != null)
                {
                    model.Id = subject.Id;
                    model.Name = subject.Name;
                    model.Description = subject.Description;
                    model.MyId = subject.MyId;
                    model.Status = subject.Status;
                    model.LevelNodeId = node.FirstOrDefault().NodeLevelId;
                    model.DepartmentNodeId = node.FirstOrDefault().NodeDepartmentId;
                }

            }

            return model;
        }
        public int DeleteSubject(string Id)
        {
            try
            {
                var subjectdata = dbcontext.Subject.Where(x => x.Id == Id).FirstOrDefault();
                subjectdata.Status = 0;
                dbcontext.Subject.Attach(subjectdata);
                dbcontext.Entry(subjectdata).State = EntityState.Modified;
                dbcontext.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }

        }
        #endregion

        #region Lesson
        public int SaveLesson(LessonModel lesson)
        {
            try
            {
                Lesson lessondata = new Lesson()
                {
                    Id = string.IsNullOrEmpty(lesson.Id) ? Guid.NewGuid().ToString() : lesson.Id,
                    Description = lesson.Description,
                    Name = lesson.Name,
                    SubjectId = lesson.SubjectId,
                    MyId = lesson.MyId,
                    Status = 1
                };

                if (!string.IsNullOrEmpty(lesson.Id))
                {
                    dbcontext.Lesson.Attach(lessondata);
                    dbcontext.Entry(lessondata).State = EntityState.Modified;
                }
                else
                {
                    dbcontext.Lesson.Add(lessondata);
                }
                dbcontext.SaveChanges();
                return 1;

            }
            catch (Exception)
            {
                return 0;
            }
        }
        public List<LessonModel> ViewLesson(int afficahage, int page)
        {
            List<LessonModel> lessons = new List<LessonModel>();

            try
            {
                int limit = afficahage, offset = (page - 1) * afficahage;
                var query = dbcontext.Lesson.Where(x => x.Status == 1).OrderByDescending(l => l.MyId).Skip(offset).Take(limit);


                foreach (var lesson in query)
                {
                    var subject = dbcontext.Subject.Where(y => y.Id == lesson.SubjectId).FirstOrDefault();
                    // var nodeLevel = subject != null? context.Node.Where(y => y.Id == subject.LevelNodeId).FirstOrDefault();
                    lessons.Add(new LessonModel()
                    {
                        Id = lesson.Id,
                        Name = lesson.Name,
                        Description = lesson.Description,
                        SubjectId = lesson.SubjectId,
                        SubjectName = subject.Name,
                        LevelNodeId = subject.LevelNodeId,
                        LevelNodeName = dbcontext.Node.Where(y => y.Id == subject.LevelNodeId).FirstOrDefault().Name,
                        MyId = lesson.MyId,
                        Status = lesson.Status
                    });
                }


                return lessons;

            }
            catch (Exception)
            {
                return new List<LessonModel>();
            }
        }

        public int CountLesson()
        {
            try
            {
                return dbcontext.Lesson.Where(x => x.Status == 1).Count();
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public List<LessonModel> GetLessonModels()
        {
            List<LessonModel> models = new List<LessonModel>();


            var query = dbcontext.Lesson.Where(x => x.Status == 1);

            foreach (var lesson in query)
            {
                models.Add(new LessonModel()
                {
                    Id = lesson.Id,
                    Description = lesson.Description,
                    Name = lesson.Name,
                    MyId = lesson.MyId,
                    SubjectId = lesson.SubjectId,
                    SubjectName = dbcontext.Subject.Where(x => x.Id == lesson.SubjectId && x.Status == 1).FirstOrDefault().Name,
                    Status = lesson.Status
                });
            }

            return models;


        }
        public LessonModel GetLessonById(string Id)
        {
            LessonModel model = new LessonModel();

            if (!string.IsNullOrEmpty(Id))
            {

                Lesson lesson = dbcontext.Lesson.SingleOrDefault(p => p.Id == Id);

                var node = (from nl in dbcontext.Node
                            join s in dbcontext.Subject on nl.Id equals s.LevelNodeId
                            join nh in dbcontext.NodeHierarchy on nl.Id equals nh.NodeId
                            where s.Id == lesson.SubjectId && nl.Status == 1 && s.Status == 1 && nh.Status == 1
                            select new { NodeLevelId = nl.Id, NodeDepartmentId = nh.ParentNodeId });

                if (lesson != null)
                {
                    model.Id = lesson.Id;
                    model.Name = lesson.Name;
                    model.Description = lesson.Description;
                    model.SubjectId = lesson.SubjectId;
                    model.MyId = lesson.MyId;
                    model.Status = lesson.Status;
                    model.LevelNodeId = node.FirstOrDefault().NodeLevelId;
                    model.DepartmentNodeId = node.FirstOrDefault().NodeDepartmentId;
                }

            }
            return model;
        }

        public List<LessonModel> GetLessonModelsBySubject(string subjectid)
        {
            List<LessonModel> models = new List<LessonModel>();


            var query = dbcontext.Lesson.Where(x => x.SubjectId == subjectid && x.Status == 1);

            foreach (var lesson in query)
            {
                models.Add(new LessonModel()
                {
                    Id = lesson.Id,
                    Description = lesson.Description,
                    Name = lesson.Name,
                    MyId = lesson.MyId,
                    SubjectId = lesson.SubjectId,
                    SubjectName = dbcontext.Subject.Where(x => x.Id == lesson.SubjectId && x.Status == 1).FirstOrDefault().Name,
                    Status = lesson.Status
                });
            }


            return models;


        }

        public List<LessonModel> GetLessonBySubjectIdAndCurriculumId(string subjectId, string curriculumId)
        {
            List<LessonModel> models = new List<LessonModel>();

            var query = dbcontext.Lesson.Where(x => x.SubjectId == subjectId && x.Status == 1);
            var curriculumDetails = dbcontext.CurriculumDetail.Where(x => x.CurriculumId == curriculumId);

            foreach (var lesson in query)
            {
                models.Add(new LessonModel()
                {
                    Id = lesson.Id,
                    Description = lesson.Description,
                    Name = lesson.Name,
                    MyId = lesson.MyId,
                    SubjectId = lesson.SubjectId,
                    SubjectName = dbcontext.Subject.Where(x => x.Id == lesson.SubjectId && x.Status == 1).FirstOrDefault().Name,
                    Selected = curriculumDetails != null
                                                ? curriculumDetails.Count(x => x.LessonId == lesson.Id) > 0
                                                    ? true : false
                                                : false,
                    Status = lesson.Status
                });
            }

            return models;
        }
        public int DeleteLesson(string Id)
        {
            try
            {
                var lessondata = dbcontext.Lesson.Where(x => x.Id == Id).FirstOrDefault();
                lessondata.Status = 0;
                dbcontext.Lesson.Attach(lessondata);
                dbcontext.Entry(lessondata).State = EntityState.Modified;
                dbcontext.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }

        }

        public int DeleteUser(string id)
        {
            using (MyCoreContext coreContext = new MyCoreContext(CoreConnectionString))
            using (IDbContextTransaction coreTransaction = coreContext.Database.BeginTransaction())
            {
                try
                {
                    Person person = coreContext.Person.Find(id);
                    person.Status = 0;
                    coreContext.SaveChanges();
                    User user = coreContext.User.Where(u => u.PersonId.Equals(id)).First();
                    user.Status = 0;
                    coreContext.SaveChanges();
                    UserRole userRole = coreContext.UserRole.Where(u => u.UserId.Equals(user.Id)).First();
                    userRole.Status = 0;
                    coreContext.SaveChanges();
                    if(!userRole.RoleId.Equals(StaticData.ROLE_ADMINISTRATOR_ID))
                    {
                        using (MySchoolContext schoolContext = new MySchoolContext(ConnectionString))
                        using (IDbContextTransaction schoolTransaction = schoolContext.Database.BeginTransaction())
                        {
                            try
                            {
                                Employee employee = schoolContext.Employee.Where(e => e.Id.Equals(person.EmployeeId)).First();
                                employee.Status = 0;
                                schoolContext.SaveChanges();
                                List<EmployeeSubject> employeeSubjects = schoolContext.EmployeeSubject.Where(s => s.EmployeeId.Equals(employee.Id)).ToList();
                                foreach(EmployeeSubject employeeSubject in employeeSubjects)
                                {
                                    employeeSubject.Status = 0;
                                    schoolContext.SaveChanges();
                                }
                                schoolTransaction.Commit();
                            }
                            catch (Exception)
                            {
                                if (schoolTransaction != null) schoolTransaction.Rollback();
                                throw;
                            }
                        }
                    }
                    coreTransaction.Commit();
                    return 1;
                }
                catch (Exception)
                {
                    if (coreTransaction != null) coreTransaction.Rollback();
                }
            }
            return 0;
        }

        #endregion

        //Delete weekly plan

        public int DeletePlan(string id)
        {
            using (MySchoolContext schoolContext = new MySchoolContext(ConnectionString))
            using (IDbContextTransaction schoolTransaction = schoolContext.Database.BeginTransaction())
            {
                try
                {
                    Plan plan = schoolContext.Plan.Where(e => e.Id.Equals(id)).First();
                    plan.Status = 0;
                    schoolContext.SaveChanges();
                    List<PlanDetail> employeeSubjects = schoolContext.PlanDetail.Where(s => s.PlanId.Equals(id)).ToList();
                    foreach (PlanDetail employeeSubject in employeeSubjects)
                    {
                        employeeSubject.Status = 0;
                        schoolContext.SaveChanges();
                    }
                    schoolTransaction.Commit();
                    return 1;
                }
                catch (Exception ex)
                {
                    if (schoolTransaction != null) schoolTransaction.Rollback();
                }
            }
            return 0;
        }





        #region Employee

        public List<EmployeeModel> GetEmployees(string e)
        {
            List<EmployeeModel> models = new List<EmployeeModel>();

            var employeeData = dbcontext.Set<Employee>().Where(p => p.Status == 1 && p.Id == "40ff5b91-3ce7-4122-a5de-3907f86c6629");

            foreach (var employee in employeeData)
            {
                if (employee != null)
                {
                    models.Add(new EmployeeModel()
                    {
                        Id = employee.Id,
                        MyId = employee.MyId,
                        Address = employee.Address,
                        Age = employee.Age,
                        EmployeeTypeId = employee.EmployeeTypeId,
                        FirstName = employee.Name,
                        Status = employee.Status
                    });
                }
            }


            return models;

        }

        public List<EmployeeModel> GetEmployees()
        {
            List<EmployeeModel> models = new List<EmployeeModel>();


            var employeeData = dbcontext.Set<Employee>().Where(p => p.Status == 1);

            foreach (var employee in employeeData)
            {
                if (employee != null)
                {
                    models.Add(new EmployeeModel()
                    {
                        Id = employee.Id,
                        MyId = employee.MyId,
                        Address = employee.Address,
                        Age = employee.Age,
                        EmployeeTypeId = employee.EmployeeTypeId,
                        FirstName = employee.Name,
                        Status = employee.Status
                    });
                }
            }


            return models;

        }

        public int SaveEmployeeUserRole(EmployeeModel employee)
        {
            if (employee.Id != null) return EditEmplyee(employee);
            Person person = new Person()
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = employee.FirstName,
                MiddleName = employee.MiddleName,
                LastName = employee.LastName,
                Status = 1
            };
            Employee employe = null;
            if (!employee.RoleName.Equals(StaticData.ROLE_ADMINISTRATOR))
            {
                employe = new Employee()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = employee.FirstName + " " + employee.MiddleName + " " + employee.LastName,
                    Address = " ",
                    EmployeeTypeId = "40ff5b91-3ce7-4122-a5de-3907f86c6621",
                    Status = 1
                };
                person.EmployeeId = employe.Id;
            }
            else person.EmployeeId = Guid.NewGuid().ToString();
            User user = new User()
            {
                Id = Guid.NewGuid().ToString(),
                PersonId = person.Id,
                UserName = employee.UserName,
                HashCode = new Fanafenana().Afeno(employee.HashCode),
                CreatedOn = DateTime.Now,
                Status = 1
            };
            UserRole userRole = new UserRole()
            {
                Id = Guid.NewGuid().ToString(),
                UserId = user.Id,
                RoleId = employee.RoleId,
                Status = 1
            };
            using (MyCoreContext myCoreContext = new MyCoreContext(CoreConnectionString))
            using (IDbContextTransaction myCoreTransaction = myCoreContext.Database.BeginTransaction())
            {
                try
                {
                    myCoreContext.Person.Add(person);
                    myCoreContext.SaveChanges();
                    myCoreContext.User.Add(user);
                    myCoreContext.SaveChanges();
                    myCoreContext.UserRole.Add(userRole);
                    myCoreContext.SaveChanges();
                    if(!employee.RoleName.Equals(StaticData.ROLE_ADMINISTRATOR))
                    {
                        using (MySchoolContext schoolContext = new MySchoolContext(ConnectionString))
                        using(IDbContextTransaction mySchoolTransaction = schoolContext.Database.BeginTransaction())
                        {
                            try
                            {
                                if(employee.RoleName.Equals(StaticData.ROLE_PARENTS))
                                {
                                    List<ParentChildrenNode> parentChildrenNodes = new List<ParentChildrenNode>();
                                    string toSplit = employee.Subjects.TrimEnd(',');
                                    string[] subjects = toSplit.Split(',');
                                    foreach (string subject in subjects)
                                    {
                                        parentChildrenNodes.Add(new ParentChildrenNode()
                                        {
                                            Id = Guid.NewGuid().ToString(),
                                            EmployeeId = person.Id,
                                            NodeId = subject
                                        });
                                    }
                                    schoolContext.Add(employe);
                                    schoolContext.SaveChanges();
                                    schoolContext.ParentChildrenNode.AddRange(parentChildrenNodes);
                                    schoolContext.SaveChanges();
                                }
                                else
                                {
                                    List<EmployeeSubject> employeeSubjects = new List<EmployeeSubject>();
                                    string toSplit = employee.Subjects.TrimEnd(',');
                                    string[] subjects = toSplit.Split(',');
                                    foreach (string subject in subjects)
                                    {
                                        employeeSubjects.Add(new EmployeeSubject()
                                        {
                                            Id = Guid.NewGuid().ToString(),
                                            EmployeeId = employe.Id,
                                            SubjectId = subject,
                                            Status = 1
                                        });
                                    }
                                    schoolContext.Add(employe);
                                    schoolContext.SaveChanges();
                                    schoolContext.EmployeeSubject.AddRange(employeeSubjects);
                                    schoolContext.SaveChanges();
                                }
                                mySchoolTransaction.Commit();
                            }
                            catch (Exception)
                            {
                                if (mySchoolTransaction != null) mySchoolTransaction.Rollback();
                                return 0;
                            }
                        }
                    }
                    myCoreTransaction.Commit();
                    return 1;
                }
                catch (Exception)
                {
                    if (myCoreTransaction != null) myCoreTransaction.Rollback();
                    return 0;
                }
            }
        }
         
        public int EditEmplyee(EmployeeModel employee)
        {
            using (
                MyCoreContext myCoreContext = new MyCoreContext(CoreConnectionString))
            using (IDbContextTransaction myCoreTransaction = myCoreContext.Database.BeginTransaction())
            {
                try
                {
                    Person person = myCoreContext.Person.Find(employee.Id);
                    person.FirstName = employee.FirstName;
                    person.MiddleName = employee.MiddleName;
                    person.LastName = employee.LastName;
                    myCoreContext.SaveChanges();
                    User user = myCoreContext.User.Where(u => u.PersonId.Equals(person.Id)).First();
                    user.UserName = employee.UserName;
                    if(!string.IsNullOrEmpty(employee.HashCode)) user.HashCode = new Fanafenana().Afeno(employee.HashCode);
                    myCoreContext.SaveChanges();
                    UserRole userRole = myCoreContext.UserRole.Where(u => u.UserId.Equals(user.Id)).First();
                    string old_user_id = userRole.RoleId;
                    userRole.RoleId = employee.RoleId;
                    myCoreContext.SaveChanges();
                    bool old_role_is_admin = userRole.RoleId.Equals(StaticData.ROLE_ADMINISTRATOR_ID);
                    bool new_role_is_admin = employee.RoleId.Equals(StaticData.ROLE_ADMINISTRATOR_ID);
                    bool old_and_new_role_are_admin = (old_role_is_admin && new_role_is_admin);
                    if (!old_and_new_role_are_admin)
                    {
                        using (MySchoolContext schoolContext = new MySchoolContext(ConnectionString))
                        using (IDbContextTransaction mySchoolTransaction = schoolContext.Database.BeginTransaction())
                        {
                            try
                            {
                                Employee employe = GetEmployeeByPerson(schoolContext, person.EmployeeId);
                                List<EmployeeSubject> employeeSubjects = new List<EmployeeSubject>();
                                if(!string.IsNullOrEmpty(employee.Subjects))
                                {
                                    string toSplit = employee.Subjects.TrimEnd(',');
                                    string[] subjects = toSplit.Split(',');
                                    foreach (string subject in subjects)
                                    {
                                        EmployeeSubject employeeSubject = new EmployeeSubject()
                                        {
                                            Id = Guid.NewGuid().ToString(),
                                            SubjectId = subject,
                                            Status = 1
                                        };
                                        if (employe != null) employeeSubject.EmployeeId = employe.Id;
                                        employeeSubjects.Add(employeeSubject);
                                    }
                                }
                                if (old_user_id.Equals(StaticData.ROLE_ADMINISTRATOR_ID) && !employee.RoleId.Equals(StaticData.ROLE_ADMINISTRATOR_ID))
                                {
                                    Employee newEmplyee = new Employee()
                                    {
                                        Id = Guid.NewGuid().ToString(),
                                        Name = employee.FirstName + " " + employee.MiddleName + " " + employee.LastName,
                                        Address = " ",
                                        EmployeeTypeId = "40ff5b91-3ce7-4122-a5de-3907f86c6621",
                                        Status = 1
                                    };
                                    schoolContext.Add(newEmplyee);
                                    schoolContext.SaveChanges();
                                    foreach (EmployeeSubject empSub in employeeSubjects)
                                    {
                                        empSub.EmployeeId = newEmplyee.Id;
                                        schoolContext.Add(empSub);
                                        schoolContext.SaveChanges();
                                    }
                                }
                                if (employee.RoleName.Equals(StaticData.ROLE_PARENTS))
                                {
                                    List<ParentChildrenNode> old_parentChildrenNodes = GetParentChildrenNodes(schoolContext, person.Id);
                                    DeleteRange2(old_parentChildrenNodes, schoolContext);
                                    List<ParentChildrenNode> parentChildrenNodes = new List<ParentChildrenNode>();
                                    if(!string.IsNullOrEmpty(employee.Subjects))
                                    {
                                        string toSplit2 = employee.Subjects.TrimEnd(',');
                                        string[] subjects2 = toSplit2.Split(',');
                                        foreach (string subject in subjects2)
                                        {
                                            parentChildrenNodes.Add(new ParentChildrenNode()
                                            {
                                                Id = Guid.NewGuid().ToString(),
                                                EmployeeId = person.Id,
                                                NodeId = subject
                                            });
                                        }
                                        schoolContext.ParentChildrenNode.AddRange(parentChildrenNodes);
                                        schoolContext.SaveChanges();
                                    }
                                }
                                else
                                {
                                    List<EmployeeSubject> employeSubjects = GetEmployeeSubjectsByEmplyeeId(schoolContext, employe.Id);
                                    if (!old_user_id.Equals(StaticData.ROLE_ADMINISTRATOR_ID) && employee.RoleId.Equals(StaticData.ROLE_ADMINISTRATOR_ID))
                                    {
                                        Employee emp = schoolContext.Employee.Where(e => e.Id.Equals(person.EmployeeId)).First();
                                        emp.Status = 0;
                                        schoolContext.SaveChanges();
                                        DeleteRange(employeSubjects, schoolContext);
                                    }
                                    if (!old_user_id.Equals(StaticData.ROLE_ADMINISTRATOR_ID) && !employee.RoleId.Equals(StaticData.ROLE_ADMINISTRATOR_ID))
                                    {
                                        DeleteRange(employeSubjects, schoolContext);
                                        schoolContext.EmployeeSubject.AddRange(employeeSubjects);
                                        schoolContext.SaveChanges();
                                    }
                                }
                                mySchoolTransaction.Commit();
                            }
                            catch (Exception ex)
                            {
                                if (mySchoolTransaction != null) mySchoolTransaction.Rollback();
                                throw;
                            }

                        }
                    }
                    myCoreTransaction.Commit();
                    return 1;
                }
                catch (Exception)
                {
                    if (myCoreTransaction != null) myCoreTransaction.Rollback();
                    throw;
                }
            }
            return 0;
        }

        private List<ParentChildrenNode> GetParentChildrenNodes(MySchoolContext schoolContext, string employee_id)
        {
            try
            {
                return schoolContext.ParentChildrenNode.Where(e => e.EmployeeId.Equals(employee_id)).ToList();
            }
            catch (Exception)
            {
                return new List<ParentChildrenNode>();
            }
        }

        private List<EmployeeSubject> GetEmployeeSubjectsByEmplyeeId(MySchoolContext schoolContext, string employee_id)
        {
            try
            {
                return schoolContext.EmployeeSubject.Where(e => e.EmployeeId.Equals(employee_id)).ToList();
            }
            catch (Exception)
            {
                return new List<EmployeeSubject>();
            }
        }

        private Employee GetEmployeeByPerson(MySchoolContext schoolContext, string employeeId)
        {
            try
            {
                Employee employe = schoolContext.Employee.Where(e => e.Id.Equals(employeeId)).First();
                return employe;
            }
            catch (Exception)
            {
                return null;
            }
        }


        private int DeleteRange2(List<ParentChildrenNode> parentChildrenNodes, MySchoolContext schoolContext)
        {
            foreach (ParentChildrenNode p in parentChildrenNodes)
            {
                schoolContext.ParentChildrenNode.Remove(p);
                schoolContext.SaveChanges();
            }
            return 1;
        }

        private int DeleteRange(List<EmployeeSubject> employeSubjects, MySchoolContext schoolContext)
        {
            foreach (EmployeeSubject employeSubject in employeSubjects)
            {
                EmployeeSubject emp = schoolContext.EmployeeSubject.Find(employeSubject.Id);
                emp.Status = 0;
                schoolContext.SaveChanges();
            }
            return 1;
        }

        private int GetUserRoleChange(EmployeeModel employee, UserRole userRole)
        {
            if (userRole.RoleId.Equals(StaticData.ROLE_ADMINISTRATOR_ID) && employee.RoleId.Equals(StaticData.ROLE_ADMINISTRATOR_ID))
                return StaticData.ADMINISTRATOR_TO_ADMINISTRATOR;
            if (userRole.RoleId.Equals(StaticData.ROLE_ADMINISTRATOR_ID) && !employee.RoleId.Equals(StaticData.ROLE_ADMINISTRATOR_ID))
                return StaticData.ADMINISTRATOR_TO_TEACHER;
            if (!userRole.RoleId.Equals(StaticData.ROLE_ADMINISTRATOR_ID) && employee.RoleId.Equals(StaticData.ROLE_ADMINISTRATOR_ID))
                return StaticData.TEACHER_TO_ADMINISTRATOR;
            if (!userRole.RoleId.Equals(StaticData.ROLE_ADMINISTRATOR_ID) && !employee.RoleId.Equals(StaticData.ROLE_ADMINISTRATOR_ID))
                return StaticData.TEACHER_TO_TEACHER;
            return 0;
        }

        public List<EmployeeModel> GetAllEmployees(string name, int affichage, int page)
        {
            int limit = affichage, offset = (page - 1) * affichage;
            List<EmployeeModel> models = new List<EmployeeModel>();
            if (string.IsNullOrEmpty(name)) name = "";
            using (var corecontext = new MyCoreContext(CoreConnectionString))
            using (var command = corecontext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "select `p`.`Id` AS `Id`,COALESCE(`p`.`FirstName`, ' ') AS `FirstName`,COALESCE(`p`.`MiddleName`, ' ') AS `MiddleName`,COALESCE(`p`.`LastName`, ' ') AS `LastName`,`u`.`UserName` AS `UserName`,`r`.`Name` AS `Name` from (((`person` `p` join `user` `u` on(`p`.`Id` = `u`.`PersonId`)) join `userrole` `ur` on(`ur`.`UserId` = `u`.`Id`)) join `role` `r` on(`r`.`Id` = `ur`.`RoleId`)) where (p.FirstName like '%" + name + "%' OR p.LastName like '%" + name + "%' OR p.MiddleName like '%" + name + "%') AND `p`.`Status` = 1 and `u`.`Status` = 1 and `ur`.`Status` = 1 and `r`.`Status` = 1 ORDER BY p.MyId DESC LIMIT " + limit + " OFFSET " + offset;
                corecontext.Database.OpenConnection();
                using (var result = command.ExecuteReader())
                {
                    while (result.Read())
                    {
                        models.Add(new EmployeeModel()
                        {
                            Id = result.GetString(0),
                            FirstName = result.GetString(1),
                            MiddleName = result.GetString(2),
                            LastName = result.GetString(3),
                            UserName = result.GetString(4),
                            RoleName = result.GetString(5)
                        });
                    }
                }

            }
            return models;
        }

        public int CountAllEmployees(string name)
        {
            int nombre = 0;
            using (var corecontext = new MyCoreContext(CoreConnectionString))
            using (var command = corecontext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "select count(*) from (((`person` `p` join `user` `u` on(`p`.`Id` = `u`.`PersonId`)) join `userrole` `ur` on(`ur`.`UserId` = `u`.`Id`)) join `role` `r` on(`r`.`Id` = `ur`.`RoleId`)) where (p.FirstName like '%" + name + "%' OR p.LastName like '%" + name + "%' OR p.MiddleName like '%" + name + "%') AND  `p`.`Status` = 1 and `u`.`Status` = 1 and `ur`.`Status` = 1 and `r`.`Status` = 1";
                corecontext.Database.OpenConnection();
                using (var result = command.ExecuteReader())
                {
                    while (result.Read())
                    {
                        nombre = result.GetInt32(0);
                    }
                }

            }
            return nombre;
        }
        public List<EmployeeModel> GetEmployeeUserRole(string id)
        {
            List<EmployeeModel> models = new List<EmployeeModel>();

            using (var corecontext = new MyCoreContext(CoreConnectionString))
            {
                var employee = string.IsNullOrEmpty(id)
                                ? (from u in corecontext.User
                                   join p in corecontext.Person on u.PersonId equals p.Id
                                   join ur in corecontext.UserRole on u.Id equals ur.UserId
                                   join r in corecontext.Role on ur.RoleId equals r.Id
                                   where u.Status == 1 && p.Status == 1 && ur.Status == 1 && r.Status == 1
                                   select new { Id = p.EmployeeId, PersonId = p.Id, p.FirstName, p.MiddleName, p.LastName, UserId = u.Id, u.UserName, u.HashCode, UserRoleId = ur.Id, RoleId = r.Id, RoleName = r.Name })

                               : (from u in corecontext.User
                                  join p in corecontext.Person on u.PersonId equals p.Id
                                  join ur in corecontext.UserRole on u.Id equals ur.UserId
                                  join r in corecontext.Role on ur.RoleId equals r.Id
                                  where p.Id == id && u.Status == 1 && p.Status == 1 && ur.Status == 1 && r.Status == 1
                                  select new { Id = p.EmployeeId, PersonId = p.Id, p.FirstName, p.MiddleName, p.LastName, UserId = u.Id, u.UserName, u.HashCode, UserRoleId = ur.Id, RoleId = r.Id, RoleName = r.Name });

                foreach (var item in employee)
                {
                    models.Add(new EmployeeModel
                    {
                        Id = item.Id,
                        PersonId = item.PersonId,
                        FirstName = item.FirstName,
                        MiddleName = item.MiddleName,
                        LastName = item.LastName,
                        UserId = item.UserId,
                        UserName = item.UserName,
                        HashCode = item.HashCode,
                        UserRoleId = item.UserRoleId,
                        RoleId = item.RoleId,
                        RoleName = item.RoleName,
                        EmployeeSubjects = string.IsNullOrEmpty(id) ? new List<EmployeeSubjectModel>() : GetEmployeeSubjects(id)
                    });
                }

            }

            return models;

        }

        public List<Role> GetRoles()
        {
            List<Role> roles = new List<Role>();
            using (var corecontext = new MyCoreContext(CoreConnectionString))
            {
                 roles = corecontext.Role.Where(x => x.Status == 1).ToList();
            }


            return roles;

        }

        public List<EmployeeSubjectModel> GetEmployeeSubjects(string employeeId)
        {
            List<EmployeeSubjectModel> models = new List<EmployeeSubjectModel>();

            try
            {
                bool isEmployeeAdmin = IsEmployeeAdmin(employeeId);
                List<EmployeeSubject> employeeSubjectsData = new List<EmployeeSubject>();
                if (!string.IsNullOrEmpty(employeeId)) employeeSubjectsData = dbcontext.EmployeeSubject.Where(x => x.EmployeeId == employeeId && x.Status == 1).ToList();
                var subjectsData = dbcontext.Subject.Where(x => x.Status == 1);

                foreach (var subject in subjectsData)
                {
                    if (subject != null)
                    {
                        EmployeeSubjectModel model = new EmployeeSubjectModel();
                        var employeeSubjectData = employeeSubjectsData.Where(x => x.SubjectId == subject.Id);

                        if (employeeSubjectData != null && employeeSubjectData.Count() > 0)
                        {
                            model.Id = employeeSubjectData.FirstOrDefault().Id;
                            model.Selected = true;
                        }

                        if (isEmployeeAdmin) model.Selected = true;


                        model.LevelNodeId = subject.LevelNodeId;
                        model.LevelNodeName = dbcontext.Node.Where(x => x.Id == subject.LevelNodeId && x.Status == 1).FirstOrDefault().Name;
                        model.SubjectId = subject.Id;
                        model.SubjectName = subject.Name;
                        model.EmployeeId = employeeId;

                        models.Add(model);

                    }
                }
            }
            catch (Exception)
            {
                return new List<EmployeeSubjectModel>();
            }
            return models;

        }

        public List<ParentChildrenNodeModel> GetParentChildrenNodeModelByEmplyeeId(string employeeId)
        {
            List<ParentChildrenNodeModel> models = new List<ParentChildrenNodeModel>();

            try
            {
                bool isEmployeeAdmin = IsEmployeeAdmin(employeeId);
                List<ParentChildrenNode> parentChildNodeDatas = new List<ParentChildrenNode>();
                if (!string.IsNullOrEmpty(employeeId)) parentChildNodeDatas = dbcontext.ParentChildrenNode.Where(x => x.EmployeeId == employeeId).ToList();
                foreach (var node in parentChildNodeDatas)
                {
                    if (node != null)
                    {
                        var grade = dbcontext.Node.Where(x => x.Id.Equals(node.NodeId)).First();
                        models.Add(new ParentChildrenNodeModel()
                        {
                            Id = node.Id,
                            NodeId = node.NodeId,
                            EmployeeId = node.EmployeeId,
                            NodeName = grade.Name,
                            Selected = true
                        });

                    }
                }
            }
            catch (Exception)
            {
                return new List<ParentChildrenNodeModel>();
            }
            return models;

        }

        public List<ParentChildrenNodeModel> GetParentChildrenNodeModels(string employeeId)
        {
            List<ParentChildrenNodeModel> models = new List<ParentChildrenNodeModel>();

            try
            {
                bool isEmployeeAdmin = IsEmployeeAdmin(employeeId);
                List<ParentChildrenNode> parentChildNodeDatas = new List<ParentChildrenNode>();
                if (!string.IsNullOrEmpty(employeeId)) parentChildNodeDatas = dbcontext.ParentChildrenNode.Where(x => x.EmployeeId == employeeId).ToList();
                var nodeDatas = ViewNodeByNodeType(StaticData.NODE_GRADE, int.MaxValue, 1);

                foreach (var node in nodeDatas)
                {
                    if (node != null)
                    {
                        ParentChildrenNodeModel model = new ParentChildrenNodeModel();
                        var parentChildNodeData = parentChildNodeDatas.Where(x => x.NodeId == node.Id);

                        if (parentChildNodeData != null && parentChildNodeData.Count() > 0)
                        {
                            model.Id = parentChildNodeData.FirstOrDefault().Id;
                            model.Selected = true;
                        }
                        model.NodeName = node.Name;
                        model.NodeId = node.Id;
                        model.EmployeeId = employeeId;
                        models.Add(model);
                    }
                }
            }
            catch (Exception)
            {
                return new List<ParentChildrenNodeModel>();
            }
            return models;

        }

        public List<EmployeeModel> GetEmployeesBySubject(string subjectId)
        {
            List<EmployeeModel> models = new List<EmployeeModel>();


            var employees = from es in dbcontext.EmployeeSubject
                            join e in dbcontext.Employee
                            on es.EmployeeId equals e.Id
                            where es.SubjectId == subjectId && es.Status == 1 && e.Status == 1
                            select new { Id = e.Id };

            using (var corecontext = new MyCoreContext(CoreConnectionString))
            {
                


                foreach (var data in employees)
                {
                    var person = corecontext.Person.Where(x => x.EmployeeId == data.Id && x.Status ==1);
                    if (person != null)
                    {
                        models.Add(new EmployeeModel()
                        {
                            Id = data.Id,
                            FirstName = person.FirstOrDefault().FirstName,
                            LastName = person.FirstOrDefault().LastName
                        });
                    }
                }
            }

            return models;
        }

        public bool IsEmployeeAdmin(string employeeId)
        {
            using (var corecontext = new MyCoreContext(CoreConnectionString))
            {
                var employee = from u in corecontext.User
                               join p in corecontext.Person on u.PersonId equals p.Id
                               join ur in corecontext.UserRole on u.Id equals ur.UserId
                               join r in corecontext.Role on ur.RoleId equals r.Id
                               where r.Name == "Administrator" && p.EmployeeId == employeeId
                               select u.Id;

                if (employee != null && employee.Count() > 0)
                    return true;
                else
                    return false;

            }
        }

        #endregion

        #region Login
        public UserModel GetUser(string username, string password)
        {
            var request = new UserRequest() { userName = username, password = new Fanafenana().Afeno(password) };
            var logic = new UserBusinessLogic(CoreConnectionString);
            var model = logic.GetUserMySchool(request);
            return model;
        }

        public List<ElementModel> GetElements(string roleId)
        {
            var logic = new UserBusinessLogic(CoreConnectionString);
            return logic.GetElements(roleId);
        }

        public List<string> GetElementList(string roleId)
        {
            var logic = new UserBusinessLogic(CoreConnectionString);
            return logic.GetElementList(roleId);
        }
        #endregion

        #region Blog
        public int SaveBlog(BlogModel blog)
        {
            try
            {
                // MySchoolContext context = new MySchoolContext();

                Blog blogData= new Blog()
                {
                    Id = string.IsNullOrEmpty(blog.Id) ? Guid.NewGuid().ToString() : blog.Id,
                    Description = blog.Description,
                    Name = blog.Name,
                    DateOfIssue  = DateTime.Now,
                    ModifiedBy = blog.ModifiedBy,
                    ModifiedOn = DateTime.Now,
                    ExpiryDate = blog.ExpiryDate,
                    MyId = blog.MyId > 0 ? blog.MyId:0,
                    Status = 1
                };

                if (!string.IsNullOrEmpty(blog.Id))
                {
                    dbcontext.Blog.Attach(blogData);
                    dbcontext.Entry(blogData).State = EntityState.Modified;
                }
                else
                {
                    dbcontext.Blog.Add(blogData);
                }
                dbcontext.SaveChanges();
                return 1;

            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int DeleteBlog(string Id)
        {
            try
            {
                var blogdata = dbcontext.Blog.Where(x => x.Id == Id).FirstOrDefault();
                blogdata.Status = 0;
                dbcontext.Blog.Attach(blogdata);
                dbcontext.Entry(blogdata).State = EntityState.Modified;
                dbcontext.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public List<BlogModel> ViewBlog(int affichage, int page)
        {
            List<BlogModel> blogs = new List<BlogModel>();

            try
            {
                int limit = affichage, offset = (page - 1) * affichage;
                var query = dbcontext.Blog.Where(x => x.Status == 1 && x.ExpiryDate.CompareTo(DateTime.Now) >= 0).OrderByDescending(b => b.MyId).Skip(offset).Take(limit);


                foreach (var blog in query)
                {
                    blogs.Add(new BlogModel()
                    {
                        Id = blog.Id,
                        Name = blog.Name,
                        Description = blog.Description,                    
                        MyId = blog.MyId,
                        DateOfIssue = blog.DateOfIssue,
                        ModifiedBy = blog.ModifiedBy,
                        ModifiedOn = blog.ModifiedOn,
                        ExpiryDate = blog.ExpiryDate,
                        Status = blog.Status
                    });
                }

                return blogs;

            }
            catch (Exception ex)
            {
                return new List<BlogModel>();
            }
        }

        public int CountBlog()
        {
            try
            {
                return dbcontext.Blog.Where(x => x.Status == 1 && x.ExpiryDate.CompareTo(DateTime.Now) >= 0).Count();
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public BlogModel ViewBlogById(string id)
        {
            BlogModel blog = new BlogModel();

            try
            {

                var query = dbcontext.Blog.Where(x => x.Status == 1 && x.Id == id).FirstOrDefault();


                if(query != null)
                {

                    blog.Id = query.Id;
                    blog.Name = query.Name;
                    blog.Description = query.Description;
                    blog.MyId = query.MyId;
                    blog.DateOfIssue = query.DateOfIssue;
                    blog.ModifiedBy = query.ModifiedBy;
                    blog.ModifiedOn = query.ModifiedOn;
                    blog.Status = query.Status;
                }

                return blog;

            }
            catch (Exception ex)
            {
                return new BlogModel();
            }
        }
        #endregion

        #region HomeWork

        public int SaveHomeWork(HomeWorkModel homeWorkModel)
        {
            try
            {
                HomeWork homeWork = new HomeWork()
                {
                    Title = homeWorkModel.Title,
                    Id = Guid.NewGuid().ToString(),
                    DateCreate = DateTime.Now,
                    DateLimit = homeWorkModel.DateLimit,
                    Description = homeWorkModel.Description,
                    SubjectId = homeWorkModel.SubjectId,
                    ActionId = homeWorkModel.ActionId,
                    Status = 1
                };
                dbcontext.HomeWork.Add(homeWork);
                dbcontext.SaveChanges();
                foreach(Attachments attachment in homeWorkModel.Attachments)
                {
                    attachment.IdHomework = homeWork.Id;
                    dbcontext.Attachments.Add(attachment);
                    dbcontext.SaveChanges();
                }
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
            
        }

        public List<HomeWorkModel> GetAllHomeWork(int affichage, int page)
        {
            try
            {
                int offset = (page - 1) * affichage, limit = affichage;
                List<HomeWorkModel> result = new List<HomeWorkModel>();
                using (var command = dbcontext.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "SELECT h.Title,h.Id, h.DateCreate, h.DateLimit, n.`Name`, s.`Name`, h.Description, a.Name FROM homework h JOIN subject s ON s.Id = h.SubjectId JOIN node n ON n.Id = s.LevelNodeId JOIN HomeWork_Action a ON a.Id = h.ActionId WHERE h.`Status` = 1 AND s.`Status` = 1 AND n.`Status` = 1 ORDER BY h.DateCreate DESC LIMIT " + limit + " OFFSET " + offset;
                    dbcontext.Database.OpenConnection();
                    using (var results = command.ExecuteReader())
                    {
                        while (results.Read())
                        {
                            result.Add(new HomeWorkModel
                            {
                                Title = results.GetString(0),
                                Id = results.GetString(1),
                                DateCreate = results.GetDateTime(2),
                                DateLimit = results.GetDateTime(3),
                                LevelNodeId = results.GetString(4),
                                SubjectId = results.GetString(5),
                                Description = results.GetString(6),
                                ActionId = results.GetString(7)
                            });
                        }
                    }

                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int CountAllHomeWork()
        {
            try
            {
                using (var command = dbcontext.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "SELECT count(*) FROM homework h JOIN subject s ON s.Id = h.SubjectId JOIN node n ON n.Id = s.LevelNodeId WHERE h.`Status` = 1 AND s.`Status` = 1 AND n.`Status` = 1";
                    dbcontext.Database.OpenConnection();
                    using (var results = command.ExecuteReader())
                    {
                        while (results.Read())
                        {
                            return results.GetInt32(0);
                        }
                    }
                    return 0;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public Attachments GetAttachmentById(string id)
        {
            try
            {
                return dbcontext.Attachments.Find(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Attachments> GetRelatedFiles(string fileId, string homeWorkId)
        {
            try
            {
                return dbcontext.Attachments.Where(a => a.IdHomework.Equals(homeWorkId) && a.Status == 1 && !a.Id.Equals(fileId)).ToList();
            }
            catch (Exception)
            {
                return new List<Attachments>();
            }
        }

        public Attachments DeleteFile(string id)
        {
            try
            {
                Attachments attachment = dbcontext.Attachments.Find(id);
                attachment.Status = 0;
                dbcontext.SaveChanges();
                return attachment;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<HomeWorkModel> CompleteFiles(List<HomeWorkModel> homeWorkModels)
        {
            List<HomeWorkModel> result = new List<HomeWorkModel>();
            try
            {
                foreach(HomeWorkModel newModel in homeWorkModels)
                {
                    newModel.Attachments = GetAttachmentsByHomeWorkId(newModel.Id);
                    result.Add(newModel);
                }
            }
            catch (Exception)
            {
                result = new List<HomeWorkModel>();
            }
            return result;
        }

        public List<HomeWorkModel> SearchHomeWork(string LevelId, int affichage, int page)
        {
            try
            {
                int offset = (page - 1) * affichage, limit = affichage;
                List<HomeWorkModel> result = new List<HomeWorkModel>();
                using (var command = dbcontext.Database.GetDbConnection().CreateCommand())
                {
                    string addWhere = "";
                    if (!string.IsNullOrEmpty(LevelId)) addWhere += " AND n.Id = '" + LevelId + "' ";
                    command.CommandText = "SELECT h.Title,h.Id, h.DateCreate, h.DateLimit, n.`Name`, s.`Name`, h.Description, a.Name FROM homework h JOIN homeWork_action a ON a.Id = h.ActionId JOIN subject s ON s.Id = h.SubjectId JOIN node n ON n.Id = s.LevelNodeId WHERE h.`Status` = 1 AND s.`Status` = 1 AND n.`Status` = 1 " + addWhere + " ORDER BY h.DateCreate DESC LIMIT " + limit + " OFFSET " + offset;
                    dbcontext.Database.OpenConnection();
                    using (var results = command.ExecuteReader())
                    {
                        while (results.Read())
                        {
                            result.Add(new HomeWorkModel
                            {
                                Title = results.GetString(0),
                                Id = results.GetString(1),
                                DateCreate = results.GetDateTime(2),
                                DateLimit = results.GetDateTime(3),
                                LevelNodeId = results.GetString(4),
                                SubjectId = results.GetString(5),
                                Description = results.GetString(6),
                                ActionId = results.GetString(7)
                            });
                        }
                    }

                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int CountSearchHomeWork(string LevelId)
        {
            try
            {
                using (var command = dbcontext.Database.GetDbConnection().CreateCommand())
                {
                    string addWhere = "";
                    if (!string.IsNullOrEmpty(LevelId)) addWhere += " AND n.Id = '" + LevelId + "' ";
                    command.CommandText = "SELECT count(*) FROM homework h JOIN subject s ON s.Id = h.SubjectId JOIN node n ON n.Id = s.LevelNodeId WHERE h.`Status` = 1 AND s.`Status` = 1 AND n.`Status` = 1 " + addWhere + "";
                    dbcontext.Database.OpenConnection();
                    using (var results = command.ExecuteReader())
                    {
                        while (results.Read())
                        {
                            return results.GetInt32(0);
                        }
                    }
                    return 0;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public List<Node> GetAllLevel()
        {
            try
            {
                return dbcontext.Node.Where(n => n.Status.Equals(1)).ToList();
            }
            catch (Exception)
            {
                return new List<Node>();
            }
        }

        public int EditHomeWork(HomeWorkModel homeWorkModel)
        {
            try
            {
                HomeWork homeWork = new HomeWork()
                {
                    Title = homeWorkModel.Title,
                    Id = Guid.NewGuid().ToString(),
                    DateCreate = DateTime.Now,
                    DateLimit = homeWorkModel.DateLimit,
                    Description = homeWorkModel.Description,
                    SubjectId = homeWorkModel.SubjectId,
                    Status = 1
                };
                dbcontext.HomeWork.Add(homeWork);
                dbcontext.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public HomeWorkModel GetHomeWorkById(string id)
        {
            try
            {
                HomeWorkModel result = new HomeWorkModel();
                using (var command = dbcontext.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "SELECT h.Title,h.Id, h.DateCreate, h.DateLimit, n.`NodeId` as grade, s.`Id` subjectId, h.Description, n.ParentNodeId, h.ActionId as department FROM homework h JOIN subject s ON s.Id = h.SubjectId JOIN nodeHierarchy n ON n.NodeId = s.LevelNodeId WHERE h.`Status` = 1 AND s.`Status` = 1 AND n.`Status` = 1 AND h.Id = '" + id + "' LIMIT 1";
                    dbcontext.Database.OpenConnection();
                    //h is for homework
                    using (var results = command.ExecuteReader())
                    {
                        while (results.Read())
                        {
                            result = new HomeWorkModel()
                            {
                                Title = results.GetString(0),
                                Id = results.GetString(1),
                                DateCreate = results.GetDateTime(2),
                                DateLimit = results.GetDateTime(3),
                                LevelNodeId = results.GetString(4),
                                SubjectId = results.GetString(5),
                                Description = results.GetString(6),
                                DepartmentNodeId = results.GetString(7),
                                ActionId = results.GetString(8)
                            };
                            break;
                        }
                    }

                }
                result.Attachments = GetAttachmentsByHomeWorkId(result.Id);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Attachments> GetAttachmentsByHomeWorkId(string HomeWorkId)
        {
            try
            {
                return dbcontext.Attachments.Where(a => a.IdHomework.Equals(HomeWorkId) && a.Status.Equals(1)).ToList();
            }
            catch (Exception ex)
            {
                return new List<Attachments>();
            }
        }

        public int UpdateHomeWork(HomeWorkModel model)
        {
            try
            {
                HomeWork homeWork = dbcontext.HomeWork.Find(model.Id);
                homeWork.DateLimit = model.DateLimit;
                homeWork.Description = model.Description;
                homeWork.Title = model.Title;
                homeWork.SubjectId = model.SubjectId;
                homeWork.ActionId = model.ActionId;
                dbcontext.SaveChanges();
                foreach (Attachments attachment in model.Attachments)
                {
                    attachment.IdHomework = homeWork.Id;
                    dbcontext.Attachments.Add(attachment);
                    dbcontext.SaveChanges();
                }
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        #endregion 
    }
}
