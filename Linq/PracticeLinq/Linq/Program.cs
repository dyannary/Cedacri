using Linq;
using PracticeLinq;

Color color = new Color();

List<Teacher> teachers = new List<Teacher>
{
    new Teacher { Id = 1, FirstName = "Lily", LastName = "Duncan" },
    new Teacher { Id = 2, FirstName = "John", LastName = "Doe" },
    new Teacher { Id = 3, FirstName = "Jane", LastName = "Smith" }
};

var students = new List<Student>
{
    new Student { Id = 1, FirstName = "John", LastName = "Doe", DepartmentId = 1 },
    new Student { Id = 2, FirstName = "Alice", LastName = "Smith", DepartmentId = 2 },
    new Student { Id = 3, FirstName = "Michael", LastName = "Johnson", DepartmentId = 2 }
};

var departments = new List<Department>
{
    new Department { Id = 1, Name = "Art", TeacherId = 1 },
    new Department { Id = 2, Name = "Literature", TeacherId = 1 },
    new Department { Id = 3, Name = "Science", TeacherId = 1 }
};

var query = from student in students
            join department in departments on student.DepartmentId equals department.Id
            select new { Name = $"{student.FirstName} {student.LastName}", DepartmentName = department.Name };

var queryMethod = students.Join(departments,
    student => student.DepartmentId, department => department.Id,
    (student, department) => new { Name = $"{student.FirstName} {student.LastName}", DepartmentName = department.Name });


//group by and order by
Console.WriteLine("Group by department\n");
var departmentsQuery = (from student in students
                        join department in departments on student.DepartmentId equals department.Id
                        group student by department.Name into departmentGroup
                        select new
                        {
                            Department = departmentGroup.Key,
                            //order by
                            Students = departmentGroup.OrderByDescending(s=>s.FirstName).ThenBy(s=>s.LastName),
                        }
                        ).Distinct();

foreach(var department in departmentsQuery)
{
    color.WriteRed(department.Department);

    foreach (var p in department.Students)
    {
        Console.WriteLine(p.FirstName + " " + p.LastName);
    }
}

//Aggregation /Aggregate

var aggregateQuery = students.Aggregate("", (current, next) => current + " \n" + next.FirstName + " " + next.LastName);

Console.WriteLine("\nAggregation query: ");
Console.WriteLine(aggregateQuery);

//foreach (var q in queryMethod)
//{
//    Console.WriteLine($"{q.Name} - {q.DepartmentName}");
//}
