namespace SampleProject.Models
{
    public class EmployeeRepository 
    {
        public bool SaveEmployee( Employee emp)
        {
            return true;
        }
        public List<Employee> Employees()
        {
            return new List<Employee>()
            {
                new Employee() { Id = 1, FirstName= "Fine", LastName= "Guy", department="CS"},
                new Employee() { Id = 2, FirstName = "Alex", LastName = "Saltz", department = "CS" },
                new Employee() { Id = 3, FirstName = "Damon", LastName = "Mark", department = "CS" }
            };
        }
        public List<Employee> GetAllEmployees()
        {
            
            return Employees();
        }
        public Employee GetEmployeeByID(int id)
        {
            List<Employee> emps = Employees();
            Employee emp= emps.Find(x=>x.Id == id);
            return emp;
        }

        /*public void DeleteEmployee() 
        {
            
        }
        public void CreateEmployee() 
        {
        
        }
        public void UpdateEmployee() 
        {
        
        }*/

    }
}
