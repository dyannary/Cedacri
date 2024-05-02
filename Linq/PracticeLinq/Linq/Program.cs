using Linq;

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

//group, order by, aggregation

foreach (var q in queryMethod)
{
    Console.WriteLine($"{q.Name} - {q.DepartmentName}");
}
